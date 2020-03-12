using BotYoutube.Entities;
using BotYoutube.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotYoutube
{
    public partial class FormSetup : FormBase
    {
        public FormSetup()
        {
            InitializeComponent();
        }
        public IDbConnection GetConnect() {
         return   new MySql.Data.MySqlClient.MySqlConnection(string.Format("server={0};database={1};uid={2};pwd={3};CharSet=utf8;",txtHost.Text,txtDatabase.Text,txtUser.Text,txtPassword.Text));
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
            }catch{
                MessageBox.Show("Connect Fail!");
            }
        }

        private void btnCreateDB_Click(object sender, EventArgs e)
        {
            var con = GetConnect();
            new DBCreateEntities(con).CheckDatabase();
            var usersce = new UserService(con);
            usersce.Insert(new UserModel() { username="admin",passsword="123456",IsAdmin=true,CreateAt=DateTime.Now});
        }
    }
}
