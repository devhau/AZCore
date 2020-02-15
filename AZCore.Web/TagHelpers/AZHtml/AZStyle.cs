﻿using AZCore.Web.Common;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZCore.Web.TagHelpers.AZHtml
{
    [HtmlTargetElement("az-style")]
    public class AZStyle : AZTagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "";

        }
    }
}
