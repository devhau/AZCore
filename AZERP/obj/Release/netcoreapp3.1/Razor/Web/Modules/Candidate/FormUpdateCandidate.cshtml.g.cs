#pragma checksum "E:\Projects\AZCore\AZERP\Web\Modules\Candidate\FormUpdateCandidate.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "466daa8e7a1efc2889f61c8dbbd4e7b351d8301f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AZ.Web.Modules.Candidate.Web_Modules_Candidate_FormUpdateCandidate), @"mvc.1.0.view", @"/Web/Modules/Candidate/FormUpdateCandidate.cshtml")]
namespace AZ.Web.Modules.Candidate
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
using AZ;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"466daa8e7a1efc2889f61c8dbbd4e7b351d8301f", @"/Web/Modules/Candidate/FormUpdateCandidate.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"92d9c9ae5d2575ea1942ba34bcbb1ab5318fdf24", @"/Web/_ViewImports.cshtml")]
    public class Web_Modules_Candidate_FormUpdateCandidate : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FormUpdateCandidate>
    {
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
        private global::AZWeb.TagHelpers.AZHtml.AZScript __AZWeb_TagHelpers_AZHtml_AZScript;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"    <div class=""az-update"" id=""FormUpdateCandidate"">
        <div class=""row"">
            <div class=""col-sm-6"">
                <!-- text input -->
                <div class=""form-group"">
                    <label>Text</label>
                    <input type=""text"" class=""form-control"" placeholder=""Enter ..."">
                </div>
            </div>
            <div class=""col-sm-6"">
                <div class=""form-group"">
                    <label>Text Disabled</label>
                    <input type=""text"" class=""form-control"" placeholder=""Enter ..."">
                </div>
            </div>
        </div>
        <div class=""row"">
            <div class=""col-sm-6"">
                <!-- textarea -->
                <div class=""form-group"">
                    <label>Textarea</label>
                    <textarea class=""form-control"" rows=""3"" placeholder=""Enter ...""></textarea>
                </div>
            </div>
            <div class=""col-sm-6"">
                <div ");
            WriteLiteral("class=\"form-group\">\r\n                    <label>Textarea Disabled</label>\r\n                    <textarea class=\"form-control\" rows=\"3\" placeholder=\"Enter ...\"></textarea>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("az-script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "466daa8e7a1efc2889f61c8dbbd4e7b351d8301f4290", async() => {
                WriteLiteral("\r\n    $(\"#FormCandidate\").AZManager();\r\n");
            }
            );
            __AZWeb_TagHelpers_AZHtml_AZScript = CreateTagHelper<global::AZWeb.TagHelpers.AZHtml.AZScript>();
            __tagHelperExecutionContext.Add(__AZWeb_TagHelpers_AZHtml_AZScript);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FormUpdateCandidate> Html { get; private set; }
    }
}
#pragma warning restore 1591
