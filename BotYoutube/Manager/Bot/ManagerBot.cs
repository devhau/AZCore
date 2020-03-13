﻿using System;
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

namespace BotYoutube.Manager.Bot
{
    public partial class ManagerBot : ManagerBase
    {
        LinkService service;
        public ManagerBot()
        {
            InitializeComponent();
            service = new LinkService(new MySql.Data.MySqlClient.MySqlConnection("server=127.0.0.1;database=botyoutube;uid=root;pwd=;CharSet=utf8;"));
        }
        public override FormUpdate GetFormUpdate()
        {
            return new UpdateBot();
        }
        public override object GetData()
        {
            return service.GetAll().ToList();
        }
       
        public override void UpdateData(IEntityModel model, bool isEdit = false)
        {
            if (isEdit) service.Update((LinkModel)model);
            else service.Insert((LinkModel)model);
        }
        public override void RemoveData(IEntityModel model)
        {
            service.Delete((LinkModel)model);
        }
    }
}
