#pragma checksum "C:\Users\ASUS\Desktop\Website-Blog\SakataBlog.Solution\SakataBlog.Admin\Views\Role\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "926d4418244b34e8ed886822406347b4774756eb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Role_Create), @"mvc.1.0.view", @"/Views/Role/Create.cshtml")]
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
#line 1 "C:\Users\ASUS\Desktop\Website-Blog\SakataBlog.Solution\SakataBlog.Admin\Views\_ViewImports.cshtml"
using SakataBlog.Admin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ASUS\Desktop\Website-Blog\SakataBlog.Solution\SakataBlog.Admin\Views\_ViewImports.cshtml"
using SakataBlog.Admin.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"926d4418244b34e8ed886822406347b4774756eb", @"/Views/Role/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b148f19e8b1a693a0194992dcc793199d9b53830", @"/Views/_ViewImports.cshtml")]
    public class Views_Role_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "Post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\ASUS\Desktop\Website-Blog\SakataBlog.Solution\SakataBlog.Admin\Views\Role\Create.cshtml"
  
    ViewData["Title"] = "Create Role";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\Users\ASUS\Desktop\Website-Blog\SakataBlog.Solution\SakataBlog.Admin\Views\Role\Create.cshtml"
  
    var Permission = ViewBag.PermissionSelect as List<SakataBlog.ViewModel.Common.SelectItem>;


#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-lg-8"">
        <div class=""card shadow mb-4"">
            <div class=""card-header py-3"">
                <h6 class=""m-0 font-weight-bold text-primary"">Create Role</h6>
            </div>
            <div class=""card-body"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "926d4418244b34e8ed886822406347b4774756eb5621", async() => {
                WriteLiteral("\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "926d4418244b34e8ed886822406347b4774756eb5899", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#nullable restore
#line 19 "C:\Users\ASUS\Desktop\Website-Blog\SakataBlog.Solution\SakataBlog.Admin\Views\Role\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.ModelOnly;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                    <div class=""form-group"">
                        <label class=""cus-text-label"" for=""name"">Name</label>
                        <input type=""text"" name=""name"" id=""name"" class=""form-control"" />
                    </div>

                    <div class=""form-group"">
                        <label class=""cus-text-label"">Role</label>
");
#nullable restore
#line 27 "C:\Users\ASUS\Desktop\Website-Blog\SakataBlog.Solution\SakataBlog.Admin\Views\Role\Create.cshtml"
                         foreach (var GroupKey in Permission.GroupBy(x => x.Value))
                        {


#line default
#line hidden
#nullable disable
                WriteLiteral(@"                            <div class=""col-lg-9"">
                                <div class=""card shadow mb-4"">
                                    <div class=""card-header py-3"">
                                        <h6 class=""m-0 font-weight-bold text-primary"">");
#nullable restore
#line 33 "C:\Users\ASUS\Desktop\Website-Blog\SakataBlog.Solution\SakataBlog.Admin\Views\Role\Create.cshtml"
                                                                                 Write(GroupKey.Key);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h6>\r\n                                    </div>\r\n                                    <div class=\"card-body\">\r\n");
#nullable restore
#line 36 "C:\Users\ASUS\Desktop\Website-Blog\SakataBlog.Solution\SakataBlog.Admin\Views\Role\Create.cshtml"
                                         foreach (var item in GroupKey)
                                        {


#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <div class=\"col-lg-3 form-check-inline\">\r\n                                                <input class=\"form-check-input\" name=\"permissions\" type=\"checkbox\"");
                BeginWriteAttribute("id", " id=\"", 1833, "\"", 1846, 1);
#nullable restore
#line 40 "C:\Users\ASUS\Desktop\Website-Blog\SakataBlog.Solution\SakataBlog.Admin\Views\Role\Create.cshtml"
WriteAttributeValue("", 1838, item.Id, 1838, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 1847, "\"", 1863, 1);
#nullable restore
#line 40 "C:\Users\ASUS\Desktop\Website-Blog\SakataBlog.Solution\SakataBlog.Admin\Views\Role\Create.cshtml"
WriteAttributeValue("", 1855, item.Id, 1855, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                                <label class=\"form-check-label\"");
                BeginWriteAttribute("for", " for=\"", 1946, "\"", 1960, 1);
#nullable restore
#line 41 "C:\Users\ASUS\Desktop\Website-Blog\SakataBlog.Solution\SakataBlog.Admin\Views\Role\Create.cshtml"
WriteAttributeValue("", 1952, item.Id, 1952, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 41 "C:\Users\ASUS\Desktop\Website-Blog\SakataBlog.Solution\SakataBlog.Admin\Views\Role\Create.cshtml"
                                                                                          Write(item.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                                            </div>\r\n");
#nullable restore
#line 43 "C:\Users\ASUS\Desktop\Website-Blog\SakataBlog.Solution\SakataBlog.Admin\Views\Role\Create.cshtml"
                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    </div>\r\n                                </div>\r\n                            </div>\r\n");
#nullable restore
#line 47 "C:\Users\ASUS\Desktop\Website-Blog\SakataBlog.Solution\SakataBlog.Admin\Views\Role\Create.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    </div>\r\n\r\n                    <div class=\"form-group\">\r\n                        <input type=\"submit\" value=\"Create\" class=\"btn btn-primary\" />\r\n                    </div>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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