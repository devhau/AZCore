#pragma checksum "E:\Projects\AZCore\AZERP\Web\Modules\Worker\FormCheckinCheckout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d1b695e8abc0c6e0c8ff173b464e56039ae9227e"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d1b695e8abc0c6e0c8ff173b464e56039ae9227e", @"/Web/Modules/Worker/FormCheckinCheckout.cshtml")]
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
        private global::AZWeb.Module.TagHelper.Module.ModuleLayout __AZWeb_Module_TagHelper_Module_ModuleLayout;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::AZWeb.Module.TagHelper.Input.AZHiddenModel __AZWeb_Module_TagHelper_Input_AZHiddenModel;
        private global::AZERP.Data.Components.YearSelect __AZERP_Data_Components_YearSelect;
        private global::AZERP.Data.Components.MonthSelect __AZERP_Data_Components_MonthSelect;
        private global::AZERP.Data.Components.CompanyWorkerSelect __AZERP_Data_Components_CompanyWorkerSelect;
        private global::AZWeb.Module.TagHelper.Input.AZSelectModel __AZWeb_Module_TagHelper_Input_AZSelectModel;
        private global::AZERP.Data.Components.WorkShiftSelect __AZERP_Data_Components_WorkShiftSelect;
        private global::AZWeb.Module.TagHelper.Input.AZText __AZWeb_Module_TagHelper_Input_AZText;
        private global::AZWeb.Module.TagHelper.Theme.AZStyle __AZWeb_Module_TagHelper_Theme_AZStyle;
        private global::AZWeb.Module.TagHelper.Theme.AZScript __AZWeb_Module_TagHelper_Theme_AZScript;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("az-module-layout", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d1b695e8abc0c6e0c8ff173b464e56039ae9227e6668", async() => {
                WriteLiteral(@"
    <div class=""az-manager"" id=""FormCheckinCheckout"" data-form-size=""az-modal-xl"">
        <div class=""az-toolbar"">
            <div class=""row"">
                <div class=""col-md-3 form-group"">
                    <button type=""button"" class=""btn btn-info   az-btn az-btn-export""><i class=""fas fa-file-export""></i> Xuất Excel (F2)</button>
                    <button type=""button"" class=""btn btn-secondary  az-btn az-btn-import""><i class=""fas fa-file-import""></i> Nhập Excel (F3)</button>
                </div>
                <div class=""col-md-7"">
                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d1b695e8abc0c6e0c8ff173b464e56039ae9227e7545", async() => {
                    WriteLiteral("\r\n                        ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("az-hidden-model", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d1b695e8abc0c6e0c8ff173b464e56039ae9227e7835", async() => {
                    }
                    );
                    __AZWeb_Module_TagHelper_Input_AZHiddenModel = CreateTagHelper<global::AZWeb.Module.TagHelper.Input.AZHiddenModel>();
                    __tagHelperExecutionContext.Add(__AZWeb_Module_TagHelper_Input_AZHiddenModel);
#nullable restore
#line 12 "E:\Projects\AZCore\AZERP\Web\Modules\Worker\FormCheckinCheckout.cshtml"
__AZWeb_Module_TagHelper_Input_AZHiddenModel.Model = Model;

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("model", __AZWeb_Module_TagHelper_Input_AZHiddenModel.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 12 "E:\Projects\AZCore\AZERP\Web\Modules\Worker\FormCheckinCheckout.cshtml"
__AZWeb_Module_TagHelper_Input_AZHiddenModel.Func = (item) => ((FormCheckinCheckout)item).PageSize;

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("func", __AZWeb_Module_TagHelper_Input_AZHiddenModel.Func, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n                        <div class=\"form-group col-md-2\">\r\n                            ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("az-year-select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d1b695e8abc0c6e0c8ff173b464e56039ae9227e9821", async() => {
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
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("az-month-select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d1b695e8abc0c6e0c8ff173b464e56039ae9227e12986", async() => {
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
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("az-company-worker-select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d1b695e8abc0c6e0c8ff173b464e56039ae9227e15749", async() => {
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
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("az-select-model", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d1b695e8abc0c6e0c8ff173b464e56039ae9227e18613", async() => {
                    }
                    );
                    __AZWeb_Module_TagHelper_Input_AZSelectModel = CreateTagHelper<global::AZWeb.Module.TagHelper.Input.AZSelectModel>();
                    __tagHelperExecutionContext.Add(__AZWeb_Module_TagHelper_Input_AZSelectModel);
#nullable restore
#line 23 "E:\Projects\AZCore\AZERP\Web\Modules\Worker\FormCheckinCheckout.cshtml"
__AZWeb_Module_TagHelper_Input_AZSelectModel.Model = Model;

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("model", __AZWeb_Module_TagHelper_Input_AZSelectModel.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 23 "E:\Projects\AZCore\AZERP\Web\Modules\Worker\FormCheckinCheckout.cshtml"
__AZWeb_Module_TagHelper_Input_AZSelectModel.Func = (item) => ((FormCheckinCheckout)item).WorkerId;

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("func", __AZWeb_Module_TagHelper_Input_AZSelectModel.Func, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 23 "E:\Projects\AZCore\AZERP\Web\Modules\Worker\FormCheckinCheckout.cshtml"
__AZWeb_Module_TagHelper_Input_AZSelectModel.ListObject = Model.Workers;

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("list-object", __AZWeb_Module_TagHelper_Input_AZSelectModel.ListObject, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    __AZWeb_Module_TagHelper_Input_AZSelectModel.InputClass = (string)__tagHelperAttribute_0.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                    __AZWeb_Module_TagHelper_Input_AZSelectModel.InputLabel = (string)__tagHelperAttribute_1.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                    __AZWeb_Module_TagHelper_Input_AZSelectModel.NullText = (string)__tagHelperAttribute_6.Value;
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
                WriteLiteral("</h3>\r\n        <div class=\"az-data-table\">\r\n            \r\n            <table class=\"table table-hover table-freeze\">\r\n                <thead>\r\n                    <tr>\r\n                        <th width=\"250px\" class=\"column-freeze text-right\">Ngày</th>\r\n");
#nullable restore
#line 36 "E:\Projects\AZCore\AZERP\Web\Modules\Worker\FormCheckinCheckout.cshtml"
                         for (var day = Model.StartDate; day <= Model.EndDate; day = day.AddDays(1))
                        {
                            var txtday = "az-color-last-day";
                            if (day.DayOfWeek != DayOfWeek.Saturday && day.DayOfWeek != DayOfWeek.Sunday)
                            {
                                txtday = "";
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <th");
                BeginWriteAttribute("class", " class=\"", 3046, "\"", 3085, 3);
                WriteAttributeValue("", 3054, "cell-freeze", 3054, 11, true);
                WriteAttributeValue(" ", 3065, "text-center", 3066, 12, true);
#nullable restore
#line 43 "E:\Projects\AZCore\AZERP\Web\Modules\Worker\FormCheckinCheckout.cshtml"
WriteAttributeValue(" ", 3077, txtday, 3078, 7, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" colspan=\"2\">");
#nullable restore
#line 43 "E:\Projects\AZCore\AZERP\Web\Modules\Worker\FormCheckinCheckout.cshtml"
                                                                               Write(day.ToString("dd"));

#line default
#line hidden
#nullable disable
                WriteLiteral(" \r\n                        \r\n");
#nullable restore
#line 45 "E:\Projects\AZCore\AZERP\Web\Modules\Worker\FormCheckinCheckout.cshtml"
                                 if(day==DateTime.Now.Date){                                     

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <b>Hôm nay</b>\r\n");
#nullable restore
#line 47 "E:\Projects\AZCore\AZERP\Web\Modules\Worker\FormCheckinCheckout.cshtml"
                                }

#line default
#line hidden
#nullable disable
                WriteLiteral("                        </th>\r\n");
#nullable restore
#line 49 "E:\Projects\AZCore\AZERP\Web\Modules\Worker\FormCheckinCheckout.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    </tr>\r\n                    <tr>\r\n                        <th width=\"250px\" class=\"column-freeze\">Họ Tên</th>\r\n");
#nullable restore
#line 53 "E:\Projects\AZCore\AZERP\Web\Modules\Worker\FormCheckinCheckout.cshtml"
                         for (var day = Model.StartDate; day <= Model.EndDate; day = day.AddDays(1))
                        {
                            var txtday = "az-color-last-day";
                            if (day.DayOfWeek != DayOfWeek.Saturday && day.DayOfWeek != DayOfWeek.Sunday)
                            {
                                txtday = "";
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <th");
                BeginWriteAttribute("class", " class=\"", 3955, "\"", 3994, 3);
                WriteAttributeValue("", 3963, "cell-freeze", 3963, 11, true);
                WriteAttributeValue(" ", 3974, "text-center", 3975, 12, true);
#nullable restore
#line 60 "E:\Projects\AZCore\AZERP\Web\Modules\Worker\FormCheckinCheckout.cshtml"
WriteAttributeValue(" ", 3986, txtday, 3987, 7, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Làm ca</th>\r\n                            <th");
                BeginWriteAttribute("class", " class=\"", 4040, "\"", 4079, 3);
                WriteAttributeValue("", 4048, "cell-freeze", 4048, 11, true);
                WriteAttributeValue(" ", 4059, "text-center", 4060, 12, true);
#nullable restore
#line 61 "E:\Projects\AZCore\AZERP\Web\Modules\Worker\FormCheckinCheckout.cshtml"
WriteAttributeValue(" ", 4071, txtday, 4072, 7, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Giờ tăng ca</th>\r\n");
#nullable restore
#line 62 "E:\Projects\AZCore\AZERP\Web\Modules\Worker\FormCheckinCheckout.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    </tr>\r\n                </thead>\r\n                <tbody>\r\n");
#nullable restore
#line 66 "E:\Projects\AZCore\AZERP\Web\Modules\Worker\FormCheckinCheckout.cshtml"
                     if (Model.Workers != null)
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 68 "E:\Projects\AZCore\AZERP\Web\Modules\Worker\FormCheckinCheckout.cshtml"
                         foreach (var worker in Model.Workers)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <tr>\r\n                        <td width=\"250px\" class=\"column-freeze\">");
#nullable restore
#line 71 "E:\Projects\AZCore\AZERP\Web\Modules\Worker\FormCheckinCheckout.cshtml"
                                                           Write(worker.FullName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ( ");
#nullable restore
#line 71 "E:\Projects\AZCore\AZERP\Web\Modules\Worker\FormCheckinCheckout.cshtml"
                                                                              Write(worker.PhoneNumber);

#line default
#line hidden
#nullable disable
                WriteLiteral(" )</td>\r\n");
#nullable restore
#line 72 "E:\Projects\AZCore\AZERP\Web\Modules\Worker\FormCheckinCheckout.cshtml"
                         for (var day = Model.StartDate; day <= Model.EndDate; day = day.AddDays(1))
                        {
                            var txtday = "az-color-last-day";
                            if (day.DayOfWeek != DayOfWeek.Saturday && day.DayOfWeek != DayOfWeek.Sunday)
                            {
                                txtday = "";
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <td");
                BeginWriteAttribute("class", " class=\"", 4942, "\"", 4969, 2);
                WriteAttributeValue("", 4950, "cell-freeze", 4950, 11, true);
#nullable restore
#line 79 "E:\Projects\AZCore\AZERP\Web\Modules\Worker\FormCheckinCheckout.cshtml"
WriteAttributeValue(" ", 4961, txtday, 4962, 7, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("az-work-shift-select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d1b695e8abc0c6e0c8ff173b464e56039ae9227e30550", async() => {
                }
                );
                __AZERP_Data_Components_WorkShiftSelect = CreateTagHelper<global::AZERP.Data.Components.WorkShiftSelect>();
                __tagHelperExecutionContext.Add(__AZERP_Data_Components_WorkShiftSelect);
#nullable restore
#line 80 "E:\Projects\AZCore\AZERP\Web\Modules\Worker\FormCheckinCheckout.cshtml"
__AZERP_Data_Components_WorkShiftSelect.AddJs = false;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("add-js", __AZERP_Data_Components_WorkShiftSelect.AddJs, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                            </td>\r\n                            <td");
                BeginWriteAttribute("class", " class=\"", 5112, "\"", 5139, 2);
                WriteAttributeValue("", 5120, "cell-freeze", 5120, 11, true);
#nullable restore
#line 82 "E:\Projects\AZCore\AZERP\Web\Modules\Worker\FormCheckinCheckout.cshtml"
WriteAttributeValue(" ", 5131, txtday, 5132, 7, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("az-text", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d1b695e8abc0c6e0c8ff173b464e56039ae9227e32450", async() => {
                }
                );
                __AZWeb_Module_TagHelper_Input_AZText = CreateTagHelper<global::AZWeb.Module.TagHelper.Input.AZText>();
                __tagHelperExecutionContext.Add(__AZWeb_Module_TagHelper_Input_AZText);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                            </td>\r\n");
#nullable restore
#line 85 "E:\Projects\AZCore\AZERP\Web\Modules\Worker\FormCheckinCheckout.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    </tr>\r\n");
#nullable restore
#line 87 "E:\Projects\AZCore\AZERP\Web\Modules\Worker\FormCheckinCheckout.cshtml"
                     
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 88 "E:\Projects\AZCore\AZERP\Web\Modules\Worker\FormCheckinCheckout.cshtml"
                         
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n        <div class=\"az-bottom-manager\">\r\n            <h4>Tổng số công nhân : ");
#nullable restore
#line 94 "E:\Projects\AZCore\AZERP\Web\Modules\Worker\FormCheckinCheckout.cshtml"
                                Write(Model.Workers != null?Model.Workers.Count:0);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </h4> \r\n        </div>\r\n    </div>\r\n");
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
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("az-style", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d1b695e8abc0c6e0c8ff173b464e56039ae9227e35221", async() => {
                WriteLiteral(@"
#FormCheckinCheckout .cell-freeze .form-control{
    margin:0px;
                    }
#FormCheckinCheckout .cell-freeze{
                    min-width:120px;
    }
#FormCheckinCheckout tbody .cell-freeze{
                padding:5px;
    }
#FormCheckinCheckout .az-color-last-day {
            background-color: #aaa;
    }
");
            }
            );
            __AZWeb_Module_TagHelper_Theme_AZStyle = CreateTagHelper<global::AZWeb.Module.TagHelper.Theme.AZStyle>();
            __tagHelperExecutionContext.Add(__AZWeb_Module_TagHelper_Theme_AZStyle);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("az-script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d1b695e8abc0c6e0c8ff173b464e56039ae9227e36471", async() => {
                WriteLiteral("\r\n    $(document).ready(function() {\r\n    $(\"#FormCheckinCheckout\").AZManager(function(ma){\r\n        $(\".table-freeze\").TableFreeze();});\r\n    });\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FormCheckinCheckout> Html { get; private set; }
    }
}
#pragma warning restore 1591