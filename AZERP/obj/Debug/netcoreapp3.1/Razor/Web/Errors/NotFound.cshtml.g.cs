#pragma checksum "E:\Projects\AZCore\AZERP\Web\Errors\NotFound.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "db440de99e84697f8eb138b2eb996453c849e5a7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AZERP.Web.Errors.Web_Errors_NotFound), @"mvc.1.0.view", @"/Web/Errors/NotFound.cshtml")]
namespace AZERP.Web.Errors
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "E:\Projects\AZCore\AZERP\Web\_ViewImports.cshtml"
using AZERP.Data.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"db440de99e84697f8eb138b2eb996453c849e5a7", @"/Web/Errors/NotFound.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f80fed39116a657d7841041bff1ceb841a7338bb", @"/Web/_ViewImports.cshtml")]
    public class Web_Errors_NotFound : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NotFound>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", "hold-transition", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::AZWeb.TagHelpers.Html.AZHtml __AZWeb_TagHelpers_Html_AZHtml;
        private global::AZWeb.TagHelpers.Html.AZHead __AZWeb_TagHelpers_Html_AZHead;
        private global::AZWeb.TagHelpers.Html.AZBody __AZWeb_TagHelpers_Html_AZBody;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("az-html", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "db440de99e84697f8eb138b2eb996453c849e5a73285", async() => {
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("az-head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "db440de99e84697f8eb138b2eb996453c849e5a73554", async() => {
                    WriteLiteral("\r\n        ");
                }
                );
                __AZWeb_TagHelpers_Html_AZHead = CreateTagHelper<global::AZWeb.TagHelpers.Html.AZHead>();
                __tagHelperExecutionContext.Add(__AZWeb_TagHelpers_Html_AZHead);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("az-body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "db440de99e84697f8eb138b2eb996453c849e5a74514", async() => {
                    WriteLiteral("\r\n            <h4>");
#nullable restore
#line 7 "E:\Projects\AZCore\AZERP\Web\Errors\NotFound.cshtml"
           Write(Model.Title);

#line default
#line hidden
#nullable disable
                    WriteLiteral("</h4>\r\n        ");
                }
                );
                __AZWeb_TagHelpers_Html_AZBody = CreateTagHelper<global::AZWeb.TagHelpers.Html.AZBody>();
                __tagHelperExecutionContext.Add(__AZWeb_TagHelpers_Html_AZBody);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
            }
            );
            __AZWeb_TagHelpers_Html_AZHtml = CreateTagHelper<global::AZWeb.TagHelpers.Html.AZHtml>();
            __tagHelperExecutionContext.Add(__AZWeb_TagHelpers_Html_AZHtml);
            __AZWeb_TagHelpers_Html_AZHtml.ClassHtml = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NotFound> Html { get; private set; }
    }
}
#pragma warning restore 1591
