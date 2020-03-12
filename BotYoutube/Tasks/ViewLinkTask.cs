using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotYoutube.Tasks
{
    public class ViewLinkTask : TaskBase
    {
        public string Link { get; set; }
        public int DelayLink { get; set; }
        public ViewLinkTask(BotBrowser _browser) : base(_browser)
        {
        }

        public override void DoTask()
        {
            this.Navigate(Link);
            this.WaitUtilDone();
            Sleep(DelayLink);
        }
    }
}
