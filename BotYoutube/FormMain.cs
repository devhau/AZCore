using BotYoutube.Entities;
using BotYoutube.Tasks;
using BotYoutube.UI;
using Gecko;
using Gecko.DOM;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotYoutube
{
    public partial class FormMain : FormBase
    {
        public static UserModel UserCurrent;
        public static string KeyConnectString ;
        public const string KeyConnect = "KeyConnectBotYoutube";
        RegistryKey BotRegistryKey;
        UserService service;
        LinkService serviceLink;
        ProxyService serviceProxy;
        AccYoutubeService serviceAccYoutube;
        public FormMain()
        {
            InitializeComponent();
        }
      
        private void FormMain_Load(object sender, EventArgs e)
        {
            BotRegistryKey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\BotYoutube");
           
            if (CheckConnect())
            {
                service = new UserService(new MySql.Data.MySqlClient.MySqlConnection(FormMain.KeyConnectString));
                serviceLink = new LinkService(new MySql.Data.MySqlClient.MySqlConnection(FormMain.KeyConnectString));
                serviceProxy = new ProxyService(new MySql.Data.MySqlClient.MySqlConnection(FormMain.KeyConnectString));
                serviceAccYoutube = new AccYoutubeService(new MySql.Data.MySqlClient.MySqlConnection(FormMain.KeyConnectString));

                UIBrowser.Browser.Focus();
                UILog.AddLog("Wellcome To Bot Youtube");
                panel2.Visible = false;
                pnMainServer.Visible = true;
            }
            else
            {
                if (File.Exists("token.bot"))
                {
                    BotRegistryKey.SetValue(KeyConnect, File.ReadAllText("token.bot"));
                    File.Delete("token.bot");
                    Application.Restart();
                    return;
                }
                pnMainServer.Visible = false;
                panel2.Visible = true;
            }
            LoadUserCurrent();
        }
        private bool CheckConnect() {
          var key=  BotRegistryKey.GetValue(KeyConnect);
            if (key == null) {
                return false;
            }
            bool IsConnect = false;
            try {

                KeyConnectString = BotAlgorithm.DecryptString(key.ToString(), BotAlgorithm.KeyString);
                var connectStr = new MySql.Data.MySqlClient.MySqlConnection(KeyConnectString);
                connectStr.Open();
                IsConnect = connectStr.State==ConnectionState.Open;
                connectStr.Close();
                connectStr = null;
            } catch {
                IsConnect = false;
                KeyConnectString = "";
            }
            return IsConnect;
        }

        private void txtComment_TextChanged(object sender, EventArgs e)
        {
            cbkTaskComment.Enabled = txtComment.Text.Length > 0;
            if (txtComment.Text.Length == 0)
                cbkTaskComment.Checked = false;
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F8) {
                new FormSetup() { BotRegistryKey=BotRegistryKey}.ShowDialog();
                return true;
            
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

      

        private void btnConnect_Click(object sender, EventArgs e)
        {
            BotRegistryKey.SetValue(KeyConnect, txtConnect.Text);
            if (CheckConnect())
            {
                pnMainServer.Visible = true;
                panel2.Visible = false;
                MessageBox.Show("Connect OK!");
                service = new UserService(new MySql.Data.MySqlClient.MySqlConnection(FormMain.KeyConnectString));
                UIBrowser.Browser.Focus();
                UILog.AddLog("Wellcome To Bot Youtube");
                LoadUserCurrent();
            }
            else {
                pnMainServer.Visible = false;
                panel2.Visible = true;
                MessageBox.Show("Connect Fail!");
                BotRegistryKey.SetValue(KeyConnect, "");
            }
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl2.SelectedTab == tabConnect) {
                txtCodeBotConnect.Text = BotRegistryKey.GetValue(KeyConnect).ToString();
            }
        }
        private void LoadUserCurrent() {

            if (UserCurrent == null)
            {
                pnInfo.Visible = false;
                pnLogin.Visible = true;
                tabControl1.TabPages.Remove(tabAdmin);
            }
            else
            {
                pnInfo.Visible = true;
                lblUserInfo.Text ="Hello, "+ UserCurrent.username;
                pnLogin.Visible = false;
                if (UserCurrent.IsAdmin)
                    tabControl1.TabPages.Insert(1,tabAdmin);
            }
            tabControl1.Update();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            var user = service.GetUserByUsername(txtUser.Text);
            if (user != null && user.passsword == BotAlgorithm.BotPassword(txtPassword.Text))
            {
                UserCurrent = user;
                LoadUserCurrent();
                txtPassword.Text = "";
            }
            else 
            {
                MessageBox.Show("Login fail!");
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            UserCurrent = null;
            LoadUserCurrent();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            BotRegistryKey.SetValue(KeyConnect, "");
            Application.Restart();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (BotWorker.IsStop)
            {
                return;
            }
            if (BotWorker.IsRunning)
            {
                BotWorker.IsStop = true;
                btnStart.Text = "Stopping....";
            }
            else
            {
                Action ActionServer = () =>
                {
                    grbServer.Enabled = !grbServer.Enabled;
                    if (grbServer.Enabled)
                    {
                        btnStart.Text = "Start";

                    }
                    else
                    {
                        btnStart.Text = "Stop";
                    }
                };
                ActionServer();
                BotWorker.StartLocal(txtLocalLink.Lines, txtLocalProxy.Lines, txtComment.Lines, cbkTaskView.Checked, cbkTaskSub.Checked, cbkTaskLike.Checked, cbkTaskDisLike.Checked, cbkTaskComment.Checked, (int)numDelay.Value * 1000, cbkLinkLoop.Checked, ActionServer);
            }
        }
        private void btnStartWork_Click(object sender, EventArgs e)
        {
            if (BotWorker.IsStop)
            {
                return;
            }
            if (BotWorker.IsRunning)
            {
                BotWorker.IsStop = true;
                btnStartWork.Text = "Stopping....";
            }
            else
            {
                Action ActionServer = () =>
                {
                    grbLocal.Enabled = btnLogout.Enabled = btnDisconnect.Enabled = !grbLocal.Enabled;
                    if (grbLocal.Enabled)
                    {
                        btnStartWork.Text = "Start Bot";
                    }
                    else
                    {
                        btnStartWork.Text = "Stop";
                    }
                };
                ActionServer();
                BotWorker.StartServer(serviceLink,serviceProxy, serviceAccYoutube, ActionServer);
            }
        }
    }
}
