#pragma checksum "C:\Users\Joel\workspace\DogGo\Views\Walkers\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5e699129847721c100cafa02114e846eb3620fc8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Walkers_Details), @"mvc.1.0.view", @"/Views/Walkers/Details.cshtml")]
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
#line 1 "C:\Users\Joel\workspace\DogGo\Views\_ViewImports.cshtml"
using DogGo;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Joel\workspace\DogGo\Views\_ViewImports.cshtml"
using DogGo.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e699129847721c100cafa02114e846eb3620fc8", @"/Views/Walkers/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"12b50fd1f91f777ae09abf39d99992ea9d25da6c", @"/Views/_ViewImports.cshtml")]
    public class Views_Walkers_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DogGo.Models.ViewModels.WalkerViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Joel\workspace\DogGo\Views\Walkers\Details.cshtml"
   ViewData["Title"] = "Profile"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("<div>\r\n    <h1 class=\"mb-4\">");
#nullable restore
#line 5 "C:\Users\Joel\workspace\DogGo\Views\Walkers\Details.cshtml"
                Write(Model.Walker.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h1>

    <section class=""container"">
        <img style=""width:100px;float:left;margin-right:20px""
             src=""https://upload.wikimedia.org/wikipedia/commons/a/a0/Font_Awesome_5_regular_user-circle.svg"" />
        <div>
            <label class=""font-weight-bold"">Address:</label>
            <span>");
#nullable restore
#line 12 "C:\Users\Joel\workspace\DogGo\Views\Walkers\Details.cshtml"
             Write(Model.Walker.Neighborhood.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n        </div>\r\n");
            WriteLiteral("    </section>\r\n\r\n    <hr class=\"mt-5\" />\r\n    <div class=\"clearfix\"></div>\r\n\r\n    <div class=\"row\">\r\n        <section class=\"col-8 container mt-5\">\r\n            <h1 class=\"text-left\">Dogs</h1>\r\n\r\n            <div class=\"row\">\r\n");
#nullable restore
#line 32 "C:\Users\Joel\workspace\DogGo\Views\Walkers\Details.cshtml"
                 foreach (Walk walk in Model.Walks)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""card m-4"" style=""width: 18rem;"">
                        <div class=""card-body"">
                            <div>
                                <label class=""font-weight-bold"">Name:</label>
                                <span>");
#nullable restore
#line 38 "C:\Users\Joel\workspace\DogGo\Views\Walkers\Details.cshtml"
                                 Write(walk.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                            </div>\r\n                            <div>\r\n                                <label class=\"font-weight-bold\">Breed:</label>\r\n                                <span>");
#nullable restore
#line 42 "C:\Users\Joel\workspace\DogGo\Views\Walkers\Details.cshtml"
                                 Write(walk.Client.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                            </div>\r\n                            <div>\r\n                                <label class=\"font-weight-bold\">Notes:</label>\r\n                                <p>");
#nullable restore
#line 46 "C:\Users\Joel\workspace\DogGo\Views\Walkers\Details.cshtml"
                              Write(walk.Duration);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 50 "C:\Users\Joel\workspace\DogGo\Views\Walkers\Details.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </section>\r\n\r\n");
            WriteLiteral("    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DogGo.Models.ViewModels.WalkerViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
