#pragma checksum "C:\Users\Faheem Akbar\Desktop\qademli-git\Qademli\Areas\User\Views\Home\Universities.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "275eee25f2b44d756316482c416d53bf08690630"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_User_Views_Home_Universities), @"mvc.1.0.view", @"/Areas/User/Views/Home/Universities.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"275eee25f2b44d756316482c416d53bf08690630", @"/Areas/User/Views/Home/Universities.cshtml")]
    public class Areas_User_Views_Home_Universities : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 2 "C:\Users\Faheem Akbar\Desktop\qademli-git\Qademli\Areas\User\Views\Home\Universities.cshtml"
  
    ViewData["Title"] = "Universities";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <style>
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
                    <div class=""row uni_heading_area mb-4"" id=""head");
            WriteLiteral(@"ingUni"">
                        <div class=""col-md-6"">
                            <h3 class=""text-blue fw_600 my-0"">Top Universities</h3>
                        </div>
                        <div class=""col-md-3"">
                            <input type=""text"" id=""searchUni"" class=""form-control"" placeholder=""Search by name"" hidden />
                        </div>
                        <div class=""col-md-3 text-right"">
                            <span id=""UniversitySort"" onclick=""sortByName()"" class=""filterStyle sortable"" style="" margin-right: 20px;display: none;"">sort</span>
                            <a class=""view_all_btn view_more_uni"">
                                <span id=""UniMore"" class=""more"">View All</span>

");
            WriteLiteral(@"                            </a>

                            <span id=""Universityfilter"" class=""filterStyle"" style=""display: none;"">filter</span>
                        </div>
                    </div>
                    <div class=""row main_row text-center mb-4"" id=""uniList"">
                        <div class=""col-md-3"">
                            <div class=""single_item"">
                                <a class=""text-blue"" id=""view_detial1"">
                                    <img src=""/assets/img/Logo1.png"" alt=""uni-logo"" class=""uni_logo"">
                                    <h4 class=""my-0 text-blue"">Saint Francis University</h4>
                                </a>
                            </div>
                        </div>
                        <div class=""col-md-3"">
                            <div class=""single_item"">
                                <a href=""#"" class=""text-blue"">
                                    <img src=""/assets/img/Logo1.png"" alt=""uni-logo"" class=");
            WriteLiteral(@"""uni_logo"">
                                    <h4 class=""my-0 text-blue"">University of North Alabama</h4>
                                </a>
                            </div>
                        </div>
                        <div class=""col-md-3"">
                            <div class=""single_item"">
                                <a href=""#"" class=""text-blue"">
                                    <img src=""/assets/img/Logo1.png"" alt=""uni-logo"" class=""uni_logo"">
                                    <h4 class=""my-0 text-blue"">Drury University</h4>
                                </a>
                            </div>
                        </div>
                        <div class=""col-md-3"">
                            <div class=""single_item"">
                                <a href=""#"" class=""text-blue"">
                                    <img src=""/assets/img/Logo1.png"" alt=""uni-logo"" class=""uni_logo"">
                                    <h4 class=""my-0 text-blue"">Monmouth Univ");
            WriteLiteral(@"ersity</h4>
                                </a>
                            </div>
                        </div>
                    </div>
                    <div class=""view_all_uni d-none row"" id=""viewAllUni"">
                        <div class=""row mb-4"">
                            <div class=""col-md-6"">
                                <div class=""single_item_details"">
                                    <div class=""row"">
                                        <div class=""col-md-4"">
                                            <a class=""text-blue"">
                                                <img src=""/assets/img/Logo1.png"" alt=""uni-logo"">
                                            </a>
                                        </div>
                                        <div class=""col-md-8"">
                                            <a class=""text-blue"">
                                                <h4 class=""mt-2 mb-3 fw_600 text-blue uni_name"">Saint Francis University</");
            WriteLiteral(@"h4>
                                            </a>
                                            <p class=""major"">Majors: <span class=""major_subject"">Business. IT, Other</span></p>
                                            <p class=""m-0 loction"">Florida, Miami</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class=""col-md-6"">
                                <div class=""single_item_details"">
                                    <div class=""row"">
                                        <div class=""col-md-4"">
                                            <a href=""#"" class=""text-blue"">
                                                <img src=""/assets/img/Logo1.png"" alt=""uni-logo"">
                                            </a>
                                        </div>
                                        <div class=""col-md-8"">
           ");
            WriteLiteral(@"                                 <a href=""#"" class=""text-blue"">
                                                <h4 class=""mt-2 mb-3 fw_600 text-blue uni_name"">University of North Alabama</h4>
                                            </a>
                                            <p class=""major"">Majors: <span class=""major_subject"">Business. IT, Other</span></p>
                                            <p class=""m-0 loction"">Florida, Miami</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class=""row mb-4"">
                            <div class=""col-md-6"">
                                <div class=""single_item_details"">
                                    <div class=""row"">
                                        <div class=""col-md-4"">
                                            <a href=""#"" class=""text-blue"">
 ");
            WriteLiteral(@"                                               <img src=""/assets/img/Logo1.png"" alt=""uni-logo"">
                                            </a>
                                        </div>
                                        <div class=""col-md-8"">
                                            <a href=""#"" class=""text-blue"">
                                                <h4 class=""mt-2 mb-3 fw_600 text-blue uni_name"">Drury University</h4>
                                            </a>
                                            <p class=""major"">Majors: <span class=""major_subject"">Business. IT, Other</span></p>
                                            <p class=""m-0 loction"">Florida, Miami</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class=""col-md-6"">
                                <div class=""single_item_details"">
                 ");
            WriteLiteral(@"                   <div class=""row"">
                                        <div class=""col-md-4"">
                                            <a href=""#"" class=""text-blue"">
                                                <img src=""/assets/img/Logo1.png"" alt=""uni-logo"">
                                            </a>
                                        </div>
                                        <div class=""col-md-8"">
                                            <a href=""#"" class=""text-blue"">
                                                <h4 class=""mt-2 mb-3 fw_600 text-blue uni_name"">Monmouth University</h4>
                                            </a>
                                            <p class=""major"">Majors: <span class=""major_subject"">Business. IT, Other</span></p>
                                            <p class=""m-0 loction"">Florida, Miami</p>
                                        </div>
                                    </div>
                              ");
            WriteLiteral(@"  </div>
                            </div>
                        </div>
                        <div class=""row mb-4"">
                            <div class=""col-md-6"">
                                <div class=""single_item_details"">
                                    <div class=""row"">
                                        <div class=""col-md-4"">
                                            <a href=""#"" class=""text-blue"">
                                                <img src=""/assets/img/Logo1.png"" alt=""uni-logo"">
                                            </a>
                                        </div>
                                        <div class=""col-md-8"">
                                            <a href=""#"" class=""text-blue"">
                                                <h4 class=""mt-2 mb-3 fw_600 text-blue uni_name"">Saint Francis University</h4>
                                            </a>
                                            <p class=""major"">Majors: <s");
            WriteLiteral(@"pan class=""major_subject"">Business. IT, Other</span></p>
                                            <p class=""m-0 loction"">Florida, Miami</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class=""col-md-6"">
                                <div class=""single_item_details"">
                                    <div class=""row"">
                                        <div class=""col-md-4"">
                                            <a href=""#"" class=""text-blue"">
                                                <img src=""/assets/img/Logo1.png"" alt=""uni-logo"">
                                            </a>
                                        </div>
                                        <div class=""col-md-8"">
                                            <a href=""#"" class=""text-blue"">
                                                <h4 class=""mt");
            WriteLiteral(@"-2 mb-3 fw_600 text-blue uni_name"">University of North Alabama</h4>
                                            </a>
                                            <p class=""major"">Majors: <span class=""major_subject"">Business. IT, Other</span></p>
                                            <p class=""m-0 loction"">Florida, Miami</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class=""row mb-4"">
                            <div class=""col-md-6"">
                                <div class=""single_item_details"">
                                    <div class=""row"">
                                        <div class=""col-md-4"">
                                            <a href=""#"" class=""text-blue"">
                                                <img src=""/assets/img/Logo1.png"" alt=""uni-logo"">
                             ");
            WriteLiteral(@"               </a>
                                        </div>
                                        <div class=""col-md-8"">
                                            <a href=""#"" class=""text-blue"">
                                                <h4 class=""mt-2 mb-3 fw_600 text-blue uni_name"">Drury University</h4>
                                            </a>
                                            <p class=""major"">Majors: <span class=""major_subject"">Business. IT, Other</span></p>
                                            <p class=""m-0 loction"">Florida, Miami</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class=""col-md-6"">
                                <div class=""single_item_details"">
                                    <div class=""row"">
                                        <div class=""col-md-4"">
                        ");
            WriteLiteral(@"                    <a href=""#"" class=""text-blue"">
                                                <img src=""/assets/img/Logo1.png"" alt=""uni-logo"">
                                            </a>
                                        </div>
                                        <div class=""col-md-8"">
                                            <a href=""#"" class=""text-blue"">
                                                <h4 class=""mt-2 mb-3 fw_600 text-blue uni_name"">Monmouth University</h4>
                                            </a>
                                            <p class=""major"">Majors: <span class=""major_subject"">Business. IT, Other</span></p>
                                            <p class=""m-0 loction"">Florida, Miami</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    ");
            WriteLiteral("<div class=\"single_uni_data text-center pos_rel d-none\" id=\"detail_item1\">\r\n");
            WriteLiteral("\r\n                    </div>\r\n\r\n                </div>\r\n                <!--Languages Area-->\r\n                <!--Ad Area-->\r\n                <div class=\"row ad_area\">\r\n                    <div class=\"col-md-8 mx-auto\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "275eee25f2b44d756316482c416d53bf0869063019274", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "275eee25f2b44d756316482c416d53bf0869063020698", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 20578, "~/js/University.js?v=", 20578, 21, true);
#nullable restore
#line 364 "C:\Users\Faheem Akbar\Desktop\qademli-git\Qademli\Areas\User\Views\Home\Universities.cshtml"
AddHtmlAttributeValue("", 20599, DateTime.Now.Millisecond, 20599, 25, false);

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
            WriteLiteral("\r\n\r\n");
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
