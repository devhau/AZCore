#pragma checksum "E:\Projects\AZCore\AZERP\Web\Modules\User\FormUpdateUser.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9f566f29e6da4cc9731b49cd46f5bfe007784537"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AZERP.Web.Modules.User.Web_Modules_User_FormUpdateUser), @"mvc.1.0.view", @"/Web/Modules/User/FormUpdateUser.cshtml")]
namespace AZERP.Web.Modules.User
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9f566f29e6da4cc9731b49cd46f5bfe007784537", @"/Web/Modules/User/FormUpdateUser.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f80fed39116a657d7841041bff1ceb841a7338bb", @"/Web/_ViewImports.cshtml")]
    public class Web_Modules_User_FormUpdateUser : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FormUpdateUser>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("label", "Họ tên", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("label", "Email", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("label", "Số điện thoại", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("label", "Trạng thái", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("label", "Mật khẩu", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::AZWeb.TagHelpers.Input.AZModelInput __AZWeb_TagHelpers_Input_AZModelInput;
        private global::AZERP.Data.Components.StatusSelect __AZERP_Data_Components_StatusSelect;
        private global::AZWeb.TagHelpers.Html.AZScript __AZWeb_TagHelpers_Html_AZScript;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"az-update row\" id=\"FormUpdateUser\" role=\"form\">\r\n    <div class=\"form-group col-md-6\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("az-model-input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9f566f29e6da4cc9731b49cd46f5bfe0077845374692", async() => {
            }
            );
            __AZWeb_TagHelpers_Input_AZModelInput = CreateTagHelper<global::AZWeb.TagHelpers.Input.AZModelInput>();
            __tagHelperExecutionContext.Add(__AZWeb_TagHelpers_Input_AZModelInput);
#nullable restore
#line 4 "E:\Projects\AZCore\AZERP\Web\Modules\User\FormUpdateUser.cshtml"
__AZWeb_TagHelpers_Input_AZModelInput.Model = Model.Data;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __AZWeb_TagHelpers_Input_AZModelInput.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 4 "E:\Projects\AZCore\AZERP\Web\Modules\User\FormUpdateUser.cshtml"
__AZWeb_TagHelpers_Input_AZModelInput.Func = (item)=>((UserModel)item).FullName;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("func", __AZWeb_TagHelpers_Input_AZModelInput.Func, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __AZWeb_TagHelpers_Input_AZModelInput.InputLabel = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n    <div class=\"form-group col-md-6\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("az-model-input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9f566f29e6da4cc9731b49cd46f5bfe0077845376649", async() => {
            }
            );
            __AZWeb_TagHelpers_Input_AZModelInput = CreateTagHelper<global::AZWeb.TagHelpers.Input.AZModelInput>();
            __tagHelperExecutionContext.Add(__AZWeb_TagHelpers_Input_AZModelInput);
#nullable restore
#line 7 "E:\Projects\AZCore\AZERP\Web\Modules\User\FormUpdateUser.cshtml"
__AZWeb_TagHelpers_Input_AZModelInput.Model = Model.Data;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __AZWeb_TagHelpers_Input_AZModelInput.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 7 "E:\Projects\AZCore\AZERP\Web\Modules\User\FormUpdateUser.cshtml"
__AZWeb_TagHelpers_Input_AZModelInput.Func = (item)=>((UserModel)item).Email;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("func", __AZWeb_TagHelpers_Input_AZModelInput.Func, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __AZWeb_TagHelpers_Input_AZModelInput.InputLabel = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n    <div class=\"form-group col-md-6\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("az-model-input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9f566f29e6da4cc9731b49cd46f5bfe0077845378603", async() => {
            }
            );
            __AZWeb_TagHelpers_Input_AZModelInput = CreateTagHelper<global::AZWeb.TagHelpers.Input.AZModelInput>();
            __tagHelperExecutionContext.Add(__AZWeb_TagHelpers_Input_AZModelInput);
#nullable restore
#line 10 "E:\Projects\AZCore\AZERP\Web\Modules\User\FormUpdateUser.cshtml"
__AZWeb_TagHelpers_Input_AZModelInput.Model = Model.Data;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __AZWeb_TagHelpers_Input_AZModelInput.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 10 "E:\Projects\AZCore\AZERP\Web\Modules\User\FormUpdateUser.cshtml"
__AZWeb_TagHelpers_Input_AZModelInput.Func = (item)=>((UserModel)item).PhoneNumber;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("func", __AZWeb_TagHelpers_Input_AZModelInput.Func, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __AZWeb_TagHelpers_Input_AZModelInput.InputLabel = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div><div class=\"col-md-6\">\r\n    <div class=\"form-group\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("az-status-select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9f566f29e6da4cc9731b49cd46f5bfe00778453710580", async() => {
            }
            );
            __AZERP_Data_Components_StatusSelect = CreateTagHelper<global::AZERP.Data.Components.StatusSelect>();
            __tagHelperExecutionContext.Add(__AZERP_Data_Components_StatusSelect);
#nullable restore
#line 13 "E:\Projects\AZCore\AZERP\Web\Modules\User\FormUpdateUser.cshtml"
__AZERP_Data_Components_StatusSelect.Model = Model.Data;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __AZERP_Data_Components_StatusSelect.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 13 "E:\Projects\AZCore\AZERP\Web\Modules\User\FormUpdateUser.cshtml"
__AZERP_Data_Components_StatusSelect.Func = (item)=>((UserModel)item).Status;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("func", __AZERP_Data_Components_StatusSelect.Func, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __AZERP_Data_Components_StatusSelect.InputLabel = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>\r\n    <div class=\"form-group col-md-6\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("az-model-input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9f566f29e6da4cc9731b49cd46f5bfe00778453712542", async() => {
            }
            );
            __AZWeb_TagHelpers_Input_AZModelInput = CreateTagHelper<global::AZWeb.TagHelpers.Input.AZModelInput>();
            __tagHelperExecutionContext.Add(__AZWeb_TagHelpers_Input_AZModelInput);
#nullable restore
#line 17 "E:\Projects\AZCore\AZERP\Web\Modules\User\FormUpdateUser.cshtml"
__AZWeb_TagHelpers_Input_AZModelInput.Model = Model.Data;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __AZWeb_TagHelpers_Input_AZModelInput.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 17 "E:\Projects\AZCore\AZERP\Web\Modules\User\FormUpdateUser.cshtml"
__AZWeb_TagHelpers_Input_AZModelInput.Func = (item)=>((UserModel)item).Password;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("func", __AZWeb_TagHelpers_Input_AZModelInput.Func, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 17 "E:\Projects\AZCore\AZERP\Web\Modules\User\FormUpdateUser.cshtml"
__AZWeb_TagHelpers_Input_AZModelInput.InputType = global::AZWeb.TagHelpers.Input.AZInputType.password;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("type", __AZWeb_TagHelpers_Input_AZModelInput.InputType, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __AZWeb_TagHelpers_Input_AZModelInput.InputLabel = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("az-script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9f566f29e6da4cc9731b49cd46f5bfe00778453714915", async() => {
                WriteLiteral("\r\n\r\n");
            }
            );
            __AZWeb_TagHelpers_Html_AZScript = CreateTagHelper<global::AZWeb.TagHelpers.Html.AZScript>();
            __tagHelperExecutionContext.Add(__AZWeb_TagHelpers_Html_AZScript);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FormUpdateUser> Html { get; private set; }
    }
}
#pragma warning restore 1591
