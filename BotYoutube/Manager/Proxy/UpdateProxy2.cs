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

namespace BotYoutube.Manager.Proxy
{
    public partial class UpdateProxy2 : FormUpdate
    {
        public List<ProxyModel> listProxy = new List<ProxyModel>();
        public UpdateProxy2()
        {
            InitializeComponent();
        }
        public override bool BeforeSave()
        {
            if (txtProxy.Lines.Length > 0) {
                foreach (var item in txtProxy.Lines)
                {
                    if (item.Trim().IndexOf(":") > 0)
                    {
                        var ip = item.Trim().Split(':')[0];
                        var port = item.Trim().Split(':')[1];
                        int pport = 0;
                        int.TryParse(port, out pport);
                        if (pport > 0 && ip != "")
                        {
                            listProxy.Add(new ProxyModel() { ip = ip, port = pport, IsActice = true });
                        }
                    }
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            
            return false;
        }
    }
}
