#pragma checksum "E:\Projects\AZCore\AZERP\Web\Modules\Auth\FormLogin.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fee318357c36f0eb3e8c2457c939a974c4836f1a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AZERP.Web.Modules.Auth.Web_Modules_Auth_FormLogin), @"mvc.1.0.view", @"/Web/Modules/Auth/FormLogin.cshtml")]
namespace AZERP.Web.Modules.Auth
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fee318357c36f0eb3e8c2457c939a974c4836f1a", @"/Web/Modules/Auth/FormLogin.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f80fed39116a657d7841041bff1ceb841a7338bb", @"/Web/_ViewImports.cshtml")]
    public class Web_Modules_Auth_FormLogin : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FormLogin>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("user-login"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", "hold-transition login-page", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::AZWeb.TagHelpers.Html.AZStyle __AZWeb_TagHelpers_Html_AZStyle;
        private global::AZWeb.TagHelpers.Html.AZBody __AZWeb_TagHelpers_Html_AZBody;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("az-html", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fee318357c36f0eb3e8c2457c939a974c4836f1a4660", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("az-head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fee318357c36f0eb3e8c2457c939a974c4836f1a4925", async() => {
                    WriteLiteral("\r\n\r\n       ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("az-style", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fee318357c36f0eb3e8c2457c939a974c4836f1a5205", async() => {
                        WriteLiteral(@"
           //
// Pages: Login & Register
//

.login-logo,
.register-logo {
  font-size: 2.1rem;
  font-weight: 300;
  margin-bottom: .9rem;
  text-align: center;

  a {
    color: $gray-700;
  }
}

.login-page,
.register-page {
  align-items: center;
  background: $gray-200;
  display: flex;
  flex-direction: column;
  height: 100vh;
  justify-content: center;
}

.login-box,
.register-box {
  width: 360px;

  ");
                        WriteLiteral(@"@media (max-width: map-get($grid-breakpoints, sm)) {
    margin-top: 20px;
    width: 90%;
  }
}

.login-card-body,
.register-card-body {
  background: $white;
  border-top: 0;
  color: #666;
  padding: 20px;

  .input-group {
    .form-control {
      border-right: 0;

      &:focus {
        box-shadow: none;

        & ~ .input-group-append .input-group-text {
          border-color: $input-focus-border-color;
        }
      }

      &.is-valid {
        &:focus {
          box-shadow: none;
        }

        & ~ .input-group-append .input-group-text {
          border-color: $success;
        }
      }

      &.is-invalid {
        &:focus {
          box-shadow: none;
        }

        & ~ .input-group-append .input-group-text {
          border-color: $danger;
        }
      }
    }

    .input-group-text {
      background-color: transparent;
      border-bottom-right-radius: $border-radius;
      border-left: 0;
      border-top-right-radius: $bord");
                        WriteLiteral("er-radius;\r\n      color: #777;\r\n      transition: $input-transition;\r\n    }\r\n  }\r\n}\r\n\r\n.login-box-msg,\r\n.register-box-msg {\r\n  margin: 0;\r\n  padding: 0 20px 20px;\r\n  text-align: center;\r\n}\r\n\r\n.social-auth-links {\r\n  margin: 10px 0;\r\n}\r\n\r\n       ");
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("az-body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fee318357c36f0eb3e8c2457c939a974c4836f1a8726", async() => {
                    WriteLiteral("\r\n        <div class=\"login-box\">\r\n            <div class=\"login-logo\">\r\n                <a");
                    BeginWriteAttribute("href", " href=\"", 1946, "\"", 1953, 0);
                    EndWriteAttribute();
                    WriteLiteral("><b>AZ Store</b></a>\r\n            </div>\r\n            <!-- /.login-logo -->\r\n            <div class=\"card\">\r\n                <div class=\"card-body login-card-body\">\r\n                    <h3 class=\"login-box-msg\">Đăng nhập hệ thống</h3>\r\n");
#nullable restore
#line 115 "E:\Projects\AZCore\AZERP\Web\Modules\Auth\FormLogin.cshtml"
                     if (Model.IsAuth)
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 117 "E:\Projects\AZCore\AZERP\Web\Modules\Auth\FormLogin.cshtml"
                   Write(Model.User.FullName);

#line default
#line hidden
#nullable disable
#nullable restore
#line 117 "E:\Projects\AZCore\AZERP\Web\Modules\Auth\FormLogin.cshtml"
                                            
                    }

#line default
#line hidden
#nullable disable
                    WriteLiteral("                    ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fee318357c36f0eb3e8c2457c939a974c4836f1a10199", async() => {
                        WriteLiteral(@"
                        <div class=""input-group mb-3"">
                            <input type=""email"" name=""azemail"" class=""form-control"" placeholder=""Email"" value=""admin@viec1.com"">
                            <div class=""input-group-append"">
                                <div class=""input-group-text"">
                                    <span class=""fas fa-envelope""></span>
                                </div>
                            </div>
                        </div>
                        <div class=""input-group mb-3"">
                            <input type=""password"" name=""azpassword"" class=""form-control"" placeholder=""Password"" value=""01644638697"">
                            <div class=""input-group-append"">
                                <div class=""input-group-text"">
                                    <span class=""fas fa-lock""></span>
                                </div>
                            </div>
                        </div>
                        <div cl");
                        WriteLiteral(@"ass=""row"">
                            <div class=""col-12"">
                                <div class=""icheck-primary"">
                                    <input type=""checkbox"" name=""remember"" id=""remember"">
                                    <label for=""remember"">
                                        Nhớ lần sau đăng nhập
                                    </label>
                                </div>
                            </div>
                            <!-- /.col -->
                            <div class=""col-12 text-center"">
                                <button type=""submit"" class=""btn btn-primary btn-block"">Đăng nhập</button>
                            </div>
                            <!-- /.col -->
                        </div>
                    ");
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral(@"

                    <div class=""social-auth-links text-center mb-3"">
                        <p>- OR -</p>
                        <a href=""/dang-nhap-bang-facebook.az"" class=""btn btn-block btn-primary"">
                            <i class=""fab fa-facebook mr-2""></i> Đăng nhập bằng Facebook
                        </a>
                        <a href=""/dang-nhap-bang-google.az"" class=""btn btn-block btn-danger"">
                            <i class=""fab fa-google-plus mr-2""></i> Đăng nhập bằng Google+
                        </a>
                    </div>
                    <!-- /.social-auth-links -->

                    <p class=""mb-1"">
                        <a href=""/lay-lai-mat-khau.az"">Lấy lại mật khẩu</a>
                    </p>
                    <p class=""mb-0"">
                        <a href=""/dang-ky.az"" class=""text-center"">Đăng ký tài khoản mới</a>
                    </p>
                </div>
                <!-- /.login-card-body -->
            </div>
        </");
                    WriteLiteral("div>\r\n        <!-- /.login-box -->\r\n    ");
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
            __AZWeb_TagHelpers_Html_AZHtml.ClassHtml = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FormLogin> Html { get; private set; }
    }
}
#pragma warning restore 1591
