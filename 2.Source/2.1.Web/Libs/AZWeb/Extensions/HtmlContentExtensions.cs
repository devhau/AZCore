using HtmlAgilityPack;
using Microsoft.AspNetCore.Html;
using System.Text.Encodings.Web;
using System.Web;

namespace AZWeb.Extensions
{
    public static class HtmlContentExtensions
    {
		public static string GetString(this IHtmlContent content)
		{
			using (var writer = new System.IO.StringWriter())
			{
				content.WriteTo(writer, HtmlEncoder.Default);
				return writer.ToString();
			}
		}
		public static HtmlDocument LoadHtml(this string content)
		{
			var htmlDoc = new HtmlDocument();
			htmlDoc.LoadHtml(content);
			return htmlDoc;
		}
		public static string HtmlEncode2(this object html)
		{
			return HttpUtility.HtmlEncode(html);
		}
		public static string HtmlEncode(this string html) {
			return HttpUtility.HtmlEncode(html);
		}
		public static string HtmlDecode(this string html)
		{
			return HttpUtility.HtmlDecode(html);
		}
	}
}
