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

namespace BotYoutube.Manager.Link
{
    public partial class ManagerLink : ManagerBase
    {
        LinkService service;
        public ManagerLink()
        {
            InitializeComponent();
             }
        public override void BeforeLoad()
        {
            service = new LinkService(new MySql.Data.MySqlClient.MySqlConnection(FormMain.KeyConnectString));
            base.BeforeLoad();
        }
        public override FormUpdate GetFormUpdate()
        {
            return new UpdateLink();
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
