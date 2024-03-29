#pragma checksum "E:\My\CyberSecurityLogin\Login-Register\CyberSecurity\Views\Login\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "77e5689b775df08a26a93a2b0fc865ca15c77a3f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Login_Login), @"mvc.1.0.view", @"/Views/Login/Login.cshtml")]
namespace AspNetCore
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
#line 1 "E:\My\CyberSecurityLogin\Login-Register\CyberSecurity\Views\_ViewImports.cshtml"
using CyberSecurity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\My\CyberSecurityLogin\Login-Register\CyberSecurity\Views\_ViewImports.cshtml"
using CyberSecurity.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "E:\My\CyberSecurityLogin\Login-Register\CyberSecurity\Views\Login\Login.cshtml"
using CyberSecurity.SharedCommon.Common;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\My\CyberSecurityLogin\Login-Register\CyberSecurity\Views\Login\Login.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"77e5689b775df08a26a93a2b0fc865ca15c77a3f", @"/Views/Login/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff6ed5ce7fb1817c9a4c3b8a3fa1c09425f88714", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Login_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CyberSecurity.Models.LoginModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/image/default/support.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Login image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("700"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/image/logo/logo.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "E:\My\CyberSecurityLogin\Login-Register\CyberSecurity\Views\Login\Login.cshtml"
  
    ViewData["Title"] = "Login";
    Layout = "~/Views/Shared/_LoginMasterLayout.cshtml";
    var code = "";
    var msg = "";
    if (ViewData.ContainsKey("dbresponse"))
    {
        if (ViewData["dbresponse"] != null)
        {
            var str = (string)ViewData["dbresponse"];
            var dbresponse = JsonConvert.DeserializeObject<DbResponse>(str);
            if (dbresponse != null)
            {
                code = dbresponse.ErrorCode.ToString();
                msg = dbresponse.Message;
            }
        }
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style>
    .authentication-inner .authentication-bg {
        background-color: #fff;
    }
</style>
<div class=""authentication-inner row m-0"">
    <!-- /Left Text -->
    <div class=""d-none d-lg-flex col-lg-7 col-xl-8 align-items-center p-5"">
        <div class=""w-100 d-flex justify-content-center"">
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "77e5689b775df08a26a93a2b0fc865ca15c77a3f6702", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
        </div>
    </div>
    <!-- /Left Text -->
    <!-- Login -->
    <div class=""d-flex col-12 col-lg-5 col-xl-4 align-items-center authentication-bg p-sm-5 p-4"">
        <div class=""w-px-400 mx-auto"">
            <!-- Logo -->
            <div class=""app-brand justify-content-center"">
                <p class=""app-brand-link flex-column"">
                    <span class=""app-brand-logo demo"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "77e5689b775df08a26a93a2b0fc865ca15c77a3f8425", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </span>\r\n                    <span class=\"app-brand-text demo text-body fw-bolder\">Login</span>\r\n                </p>\r\n            </div>\r\n            <!-- /Logo -->\r\n");
#nullable restore
#line 49 "E:\My\CyberSecurityLogin\Login-Register\CyberSecurity\Views\Login\Login.cshtml"
             using (Html.BeginForm("Login", "Login", FormMethod.Post, new { @id = "Login" }))
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 51 "E:\My\CyberSecurityLogin\Login-Register\CyberSecurity\Views\Login\Login.cshtml"
           Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"mb-3\">\r\n                    ");
#nullable restore
#line 53 "E:\My\CyberSecurityLogin\Login-Register\CyberSecurity\Views\Login\Login.cshtml"
               Write(Html.LabelFor(x=>x.UserName, new{@class="form-label"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 54 "E:\My\CyberSecurityLogin\Login-Register\CyberSecurity\Views\Login\Login.cshtml"
               Write(Html.TextBoxFor(x=>x.UserName,new{@class="form-control", @placeholder="Username", @required="required"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div class=\"mb-3 form-password-toggle\">\r\n                    <div class=\"d-flex justify-content-between\">\r\n                        ");
#nullable restore
#line 58 "E:\My\CyberSecurityLogin\Login-Register\CyberSecurity\Views\Login\Login.cshtml"
                   Write(Html.LabelFor(x=>x.Password, new{@class="form-label"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"input-group input-group-merge\">\r\n                        ");
#nullable restore
#line 61 "E:\My\CyberSecurityLogin\Login-Register\CyberSecurity\Views\Login\Login.cshtml"
                   Write(Html.TextBoxFor(x=>x.Password,new{@type="password", @class="form-control", @placeholder="Password", @required="required"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <span class=\"input-group-text cursor-pointer\"><i class=\"bx bx-hide\"></i></span>\r\n                        ");
#nullable restore
#line 63 "E:\My\CyberSecurityLogin\Login-Register\CyberSecurity\Views\Login\Login.cshtml"
                   Write(Html.ValidationMessageFor(x=>x.Password));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=\"mb-3\">\r\n                    <button class=\"btn btn-primary d-grid w-100\" type=\"submit\" id=\"btnSubmit\">Sign in</button>\r\n                </div>\r\n");
#nullable restore
#line 69 "E:\My\CyberSecurityLogin\Login-Register\CyberSecurity\Views\Login\Login.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <p class=""text-center"">
                <span>New on our platform?</span>
                <a href=""/Login/SignUp"">
                    <span>Create an account</span>
                </a>
            </p>
        </div>
    </div>
    <!-- /Login -->
</div>
");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n        $(document).ready(function () {\r\n            if (\"");
#nullable restore
#line 83 "E:\My\CyberSecurityLogin\Login-Register\CyberSecurity\Views\Login\Login.cshtml"
            Write(code);

#line default
#line hidden
#nullable disable
                WriteLiteral("\" != \"\" && \"");
#nullable restore
#line 83 "E:\My\CyberSecurityLogin\Login-Register\CyberSecurity\Views\Login\Login.cshtml"
                             Write(msg);

#line default
#line hidden
#nullable disable
                WriteLiteral("\" != \"\") {\r\n                if (\"");
#nullable restore
#line 84 "E:\My\CyberSecurityLogin\Login-Register\CyberSecurity\Views\Login\Login.cshtml"
                Write(code);

#line default
#line hidden
#nullable disable
                WriteLiteral("\" == \"1\") {\r\n                    Swal.fire({\r\n                        title: \'");
#nullable restore
#line 86 "E:\My\CyberSecurityLogin\Login-Register\CyberSecurity\Views\Login\Login.cshtml"
                           Write(msg);

#line default
#line hidden
#nullable disable
                WriteLiteral("\',\r\n                        icon: \'error\',\r\n                        confirmButtonText: \'Ok\'\r\n                    });\r\n                }\r\n                else {\r\n                    Swal.fire({\r\n                        title: \'");
#nullable restore
#line 93 "E:\My\CyberSecurityLogin\Login-Register\CyberSecurity\Views\Login\Login.cshtml"
                           Write(msg);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
                        icon: 'success',
                        confirmButtonText: 'Ok'
                    });
                }
            }
            $(""#btnSubmit"").on(""click"", function () {
                if ($(""#Login"").valid()) {
                    $(""#Login"").submit();
                }
            });
        });
    </script>
");
            }
            );
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CyberSecurity.Models.LoginModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
