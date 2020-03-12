using Gecko;
using Gecko.DOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotYoutube.Tasks
{
    public abstract class TaskBase
    {
        protected BotBrowser browser;
        public TaskBase(BotBrowser _browser)
        {
            browser = _browser;
        }
        public abstract void DoTask();
        public void WaitUtilDone() => browser.WaitUtilDone();
        public void Navigate(string url) => browser.Navigate(url);
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
                Application.DoEvents();
            } while (time > 0);


        }
        #region Anchor
        protected GeckoAnchorElement GetAnchorElement(Func<GeckoAnchorElement, bool> func)
        {
            return this.GetElement("a", func);
        }
        protected List<GeckoAnchorElement> GetAnchorElements(Func<GeckoAnchorElement, bool> func)
        {
            return this.GetElements("a", func);
        }
        #endregion

        #region Input
        protected GeckoInputElement GetInputElement(Func<GeckoInputElement, bool> func)
        {
            return this.GetElement("input", func);
        }
        protected List<GeckoInputElement> GetInputElements(Func<GeckoInputElement, bool> func)
        {
            return this.GetElements("input", func);
        }
        #endregion

        #region Base
        protected T GetElement<T>(string tagName, Func<T, bool> func)
        {

            if (func != null)
            {
                return browser.Document.GetElementsByTagName(tagName).OfType<T>().Cast<T>().Where(func).FirstOrDefault();
            }
            return browser.Document.GetElementsByTagName(tagName).OfType<T>().Cast<T>().FirstOrDefault();
        }
       
        protected List<T> GetElements<T>(string tagName, Func<T, bool> func)
        {
            if (func != null)
            {
                return browser.Document.GetElementsByTagName(tagName).OfType<T>().Cast<T>().Where(func).ToList();
            }
            return browser.Document.GetElementsByTagName(tagName).OfType<T>().Cast<T>().ToList();
        }
        #endregion
        public string RunJS(string js) {
            string result;
            using (AutoJSContext context = new AutoJSContext(browser.Window))
            {
                context.EvaluateScript(js, out result);
            }
            return result;
        }
        public void GoToTop() => this.browser.GoToTop();
        public void GoToBottom() => this.browser.GoToBottom();
        public void GoToCenter() => this.browser.GoToCenter();
        public void GoToSubYoutube() => this.browser.GoToSubYoutube();
        
    }
}
