#pragma checksum "E:\Projects\AZCore\AZERP\Web\Modules\Auth\FormRegister.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5e4d6262c39ba7a51f4a110d57d31821974007a6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AZ.Web.Modules.Auth.Web_Modules_Auth_FormRegister), @"mvc.1.0.view", @"/Web/Modules/Auth/FormRegister.cshtml")]
namespace AZ.Web.Modules.Auth
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e4d6262c39ba7a51f4a110d57d31821974007a6", @"/Web/Modules/Auth/FormRegister.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"92d9c9ae5d2575ea1942ba34bcbb1ab5318fdf24", @"/Web/_ViewImports.cshtml")]
    public class Web_Modules_Auth_FormRegister : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FormRegister>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("user-register"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", "hold-transition register-page", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::AZWeb.TagHelpers.AZHtml.AZHtml __AZWeb_TagHelpers_AZHtml_AZHtml;
        private global::AZWeb.TagHelpers.AZHtml.AZHead __AZWeb_TagHelpers_AZHtml_AZHead;
        private global::AZWeb.TagHelpers.AZHtml.AZStyle __AZWeb_TagHelpers_AZHtml_AZStyle;
        private global::AZWeb.TagHelpers.AZHtml.AZBody __AZWeb_TagHelpers_AZHtml_AZBody;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("az-html", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5e4d6262c39ba7a51f4a110d57d31821974007a64677", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("az-head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5e4d6262c39ba7a51f4a110d57d31821974007a64942", async() => {
                    WriteLiteral("\r\n        ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("az-style", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5e4d6262c39ba7a51f4a110d57d31821974007a65219", async() => {
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
            border-color: $dange");
                        WriteLiteral(@"r;
            }
            }
            }

            .input-group-text {
            background-color: transparent;
            border-bottom-right-radius: $border-radius;
            border-left: 0;
            border-top-right-radius: $border-radius;
            color: #777;
            transition: $input-transition;
            }
            }
            }

            .login-box-msg,
            .register-box-msg {
            margin: 0;
            padding: 0 20px 20px;
            text-align: center;
            }

            .social-auth-links {
            margin: 10px 0;
            }

        ");
                    }
                    );
                    __AZWeb_TagHelpers_AZHtml_AZStyle = CreateTagHelper<global::AZWeb.TagHelpers.AZHtml.AZStyle>();
                    __tagHelperExecutionContext.Add(__AZWeb_TagHelpers_AZHtml_AZStyle);
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
                __AZWeb_TagHelpers_AZHtml_AZHead = CreateTagHelper<global::AZWeb.TagHelpers.AZHtml.AZHead>();
                __tagHelperExecutionContext.Add(__AZWeb_TagHelpers_AZHtml_AZHead);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("az-body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5e4d6262c39ba7a51f4a110d57d31821974007a69385", async() => {
                    WriteLiteral("\r\n        <div class=\"register-box\">\r\n            <div class=\"register-logo\">\r\n                <a");
                    BeginWriteAttribute("href", " href=\"", 2625, "\"", 2632, 0);
                    EndWriteAttribute();
                    WriteLiteral("><b>Viec1.com</b></a>\r\n            </div>\r\n\r\n            <div class=\"card\">\r\n                <div class=\"card-body register-card-body\">\r\n                    <p class=\"login-box-msg\">Đăng ký tài khoản</p>\r\n\r\n                    ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5e4d6262c39ba7a51f4a110d57d31821974007a610168", async() => {
                        WriteLiteral(@"
                        <div class=""input-group mb-3"">
                            <input type=""text"" required name=""fullname"" class=""form-control"" placeholder=""Họ tên"">
                            <div class=""input-group-append"">
                                <div class=""input-group-text"">
                                    <span class=""fas fa-user""></span>
                                </div>
                            </div>
                        </div>
                        <div class=""input-group mb-3"">
                            <input type=""email"" required name=""email"" class=""form-control"" placeholder=""Tài khoản email"">
                            <div class=""input-group-append"">
                                <div class=""input-group-text"">
                                    <span class=""fas fa-envelope""></span>
                                </div>
                            </div>
                        </div>
                        <div class=""input-group mb-3"">
 ");
                        WriteLiteral(@"                           <input type=""tel"" required name=""phone"" class=""form-control"" placeholder=""Số điện thoại"">
                            <div class=""input-group-append"">
                                <div class=""input-group-text"">
                                    <span class=""fas fa-phone""></span>
                                </div>
                            </div>
                        </div>
                        <div class=""input-group mb-3"">
                            <input type=""password"" name=""password"" class=""form-control"" placeholder=""Mật khẩu"">
                            <div class=""input-group-append"">
                                <div class=""input-group-text"">
                                    <span class=""fas fa-lock""></span>
                                </div>
                            </div>
                        </div>
                        <div class=""row"">
                            <div class=""col-8"">
                                <d");
                        WriteLiteral(@"iv class=""icheck-primary"">
                                    <input type=""checkbox"" id=""agreeTerms"" name=""terms"" value=""agree"">
                                    <label for=""agreeTerms"">
                                        Tôi đồng ý các <a href=""#"">điều khoản</a>
                                    </label>
                                </div>
                            </div>
                            <!-- /.col -->
                            <div class=""col-12 text-center"">
                                <button type=""submit"" class=""btn btn-primary btn-block"">Đăng ký</button>
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

                    <div class=""social-auth-links text-center"">
                        <p>- OR -</p>
                        <a href=""#"" class=""btn btn-block btn-primary"">
                            <i class=""fab fa-facebook mr-2""></i>
                            Đăng ký bằng facebook
                        </a>
                        <a href=""#"" class=""btn btn-block btn-danger"">
                            <i class=""fab fa-google-plus mr-2""></i>
                            Đăng ký bằng google
                        </a>
                    </div>

                    <a href=""/dang-nhap.az"" class=""text-center"">Tôi có tài khoản rồi.</a>
                </div>
                <!-- /.form-box -->
            </div><!-- /.card -->
        </div>
        <!-- /.register-box -->
    ");
                }
                );
                __AZWeb_TagHelpers_AZHtml_AZBody = CreateTagHelper<global::AZWeb.TagHelpers.AZHtml.AZBody>();
                __tagHelperExecutionContext.Add(__AZWeb_TagHelpers_AZHtml_AZBody);
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
            __AZWeb_TagHelpers_AZHtml_AZHtml = CreateTagHelper<global::AZWeb.TagHelpers.AZHtml.AZHtml>();
            __tagHelperExecutionContext.Add(__AZWeb_TagHelpers_AZHtml_AZHtml);
            __AZWeb_TagHelpers_AZHtml_AZHtml.ClassHtml = (string)__tagHelperAttribute_3.Value;
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FormRegister> Html { get; private set; }
    }
}
#pragma warning restore 1591