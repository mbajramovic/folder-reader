#pragma checksum "c:\Users\xy\Desktop\folder-reader-dotnet\FolderReader\Views\Shared\FolderContent.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2bcb43d9cb32dcbc15bdeb2a8d5bc8609e11e9c0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_FolderContent), @"mvc.1.0.view", @"/Views/Shared/FolderContent.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/FolderContent.cshtml", typeof(AspNetCore.Views_Shared_FolderContent))]
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
#line 1 "c:\Users\xy\Desktop\folder-reader-dotnet\FolderReader\Views\_ViewImports.cshtml"
using FolderReader;

#line default
#line hidden
#line 2 "c:\Users\xy\Desktop\folder-reader-dotnet\FolderReader\Views\_ViewImports.cshtml"
using FolderReader.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2bcb43d9cb32dcbc15bdeb2a8d5bc8609e11e9c0", @"/Views/Shared/FolderContent.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44a234365530eb9a7d24bacefb777d953243cf9b", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_FolderContent : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FolderReader.Models.FolderContent>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "c:\Users\xy\Desktop\folder-reader-dotnet\FolderReader\Views\Shared\FolderContent.cshtml"
  
    ViewData["Title"] = "Folder Reader";

#line default
#line hidden
            BeginContext(91, 23, true);
            WriteLiteral("\r\n<p class=\"error-msg\">");
            EndContext();
            BeginContext(115, 11, false);
#line 6 "c:\Users\xy\Desktop\folder-reader-dotnet\FolderReader\Views\Shared\FolderContent.cshtml"
                Write(Model.Error);

#line default
#line hidden
            EndContext();
            BeginContext(126, 45, true);
            WriteLiteral("</p>\r\n\r\n<table class=\"table table-striped\">\r\n");
            EndContext();
#line 9 "c:\Users\xy\Desktop\folder-reader-dotnet\FolderReader\Views\Shared\FolderContent.cshtml"
         foreach(var Content in Model.Content)
        {

#line default
#line hidden
            BeginContext(230, 73, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    U folderu <b>");
            EndContext();
            BeginContext(304, 14, false);
#line 13 "c:\Users\xy\Desktop\folder-reader-dotnet\FolderReader\Views\Shared\FolderContent.cshtml"
                            Write(Content.Folder);

#line default
#line hidden
            EndContext();
            BeginContext(318, 24, true);
            WriteLiteral("</b> se nalazi datoteka ");
            EndContext();
            BeginContext(343, 139, false);
#line 13 "c:\Users\xy\Desktop\folder-reader-dotnet\FolderReader\Views\Shared\FolderContent.cshtml"
                                                                   Write(Html.ActionLink(@Content.File, "FolderContent", "FolderContent", new {folder = @Content.Folder, file=@Content.File}, new {target="_blank"}));

#line default
#line hidden
            EndContext();
            BeginContext(482, 45, true);
            WriteLiteral(".\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 16 "c:\Users\xy\Desktop\folder-reader-dotnet\FolderReader\Views\Shared\FolderContent.cshtml"
        }

#line default
#line hidden
            BeginContext(538, 12, true);
            WriteLiteral("</table>\r\n\r\n");
            EndContext();
            DefineSection("Styles", async() => {
                BeginContext(568, 103, true);
                WriteLiteral("\r\n    <style type=\"text/css\">\r\n        .error-msg {\r\n            color: red;\r\n        }\r\n    </style>\r\n");
                EndContext();
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FolderReader.Models.FolderContent> Html { get; private set; }
    }
}
#pragma warning restore 1591
