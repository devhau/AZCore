using BotYoutube.UI;
using System;
using System.Drawing;

namespace BotYoutube
{
    public partial class UILog : FormBase
    {
        static UILog ui;
        public static UILog Log
        {
            get
            {
                if (ui == null)
                {
                    ui = new UILog(); ui.TopMost = true; ui.Show(); ui.Location = new Point(200, 0);
                    ui.HideButtuonClose = false;
                    ui.HideButtuonMin = false;
                }
                return ui;
            }
        }
        public static void AddLog(string log) {
            Log.txtLog.Invoke(new Action(() => {
                Log.txtLog.AppendText(string.Format("{0:hh:mm:ss} : {1}\r\n", DateTime.Now, log));
                Log.txtLog.ScrollToCaret();
            }));
        }
        private UILog()
        {
            InitializeComponent();
        }
    }
}
