#pragma checksum "E:\Projects\AZCore\AZERP\Web\Modules\Role\FormRole.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c58de52fc638c101fc9413805a1c1e342e04be63"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AZERP.Web.Modules.Role.Web_Modules_Role_FormRole), @"mvc.1.0.view", @"/Web/Modules/Role/FormRole.cshtml")]
namespace AZERP.Web.Modules.Role
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c58de52fc638c101fc9413805a1c1e342e04be63", @"/Web/Modules/Role/FormRole.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f80fed39116a657d7841041bff1ceb841a7338bb", @"/Web/_ViewImports.cshtml")]
    public class Web_Modules_Role_FormRole : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FormRole>
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
        private global::AZWeb.Module.TagHelper.Module.ModuleLayout __AZWeb_Module_TagHelper_Module_ModuleLayout;
        private global::AZWeb.TagHelpers.AZTable __AZWeb_TagHelpers_AZTable;
        private global::AZWeb.Module.TagHelper.Theme.AZScript __AZWeb_Module_TagHelper_Theme_AZScript;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("az-module-layout", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c58de52fc638c101fc9413805a1c1e342e04be633021", async() => {
                WriteLiteral(@"
    <div class=""az-manager"" id=""FormCatalog"" data-form-size=""az-modal-xl"">
        <div class=""az-toolbar"">
            <button type=""button"" class=""btn btn-success btn-sm az-btn az-btn-add"" data-hot-key=""f1""><i class=""far fa-plus-square""></i> Thêm Mới (F1)</button>
            <button type=""button"" class=""btn btn-info btn-sm az-btn az-btn-export""><i class=""fas fa-file-export""></i> Xuất Excel (F2)</button>
            <button type=""button"" class=""btn btn-secondary btn-sm az-btn az-btn-import""><i class=""fas fa-file-import""></i> Nhập Excel (F3)</button>
        </div>
        <div class=""az-data-table"">
            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("az-table", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c58de52fc638c101fc9413805a1c1e342e04be633948", async() => {
                }
                );
                __AZWeb_TagHelpers_AZTable = CreateTagHelper<global::AZWeb.TagHelpers.AZTable>();
                __tagHelperExecutionContext.Add(__AZWeb_TagHelpers_AZTable);
#nullable restore
#line 10 "E:\Projects\AZCore\AZERP\Web\Modules\Role\FormRole.cshtml"
__AZWeb_TagHelpers_AZTable.Data = Model.Data;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("data", __AZWeb_TagHelpers_AZTable.Data, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 10 "E:\Projects\AZCore\AZERP\Web\Modules\Role\FormRole.cshtml"
__AZWeb_TagHelpers_AZTable.FunKey = (item)=>((RoleModel)item).Id;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("FunKey", __AZWeb_TagHelpers_AZTable.FunKey, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 10 "E:\Projects\AZCore\AZERP\Web\Modules\Role\FormRole.cshtml"
__AZWeb_TagHelpers_AZTable.Columns = Model.Columns;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("columns", __AZWeb_TagHelpers_AZTable.Columns, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        </div>\r\n    </div>\r\n");
            }
            );
            __AZWeb_Module_TagHelper_Module_ModuleLayout = CreateTagHelper<global::AZWeb.Module.TagHelper.Module.ModuleLayout>();
            __tagHelperExecutionContext.Add(__AZWeb_Module_TagHelper_Module_ModuleLayout);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("az-script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c58de52fc638c101fc9413805a1c1e342e04be636716", async() => {
                WriteLiteral("\r\n        $(\"#FormCatalog\").AZManager();\r\n    ");
            }
            );
            __AZWeb_Module_TagHelper_Theme_AZScript = CreateTagHelper<global::AZWeb.Module.TagHelper.Theme.AZScript>();
            __tagHelperExecutionContext.Add(__AZWeb_Module_TagHelper_Theme_AZScript);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FormRole> Html { get; private set; }
    }
}
#pragma warning restore 1591
