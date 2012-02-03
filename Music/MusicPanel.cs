using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Threading;
using NAudio.Wave;
using System.Windows.Forms;
using NAudioDemo;

namespace Kontalka.Music
{
    public partial class MusicPanel : UserControl
    {
        enum StreamingPlaybackState
        {
            Stopped,
            Playing,
            Buffering,
            Paused
        }

        public MusicPanel()
        {
            InitializeComponent();
        }


        private BufferedWaveProvider _bufferedWaveProvider;
        private IWavePlayer _waveOut;
        private volatile StreamingPlaybackState _playbackState;
        private volatile bool _fullyDownloaded;
        private HttpWebRequest _webRequest;
        private VolumeWaveProvider16 _volumeProvider;
        private string _songName;
        private string _urlToSong;

        public String SongName
        {
            get
            {
                return _songName;
            }

            set
            {
                _songName = value;
                groupControl1.Text = _songName;
            }
        }

        public String UrlToSong
        {
            get
            {
                return _urlToSong;
            }

            set { _urlToSong = value;
                playButton.Enabled = true;
                Console.WriteLine(_urlToSong);
            }
        }

        private void StreamMP3(object state)
        {
           _fullyDownloaded = false;
            string url = (string)state;
            try
            {
                _webRequest = (HttpWebRequest)WebRequest.Create(url);
            }
            catch (UriFormatException e)
            {
                Console.WriteLine(e);
                return;
            }
            HttpWebResponse resp;
            try
            {
                resp = (HttpWebResponse)_webRequest.GetResponse();
            }
            catch (WebException e)
            {
                if (e.Status != WebExceptionStatus.RequestCanceled)
                {
                    Console.WriteLine(e.Message);
                }
                return;
            }
            byte[] buffer = new byte[16384 * 4]; // needs to be big enough to hold a decompressed frame

            IMp3FrameDecompressor decompressor = null;
            try
            {
                using (var responseStream = resp.GetResponseStream())
                {
                    var readFullyStream = new ReadFullyStream(responseStream);
                    do
                    {
                        if (_bufferedWaveProvider != null && _bufferedWaveProvider.BufferLength - _bufferedWaveProvider.BufferedBytes < _bufferedWaveProvider.WaveFormat.AverageBytesPerSecond / 4)
                        {
                            Debug.WriteLine("Buffer getting full, taking a break");
                            Thread.Sleep(500);
                        }
                        else
                        {
                            Mp3Frame frame;
                            try
                            {
                                frame = Mp3Frame.LoadFromStream(readFullyStream);
                            }
                            catch (EndOfStreamException)
                            {
                                _fullyDownloaded = true;
                                // reached the end of the MP3 file / stream
                                break;
                            }
                            catch (WebException)
                            {
                                // probably we have aborted download from the GUI thread
                                break;
                            }
                            if (decompressor == null)
                            {
                                // don't think these details matter too much - just help ACM select the right codec
                                // however, the buffered provider doesn't know what sample rate it is working at
                                // until we have a frame
                                WaveFormat waveFormat = new Mp3WaveFormat(frame.SampleRate, frame.ChannelMode == ChannelMode.Mono ? 1 : 2, frame.FrameLength, frame.BitRate);
                                decompressor = new AcmMp3FrameDecompressor(waveFormat);
                                _bufferedWaveProvider = new BufferedWaveProvider(decompressor.OutputFormat);
                                _bufferedWaveProvider.BufferDuration = TimeSpan.FromSeconds(20); // allow us to get well ahead of ourselves
                                //this.bufferedWaveProvider.BufferedDuration = 250;
                            }
                            int decompressed = decompressor.DecompressFrame(frame, buffer, 0);
                            //Debug.WriteLine(String.Format("Decompressed a frame {0}", decompressed));
                            _bufferedWaveProvider.AddSamples(buffer, 0, decompressed);
                        }

                    } while (_playbackState != StreamingPlaybackState.Stopped);
                    Debug.WriteLine("Exiting");
                    // was doing this in a finally block, but for some reason
                    // we are hanging on response stream .Dispose so never get there
                    decompressor.Dispose();
                }
            }
            finally
            {
                if (decompressor != null)
                {
                    decompressor.Dispose();
                }
            }
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            
            if (_playbackState == StreamingPlaybackState.Stopped)
            {
                _playbackState = StreamingPlaybackState.Buffering;
                _bufferedWaveProvider = null;
                ThreadPool.QueueUserWorkItem(StreamMP3, _urlToSong);
                timer1.Enabled = true;
            }
            else if (_playbackState == StreamingPlaybackState.Paused)
            {
                _playbackState = StreamingPlaybackState.Buffering;
            }

            playButton.Visible = false;
            pauseButton.Visible = true;
            stopButton.Enabled = true;
        }

