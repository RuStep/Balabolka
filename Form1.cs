using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ApiCore;
using ApiCore.Friends;
using ApiCore.Messages;
using System.Xml;

namespace Balabolka
{
    public partial class Form1 : Form
    {
        private bool isLoggedIn = false;

        private SessionInfo sessionInfo;
        private ApiManager manager;
        private MessagesFactory messagesFactory;
        private FriendsFactory friendsFactory;
        private List<Friend> friendsList;
        private List<ApiCore.Messages.Message> messagesList;
        public string mid;
        private int uid;
        private int my_id;
        private string fname;
        private string lname;

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
            if (isLoggedIn != true)
            {
                SessionManager sm = new SessionManager(2774221, Convert.ToInt32(ApiPerms.Audio | ApiPerms.ExtendedMessages | ApiPerms.ExtendedWall | ApiPerms.Friends | ApiPerms.Offers | ApiPerms.Photos | ApiPerms.Questions | ApiPerms.SendNotify | ApiPerms.SidebarLink | ApiPerms.UserNotes | ApiPerms.UserStatus | ApiPerms.Video | ApiPerms.WallPublisher | ApiPerms.Wiki));
                //sm.Log += new SessionManagerLogHandler(sm_Log);
                sessionInfo = sm.GetSession();
                my_id = int.Parse(sessionInfo.MemberId);

                if (sessionInfo != null)
                {
                    isLoggedIn = true;
                }
                Reauth();
            }

            if (isLoggedIn)
            {
                manager = new ApiManager(sessionInfo);
                //manager.Log += new ApiManagerLogHandler(manager_Log);
                //manager.DebugMode = true;
                manager.Timeout = 10000;
                tStrip1.Text = "Онлайн";
                GetFriends();
            }
        }

        private void Send(int id, string message)
        {
            messagesFactory = new MessagesFactory(manager);
            messagesFactory.Send(id, message, null, SendMessageType.FromChat);
        }

        private void GetFriends()
        {
            friendsFactory = new FriendsFactory(manager);
            string[] fields = { "uid", "first_name", "last_name" };
            friendsList = friendsFactory.Get("nom", null, 0, null, fields);

            foreach (Friend a in friendsList)
            {
                listF.Items.Add(String.Concat(a.Id));
                listId.Items.Add(String.Concat(a.FirstName + " " + a.LastName));
            }
        }
        private void GetName()
        {
            manager.Method("getProfiles");
            manager.Params("uids", mid);
            manager.Params("fields", "first_name, last_name");

            XmlNode result = manager.Execute().GetResponseXml().FirstChild;
            XmlUtils.UseNode(result);
            fname = XmlUtils.String("first_name");
            lname = XmlUtils.String("last_name");
            label1.Text = "Ваш собеседник - " + fname + " " + lname;
        }

        private void GetHistory()
        {
            messagesFactory = new MessagesFactory(manager);
            messagesList = messagesFactory.GetHistory(Convert.ToInt32(mid), null, 50);

            if (messagesList != null)
            {
                foreach (ApiCore.Messages.Message a in messagesList)
                {
                    if (a.Body != null)
                    {
                        if (a.UserId == Convert.ToInt32(mid))
                        {
                            listH.Items.Add(String.Concat(fname + ":"));
                        }
                        else
                        {
                            listH.Items.Add("Я:");
                        }
                        listH.Items.Add(String.Concat("    " + a.Body));
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
            mid = listF.SelectedItem.ToString();
            listH.Items.Clear();
            GetName();
            GetHistory();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Send(Convert.ToInt32(mid), textBox1.Text);
            textBox1.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GetHistory();
            GetName();
            GetFriends();
        }

    }
}
