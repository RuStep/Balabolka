using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using ApiCore;
using ApiCore.Friends;
using ApiCore.Messages;
using ApiCore.Status;
using ApiCore.Audio;
using Kontalka.Helpers;


namespace Kontalka
{
    public partial class Main : Form
    {
        private bool _isLoggedIn;
        private bool _online;

        private SessionInfo _sessionInfo;
        private ApiManager _manager;
        private MessagesFactory _messagesFactory;
        private FriendsFactory _friendsFactory;
        private StatusFactory _statusFactory;
        private AudioFactory _audioFactory;
        private List<Friend> _friendsList;
        private List<Friend> _onlineFriendsList;
        private List<ApiCore.Messages.Message> _messagesList;
        private List<AudioEntry> _audioList; 

        private string _fname;
        private string _lname;
        private string _nname;
        private string _avaurl;
        private string _facultyName;
        private string _universityName;
        private string _bdate;
        private string _myFirstName;
        private string _myLastName;
        private string _myName;
        private string _myAvatarUrl;
        private string _mystatus;
        private string _newstatus;
        private string _audioUrl;
        private string _audioName;


        private int _myId;

        public string Mid;
        public string MName;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            tStrip1.Text = "Оффлайн";
            Reauth();
            status_send.Visible = false; // Пашет через раз или не пашет вообще
        }

        private void Reauth()
        {
            if (_isLoggedIn != true)
            {
                SessionManager sm = new SessionManager(2774221, Convert.ToInt32(ApiPerms.Audio | ApiPerms.ExtendedMessages | ApiPerms.ExtendedWall | ApiPerms.Friends | ApiPerms.Offers | ApiPerms.Photos | ApiPerms.Questions | ApiPerms.SendNotify | ApiPerms.SidebarLink | ApiPerms.UserNotes | ApiPerms.UserStatus | ApiPerms.Video | ApiPerms.WallPublisher | ApiPerms.Wiki));
                //sm.Log += new SessionManagerLogHandler(sm_Log);
                _sessionInfo = sm.GetSession();
                _myId = int.Parse(_sessionInfo.MemberId);

                if (_sessionInfo != null)
                {
                    _isLoggedIn = true;
                }
                Reauth();
            }

            if (_isLoggedIn)
            {
                _manager = new ApiManager(_sessionInfo);
                //manager.Log += new ApiManagerLogHandler(manager_Log);
                //manager.DebugMode = true;
                _manager.Timeout = 10000;
                tStrip1.Text = "Онлайн";
                GetFriends();
                GetStatus();
                GetMyName();

            }
        }

        /// <summary>
        /// Отправляет сообщение указанному пользователю
        /// </summary>
        /// <param name="id">ID пользователя</param>
        /// <param name="message">Текст сообщения</param>
        private void Send(int id, string message)
        {
            _messagesFactory = new MessagesFactory(_manager);
            _messagesFactory.Send(id, message, null, SendMessageType.FromChat);
        }

        /// <summary>
        /// Получает список друзей
        /// </summary>
        private void GetFriends()
        {
            _friendsFactory = new FriendsFactory(_manager);
            string[] fields = { "uid", "first_name", "last_name" };
            _friendsList = _friendsFactory.Get("nom", null, 0, null, fields);

            foreach (Friend a in _friendsList)
            {
                listF.Items.Add(String.Concat(a.Id));
                listId.Items.Add(String.Concat(a.FirstName + " " + a.LastName));
            }
        }

        /// <summary>
        /// Получает список друзей находящихся в онлайне
        /// </summary>
        private void GetOnlineFriends()
        {
            _friendsFactory = new FriendsFactory(_manager);
            _onlineFriendsList = _friendsFactory.GetOnline();

            foreach (Friend a in _onlineFriendsList)
            {
                Console.WriteLine(a.Id);
            }
        }

        /// <summary>
        /// Получает данные текущего пользователя
        /// </summary>
        private void GetMyName()
        {
            _manager.Method("getProfiles");
            _manager.Params("uids", _myId);
            _manager.Params("fields", "first_name, last_name, photo_medium_rec");

            XmlNode result = _manager.Execute().GetResponseXml().FirstChild;
            XmlUtils.UseNode(result);
            _myFirstName = XmlUtils.String("first_name");
            _myLastName = XmlUtils.String("last_name");
            _myName = String.Concat(_myFirstName, " ", _myLastName);
            _myAvatarUrl = XmlUtils.String("photo_medium_rec");

            pictureBox2.ImageLocation = _myAvatarUrl;
            myNameLabel.Text = _myName;
        }

