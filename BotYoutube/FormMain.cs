using BotYoutube.Tasks;
using BotYoutube.UI;
using Gecko;
using Gecko.DOM;
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
    public partial class FormMain : FormBase
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            UIBrowser.Browser.Focus();
            UILog.AddLog("Wellcome To Bot Youtube");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new DisLikeYoutubeTask(UIBrowser.GetBotBrowser()).DoTask();
        }
    }
}
