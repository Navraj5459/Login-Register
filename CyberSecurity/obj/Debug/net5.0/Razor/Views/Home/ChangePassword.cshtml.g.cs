#pragma checksum "D:\Sandeep\CyberSecurity\CyberSecurity\Views\Home\ChangePassword.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "94d9c4fb85c4252977b09d48d1e5446e83fdef23"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ChangePassword), @"mvc.1.0.view", @"/Views/Home/ChangePassword.cshtml")]
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
#line 1 "D:\Sandeep\CyberSecurity\CyberSecurity\Views\_ViewImports.cshtml"
using CyberSecurity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Sandeep\CyberSecurity\CyberSecurity\Views\_ViewImports.cshtml"
using CyberSecurity.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Sandeep\CyberSecurity\CyberSecurity\Views\Home\ChangePassword.cshtml"
using CyberSecurity.SharedCommon.Common;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Sandeep\CyberSecurity\CyberSecurity\Views\Home\ChangePassword.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Sandeep\CyberSecurity\CyberSecurity\Views\Home\ChangePassword.cshtml"
using CyberSecurity.Library;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"94d9c4fb85c4252977b09d48d1e5446e83fdef23", @"/Views/Home/ChangePassword.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff6ed5ce7fb1817c9a4c3b8a3fa1c09425f88714", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ChangePassword : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CyberSecurity.Models.UserDetailModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/ChangePassword.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 5 "D:\Sandeep\CyberSecurity\CyberSecurity\Views\Home\ChangePassword.cshtml"
  
    ViewData["Title"] = "ChangePassword";
    Layout = "~/Views/Shared/_Layout.cshtml";
    var code = "";
    var msg = "";
    var dbresponse = StaticData.GetSessionMessage();
    if (dbresponse != null)
    {
        code = dbresponse.ErrorCode.ToString();
        msg = dbresponse.Message;
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""container"">
    <div class=""row justify-content-center"">
        <div class=""col-md-6 col-lg-5"">
            <div class=""login-wrap p-md-5"">
                <div class=""icon d-flex align-items-center justify-content-center"">
                    <span class=""fa fa-user-o""></span>
                </div>
");
#nullable restore
#line 24 "D:\Sandeep\CyberSecurity\CyberSecurity\Views\Home\ChangePassword.cshtml"
                 using (Html.BeginForm("ChangePassword", "Home", FormMethod.Post, new { @id = "ChangePassword" }))
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "D:\Sandeep\CyberSecurity\CyberSecurity\Views\Home\ChangePassword.cshtml"
               Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"form-group\">\r\n                        ");
