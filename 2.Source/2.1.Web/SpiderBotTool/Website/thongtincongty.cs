using AZCore.Extensions;
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
            var html = GetDoc("https://www.thongtincongty.com/?page=" + PageIndex);
            var links = html.SelectNodes("//*[@class=\"container\"]//*[@class=\"search-results\"]//a");
            if (links == null) {
                frmMain.WriteLog("Null Page:" + PageIndex);
                frmMain.WriteLog(html.InnerText);
                return;
            }
           var _isNext = links?.Count > 0;
            if (_isNext) File.WriteAllLines("{1}data/thongtincongty_Page{0}.txt".Frmat(PageIndex, path), links.Select(p => p.GetAttributeValue("href", string.Empty)).Where(p => p != string.Empty).Distinct().ToList());
            frmMain.WriteLog("Page:" + PageIndex);
        }

        string path;
        public void getLink()
        {
             path = Application.StartupPath;
            var rs = Parallel.For(599, 24331, new ParallelOptions() { MaxDegreeOfParallelism = 5 }, (index)=> savePage(index));
            
        }
    }
}
