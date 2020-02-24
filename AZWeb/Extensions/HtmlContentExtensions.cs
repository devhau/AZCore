using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace AZWeb.Extensions
{
    public static class HtmlContentExtensions
    {
		internal static string GetString(this IHtmlContent content)
		{
			using (var writer = new System.IO.StringWriter())
			{
				content.WriteTo(writer, HtmlEncoder.Default);
				return writer.ToString();
			}
		}
	}
}
