#pragma checksum "C:\Users\Makson\source\repos\BicycleStore\BicycleStore\Views\Cart\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "adf1c1ae94d534b4eeb478bcaa10745090d7b5d5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cart_Index), @"mvc.1.0.view", @"/Views/Cart/Index.cshtml")]
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
#line 1 "C:\Users\Makson\source\repos\BicycleStore\BicycleStore\Views\_ViewImports.cshtml"
using BicycleStore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Makson\source\repos\BicycleStore\BicycleStore\Views\_ViewImports.cshtml"
using BicycleStore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"adf1c1ae94d534b4eeb478bcaa10745090d7b5d5", @"/Views/Cart/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bb9f18bd330e5d586f72127509e0b78990b1e134", @"/Views/_ViewImports.cshtml")]
    public class Views_Cart_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BicycleStore.Models.ViewModels.CartIndexViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Makson\source\repos\BicycleStore\BicycleStore\Views\Cart\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Cart</h1>
<table class=""table table-bordered border-primary table-dark mt-3"">
    <thead>
        <tr>
            <th>Title</th>
            <th>Color</th>
            <th>Price</th>
            <th>Quantity</th>
            <th>Subtotal</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 18 "C:\Users\Makson\source\repos\BicycleStore\BicycleStore\Views\Cart\Index.cshtml"
         foreach (var line in Model.Cart.Lines)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 21 "C:\Users\Makson\source\repos\BicycleStore\BicycleStore\Views\Cart\Index.cshtml"
           Write(line.BicycleInLine.BicycleTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 22 "C:\Users\Makson\source\repos\BicycleStore\BicycleStore\Views\Cart\Index.cshtml"
           Write(line.BicycleInLine.BicycleColor);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 23 "C:\Users\Makson\source\repos\BicycleStore\BicycleStore\Views\Cart\Index.cshtml"
           Write(line.BicycleInLine.BicyclePrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 24 "C:\Users\Makson\source\repos\BicycleStore\BicycleStore\Views\Cart\Index.cshtml"
           Write(line.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 25 "C:\Users\Makson\source\repos\BicycleStore\BicycleStore\Views\Cart\Index.cshtml"
            Write(line.Count * line.BicycleInLine.BicyclePrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n");
#nullable restore
#line 27 "C:\Users\Makson\source\repos\BicycleStore\BicycleStore\Views\Cart\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n    <tfoot>\r\n        <tr>\r\n            <td>Total: </td>\r\n            <td>");
#nullable restore
#line 32 "C:\Users\Makson\source\repos\BicycleStore\BicycleStore\Views\Cart\Index.cshtml"
           Write(Model.Cart.ComputeTotalValue());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n    </tfoot>\r\n</table>\r\n\r\n<p class=\"btn btn-success\">\r\n    <a");
            BeginWriteAttribute("href", " href=\"", 970, "\"", 993, 1);
#nullable restore
#line 38 "C:\Users\Makson\source\repos\BicycleStore\BicycleStore\Views\Cart\Index.cshtml"
WriteAttributeValue("", 977, Model.ReturnUrl, 977, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Continue shopping</a>\r\n</p>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BicycleStore.Models.ViewModels.CartIndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
