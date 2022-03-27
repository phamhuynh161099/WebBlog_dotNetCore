#pragma checksum "C:\Users\ASUS\Desktop\Website-Blog\SakataBlog.Solution\SakataBlog.Admin\Views\Role\Update.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "106355f4dfc7aa7a4b4ce8c0c8cff65e63c12eda"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Role_Update), @"mvc.1.0.view", @"/Views/Role/Update.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"106355f4dfc7aa7a4b4ce8c0c8cff65e63c12eda", @"/Views/Role/Update.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b148f19e8b1a693a0194992dcc793199d9b53830", @"/Views/_ViewImports.cshtml")]
    public class Views_Role_Update : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SakataBlog.ViewModel.System.RoleFolder.RoleVm>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\ASUS\Desktop\Website-Blog\SakataBlog.Solution\SakataBlog.Admin\Views\Role\Update.cshtml"
  
    ViewData["Title"] = "AssignPermission";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\ASUS\Desktop\Website-Blog\SakataBlog.Solution\SakataBlog.Admin\Views\Role\Update.cshtml"
  
    var Permission = ViewBag.PermissionSelect as List<SakataBlog.ViewModel.Common.SelectItem>;


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>RoleAssignPermission</h1>\r\n<div class=\"row\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "106355f4dfc7aa7a4b4ce8c0c8cff65e63c12eda4262", async() => {
                WriteLiteral("\r\n        <div class=\"form-group\">\r\n            <label class=\"cus-text-label\" for=\"name\">Name</label>\r\n            <input type=\"text\" name=\"name\" id=\"name\"");
                BeginWriteAttribute("value", " value=\"", 523, "\"", 542, 1);
#nullable restore
#line 17 "C:\Users\ASUS\Desktop\Website-Blog\SakataBlog.Solution\SakataBlog.Admin\Views\Role\Update.cshtml"
WriteAttributeValue("", 531, Model.Name, 531, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"form-control\" />\r\n        </div>\r\n");
#nullable restore
#line 19 "C:\Users\ASUS\Desktop\Website-Blog\SakataBlog.Solution\SakataBlog.Admin\Views\Role\Update.cshtml"
         foreach (var GroupKey in Permission.GroupBy(x => x.Value))
        {


#line default
#line hidden
#nullable disable
                WriteLiteral("            <div class=\"col-lg-9\">\r\n                <div class=\"card shadow mb-4\">\r\n                    <div class=\"card-header py-3\">\r\n                        <h6 class=\"m-0 font-weight-bold text-primary\">");
#nullable restore
#line 25 "C:\Users\ASUS\Desktop\Website-Blog\SakataBlog.Solution\SakataBlog.Admin\Views\Role\Update.cshtml"
                                                                 Write(GroupKey.Key);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h6>\r\n                    </div>\r\n                    <div class=\"card-body\">\r\n");
#nullable restore
#line 28 "C:\Users\ASUS\Desktop\Website-Blog\SakataBlog.Solution\SakataBlog.Admin\Views\Role\Update.cshtml"
                         foreach (var item in GroupKey)
                        {


#line default
#line hidden
#nullable disable
                WriteLiteral("                            <div class=\"col-lg-3 form-check-inline\">\r\n");
#nullable restore
#line 32 "C:\Users\ASUS\Desktop\Website-Blog\SakataBlog.Solution\SakataBlog.Admin\Views\Role\Update.cshtml"
                                 if (item.Selected == true)
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <input class=\"form-check-input\" name=\"permissions\" type=\"checkbox\" checked");
                BeginWriteAttribute("id", " id=\"", 1328, "\"", 1341, 1);
#nullable restore
#line 34 "C:\Users\ASUS\Desktop\Website-Blog\SakataBlog.Solution\SakataBlog.Admin\Views\Role\Update.cshtml"
WriteAttributeValue("", 1333, item.Id, 1333, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 1342, "\"", 1358, 1);
#nullable restore
#line 34 "C:\Users\ASUS\Desktop\Website-Blog\SakataBlog.Solution\SakataBlog.Admin\Views\Role\Update.cshtml"
WriteAttributeValue("", 1350, item.Id, 1350, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n");
#nullable restore
#line 35 "C:\Users\ASUS\Desktop\Website-Blog\SakataBlog.Solution\SakataBlog.Admin\Views\Role\Update.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <input class=\"form-check-input\" name=\"permissions\" type=\"checkbox\"");
                BeginWriteAttribute("id", " id=\"", 1572, "\"", 1585, 1);
#nullable restore
#line 38 "C:\Users\ASUS\Desktop\Website-Blog\SakataBlog.Solution\SakataBlog.Admin\Views\Role\Update.cshtml"
WriteAttributeValue("", 1577, item.Id, 1577, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 1586, "\"", 1602, 1);
#nullable restore
#line 38 "C:\Users\ASUS\Desktop\Website-Blog\SakataBlog.Solution\SakataBlog.Admin\Views\Role\Update.cshtml"
WriteAttributeValue("", 1594, item.Id, 1594, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n");
#nullable restore
#line 39 "C:\Users\ASUS\Desktop\Website-Blog\SakataBlog.Solution\SakataBlog.Admin\Views\Role\Update.cshtml"
                                }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <label class=\"form-check-label\"");
                BeginWriteAttribute("for", " for=\"", 1704, "\"", 1718, 1);
#nullable restore
#line 40 "C:\Users\ASUS\Desktop\Website-Blog\SakataBlog.Solution\SakataBlog.Admin\Views\Role\Update.cshtml"
WriteAttributeValue("", 1710, item.Id, 1710, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 40 "C:\Users\ASUS\Desktop\Website-Blog\SakataBlog.Solution\SakataBlog.Admin\Views\Role\Update.cshtml"
                                                                          Write(item.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                            </div>\r\n");
#nullable restore
#line 42 "C:\Users\ASUS\Desktop\Website-Blog\SakataBlog.Solution\SakataBlog.Admin\Views\Role\Update.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 46 "C:\Users\ASUS\Desktop\Website-Blog\SakataBlog.Solution\SakataBlog.Admin\Views\Role\Update.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("        <button type=\"submit\" class=\"btn btn-primary\">Submit</button>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 330, "/Role/Update/", 330, 13, true);
#nullable restore
#line 14 "C:\Users\ASUS\Desktop\Website-Blog\SakataBlog.Solution\SakataBlog.Admin\Views\Role\Update.cshtml"
AddHtmlAttributeValue("", 343, Model.Id, 343, 9, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SakataBlog.ViewModel.System.RoleFolder.RoleVm> Html { get; private set; }
    }
}
#pragma warning restore 1591