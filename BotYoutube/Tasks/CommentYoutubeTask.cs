using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotYoutube.Tasks
{
    public class CommentYoutubeTask : TaskBase
    {
        string jsComment = "document.querySelector(\"#simplebox-placeholder\").click();document.querySelector(\"#contenteditable-root\").innerHTML=\"{0}\";document.querySelector(\"ytd-button-renderer#submit-button\").removeAttribute(\"disabled\");document.querySelector(\"ytd-button-renderer#submit-button\").click()";
        public string Link { get; set; } = "https://www.youtube.com/watch?v=Iuo56gEO2eI";
        public int DelayLink { get; set; } = 3000;
        public string Comment { get; set; } = "Xin chào,Chúc bạn 1 video thành công";
        public CommentYoutubeTask(BotBrowser _browser) : base(_browser)
        {
        }

        public override void DoTask()
        {
            UILog.AddLog("Start Comment : " + Link + " - " + DelayLink);
            this.Navigate(Link);
            this.WaitUtilDone();            
            this.GoToSubYoutube();
            this.WaitUtilDone();
            BotWorker.Sleep(DelayLink);
            this.RunJS(string.Format(jsComment,Comment));
            this.WaitUtilDone();
            UILog.AddLog("End Comment : " + Link + " - " + DelayLink);
        }
    }
}
