using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotYoutube.Tasks
{
    public class SubYoutubeTask : TaskBase
    {
        string jsSub= "if(document.querySelector(\"#subscribe-button.ytd-video-secondary-info-renderer > ytd-subscribe-button-renderer > paper-button[subscribed] > yt-formatted-string\")==undefined){document.querySelector(\"#subscribe-button.ytd-video-secondary-info-renderer > ytd-subscribe-button-renderer > paper-button > yt-formatted-string\").click()}";
        public string Link { get; set; } = "https://www.youtube.com/watch?v=dtl4tMLAeW4";
        public int DelayLink { get; set; } =1000;
        public SubYoutubeTask(BotBrowser _browser) : base(_browser)
        {
        }

        public override void DoTask()
        {
            UILog.AddLog("Start Sub : " + Link + " - " + DelayLink);
            this.Navigate(Link);
            this.WaitUtilDone();
            BotWorker.Sleep(DelayLink);
            this.RunJS(jsSub);
            this.WaitUtilDone();
            UILog.AddLog("End Sub : " + Link + " - " + DelayLink);
        }
    }
}