        private void StopPlayback()
        {
            if (_playbackState != StreamingPlaybackState.Stopped)
            {
                if (!_fullyDownloaded)
                {
                    _webRequest.Abort();
                }
                _playbackState = StreamingPlaybackState.Stopped;
                if (_waveOut != null)
                {
                    _waveOut.Stop();
                    _waveOut.Dispose();
                    _waveOut = null;
                }
                timer1.Enabled = false;

                Thread.Sleep(500);
                ShowBufferState(0);
            }

            playButton.Visible = true;
            pauseButton.Visible = false;
            stopButton.Enabled = false;
        }

        private void ShowBufferState(double totalSeconds)
        {
            progressBarBuffer.Text = (totalSeconds * 1000).ToString(CultureInfo.InvariantCulture);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_playbackState != StreamingPlaybackState.Stopped)
            {
                if (_waveOut == null && _bufferedWaveProvider != null)
                {
                    Debug.WriteLine("Creating WaveOut Device");
                    _waveOut = CreateWaveOut();
                    _waveOut.PlaybackStopped += waveOut_PlaybackStopped;
                    _volumeProvider = new VolumeWaveProvider16(_bufferedWaveProvider);
                    _volumeProvider.Volume = 1;
                    _waveOut.Init(_volumeProvider);
                    progressBarBuffer.Properties.Maximum = (int)_bufferedWaveProvider.BufferDuration.TotalMilliseconds;
                }
                else if (_bufferedWaveProvider != null)
                {
                    var bufferedSeconds = _bufferedWaveProvider.BufferedDuration.TotalSeconds;
                    ShowBufferState(bufferedSeconds);
                    // make it stutter less if we buffer up a decent amount before playing
                    if (bufferedSeconds < 0.5 && _playbackState == StreamingPlaybackState.Playing && !_fullyDownloaded)
                    {
                        _playbackState = StreamingPlaybackState.Buffering;
                        _waveOut.Pause();
                        Debug.WriteLine(String.Format("Paused buffer, waveOut.PlaybackState={0}", _waveOut.PlaybackState));
                    }
                    else if (bufferedSeconds > 4 && _playbackState == StreamingPlaybackState.Buffering)
                    {
                        _waveOut.Play();
                        Debug.WriteLine(String.Format("Started playing, waveOut.PlaybackState={0}", _waveOut.PlaybackState));
                        _playbackState = StreamingPlaybackState.Playing;
                    }
                    else if (_fullyDownloaded && bufferedSeconds == 0)
                    {
                        Debug.WriteLine("End of stream");
                        StopPlayback();
                    }
                }

            }
        }

        private IWavePlayer CreateWaveOut()
        {
            return new WaveOut();
            //return new DirectSoundOut();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            StopPlayback();
        }

        private void waveOut_PlaybackStopped(object sender, EventArgs e)
        {
            Debug.WriteLine("Playback Stopped");
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            if (_playbackState == StreamingPlaybackState.Playing || _playbackState == StreamingPlaybackState.Buffering)
            {
                _waveOut.Pause();
                Debug.WriteLine(String.Format("User requested Pause, waveOut.PlaybackState={0}", _waveOut.PlaybackState));
                _playbackState = StreamingPlaybackState.Paused;
            }

            playButton.Visible = true;
            pauseButton.Visible = false;
            stopButton.Enabled = false;
        }
    }
}