        /// <summary>
        /// Получает данные выбранного пользователя из списка друзей
        /// </summary>
        private void GetProfiles()
        {
            try
            {
                _manager.Method("getProfiles");
                _manager.Params("uids", Mid);
                _manager.Params("fields", "first_name, last_name, photo_medium_rec, nickname, education, bdate, online");

                XmlNode result = _manager.Execute().GetResponseXml().FirstChild;
                XmlUtils.UseNode(result);
                _fname = XmlUtils.String("first_name");
                _lname = XmlUtils.String("last_name");
                _avaurl = XmlUtils.String("photo_medium_rec");
                _nname = XmlUtils.String("nickname");
                _universityName = XmlUtils.String("university_name");
                _facultyName = XmlUtils.String("faculty_name");
                _bdate = XmlUtils.String("bdate");
                _online = XmlUtils.Bool("online");

                pictureBox1.ImageLocation = _avaurl;
                label1.Text = _fname + " " + _lname;
                label3.Text = _bdate;

                if (_universityName == null) // Должно, но не пашет
                {
                    label2.Text = _bdate;
                    label3.Text = "";
                }
                else
                {
                    label2.Text = _universityName + ", " + _facultyName;
                }

                if (_online)
                {
                    label4.Text = "В сети";
                    label4.ForeColor = Color.DarkGreen;
                }
                else
                {
                    label4.Text = "Не в сети";
                    label4.ForeColor = Color.DarkRed;
                }

            }

            catch (ApiRequestErrorException ex)
            {
                Console.WriteLine(ex);
            }
        }

        /// <summary>
        /// Получает историю сообщений
        /// </summary>
        private void GetHistory()
        {
            try
            {
                _messagesFactory = new MessagesFactory(_manager);
                _messagesList = _messagesFactory.GetHistory(Convert.ToInt32(Mid), null, 50);

                if (_messagesList != null)
                {
                    foreach (ApiCore.Messages.Message a in _messagesList)
                    {
                        if (a.Body != null)
                        {
                            if (a.UserId == Convert.ToInt32(Mid))
                            {
                                col1.ListView.Items.Add(String.Concat(_fname + ":"));
                            }
                            else
                            {
                                col1.ListView.Items.Add("Я:");
                            }
                            col2.ListView.Items.Add(a.Body);
                        }
                    }

                    for (int i = 0; i < listH.Items.Count; i++)
                    {
                        // 0,2,4 - это автор (То бишь четные)
                        // 1,3,5 - это сообщение (То бишь нечётные)
                        if (i == 0 || i % 2 == 0)
                        {
                            listH.Items[i].ForeColor = Color.Green;
                        }
                        else
                        {
                            listH.Items[i].ForeColor = Color.Black;
                        }
                    }
                }
                else
                {

                    listH.Items.Clear();
                }
            }
            catch (ApiRequestErrorException ex)
            {
                Console.WriteLine(ex);
            }
        }

