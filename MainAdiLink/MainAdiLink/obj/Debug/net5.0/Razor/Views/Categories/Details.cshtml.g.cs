#pragma checksum "C:\Users\Богдан Гущин\Desktop\это папка\Pron\MainAdiLink\MainAdiLink\Views\Categories\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ec3922a8d244f57471854dc6d5e566fa62cc2ff6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Categories_Details), @"mvc.1.0.view", @"/Views/Categories/Details.cshtml")]
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
#line 1 "C:\Users\Богдан Гущин\Desktop\это папка\Pron\MainAdiLink\MainAdiLink\Views\_ViewImports.cshtml"
using MainAdiLink;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Богдан Гущин\Desktop\это папка\Pron\MainAdiLink\MainAdiLink\Views\_ViewImports.cshtml"
using MainAdiLink.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec3922a8d244f57471854dc6d5e566fa62cc2ff6", @"/Views/Categories/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"255c058be5da6036be93a0a84d1c00511782cc06", @"/Views/_ViewImports.cshtml")]
    public class Views_Categories_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MainAdiLink.Models.Category>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Богдан Гущин\Desktop\это папка\Pron\MainAdiLink\MainAdiLink\Views\Categories\Details.cshtml"
  
    Layout = null;
    ViewData["Title"] = "Подробнее";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""modal-content"">
    <div class=""modal-header"">
        <h1 class=""animate__animated animate__fadeInUp"">Подробнее</h1>
        <button class=""close"" data-dismiss=""modal"" area-hidden=""true"">X</button>
    </div>
    <div class=""modal-body"">
        <div class=""animate__animated animate__fadeInUp"">
            <dl class=""row"">
                <dt class=""col-sm-2"">
                    Имя:
                </dt>
                <dd class=""col-sm-10"">
                    ");
#nullable restore
#line 20 "C:\Users\Богдан Гущин\Desktop\это папка\Pron\MainAdiLink\MainAdiLink\Views\Categories\Details.cshtml"
               Write(Html.DisplayFor(model => model.CategoryName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n                <dt class=\"col-sm-2\">\r\n                    Описание:\r\n                </dt>\r\n                <dd class=\"col-sm-10\">\r\n                    ");
#nullable restore
#line 26 "C:\Users\Богдан Гущин\Desktop\это папка\Pron\MainAdiLink\MainAdiLink\Views\Categories\Details.cshtml"
               Write(Html.DisplayFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n            </dl>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MainAdiLink.Models.Category> Html { get; private set; }
    }
}
#pragma warning restore 1591