#nullable restore
#line 28 "D:\Sandeep\CyberSecurity\CyberSecurity\Views\Home\ChangePassword.cshtml"
                   Write(Html.LabelFor(x => x.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 29 "D:\Sandeep\CyberSecurity\CyberSecurity\Views\Home\ChangePassword.cshtml"
                   Write(Html.TextBoxFor(x => x.UserName, new { @class = "form-control rounded-left", @placeholder = "Username", @disabled = "disabled", @required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 30 "D:\Sandeep\CyberSecurity\CyberSecurity\Views\Home\ChangePassword.cshtml"
                   Write(Html.ValidationMessageFor(x => x.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"form-group\">\r\n                        ");
#nullable restore
#line 33 "D:\Sandeep\CyberSecurity\CyberSecurity\Views\Home\ChangePassword.cshtml"
                   Write(Html.LabelFor(x => x.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 34 "D:\Sandeep\CyberSecurity\CyberSecurity\Views\Home\ChangePassword.cshtml"
                   Write(Html.TextBoxFor(x => x.FullName, new { @class = "form-control rounded-left", @placeholder = "Full Name", @disabled = "disabled", @required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 35 "D:\Sandeep\CyberSecurity\CyberSecurity\Views\Home\ChangePassword.cshtml"
                   Write(Html.ValidationMessageFor(x => x.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"form-group\">\r\n                        ");
#nullable restore
#line 38 "D:\Sandeep\CyberSecurity\CyberSecurity\Views\Home\ChangePassword.cshtml"
                   Write(Html.LabelFor(x => x.OldPassword));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 39 "D:\Sandeep\CyberSecurity\CyberSecurity\Views\Home\ChangePassword.cshtml"
                   Write(Html.TextBoxFor(x => x.OldPassword, new { @type = "password", @class = "form-control rounded-left", @placeholder = "Old Password", @required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 40 "D:\Sandeep\CyberSecurity\CyberSecurity\Views\Home\ChangePassword.cshtml"
                   Write(Html.ValidationMessageFor(x => x.OldPassword));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"form-group\">\r\n                        ");
#nullable restore
#line 43 "D:\Sandeep\CyberSecurity\CyberSecurity\Views\Home\ChangePassword.cshtml"
                   Write(Html.LabelFor(x => x.Password));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 44 "D:\Sandeep\CyberSecurity\CyberSecurity\Views\Home\ChangePassword.cshtml"
                   Write(Html.TextBoxFor(x => x.Password, new { @type = "password", @class = "form-control rounded-left", @placeholder = "Password", @required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 45 "D:\Sandeep\CyberSecurity\CyberSecurity\Views\Home\ChangePassword.cshtml"
                   Write(Html.ValidationMessageFor(x => x.Password));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"form-group\">\r\n                        ");
#nullable restore
#line 48 "D:\Sandeep\CyberSecurity\CyberSecurity\Views\Home\ChangePassword.cshtml"
                   Write(Html.LabelFor(x => x.ConfirmPassword));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 49 "D:\Sandeep\CyberSecurity\CyberSecurity\Views\Home\ChangePassword.cshtml"
                   Write(Html.TextBoxFor(x => x.ConfirmPassword, new { @type = "password", @class = "form-control rounded-left", @placeholder = "Confirm Password", @required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 50 "D:\Sandeep\CyberSecurity\CyberSecurity\Views\Home\ChangePassword.cshtml"
                   Write(Html.ValidationMessageFor(x => x.ConfirmPassword));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"form-group row col-md-12\">\r\n                        <button type=\"submit\" class=\"btn btn-primary col-md-6\" id=\"btnSubmit\">Submit</button>\r\n                    </div>\r\n");
#nullable restore
#line 55 "D:\Sandeep\CyberSecurity\CyberSecurity\Views\Home\ChangePassword.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "94d9c4fb85c4252977b09d48d1e5446e83fdef2311122", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <script>\r\n    $(document).ready(function () {\r\n        if (\"");
#nullable restore
#line 64 "D:\Sandeep\CyberSecurity\CyberSecurity\Views\Home\ChangePassword.cshtml"
        Write(code);

#line default
#line hidden
#nullable disable
                WriteLiteral("\" != \"\" && \"");
#nullable restore
#line 64 "D:\Sandeep\CyberSecurity\CyberSecurity\Views\Home\ChangePassword.cshtml"
                         Write(msg);

#line default
#line hidden
#nullable disable
                WriteLiteral("\" != \"\") {\r\n            if (\"");
#nullable restore
#line 65 "D:\Sandeep\CyberSecurity\CyberSecurity\Views\Home\ChangePassword.cshtml"
            Write(code);

#line default
#line hidden
#nullable disable
                WriteLiteral("\" == \"1\") {\r\n                Swal.fire({\r\n                    title: \'");
#nullable restore
#line 67 "D:\Sandeep\CyberSecurity\CyberSecurity\Views\Home\ChangePassword.cshtml"
                       Write(msg);

#line default
#line hidden
#nullable disable
                WriteLiteral("\',\r\n                    icon: \'error\',\r\n                    confirmButtonText: \'Ok\'\r\n                });\r\n            }\r\n            else {\r\n                Swal.fire({\r\n                    title: \'");
#nullable restore
#line 74 "D:\Sandeep\CyberSecurity\CyberSecurity\Views\Home\ChangePassword.cshtml"
                       Write(msg);

#line default
#line hidden
#nullable disable
                WriteLiteral("\',\r\n                    icon: \'success\',\r\n                    confirmButtonText: \'Ok\'\r\n                });\r\n            }\r\n        }\r\n    });\r\n    </script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CyberSecurity.Models.UserDetailModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
