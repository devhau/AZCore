using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BotYoutube.UI;
using BotYoutube.Entities;
using BotYoutube.Database;

namespace BotYoutube.Manager.User
{
    public partial class ManagerUser : ManagerBase
    {
        UserService service;
        public ManagerUser()
        {
            InitializeComponent();
            service = new UserService(new MySql.Data.MySqlClient.MySqlConnection("server=127.0.0.1;database=botyoutube;uid=root;pwd=;CharSet=utf8;"));
        }
        public override FormUpdate GetFormUpdate()
        {
            return new UpdateUser();
        }
        public override object GetData()
        {
            return service.GetAll().ToList();
        }
       
        public override void UpdateData(IEntityModel model, bool isEdit = false)
        {
            if (isEdit) service.Update((UserModel)model);
            else service.Insert((UserModel)model);
        }
        public override void RemoveData(IEntityModel model)
        {
            service.Delete((UserModel)model);
        }
    }
}
