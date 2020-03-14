using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotYoutube.Tasks
{
    public class DisLikeYoutubeTask : TaskBase
    {
        string jsDisLike = "if(document.querySelector(\"#top-level-buttons > ytd-toggle-button-renderer:nth-child(2).style-scope.ytd-menu-renderer.force-icon-button.style-default-active > a\")==undefined){document.querySelector(\"#top-level-buttons > ytd-toggle-button-renderer:nth-child(2) > a\").click();}";
        public string Link { get; set; } = "https://www.youtube.com/watch?v=dtl4tMLAeW4";
        public int DelayLink { get; set; } = 1000;
        public DisLikeYoutubeTask(BotBrowser _browser) : base(_browser)
        {
        }

        public override void DoTask()
        {
            UILog.AddLog("Start DisLkie : " + Link + " - " + DelayLink);
            this.Navigate(Link);
            this.WaitUtilDone();
            BotWorker.Sleep(DelayLink);
            this.RunJS(jsDisLike); 
            this.WaitUtilDone();
            UILog.AddLog("End DisLkie : " + Link + " - " + DelayLink);
        }
    }
}
