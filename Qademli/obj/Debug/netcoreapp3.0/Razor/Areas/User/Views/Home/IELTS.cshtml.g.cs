#pragma checksum "C:\Users\Faheem Akbar\Desktop\qademli-git\Qademli\Areas\User\Views\Home\IELTS.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c49cbfa7e402392f940de5c698adf0f2cb0ce43b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_User_Views_Home_IELTS), @"mvc.1.0.view", @"/Areas/User/Views/Home/IELTS.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c49cbfa7e402392f940de5c698adf0f2cb0ce43b", @"/Areas/User/Views/Home/IELTS.cshtml")]
    public class Areas_User_Views_Home_IELTS : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/img/ad.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("ad"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-responsive ad_img"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\Faheem Akbar\Desktop\qademli-git\Qademli\Areas\User\Views\Home\IELTS.cshtml"
  
    ViewData["Title"] = "IELTS";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <style>
        .filterStyle {
            font-size: 19px;
            /*        text-decoration: underline !important;*/
            color: #001d57 !important;
            cursor: pointer;
        }
    </style>
<div id=""home_banner"" class=""pos_rel"" data-parallax=""true"" style=""background-image: url('/assets/img/home-banner.jpg');"">
    <div class=""filter""></div>
    <div class=""content-center"">
        <div class=""container"">
            <div class=""motto"">
                <!--
                          <h1 class=""title"">Qademli</h1>
                          <h3 class=""description"">Welcome to Qademli</h3>
                -->

            </div>
        </div>
    </div>
</div>
<section id=""services"" class=""services_section"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-12"">
                <!--University Area-->
                <div class=""uni_section sec_single mb-4"">
                    <div class=""row uni_heading_area mb-4"" id=""he");
            WriteLiteral(@"adingIELTS"">
                        <div class=""col-md-6"">
                            <h3 class=""text-blue fw_600 my-0"">Top IELTS Tests</h3>
                        </div>
                        <div class=""col-md-3"">
                            <input type=""text"" id=""searchIELTS"" class=""form-control"" placeholder=""Search by name"" hidden />
                        </div>
                        <div class=""col-md-3 text-right"">
                            <span id=""IELTSSort"" onclick=""sortByName()"" class=""filterStyle sortable"" style="" margin-right: 20px;display: none;"">sort</span>
                            <a class=""view_all_btn view_more_uni"">
                                <span id=""lIELTSMore"" class=""more"">View All</span>

");
            WriteLiteral(@"                            </a>

                            <span id=""IELTSfilter"" class=""filterStyle"" style=""display: none;"">filter</span>
                        </div>
                    </div>
                    <div class=""row main_row text-center mb-4"" id=""IELTSList"">
                        <div class=""col-4 ""></div>
                        <div class=""col-4 mb-5"">
                            <h4>Loading...</h4>
                        </div>
                        <div class=""col-4""></div>
                    </div>
                    <div class=""view_all_uni d-none row"" id=""viewAllIELTS"">
                        <div class=""col-4 ""></div>
                        <div class=""col-4 mb-5"">
                            <h4>Loading...</h4>
                        </div>
                        <div class=""col-4""></div>
                    </div>
                    <div class=""single_uni_data text-center pos_rel d-none"" id=""detail_item1"">
");
            WriteLiteral("\r\n                    </div>\r\n\r\n                </div>\r\n                <!--Languages Area-->\r\n                <!--Ad Area-->\r\n                <div class=\"row ad_area\">\r\n                    <div class=\"col-md-8 mx-auto\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "c49cbfa7e402392f940de5c698adf0f2cb0ce43b7165", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c49cbfa7e402392f940de5c698adf0f2cb0ce43b8588", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 10872, "~/js/IELTS.js?v=", 10872, 16, true);
#nullable restore
#line 191 "C:\Users\Faheem Akbar\Desktop\qademli-git\Qademli\Areas\User\Views\Home\IELTS.cshtml"
AddHtmlAttributeValue("", 10888, DateTime.Now.Millisecond, 10888, 25, false);

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
                WriteLiteral("\r\n");
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
