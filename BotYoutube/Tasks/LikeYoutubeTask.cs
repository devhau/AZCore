using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotYoutube.Tasks
{
    public class LikeYoutubeTask : TaskBase
    {
        string jsLike = "if(document.querySelector(\"#top-level-buttons > ytd-toggle-button-renderer.style-scope.ytd-menu-renderer.force-icon-button.style-default-active > a\")==undefined){document.querySelector(\"#top-level-buttons > ytd-toggle-button-renderer:nth-child(1) > a\").click()}";
        public string Link { get; set; } = "https://www.youtube.com/watch?v=dtl4tMLAeW4";
        public int DelayLink { get; set; } = 5000;
        public LikeYoutubeTask(BotBrowser _browser) : base(_browser)
        {
        }

        public override void DoTask()
        {
            this.Navigate(Link);
            this.WaitUtilDone();
            Sleep(DelayLink);
            this.RunJS(jsLike);
            UILog.AddLog("log");
        }
    }
}
