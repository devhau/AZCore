using HtmlAgilityPack;
using Microsoft.AspNetCore.Html;
using System.Text.Encodings.Web;

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
	}
}
