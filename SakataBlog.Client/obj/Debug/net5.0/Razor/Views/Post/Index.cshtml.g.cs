#pragma checksum "C:\Users\ASUS\Desktop\Website-Blog\SakataBlog.Solution\SakataBlog.Client\Views\Post\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d9cfddf2bd4aab5c1a70d2f628031673251df724"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Post_Index), @"mvc.1.0.view", @"/Views/Post/Index.cshtml")]
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
#line 1 "C:\Users\ASUS\Desktop\Website-Blog\SakataBlog.Solution\SakataBlog.Client\Views\_ViewImports.cshtml"
using SakataBlog.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ASUS\Desktop\Website-Blog\SakataBlog.Solution\SakataBlog.Client\Views\_ViewImports.cshtml"
using SakataBlog.Client.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ASUS\Desktop\Website-Blog\SakataBlog.Solution\SakataBlog.Client\Views\Post\Index.cshtml"
using SakataBlog.ViewModel.Common;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d9cfddf2bd4aab5c1a70d2f628031673251df724", @"/Views/Post/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"60f0fa6446cfcbd6c6aeb0c1940ad97730d10830", @"/Views/_ViewImports.cshtml")]
    public class Views_Post_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PagingResult<SakataBlog.ViewModel.Catalog.PostFolder.PostVm>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\ASUS\Desktop\Website-Blog\SakataBlog.Solution\SakataBlog.Client\Views\Post\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Header", async() => {
                WriteLiteral(@"
    <header class=""masthead"" style=""background-image: url('/img/home-bg.jpg')"">
        <div class=""overlay""></div>
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-8 col-md-10 mx-auto"">
                    <div class=""site-heading"">
                        <h1>Clean Blog</h1>
                        <span class=""subheading"">A Blog Theme by Start Bootstrap</span>
                    </div>
                </div>
            </div>
        </div>
    </header>
");
            }
            );
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-lg-8 col-md-10 mx-auto\">\r\n");
#nullable restore
#line 27 "C:\Users\ASUS\Desktop\Website-Blog\SakataBlog.Solution\SakataBlog.Client\Views\Post\Index.cshtml"
         foreach (var post in @Model.items)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"post-preview\">\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 987, "\"", 1015, 2);
            WriteAttributeValue("", 994, "/post/detail/", 994, 13, true);
#nullable restore
#line 30 "C:\Users\ASUS\Desktop\Website-Blog\SakataBlog.Solution\SakataBlog.Client\Views\Post\Index.cshtml"
WriteAttributeValue("", 1007, post.Id, 1007, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <h2 class=\"post-title\">\r\n                        ");
#nullable restore
#line 32 "C:\Users\ASUS\Desktop\Website-Blog\SakataBlog.Solution\SakataBlog.Client\Views\Post\Index.cshtml"
                   Write(Html.Raw(post.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </h2>\r\n                    <h3 class=\"post-subtitle\">\r\n                        ");
#nullable restore
#line 35 "C:\Users\ASUS\Desktop\Website-Blog\SakataBlog.Solution\SakataBlog.Client\Views\Post\Index.cshtml"
                   Write(Html.Raw(post.ShortDesc));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </h3>\r\n                </a>\r\n                <p class=\"post-meta\">\r\n                    Posted by\r\n                    <a href=\"#\">");
#nullable restore
#line 40 "C:\Users\ASUS\Desktop\Website-Blog\SakataBlog.Solution\SakataBlog.Client\Views\Post\Index.cshtml"
                           Write(post.CreatedBy);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>on\r\n                    <br />\r\n                    ");
#nullable restore
#line 42 "C:\Users\ASUS\Desktop\Website-Blog\SakataBlog.Solution\SakataBlog.Client\Views\Post\Index.cshtml"
               Write(post.CreatedAt.ToString("dd-MM-yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </p>\r\n            </div>\r\n            <hr>\r\n");
#nullable restore
#line 46 "C:\Users\ASUS\Desktop\Website-Blog\SakataBlog.Solution\SakataBlog.Client\Views\Post\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        ");
#nullable restore
#line 47 "C:\Users\ASUS\Desktop\Website-Blog\SakataBlog.Solution\SakataBlog.Client\Views\Post\Index.cshtml"
   Write(await Component.InvokeAsync("Pager", Model));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PagingResult<SakataBlog.ViewModel.Catalog.PostFolder.PostVm>> Html { get; private set; }
    }
}
#pragma warning restore 1591
