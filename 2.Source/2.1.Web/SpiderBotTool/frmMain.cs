using AZCore.Extensions;
using HtmlAgilityPack;
using SpiderBotTool.Website;
using System;
using System.Windows.Forms;

namespace SpiderBotTool
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            main = this;
        }
        private static frmMain main;
        public static void WriteLog(string _message, string _type = "Info")
        {
            main.txtLog.Invoke((Action)(()=>main.txtLog.AppendText(string.Format("{0:dd/MM/yy HH:mm:ss:sss} [{1}] {2}{3}", DateTime.Now, _type, _message,Environment.NewLine))));
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            main.txtLog.Clear();
            WriteLog("Wellcome to Spider Bot - Crawl Data For System 2020");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var mst = new masothue();
            var link = mst.GetPage();
            var ms = mst.GetCompanyInfo("https://masothue.vn{0}".Frmat(link[0]));
            Console.WriteLine("Text 2: ");
        }
    }
}
