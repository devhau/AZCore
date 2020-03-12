namespace BotYoutube.Tasks
{
    public class ChangeProxyTask : TaskBase
    {
        public string Proxy { get; set; }
        public string ProxyIP { get; set; }
        public int ProxyPort { get; set; } = 0;
        public ChangeProxyTask(BotBrowser _browser) : base(_browser)
        {
        }

        public override void DoTask()
        {
            if (!string.IsNullOrEmpty(Proxy)) {
                if (string.IsNullOrEmpty(Proxy) || Proxy.IndexOf(":") < 0) return;
                ProxyIP = Proxy.Split(':')[0];
                string pport = Proxy.Split(':')[1];
                if (string.IsNullOrEmpty(ProxyIP) || string.IsNullOrEmpty(pport)) return ;
                int port = 0;
                int.TryParse(pport, out port);
                ProxyPort = port;
            }
            if (string.IsNullOrEmpty(ProxyIP) ||  ProxyPort <= 0) return;
            this.browser.ChangeProxy(ProxyIP, ProxyPort);
        }
    }
}
