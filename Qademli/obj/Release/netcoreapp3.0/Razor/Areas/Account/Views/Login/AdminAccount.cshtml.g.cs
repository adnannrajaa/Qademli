#pragma checksum "C:\Users\Adnan Raja\Documents\GitHub\Qademli\Qademli\Areas\Account\Views\Login\AdminAccount.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f6acd9e8e7ab34f2a30ddf80ea97e092f8934da6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Account_Views_Login_AdminAccount), @"mvc.1.0.view", @"/Areas/Account/Views/Login/AdminAccount.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f6acd9e8e7ab34f2a30ddf80ea97e092f8934da6", @"/Areas/Account/Views/Login/AdminAccount.cshtml")]
    public class Areas_Account_Views_Login_AdminAccount : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery-validation/dist/jquery.validate.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Adnan Raja\Documents\GitHub\Qademli\Qademli\Areas\Account\Views\Login\AdminAccount.cshtml"
  
    ViewData["Title"] = "AdminAccount";
    Layout = "~/Views/Shared/_LayoutAdmin.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <div class=""row mb-3"">
        
    </div>
    <section id=""services"">
        <div class=""row"">
            <div class=""col-lg-3  ml-0 mr-0""></div>
            <div class=""col-lg-6 col-md-8 col-sm-12 ml-0 mr-0"">

                <div class=""data_wrap bg_white mg-t-30"">

                    <div class=""row"">
                        <div class=""col-md-12"">
                            <div class=""form_heading_area text-center"">

                                <h3 class=""fw_600 text-uppercase text-blue text-center mt-0 mb-3"">Update Account</h3>
                            </div>
                            <form class=""register-form ml-4 mr-4"" id=""myForm"">
                                <label id=""userid"" hidden></label>
                                <div class=""form-group"">
                                    <label>First Name</label>
                                    <input type=""text"" name=""firstName"" id=""firstName"" class=""form-control"" placeholder=""First Name"">
              ");
            WriteLiteral(@"                  </div>
                                <div class=""form-group"">
                                    <label>Middle Name</label>
                                    <input type=""text"" name=""middleName"" id=""middleName"" class=""form-control"" placeholder=""Middle Name"">
                                </div>
                                <div class=""form-group"">
                                    <label>Last Name</label>
                                    <input type=""text"" name=""lastName"" id=""lastName"" class=""form-control"" placeholder=""Last Name"">
                                </div>
                                <div class=""form-group"">
                                    <label>Email Address</label>
                                    <input type=""email"" name=""inputEmail"" id=""inputEmail"" class=""form-control"" placeholder=""Email"">
                                </div>
                                <div class=""form-group"">
                                    <label>Update P");
            WriteLiteral(@"assword</label>
                                    <input type=""password"" name=""password"" id=""password"" class=""form-control"" placeholder=""Password"">
                                </div>
                                <div class=""form-group"">
                                    <label>Confirm Password</label>
                                    <input type=""password"" name=""confirmPassword"" id=""confirmpassword"" class=""form-control"" placeholder=""Password"">
                                </div>
                                <div class=""form-group"">
                                    <button class=""btn btn-block btn-primary btn-round btn_submit"" id=""btnRegister"" type=""submit"">Update</button>
                                </div>
                                <div class=""spinner-border text-primary mt-2"" role=""status"" id=""loginSpinner"" style=""display:none;"">
                                    <span class=""sr-only"">Loading...</span>
                                </div>
                    ");
            WriteLiteral("        </form>\r\n\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n\r\n        </div>\r\n            \r\n    </section>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f6acd9e8e7ab34f2a30ddf80ea97e092f8934da66932", async() => {
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
                WriteLiteral("\r\n\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f6acd9e8e7ab34f2a30ddf80ea97e092f8934da68035", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 3460, "~/js/UserAccountUpdate.js?v=", 3460, 28, true);
#nullable restore
#line 68 "C:\Users\Adnan Raja\Documents\GitHub\Qademli\Qademli\Areas\Account\Views\Login\AdminAccount.cshtml"
AddHtmlAttributeValue("", 3488, DateTime.Now.Millisecond, 3488, 25, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
