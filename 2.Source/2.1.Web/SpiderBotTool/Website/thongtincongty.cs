using AZCore.Extensions;
using HtmlAgilityPack;
using SpiderBotTool.common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpiderBotTool.Website
{
    public class thongtincongty : WebBaseBot
    {
        void savePage(int PageIndex) {
            if (File.Exists("{1}data/thongtincongty_Page{0}.txt".Frmat(PageIndex, path))) return;
            HtmlNode html=null;
            bool isNext = false;
            do {
                try
                {
                    html = GetDoc("http://server1.kproxy.com/servlet/redirect.srv/sruj/shdrzbqcykygicp/suvw/p2/?page=" + PageIndex);
                    isNext = html.InnerText.Trim() == "Cannot Connect To MySQL Server";
                }
                catch(Exception ex)
                {
                    frmMain.WriteLog(ex.Message);
                   
                }
                Application.DoEvents();

            } while (isNext || html == null);
            var links = html.SelectNodes("//*[@class=\"container\"]//*[@class=\"search-results\"]//a");
            if (links == null) {
                frmMain.WriteLog("Null Page:" + PageIndex);
                frmMain.WriteLog(html.InnerText);
                return;
            }
           var _isNext = links?.Count > 0;
            if (_isNext) File.WriteAllLines("{1}data/thongtincongty_Page{0}.txt".Frmat(PageIndex, path), links.Select(p => p.GetAttributeValue("href", string.Empty)).Where(p => p != string.Empty).Distinct().ToList());
            frmMain.WriteLog("Page:" + PageIndex);
            Application.DoEvents();
        }

        string path;
        public void getLink()
        {
             path = Application.StartupPath;
            var rs = Parallel.For(1, 24333, new ParallelOptions() { MaxDegreeOfParallelism = 10 }, (index)=> savePage(index));
            
        }
    }
}
