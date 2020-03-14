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

namespace BotYoutube.Manager.Proxy
{
    public partial class ManagerProxy : ManagerBase
    {
        ProxyService service;
        public ManagerProxy()
        {
            InitializeComponent();
          }
        public override void BeforeLoad()
        {
            service = new ProxyService(new MySql.Data.MySqlClient.MySqlConnection(FormMain.KeyConnectString));
            base.BeforeLoad();
        }
        public override FormUpdate GetFormUpdate()
        {
            return new UpdateProxy();
        }
        public override object GetData()
        {
            return service.GetAll().ToList();
        }
       
        public override void UpdateData(IEntityModel model, bool isEdit = false)
        {
            if (isEdit) service.Update((ProxyModel)model);
            else service.Insert((ProxyModel)model);
        }
        public override void RemoveData(IEntityModel model)
        {
            service.Delete((ProxyModel)model);
        }

        private void btnAddProxy_Click(object sender, EventArgs e)
        {
            var frm = new UpdateProxy2();
            if (frm.ShowDialog() == DialogResult.OK) {
                foreach (var item in frm.listProxy) {
                    service.Insert(item);
                }
            }
        }
    }
}
