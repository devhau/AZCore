using AZCore.Database;
using AZWeb.Module.Common;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZERP.Data.Components.Tables
{
    public abstract class AZDataCheckinCheckout {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<IEntity> Users { get; set; }
        public List<IEntity> DataCheckInCheckOut { get; set; }
        public abstract StringBuilder GetContentCell(IEntity User,DateTime day);
        public abstract StringBuilder GetContentUser(IEntity User);

    }
    [HtmlTargetElement("az-table-checkin-checkout")]
    public class AZTableCheckinCheckout: TagHelperBase
    {
        public AZDataCheckinCheckout Data { get; set; }
        public string LastDay { get; set; } = "az-color-last-day";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "";
            if (Data == null) return;
            StringBuilder htmlBuild = new StringBuilder(); 
            htmlBuild.Append("<table class=\"az-table-freeze\">");
            htmlBuild.Append("<thead>");
            htmlBuild.Append("<tr>");
            htmlBuild.Append("<th class=\"col-freeze\">Công nhân</th>");
            for (DateTime day = Data.StartDate; day <= Data.EndDate; day = day.AddDays(1))
            {
                htmlBuild.AppendFormat("<th class=\"cell-freeze {1} \">{0:dd/MM/yyyy} {2}</th>", day, day.DayOfWeek== DayOfWeek.Sunday|| day.DayOfWeek==DayOfWeek.Saturday? LastDay:"",day==DateTime.Now.Date?"(Hôm nay)":"");
            }
            htmlBuild.Append("</tr>");
            htmlBuild.Append("</thead>");
            htmlBuild.Append("<tbody>");
            if(Data.Users!=null)
            foreach (var item in Data.Users)
            {
                var RowBuild = new StringBuilder();
                RowBuild.Append("<tr>");
                RowBuild.AppendFormat("<td class=\"col-freeze\">{0}</td>", Data.GetContentUser(item));

                for (DateTime day = Data.StartDate; day <= Data.EndDate; day = day.AddDays(1))
                {
                    RowBuild.AppendFormat("<td class=\"cell-freeze {1}\">{0}</td>", Data.GetContentCell(item, day), day.DayOfWeek == DayOfWeek.Sunday || day.DayOfWeek == DayOfWeek.Saturday ? LastDay : "");
                }
                RowBuild.Append("</tr>");
                htmlBuild.Append(RowBuild.ToString());

                RowBuild.Clear();
            }
            htmlBuild.Append("</tbody>");
            htmlBuild.Append("</table>");
            output.Content.Clear();
            output.Content.SetHtmlContent(htmlBuild.ToString());
        }
    }
}
