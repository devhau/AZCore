#pragma checksum "E:\Projects\AZCore\AZERP\Web\Modules\Worker\FormCheckinCheckout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f5e303fa815b9b41b7c39ec9c047ddefa877427c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AZERP.Web.Modules.Worker.Web_Modules_Worker_FormCheckinCheckout), @"mvc.1.0.view", @"/Web/Modules/Worker/FormCheckinCheckout.cshtml")]
namespace AZERP.Web.Modules.Worker
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f5e303fa815b9b41b7c39ec9c047ddefa877427c", @"/Web/Modules/Worker/FormCheckinCheckout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f80fed39116a657d7841041bff1ceb841a7338bb", @"/Web/_ViewImports.cshtml")]
    public class Web_Modules_Worker_FormCheckinCheckout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FormCheckinCheckout>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", "form-control form-control-sm  az-input-change-search", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("label", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("attr", "data-not-search=\'WorkerId\'", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("null-text", "Chọn năm", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("null-text", "Chọn tháng", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("null-text", "Chọn công ty", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("null-text", "Chọn công nhân", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("az-search-form row"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::AZWeb.TagHelpers.Module.ModuleLayout __AZWeb_TagHelpers_Module_ModuleLayout;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::AZWeb.TagHelpers.Input.AZHiddenModel __AZWeb_TagHelpers_Input_AZHiddenModel;
        private global::AZERP.Data.Components.YearSelect __AZERP_Data_Components_YearSelect;
        private global::AZERP.Data.Components.MonthSelect __AZERP_Data_Components_MonthSelect;
        private global::AZERP.Data.Components.CompanyWorkerSelect __AZERP_Data_Components_CompanyWorkerSelect;
        private global::AZWeb.TagHelpers.Input.AZSelectModel __AZWeb_TagHelpers_Input_AZSelectModel;
        private global::AZERP.Data.Components.Tables.AZTableCheckinCheckout __AZERP_Data_Components_Tables_AZTableCheckinCheckout;
        private global::AZWeb.TagHelpers.Module.AZPagination __AZWeb_TagHelpers_Module_AZPagination;
        private global::AZWeb.TagHelpers.Html.AZStyle __AZWeb_TagHelpers_Html_AZStyle;
        private global::AZWeb.TagHelpers.Html.AZScript __AZWeb_TagHelpers_Html_AZScript;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("az-module-layout", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f5e303fa815b9b41b7c39ec9c047ddefa877427c6634", async() => {
                WriteLiteral(@"
    <div class=""az-manager"" id=""FormCheckinCheckOut"" data-form-size=""az-modal-xl"">
        <div class=""az-toolbar"">
            <div class=""row"">
                <div class=""col-md-3 form-group"">
                    <button type=""button"" class=""btn btn-info   az-btn az-btn-export""><i class=""fas fa-file-export""></i> Xuất Excel (F2)</button>
                    <button type=""button"" class=""btn btn-secondary  az-btn az-btn-import""><i class=""fas fa-file-import""></i> Nhập Excel (F3)</button>
                </div>
                <div class=""col-md-7"">
                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f5e303fa815b9b41b7c39ec9c047ddefa877427c7511", async() => {
                    WriteLiteral("\r\n                        ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("az-hidden-model", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f5e303fa815b9b41b7c39ec9c047ddefa877427c7801", async() => {
                    }
                    );
                    __AZWeb_TagHelpers_Input_AZHiddenModel = CreateTagHelper<global::AZWeb.TagHelpers.Input.AZHiddenModel>();
                    __tagHelperExecutionContext.Add(__AZWeb_TagHelpers_Input_AZHiddenModel);
#nullable restore
#line 12 "E:\Projects\AZCore\AZERP\Web\Modules\Worker\FormCheckinCheckout.cshtml"
__AZWeb_TagHelpers_Input_AZHiddenModel.Model = Model;

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("model", __AZWeb_TagHelpers_Input_AZHiddenModel.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 12 "E:\Projects\AZCore\AZERP\Web\Modules\Worker\FormCheckinCheckout.cshtml"
__AZWeb_TagHelpers_Input_AZHiddenModel.Func = (item) => ((FormCheckinCheckout)item).PageSize;

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("func", __AZWeb_TagHelpers_Input_AZHiddenModel.Func, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n                        <div class=\"form-group col-md-2\">\r\n                            ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("az-year-select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f5e303fa815b9b41b7c39ec9c047ddefa877427c9745", async() => {
                    }
                    );
                    __AZERP_Data_Components_YearSelect = CreateTagHelper<global::AZERP.Data.Components.YearSelect>();
                    __tagHelperExecutionContext.Add(__AZERP_Data_Components_YearSelect);
#nullable restore
#line 14 "E:\Projects\AZCore\AZERP\Web\Modules\Worker\FormCheckinCheckout.cshtml"
__AZERP_Data_Components_YearSelect.Model = Model;

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("model", __AZERP_Data_Components_YearSelect.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 14 "E:\Projects\AZCore\AZERP\Web\Modules\Worker\FormCheckinCheckout.cshtml"
__AZERP_Data_Components_YearSelect.Func = (item) => ((FormCheckinCheckout)item).Year;

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("func", __AZERP_Data_Components_YearSelect.Func, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    __AZERP_Data_Components_YearSelect.InputClass = (string)__tagHelperAttribute_0.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                    __AZERP_Data_Components_YearSelect.InputLabel = (string)__tagHelperAttribute_1.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 14 "E:\Projects\AZCore\AZERP\Web\Modules\Worker\FormCheckinCheckout.cshtml"
__AZERP_Data_Components_YearSelect.TimeYear = 3;

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("time-year", __AZERP_Data_Components_YearSelect.TimeYear, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    __AZERP_Data_Components_YearSelect.Attr = (string)__tagHelperAttribute_2.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                    __AZERP_Data_Components_YearSelect.NullText = (string)__tagHelperAttribute_3.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n                        </div>\r\n                        <div class=\"form-group col-md-2\">\r\n                            ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("az-month-select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f5e303fa815b9b41b7c39ec9c047ddefa877427c12910", async() => {
                    }
                    );
                    __AZERP_Data_Components_MonthSelect = CreateTagHelper<global::AZERP.Data.Components.MonthSelect>();
                    __tagHelperExecutionContext.Add(__AZERP_Data_Components_MonthSelect);
#nullable restore
#line 17 "E:\Projects\AZCore\AZERP\Web\Modules\Worker\FormCheckinCheckout.cshtml"
__AZERP_Data_Components_MonthSelect.Model = Model;

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("model", __AZERP_Data_Components_MonthSelect.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 17 "E:\Projects\AZCore\AZERP\Web\Modules\Worker\FormCheckinCheckout.cshtml"
__AZERP_Data_Components_MonthSelect.Func = (item) => ((FormCheckinCheckout)item).Month;

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("func", __AZERP_Data_Components_MonthSelect.Func, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    __AZERP_Data_Components_MonthSelect.InputClass = (string)__tagHelperAttribute_0.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                    __AZERP_Data_Components_MonthSelect.InputLabel = (string)__tagHelperAttribute_1.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                    __AZERP_Data_Components_MonthSelect.Attr = (string)__tagHelperAttribute_2.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                    __AZERP_Data_Components_MonthSelect.NullText = (string)__tagHelperAttribute_4.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n                        </div>\r\n                        <div class=\"form-group col-md-2\">\r\n                            ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("az-company-worker-select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f5e303fa815b9b41b7c39ec9c047ddefa877427c15673", async() => {
                    }
                    );
                    __AZERP_Data_Components_CompanyWorkerSelect = CreateTagHelper<global::AZERP.Data.Components.CompanyWorkerSelect>();
                    __tagHelperExecutionContext.Add(__AZERP_Data_Components_CompanyWorkerSelect);
#nullable restore
#line 20 "E:\Projects\AZCore\AZERP\Web\Modules\Worker\FormCheckinCheckout.cshtml"
__AZERP_Data_Components_CompanyWorkerSelect.Model = Model;

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("model", __AZERP_Data_Components_CompanyWorkerSelect.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 20 "E:\Projects\AZCore\AZERP\Web\Modules\Worker\FormCheckinCheckout.cshtml"
__AZERP_Data_Components_CompanyWorkerSelect.Func = (item) => ((FormCheckinCheckout)item).CompanyId;

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("func", __AZERP_Data_Components_CompanyWorkerSelect.Func, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    __AZERP_Data_Components_CompanyWorkerSelect.InputClass = (string)__tagHelperAttribute_0.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                    __AZERP_Data_Components_CompanyWorkerSelect.InputLabel = (string)__tagHelperAttribute_1.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                    __AZERP_Data_Components_CompanyWorkerSelect.Attr = (string)__tagHelperAttribute_2.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                    __AZERP_Data_Components_CompanyWorkerSelect.NullText = (string)__tagHelperAttribute_5.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n                        </div>\r\n                        <div class=\"form-group col-md-2\">\r\n                            ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("az-select-model", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f5e303fa815b9b41b7c39ec9c047ddefa877427c18537", async() => {
                    }
                    );
                    __AZWeb_TagHelpers_Input_AZSelectModel = CreateTagHelper<global::AZWeb.TagHelpers.Input.AZSelectModel>();
                    __tagHelperExecutionContext.Add(__AZWeb_TagHelpers_Input_AZSelectModel);
#nullable restore
#line 23 "E:\Projects\AZCore\AZERP\Web\Modules\Worker\FormCheckinCheckout.cshtml"
__AZWeb_TagHelpers_Input_AZSelectModel.Model = Model;

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("model", __AZWeb_TagHelpers_Input_AZSelectModel.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 23 "E:\Projects\AZCore\AZERP\Web\Modules\Worker\FormCheckinCheckout.cshtml"
__AZWeb_TagHelpers_Input_AZSelectModel.Func = (item) => ((FormCheckinCheckout)item).WorkerId;

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("func", __AZWeb_TagHelpers_Input_AZSelectModel.Func, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 23 "E:\Projects\AZCore\AZERP\Web\Modules\Worker\FormCheckinCheckout.cshtml"
__AZWeb_TagHelpers_Input_AZSelectModel.ListObject = Model.Workers;

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("list-object", __AZWeb_TagHelpers_Input_AZSelectModel.ListObject, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    __AZWeb_TagHelpers_Input_AZSelectModel.InputClass = (string)__tagHelperAttribute_0.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                    __AZWeb_TagHelpers_Input_AZSelectModel.InputLabel = (string)__tagHelperAttribute_1.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                    __AZWeb_TagHelpers_Input_AZSelectModel.NullText = (string)__tagHelperAttribute_6.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n                        </div>\r\n                    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <h3 style=\"padding:5px;\">Chấm công từ ngày ");
#nullable restore
#line 29 "E:\Projects\AZCore\AZERP\Web\Modules\Worker\FormCheckinCheckout.cshtml"
                                              Write(Model.StartDate.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
                WriteLiteral(" đến ");
#nullable restore
#line 29 "E:\Projects\AZCore\AZERP\Web\Modules\Worker\FormCheckinCheckout.cshtml"
                                                                                          Write(Model.EndDate.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</h3>\r\n        <div class=\"az-data-table\">\r\n            <div class=\"az-div-freeze\">\r\n               ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("az-table-checkin-checkout", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f5e303fa815b9b41b7c39ec9c047ddefa877427c23460", async() => {
                }
                );
                __AZERP_Data_Components_Tables_AZTableCheckinCheckout = CreateTagHelper<global::AZERP.Data.Components.Tables.AZTableCheckinCheckout>();
                __tagHelperExecutionContext.Add(__AZERP_Data_Components_Tables_AZTableCheckinCheckout);
#nullable restore
#line 32 "E:\Projects\AZCore\AZERP\Web\Modules\Worker\FormCheckinCheckout.cshtml"
__AZERP_Data_Components_Tables_AZTableCheckinCheckout.Data = Model.AZData;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("data", __AZERP_Data_Components_Tables_AZTableCheckinCheckout.Data, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div class=\"az-bottom-manager\">\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("az-pagination", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f5e303fa815b9b41b7c39ec9c047ddefa877427c24988", async() => {
                }
                );
                __AZWeb_TagHelpers_Module_AZPagination = CreateTagHelper<global::AZWeb.TagHelpers.Module.AZPagination>();
                __tagHelperExecutionContext.Add(__AZWeb_TagHelpers_Module_AZPagination);
#nullable restore
#line 36 "E:\Projects\AZCore\AZERP\Web\Modules\Worker\FormCheckinCheckout.cshtml"
__AZWeb_TagHelpers_Module_AZPagination.Pagination = Model;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("pagination", __AZWeb_TagHelpers_Module_AZPagination.Pagination, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            __AZWeb_TagHelpers_Module_ModuleLayout = CreateTagHelper<global::AZWeb.TagHelpers.Module.ModuleLayout>();
            __tagHelperExecutionContext.Add(__AZWeb_TagHelpers_Module_ModuleLayout);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("az-style", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f5e303fa815b9b41b7c39ec9c047ddefa877427c27026", async() => {
                WriteLiteral(@"
    #FormCheckinCheckOut .az-table-freeze .col-freeze{
    width:200px;
    line-height: 50px;
    text-align: center;
    }

    #FormCheckinCheckOut .az-table-freeze tbody .col-freeze{
    height:78px;
    line-height: 39px;
    }
    #FormCheckinCheckOut .az-table-freeze .cell-freeze{
    width:400px;
    }
    #FormCheckinCheckOut .az-table-freeze .az-color-last-day {
    background-color: orangered;
    }
");
            }
            );
            __AZWeb_TagHelpers_Html_AZStyle = CreateTagHelper<global::AZWeb.TagHelpers.Html.AZStyle>();
            __tagHelperExecutionContext.Add(__AZWeb_TagHelpers_Html_AZStyle);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("az-script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f5e303fa815b9b41b7c39ec9c047ddefa877427c28348", async() => {
                WriteLiteral("\r\n    $(document).ready(function() {\r\n    $(\"#FormCheckinCheckOut\").AZManager();\r\n    $(\".az-div-freeze\").TableFreeze();\r\n    });\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FormCheckinCheckout> Html { get; private set; }
    }
}
#pragma warning restore 1591