        /// <summary>
        /// Получает статус пользователя
        /// </summary>
        private void GetStatus()
        {
            try
            {
                _statusFactory = new StatusFactory(_manager);
                _mystatus = _statusFactory.Get(_myId);
                myStatusTextBox.Text = _mystatus;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void listF_SelectedIndexChanged(object sender, EventArgs e)
        {
            listF.SelectedIndex = listId.SelectedIndex;
            MName = listId.SelectedItem.ToString();
            Mid = listF.SelectedItem.ToString();
            listH.Items.Clear();
            textBox1.Enabled = true;
            addUserToFaveButton.Enabled = true;
            usersProfileButton.Enabled = true;

            GetProfiles();
            GetHistory();
        }

        private void GetAudio()
        {
            try
            {
                _audioFactory = new AudioFactory(_manager);
                _audioList = _audioFactory.Get(_myId, null, null);

                foreach (AudioEntry a in _audioList)
                {
                    audioLinksListBox.Items.Add(a.Url);
                    audioListBox.Items.Add(String.Concat(a.Artist, " - ", a.Title));
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void audioListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            audioLinksListBox.SelectedIndex = audioListBox.SelectedIndex;

            _audioUrl = audioLinksListBox.SelectedItem.ToString();
            _audioName = audioListBox.SelectedItem.ToString();

            musicPanel1.SongName = _audioName;
            musicPanel1.UrlToSong = _audioUrl;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null && textBox1.Text != " ")
            {
                Send(Convert.ToInt32(Mid), textBox1.Text);
                textBox1.Text = "";
                GetHistory();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GetHistory();
            GetProfiles();
            GetFriends();
        }

        private void simpleButton1_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox1.Text != null && textBox1.Text != " ")
            {
                Send(Convert.ToInt32(Mid), textBox1.Text);
                textBox1.Text = "";
                GetHistory();
            }
        }

        private void StatusChange(object sender, EventArgs e) //происходит при нажатии на поле статуса
        {
            myStatusTextBox.ReadOnly = false;
            myStatusTextBox.MaxLength = 140;

            if (myStatusTextBox.Text == "")
            {
                myStatusTextBox.Text = "Поделитесь своими эмоциями";
            }
        }

        private void status_send_Click(object sender, EventArgs e)
        {
            _newstatus = myStatusTextBox.Text;
            _statusFactory = new StatusFactory(_manager);
            _statusFactory.Set(_newstatus);
            status_send.Visible = false;
            myStatusTextBox.ReadOnly = true;
        }

        private void myStatusTextBox_TextChanged(object sender, EventArgs e)
        {
            status_send.Visible = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (Mid != null && textBox1.TextLength != 0 && textBox1.Text != " ")
            {
                simpleButton1.Enabled = true;
            }
            else
            {
                simpleButton1.Enabled = false;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == false)
            {
                if (textBox1.Text != null && textBox1.Text != " ")
                {
                    simpleButton1.PerformClick();
                }
            }
            else if (e.Control && e.KeyCode == Keys.Enter)
            {
                
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(String.Concat("http://vk.com/id", Mid));
        }

        private void addUserToFaveButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.favoritesIDs = new StringCollection();
            Properties.Settings.Default.favoritesIDs.Add(Mid);
            Properties.Settings.Default.favoritesNames = new StringCollection();
            Properties.Settings.Default.favoritesNames.Add(MName);
            Console.WriteLine("В закладки!");

            for (int i = 0; i < Properties.Settings.Default.favoritesIDs.Count; i++)
            {
                listFavNames.Items.Add(Properties.Settings.Default.favoritesIDs[i]);
            }
            for (int o = 0; o < Properties.Settings.Default.favoritesNames.Count; o++)
            {
                listFavId.Items.Add(Properties.Settings.Default.favoritesNames[o]);
            }
            Properties.Settings.Default.Save();
        }

        // Слишком медленно работает :(
        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == friendsTab)
            {
                heartTab.Text = "";
                newsTab.Text = "";
                musicTab.Text = "";
                settingsTab.Text = "";
                friendsTab.Text = "Друзья";
            }
            else if (xtraTabControl1.SelectedTabPage == heartTab)
            {
                friendsTab.Text = "";
                heartTab.Text = "Избранное";
                newsTab.Text = "";
                musicTab.Text = "";
                settingsTab.Text = "";
            }
            else if (xtraTabControl1.SelectedTabPage == newsTab)
            {
                friendsTab.Text = "";
                heartTab.Text = "";
                newsTab.Text = "Новости";
                musicTab.Text = "";
                settingsTab.Text = "";
            }
            else if (xtraTabControl1.SelectedTabPage == musicTab)
            {
                friendsTab.Text = "";
                heartTab.Text = "";
                newsTab.Text = "";
                musicTab.Text = "Музыка";
                settingsTab.Text = "";
                GetAudio();
            }
            else if (xtraTabControl1.SelectedTabPage == settingsTab)
            {
                friendsTab.Text = "";
                heartTab.Text = "";
                newsTab.Text = "";
                musicTab.Text = "";
                settingsTab.Text = "Настройки";
                clear_btn.Visible = true;
            }
        }

        private void listFavorites_SelectedIndexChanged(object sender, EventArgs e)
        {
            listFavNames.SelectedIndex = listFavId.SelectedIndex;
            Mid = listFavNames.SelectedItem.ToString();
            listH.Items.Clear();
            textBox1.Enabled = true;
            addUserToFaveButton.Enabled = true;
            usersProfileButton.Enabled = true;

            GetProfiles();
            GetHistory();
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            listFavId.Items.Clear();
            listFavId.Items.Clear();
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }
    }
}