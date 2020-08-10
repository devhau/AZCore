using AZCore.Extensions;
using HtmlAgilityPack;
using SpiderBotTool.common;
using System.Collections.Generic;
using System.Linq;

namespace SpiderBotTool.Website
{
    public class masothue: WebBaseBot
    {
        public class CompanyInfo {
            public const string _Name2= "tên quốc tế";
            public const string _Name3 = "tên viết tắt";
            public const string _PhoneNumber = "điện thoại";
            public const string _TexCode = "mã số thuế";
            public const string _Address = "địa chỉ";
            public const string _Agent = "người đại diện";
            public const string _OperationDate = "ngày hoạt động";
            public const string _CompanyType = "loại hình dn";
            public const string _ManagamentBy = "quản lý bởi";
            public const string _Status = "tình trạng";
            public string RefLink { get; set; }
            //
            /// <summary>
            /// Tên công ty
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// Tên quốc tế
            /// </summary>
            public string Name2 { get; set; }
            /// <summary>
            /// Tên viết tắt
            /// </summary>
            public string Name3 { get; set; }
            /// <summary>
            /// Điện thoại
            /// </summary>
            public string PhoneNumber { get; set; }
            /// <summary>
            /// Mã số thuế
            /// </summary>
            public string TexCode { get; set; }
            /// <summary>
            /// Địa chỉ
            /// </summary>
            public string Address { get; set; }
            /// <summary>
            /// Người đại diện
            /// </summary>
            public string Agent { get; set; }
            /// <summary>
            /// Ngày hoạt động
            /// </summary>
            public string OperationDate{get;set; }
            /// <summary>
            /// Quản lý bởi
            /// </summary>
            public string ManagamentBy { get; set; }
            /// <summary>
            /// Loại hình công ty
            /// </summary>
            public string CompanyType { get; set; }
            /// <summary>
            /// Trạng thái
            /// </summary>
            public string Status { get; set; }

        }
        public List<string> GetPage(int page=1)
        {
            //https://masothue.vn/Search/?q=CUNG+%E1%BB%A8NG+NH%C3%82N+L%E1%BB%B0C&type=auto
            var html = GetDoc("https://masothue.vn/Search/?q=CUNG+%E1%BB%A8NG+NH%C3%82N+L%E1%BB%B0C&type=auto&page=" + page);
            var link = html.SelectNodes("//*[@id=\"main\"]//*[@class=\"tax-listing\"]//h3/a");
            return link.Select(p => p.GetAttributeValue("href", string.Empty)).Where(p => p != string.Empty).ToList();
        }
        public Dictionary<string, string> GetDicTable(HtmlNode html) {
            var dic = new Dictionary<string, string>();
            ////*[@id=\"main\"]/section[1]/div/table[1]/tbody/tr[1]
            int len = html.SelectNodes("//*[@id=\"main\"]/section[1]/div/table[1]/tbody/tr").Count;
            for (int i = 1; i <= len; i++)
            {
                string _name = html.SelectSingleNode("//*[@id=\"main\"]/section[1]/div/table[1]/tbody/tr[{0}]/td[1]".Frmat(i))?.InnerText.Trim().ToLower();
                string _val = html.SelectSingleNode("//*[@id=\"main\"]/section[1]/div/table[1]/tbody/tr[{0}]/td[2]".Frmat(i))?.InnerText.Trim();
                if (!_val.IsNullOrEmpty())
                    dic[_name] = _val;
            }
            return dic;
        }
        public CompanyInfo GetCompanyInfo(string link)
        {
            var html = GetDoc(link);
            var company = new CompanyInfo();
            company.RefLink = link;
            company.Name = html.SelectSingleNode("//*[@id=\"main\"]/section[1]/div/table/thead/tr/th").InnerText;
            var dic = GetDicTable(html);
            if (dic.ContainsKey(CompanyInfo._Name2))
                company.Name2 = dic[CompanyInfo._Name2];
            if (dic.ContainsKey(CompanyInfo._Name3))
                company.Name3 = dic[CompanyInfo._Name3];
            if (dic.ContainsKey(CompanyInfo._PhoneNumber))
                company.PhoneNumber = dic[CompanyInfo._PhoneNumber];
            if (dic.ContainsKey(CompanyInfo._TexCode))
                company.TexCode = dic[CompanyInfo._TexCode];
            if (dic.ContainsKey(CompanyInfo._Address))
                company.Address = dic[CompanyInfo._Address];
            if (dic.ContainsKey(CompanyInfo._Agent))
                company.Agent = dic[CompanyInfo._Agent];
            if (dic.ContainsKey(CompanyInfo._OperationDate))
                company.OperationDate = dic[CompanyInfo._OperationDate];
            if (dic.ContainsKey(CompanyInfo._CompanyType))
                company.CompanyType = dic[CompanyInfo._CompanyType];
            if (dic.ContainsKey(CompanyInfo._ManagamentBy))
                company.ManagamentBy = dic[CompanyInfo._ManagamentBy];
            if (dic.ContainsKey(CompanyInfo._Status))
                company.Status = dic[CompanyInfo._Status];
            return company;
        }
    }
}
