#pragma checksum "C:\Users\Adnan Raja\Documents\GitHub\Qademli\Qademli\Areas\Admin\Views\Dashboard\GoalPropertyHeading.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5ccf0a67551e61b82540775d24169ab682acfcf4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Dashboard_GoalPropertyHeading), @"mvc.1.0.view", @"/Areas/Admin/Views/Dashboard/GoalPropertyHeading.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ccf0a67551e61b82540775d24169ab682acfcf4", @"/Areas/Admin/Views/Dashboard/GoalPropertyHeading.cshtml")]
    public class Areas_Admin_Views_Dashboard_GoalPropertyHeading : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
#line 2 "C:\Users\Adnan Raja\Documents\GitHub\Qademli\Qademli\Areas\Admin\Views\Dashboard\GoalPropertyHeading.cshtml"
  
    ViewData["Title"] = ViewBag.Goal +" Properties";
    Layout = "~/Views/Shared/_LayoutAdmin.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row mb-3\">\r\n    <div class=\"col-md-10 mt-auto mb-auto\">\r\n        <h3>");
#nullable restore
#line 9 "C:\Users\Adnan Raja\Documents\GitHub\Qademli\Qademli\Areas\Admin\Views\Dashboard\GoalPropertyHeading.cshtml"
       Write(ViewBag.PropName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Headings</h3>\r\n    </div>\r\n    <div class=\"d-flex justify-content-end col-md-2\">\r\n        <button class=\"btn btn-primary\" onclick=\"openModal()\">Add Heading</button>\r\n    </div>\r\n</div>\r\n<input type=\"text\" id=\"goalPropid\"");
            BeginWriteAttribute("value", " value=\"", 436, "\"", 463, 1);
#nullable restore
#line 15 "C:\Users\Adnan Raja\Documents\GitHub\Qademli\Qademli\Areas\Admin\Views\Dashboard\GoalPropertyHeading.cshtml"
WriteAttributeValue("", 444, ViewBag.PropertyId, 444, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" hidden/>
<div class=""data_wrap bg_white"">
    <div class=""table-responsive"">
        <table class=""table data_tbl"">
            <thead>
                <tr>
                    <th scope=""col"" class=""align-middle text-center"">#</th>
                    <th scope=""col"" class=""align-middle text-center"">Heading Name</th>
                    <th scope=""col"" class=""align-middle text-center"">Actions</th>
                </tr>
            </thead>
            <tbody id=""tBody"">
            </tbody>
        </table>
    </div>
</div>

<div class=""modal"" tabindex=""-1"" role=""dialog"" id=""myModal"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
                <h5 class=""modal-title"" id=""modalTitle"">Add Heading</h5>

            </div>
        ");
            WriteLiteral(@"    <div class=""modal-body"" id=""modalBody"">
                <form id=""saveGoalForm"">
                    <div class=""form-group"">
                        <label for=""exampleInputEmail1"">Heading Name</label>
                        <input type=""text"" class=""form-control"" id=""headingName"" name=""headingName"" />
                    </div>
                    <button type=""submit"" class=""btn btn-primary"">Save</button>
                </form>
            </div>
        </div>
    </div>
</div>
<div class=""modal"" tabindex=""-1"" role=""dialog"" id=""myModal2"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
                <h5 class=""modal-title"" id=""modalTitle"">Update Heading</h5>

            </div>
            <div class=""modal-body"" id=""modalBody2");
            WriteLiteral(@""">
                <form id=""editHeadingForm"">
                </form>
            </div>
        </div>
    </div>
</div>
<div class=""modal"" tabindex=""-1"" role=""dialog"" id=""myModal3"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
                <h5 id=""modalTitle3""></h5>

            </div>
            <div class=""modal-body"" id=""modalBody3"">
            </div>
        </div>
    </div>
</div>
");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5ccf0a67551e61b82540775d24169ab682acfcf47052", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 3225, "~/js/GoalPropertyHeading.js?v=", 3225, 30, true);
#nullable restore
#line 87 "C:\Users\Adnan Raja\Documents\GitHub\Qademli\Qademli\Areas\Admin\Views\Dashboard\GoalPropertyHeading.cshtml"
AddHtmlAttributeValue("", 3255, DateTime.Now.Millisecond, 3255, 25, false);

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
