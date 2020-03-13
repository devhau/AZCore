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

namespace BotYoutube.Manager.AccYoutube
{
    public partial class ManagerAccYoutube : ManagerBase
    {
        AccYoutubeService service;
        public ManagerAccYoutube()
        {
            InitializeComponent();
            service = new AccYoutubeService(new MySql.Data.MySqlClient.MySqlConnection("server=127.0.0.1;database=botyoutube;uid=root;pwd=;CharSet=utf8;"));
        }
        public override FormUpdate GetFormUpdate()
        {
            return new UpdateAccYoutube();
        }
        public override object GetData()
        {
            return service.GetAll().ToList();
        }
       
        public override void UpdateData(IEntityModel model, bool isEdit = false)
        {
            if (isEdit) service.Update((AccYoutubeModel)model);
            else service.Insert((AccYoutubeModel)model);
        }
        public override void RemoveData(IEntityModel model)
        {
            service.Delete((AccYoutubeModel)model);
        }
    }
}
