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
    public partial class UIBrowser : FormBase
    {
        static UIBrowser ui;
        public static UIBrowser Browser
        {
            get
            {
                if (ui == null)
                {
                    ui = new UIBrowser();  ui.Show(); ui.Location = new Point(0, 0);
                    ui.HideButtuonClose = false;
                    ui.HideButtuonMin = false;
                }
                return ui;
            }
        }
        public static BotBrowser GetBotBrowser() => Browser.botBrowser1;
        private UIBrowser()
        {
            InitializeComponent();
        }

        private void UIBrowser_Load(object sender, EventArgs e)
        {
            btnHome.PerformClick();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            botBrowser1.Navigate("google.com");
        }
    }
}
