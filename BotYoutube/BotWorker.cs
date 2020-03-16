using BotYoutube.Entities;
using BotYoutube.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotYoutube
{
    public class BotWorker
    {
        public static void Sleep(int time)
        {
            do
            {
                if (time > 100)
                {
                    Thread.Sleep(100);
                    time = time - 100;
                }
                else
                {
                    Thread.Sleep(time);
                    time = 0;
                }
                if (IsStop) return;
                Application.DoEvents();
            } while (time > 0);


        }
        protected static readonly object objData = new object();
        public static void Worker(Action acDo,Action acDone) {
            var bck = new BackgroundWorker();
            bck.DoWork += (s, e) => { lock (objData) { if (acDo != null) acDo(); } };
            bck.RunWorkerCompleted += (s, e) =>
            {
                if(e.Error!=null)
                UILog.AddLog(e.Error.Message);
                lock (objData) { if (acDone != null) acDone(); }
             };
            
            bck.RunWorkerAsync();
        }
        public static bool IsStop = false;
        public static bool IsRunning = false;
        public static void StartLocal(string[] Links,string[] Proxys,string[] comments,bool isView,bool isSub,bool isLike,bool isDisLike,bool isComment,int delay,bool isLoop,Action acDone=null) {
            IsStop = false;
            IsRunning = true;
            do
            {
                
                if (Proxys == null || Proxys.Length == 0)
                {
                    foreach (var link in Links)
                    {
                        Application.DoEvents();
                        if (isView)
                        {
                            new ViewLinkTask(UIBrowser.GetBotBrowser()) { Link = link, DelayLink = delay }.DoTask();
                        }
                        Application.DoEvents();
                        if (IsStop) break;
                        if (isSub)
                        {
                            new SubYoutubeTask(UIBrowser.GetBotBrowser()) { Link = link, DelayLink = delay }.DoTask();
                        }
                        Application.DoEvents();
                        if (IsStop) break;
                        if (isLike)
                        {
                            new LikeYoutubeTask(UIBrowser.GetBotBrowser()) { Link = link, DelayLink = delay }.DoTask();
                        }
                        Application.DoEvents();
                        if (IsStop) break;
                        if (isDisLike)
                        {
                            new DisLikeYoutubeTask(UIBrowser.GetBotBrowser()) { Link = link, DelayLink = delay }.DoTask();
                        }
                        Application.DoEvents();
                        if (IsStop) break;
                        if (isComment)
                        {
                            string comment = comments[0];
                            new CommentYoutubeTask(UIBrowser.GetBotBrowser()) { Link = link, DelayLink = delay, Comment = comment }.DoTask();
                        }
                        Application.DoEvents();
                        if (IsStop) break;
                    }

                }
                else {
                    foreach (var item in Proxys) {

                        new ChangeProxyTask(UIBrowser.GetBotBrowser()) { Proxy=item }.DoTask();
                        foreach (var link in Links)
                        {
                            Application.DoEvents();
                            if (isView)
                            {
                                new ViewLinkTask(UIBrowser.GetBotBrowser()) { Link = link, DelayLink = delay }.DoTask();
                            }
                            Application.DoEvents();
                            if (IsStop) break;
                            if (isSub)
                            {
                                new SubYoutubeTask(UIBrowser.GetBotBrowser()) { Link = link, DelayLink = delay }.DoTask();
                            }
                            Application.DoEvents();
                            if (IsStop) break;
                            if (isLike)
                            {
                                new LikeYoutubeTask(UIBrowser.GetBotBrowser()) { Link = link, DelayLink = delay }.DoTask();
                            }
                            Application.DoEvents();
                            if (IsStop) break;
                            if (isDisLike)
                            {
                                new DisLikeYoutubeTask(UIBrowser.GetBotBrowser()) { Link = link, DelayLink = delay }.DoTask();
                            }
                            Application.DoEvents();
                            if (IsStop) break;
                            if (isComment)
                            {
                                string comment = comments[0];
                                new CommentYoutubeTask(UIBrowser.GetBotBrowser()) { Link = link, DelayLink = delay, Comment = comment }.DoTask();
                            }
                            Application.DoEvents();
                            if (IsStop) break;
                        }
                        Application.DoEvents();
                        if (IsStop) break;
                    }
                }
                Application.DoEvents();
                if (IsStop) break;
            } while (isLoop);
            IsStop = false;
            IsRunning = false;
            if (acDone != null) acDone();
        }
        public static void StartServer(LinkService serviceLink, ProxyService serviceProxy, AccYoutubeService serviceAccYoutube, Action acDone = null) {
            IsStop = false;
            IsRunning = true;
            DateTime startDateProcess = DateTime.Now;
            do {
                if ((DateTime.Now - startDateProcess).TotalMinutes > 15) {
                    startDateProcess = DateTime.Now;
                    // set Proxy
                    var proxy = serviceProxy.GetProxyProcess();
                    if(proxy!=null)
                     new ChangeProxyTask(UIBrowser.GetBotBrowser()) { ProxyIP=proxy.ip,ProxyPort= proxy.port}.DoTask();
                    var accc = serviceAccYoutube.GetAccProcess();
                    if (accc != null)
                        new LoginGoogleTask(UIBrowser.GetBotBrowser()) { Email = accc.email, Password = accc.pass}.DoTask();
                }
                var taskLink = serviceLink.GetLinkProcess();
                if (taskLink!=null) {
                    if (taskLink.IsView && !IsStop) {
                        new ViewLinkTask(UIBrowser.GetBotBrowser()) { Link = taskLink.link, DelayLink = taskLink.DelayView }.DoTask();
                    }
                    Application.DoEvents();
                    if (taskLink.IsSub && !IsStop)
                    {
                        new SubYoutubeTask(UIBrowser.GetBotBrowser()) { Link = taskLink.link, DelayLink = taskLink.DelaySub }.DoTask();
                    }
                    Application.DoEvents();
                    if (taskLink.IsLike && !IsStop)
                    {
                        new LikeYoutubeTask(UIBrowser.GetBotBrowser()) { Link = taskLink.link, DelayLink = taskLink.DelayLike }.DoTask();
                    }
                    Application.DoEvents();
                    if (taskLink.IsDisLike && !IsStop)
                    {
                        new DisLikeYoutubeTask(UIBrowser.GetBotBrowser()) { Link = taskLink.link, DelayLink = taskLink.DelayDisLike }.DoTask();
                    }
                    Application.DoEvents();
                    if (taskLink.IsComment && !IsStop)
                    {
                        string comment = "Xin chào ";
                        new CommentYoutubeTask(UIBrowser.GetBotBrowser()) { Link = taskLink.link, DelayLink = taskLink.DelayComment, Comment = comment }.DoTask();
                    }
                    Application.DoEvents();
                }
                Application.DoEvents();
            } while (!IsStop);
            IsStop = false;
            IsRunning = false;
            if (acDone != null) acDone();

        }
    }
}
