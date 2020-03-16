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

namespace BotYoutube.Manager.Campaign
{
    public partial class ManagerCampaign : ManagerBase
    {
       CampaignService service;
        public ManagerCampaign()
        {
            InitializeComponent();
        }
        public override void BeforeLoad()
        {
            service = new CampaignService(new MySql.Data.MySqlClient.MySqlConnection(FormMain.KeyConnectString));
            base.BeforeLoad();
        }
        public override FormUpdate GetFormUpdate()
        {
            return new UpdateCampaign();
        }
        public override object GetData()
        {
            return service.GetAll().ToList();
        }
       
        public override void UpdateData(IEntityModel model, bool isEdit = false)
        {
            if (isEdit) service.Update((CampaignModel)model);
            else service.Insert((CampaignModel)model);
        }
        public override void RemoveData(IEntityModel model)
        {
            service.Delete((CampaignModel)model);
        }
        public override void AfterLoad()
        {
            this.dataView.Columns["pass"].Visible = false;
        }

    }
}
