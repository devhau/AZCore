using BotYoutube.Entities;
using BotYoutube.UI;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotYoutube
{
    public partial class FormSetup : FormBase
    {
        public RegistryKey BotRegistryKey;
        public FormSetup()
        {
            InitializeComponent();
        }
        public IDbConnection GetConnect() {
         return   new MySql.Data.MySqlClient.MySqlConnection(txtConnectString.Text);
        }
        private void btnConnectDB_Click(object sender, EventArgs e)
        {
            try
            {
                var con = GetConnect();
                con.Open();
                MessageBox.Show(con.State.ToString());
                con.Close();
                con.Dispose();
                con = null;

                BotRegistryKey.SetValue(FormMain.KeyConnect, BotAlgorithm.EncryptString(txtConnectString.Text, BotAlgorithm.KeyString));
            }
            catch{
                MessageBox.Show("Connect Fail!");
            }
        }

        private void btnCreateDB_Click(object sender, EventArgs e)
        {
            var con = GetConnect();
            new DBCreateEntities(con).CheckDatabase();
            var usersce = new UserService(con);
            if (usersce.GetAll().Count() == 0)
                usersce.Insert(new UserModel() { username = "admin", passsword = BotAlgorithm.BotPassword("123456"), IsAdmin = true, CreateAt = DateTime.Now });
            MessageBox.Show("OK");
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            txtConnectString.Text = string.Format("server={0};database={1};uid={2};pwd={3};CharSet=utf8;", txtHost.Text, txtDatabase.Text, txtUser.Text, txtPassword.Text);
        }

        private void FormSetup_Load(object sender, EventArgs e)
        {
            txt_TextChanged(null,null);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
#if DEBUG
#else
            if (txtPass.Text == string.Format("Admin@01644638697{0:HH}", DateTime.Now))
#endif
            {
                panel2.Visible = false;
            }
        }
    }
}
