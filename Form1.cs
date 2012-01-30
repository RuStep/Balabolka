using System;
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


namespace Balabolka
{
    public partial class Form1 : Form
    {
        private bool _isLoggedIn = false;

        private SessionInfo _sessionInfo;
        private ApiManager _manager;
        private MessagesFactory _messagesFactory;
        private FriendsFactory _friendsFactory;
        private List<Friend> _friendsList;
        private List<ApiCore.Messages.Message> _messagesList;
        public string Mid;
        private int _myId;
        private string _fname;
        private string _lname;
        private string _nname;
        private string _avaurl;
        private string _faculty_name;
        private string _university_name;
        private string _bdate;
        private bool _online;



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tStrip1.Text = "Оффлайн";
            Reauth();
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
        private void GetFriend()
        {
            _manager.Method("getProfiles");
            _manager.Params("uids", Mid);
            _manager.Params("fields", "first_name, last_name, photo_medium, nickname, education, bdate, online");

            XmlNode result = _manager.Execute().GetResponseXml().FirstChild;
            XmlUtils.UseNode(result);
            _fname = XmlUtils.String("first_name");
            _lname = XmlUtils.String("last_name");
            _avaurl = XmlUtils.String("photo_medium");
            _nname = XmlUtils.String("nickname");
            _university_name = XmlUtils.String("university_name");
            _faculty_name = XmlUtils.String("faculty_name");
            _bdate = XmlUtils.String("bdate");
            _online = XmlUtils.Bool("online");

            pictureBox1.ImageLocation = _avaurl;
            label1.Text = _fname + " " + _nname + " " + _lname;
            label3.Text = _bdate;

            if (_university_name == null)
            {
                label2.Text = _university_name + ", " + _faculty_name;
            }
            else
            {
                label2.Text = _bdate;
                label3.Text = "";
            }

            if (_online == true)
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


        private void listF_SelectedIndexChanged(object sender, EventArgs e)
        {
            listF.SelectedIndex = listId.SelectedIndex;
            Mid = listF.SelectedItem.ToString();
            listH.Items.Clear();
            GetFriend();
            GetHistory();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null && textBox1.Text != " ")
            {
                Send(Convert.ToInt32(Mid), textBox1.Text);
                textBox1.Text = "";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GetHistory();
            GetFriend();
            GetFriends();
        }

    }
}