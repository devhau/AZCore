using AZCore.Extensions;
using AZCore.Networks;
using HtmlAgilityPack;
using SpiderBotTool.Website;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Management;
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
            button1.Enabled = false;
            new thongtincongty().getLink(); 
            WriteLog("Done");
            button1.Enabled = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int start = 1;
            int end = 5;
            var mst = new masothue();
            string pathData = string.Format("{0}data", Application.StartupPath);
            if (!System.IO.Directory.Exists(pathData)) System.IO.Directory.CreateDirectory(pathData);

            for (int index = start; index < end; index++)
            {
                var links = mst.GetPage(index);
                foreach (string link in links)
                {
                    Application.DoEvents();
                    WriteLog("Xử lý link: {0}".Frmat(link));
                    var ms = mst.GetCompanyInfo("https://masothue.vn{0}".Frmat(link));
                    WriteLog("Lưu file: {0}".Frmat(ms.TexCode));
                    if (File.Exists("{0}/{1}.data".Frmat(pathData, ms.TexCode)))
                    {
                        WriteLog("Đã Tồn Tại File {1}.data".Frmat(pathData, ms.TexCode));
                    }
                    else
                    {
                        File.WriteAllText("{0}/{1}.data".Frmat(pathData, ms.TexCode), Newtonsoft.Json.JsonConvert.SerializeObject(ms));
                        WriteLog("Hoàn thành: {0}".Frmat(link));
                    }
                }
            };
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NetSH.Disable("Cellular");
            //SelectQuery wmiQuery = new SelectQuery("SELECT * FROM Win32_NetworkAdapter WHERE NetConnectionId != NULL");
            //ManagementObjectSearcher searchProcedure = new ManagementObjectSearcher(wmiQuery);
            //foreach (ManagementObject item in searchProcedure.Get())
            //{
            //    string name = (string)item["NetConnectionId"];
            //    WriteLog(name);

            //    if (name == "Cellular")
            //    {
            //        item.InvokeMethod("Disable", null);
            //    }
            //}
        }
    }
}
