﻿using System;
using System.Collections.Generic;
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


namespace Balabolka
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
        private List<Friend> _friendsList;
        private List<Friend> _onlineFriendsList;
        private List<ApiCore.Messages.Message> _messagesList;

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

        private int _myId;

        public string Mid;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            tStrip1.Text = "Оффлайн";
            Reauth();
            status_send.Visible = false;
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

        private void Send(int id, string message)
        {
            _messagesFactory = new MessagesFactory(_manager);
            _messagesFactory.Send(id, message, null, SendMessageType.FromChat);
        }

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

        private void GetOnlineFriends()
        {
            _friendsFactory = new FriendsFactory(_manager);
            _onlineFriendsList = _friendsFactory.GetOnline();

            foreach (Friend a in _onlineFriendsList)
            {
                Console.WriteLine(a.Id);
            }
        }

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

        private void GetProfiles()
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

            if (_universityName == null)
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

        private void GetHistory()
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
                            //listH.Items.Add(String.Concat(_fname + ":"));
                            col1.ListView.Items.Add(String.Concat(_fname + ":"));
                        }
                        else
                        {
                            col1.ListView.Items.Add("Я:");
                            //listH.Items.Add("Я:");
                        }
                        //listH.Items.Add(String.Concat("    " + a.Body));
                        //listH.Items.Add(a.Body);
                        col2.ListView.Items.Add(a.Body);
                    }
                }

                for (int i = 0; i < listH.Items.Count; i++)
                {
                    // 0 - это автор
                    // 1 - это сообщение
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
            Mid = listF.SelectedItem.ToString();
            listH.Items.Clear();

            GetProfiles();
            GetHistory();
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
            if (e.KeyCode == Keys.Enter && e.KeyCode == Keys.Control)
            {
                if (textBox1.Text != null && textBox1.Text != " ")
                {
                    Send(Convert.ToInt32(Mid), textBox1.Text);
                    textBox1.Text = "";
                    GetHistory();
                }
            }
        }

        private void StatusChange(object sender, EventArgs e) //происходит при нажатии на поле статуса
        {
            myStatusTextBox.ReadOnly = false;
            myStatusTextBox.MaxLength = 140;

            if (myStatusTextBox.Text == "")
            {
                myStatusTextBox.Text = "Поделитеь здесь своими эмоциями";
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

        // Слишком медленно работает :(
        //private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        //{
        //    if (xtraTabControl1.SelectedTabPage == friendsTab)
        //    {
        //        newsTab.Text = "";
        //        musicTab.Text = "";
        //        settingsTab.Text = "";
        //        friendsTab.Text = "Друзья";
        //    }
        //    else if (xtraTabControl1.SelectedTabPage == newsTab)
        //    {
        //        friendsTab.Text = "";
        //        newsTab.Text = "Новости";
        //        musicTab.Text = "";
        //        settingsTab.Text = "";
           
        //    }
        //    else if (xtraTabControl1.SelectedTabPage == musicTab)
        //    {
        //        friendsTab.Text = "";
        //        newsTab.Text = "";
        //        musicTab.Text = "Музыка";
        //        settingsTab.Text = "";
        //    }
        //    else if (xtraTabControl1.SelectedTabPage == settingsTab)
        //    {
        //        friendsTab.Text = "";
        //        newsTab.Text = "";
        //        musicTab.Text = "";
        //        settingsTab.Text = "Настройки";
        //    }
        //}
    }
}