﻿using AZWeb.Common;
using AZWeb.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZWeb.TagHelpers.Html
{
    public class AZContent:AZTagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "";

            output.Content.SetHtmlContent(this.Html.Html.ToString());
        }
    }
}