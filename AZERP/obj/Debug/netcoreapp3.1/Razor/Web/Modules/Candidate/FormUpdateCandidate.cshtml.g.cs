#pragma checksum "E:\Projects\AZCore\AZERP\Web\Modules\Candidate\FormUpdateCandidate.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7864af4303211aae9f8fb441eec77fa88efc2a36"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7864af4303211aae9f8fb441eec77fa88efc2a36", @"/Web/Modules/Candidate/FormUpdateCandidate.cshtml")]
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
            WriteLiteral(@"<div class=""az-update"" id=""FormUpdateCandidate"" role=""form"">
        <div class=""form-group"">
            <label for=""exampleInputEmail1"">Email address</label>
            <input type=""email"" class=""form-control""  name=""email"">
        </div>
        <div class=""form-group"">
            <label for=""exampleInputPassword1"">Password</label>
            <input type=""password"" class=""form-control""  name=""passsw"">
        </div>
</div>
");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("az-script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7864af4303211aae9f8fb441eec77fa88efc2a363399", async() => {
                WriteLiteral("\r\n    \r\n");
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
