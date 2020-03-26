#pragma checksum "E:\Projects\AZCore\AZERP\Web\Themes\Admin\LayoutTheme.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "049ffeec28d70b481de73d30ebc48cb7b047f518"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AZ.Web.Themes.Admin.Web_Themes_Admin_LayoutTheme), @"mvc.1.0.view", @"/Web/Themes/Admin/LayoutTheme.cshtml")]
namespace AZ.Web.Themes.Admin
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"049ffeec28d70b481de73d30ebc48cb7b047f518", @"/Web/Themes/Admin/LayoutTheme.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"92d9c9ae5d2575ea1942ba34bcbb1ab5318fdf24", @"/Web/_ViewImports.cshtml")]
    public class Web_Themes_Admin_LayoutTheme : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LayoutTheme>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", "az-layout layout-top-nav", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::AZWeb.TagHelpers.Html.AZScript __AZWeb_TagHelpers_Html_AZScript;
        private global::AZWeb.TagHelpers.Html.AZBody __AZWeb_TagHelpers_Html_AZBody;
        private global::AZWeb.TagHelpers.Navbar.AZNavbar __AZWeb_TagHelpers_Navbar_AZNavbar;
        private global::AZWeb.TagHelpers.Html.AZContent __AZWeb_TagHelpers_Html_AZContent;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("az-html", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "049ffeec28d70b481de73d30ebc48cb7b047f5183568", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("az-head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "049ffeec28d70b481de73d30ebc48cb7b047f5183833", async() => {
                    WriteLiteral("\r\n\r\n        ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("az-script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "049ffeec28d70b481de73d30ebc48cb7b047f5184114", async() => {
                        WriteLiteral("\r\n            $(function() {\r\n               new AZUrl().Init();\r\n            });\r\n        ");
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
                    WriteLiteral("\r\n    ");
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
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("az-body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "049ffeec28d70b481de73d30ebc48cb7b047f5185900", async() => {
                    WriteLiteral(@"
        <!-- Site wrapper -->
        <div class=""wrapper"">
            <nav class=""main-header navbar navbar-expand-md navbar-light navbar-dark"">
                <a href=""/"" class=""navbar-brand"">
                    <span class=""brand-text"" style=""font-weight:700;"">AZ Store</span>
                </a>
                <div class=""navbar-collapse collapse"">
                    ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("az-navabar", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "049ffeec28d70b481de73d30ebc48cb7b047f5186568", async() => {
                    }
                    );
                    __AZWeb_TagHelpers_Navbar_AZNavbar = CreateTagHelper<global::AZWeb.TagHelpers.Navbar.AZNavbar>();
                    __tagHelperExecutionContext.Add(__AZWeb_TagHelpers_Navbar_AZNavbar);
#nullable restore
#line 19 "E:\Projects\AZCore\AZERP\Web\Themes\Admin\LayoutTheme.cshtml"
__AZWeb_TagHelpers_Navbar_AZNavbar.Menus = Model.MenuTop;

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("menus", __AZWeb_TagHelpers_Navbar_AZNavbar.Menus, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral(@"
                </div>

                <!-- Right navbar links -->
                <ul class=""order-1 order-md-3 navbar-nav navbar-no-expand ml-auto"">
                    <!-- Messages Dropdown Menu -->
                    <li class=""nav-item dropdown"">
                        <a class=""nav-link"" data-toggle=""dropdown"" href=""#"">
                            <i class=""fas fa-comments""></i>
                            <span class=""badge badge-danger navbar-badge"">3</span>
                        </a>
                        <div class=""dropdown-menu dropdown-menu-lg dropdown-menu-right"">
                            <a href=""#"" class=""dropdown-item"">
                                <!-- Message Start -->
                                <div class=""media"">
                                    <img src=""../../dist/img/user1-128x128.jpg"" alt=""User Avatar"" class=""img-size-50 mr-3 img-circle"">
                                    <div class=""media-body"">
                                        <h3 cla");
                    WriteLiteral(@"ss=""dropdown-item-title"">
                                            Brad Diesel
                                            <span class=""float-right text-sm text-danger""><i class=""fas fa-star""></i></span>
                                        </h3>
                                        <p class=""text-sm"">Call me whenever you can...</p>
                                        <p class=""text-sm text-muted""><i class=""far fa-clock mr-1""></i> 4 Hours Ago</p>
                                    </div>
                                </div>
                                <!-- Message End -->
                            </a>
                            <div class=""dropdown-divider""></div>
                            <a href=""#"" class=""dropdown-item"">
                                <!-- Message Start -->
                                <div class=""media"">
                                    <img src=""../../dist/img/user8-128x128.jpg"" alt=""User Avatar"" class=""img-size-50 img-circle mr-3"">
       ");
                    WriteLiteral(@"                             <div class=""media-body"">
                                        <h3 class=""dropdown-item-title"">
                                            John Pierce
                                            <span class=""float-right text-sm text-muted""><i class=""fas fa-star""></i></span>
                                        </h3>
                                        <p class=""text-sm"">I got your message bro</p>
                                        <p class=""text-sm text-muted""><i class=""far fa-clock mr-1""></i> 4 Hours Ago</p>
                                    </div>
                                </div>
                                <!-- Message End -->
                            </a>
                            <div class=""dropdown-divider""></div>
                            <a href=""#"" class=""dropdown-item"">
                                <!-- Message Start -->
                                <div class=""media"">
                                    <img src="".");
                    WriteLiteral(@"./../dist/img/user3-128x128.jpg"" alt=""User Avatar"" class=""img-size-50 img-circle mr-3"">
                                    <div class=""media-body"">
                                        <h3 class=""dropdown-item-title"">
                                            Nora Silvester
                                            <span class=""float-right text-sm text-warning""><i class=""fas fa-star""></i></span>
                                        </h3>
                                        <p class=""text-sm"">The subject goes here</p>
                                        <p class=""text-sm text-muted""><i class=""far fa-clock mr-1""></i> 4 Hours Ago</p>
                                    </div>
                                </div>
                                <!-- Message End -->
                            </a>
                            <div class=""dropdown-divider""></div>
                            <a href=""#"" class=""dropdown-item dropdown-footer"">See All Messages</a>
                    ");
                    WriteLiteral(@"    </div>
                    </li>
                    <!-- Notifications Dropdown Menu -->
                    <li class=""nav-item dropdown"">
                        <a class=""nav-link"" data-toggle=""dropdown"" href=""#"">
                            <i class=""far fa-bell""></i>
                            <span class=""badge badge-warning navbar-badge"">15</span>
                        </a>
                        <div class=""dropdown-menu dropdown-menu-lg dropdown-menu-right"">
                            <span class=""dropdown-header"">15 Notifications</span>
                            <div class=""dropdown-divider""></div>
                            <a href=""#"" class=""dropdown-item"">
                                <i class=""fas fa-envelope mr-2""></i> 4 new messages
                                <span class=""float-right text-muted text-sm"">3 mins</span>
                            </a>
                            <div class=""dropdown-divider""></div>
                            <a href=""#"" clas");
                    WriteLiteral(@"s=""dropdown-item"">
                                <i class=""fas fa-users mr-2""></i> 8 friend requests
                                <span class=""float-right text-muted text-sm"">12 hours</span>
                            </a>
                            <div class=""dropdown-divider""></div>
                            <a href=""#"" class=""dropdown-item"">
                                <i class=""fas fa-file mr-2""></i> 3 new reports
                                <span class=""float-right text-muted text-sm"">2 days</span>
                            </a>
                            <div class=""dropdown-divider""></div>
                            <a href=""#"" class=""dropdown-item dropdown-footer"">See All Notifications</a>
                        </div>
                    </li>
                    <li class=""nav-item"">
                        <a class=""nav-link"" data-widget=""control-sidebar"" data-slide=""true"" href=""#""><i class=""fas fa-th-large""></i></a>
                    </li>
                <");
                    WriteLiteral("/ul>\r\n            </nav>\r\n            <!-- Content Wrapper. Contains page content -->\r\n            <div class=\"content-wrapper\" id=\"ContentAZ\">\r\n                ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("az-content", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "049ffeec28d70b481de73d30ebc48cb7b047f51814659", async() => {
                    }
                    );
                    __AZWeb_TagHelpers_Html_AZContent = CreateTagHelper<global::AZWeb.TagHelpers.Html.AZContent>();
                    __tagHelperExecutionContext.Add(__AZWeb_TagHelpers_Html_AZContent);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n            </div>\r\n            <!-- /.content-wrapper -->\r\n            <!-- /.control-sidebar -->\r\n        </div>\r\n        <!-- ./wrapper -->\r\n    ");
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
                WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LayoutTheme> Html { get; private set; }
    }
}
#pragma warning restore 1591
