#pragma checksum "C:\Users\Pello Usabiaga\Documents\GitHub repositorios\Imatek Proiektua\Proyecto Imatek\CMS\Views\Profile\Upload.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "92048a0fe70248d299448de822f00200358a99da"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Profile_Upload), @"mvc.1.0.view", @"/Views/Profile/Upload.cshtml")]
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
#line 1 "C:\Users\Pello Usabiaga\Documents\GitHub repositorios\Imatek Proiektua\Proyecto Imatek\CMS\Views\_ViewImports.cshtml"
using CMS02;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Pello Usabiaga\Documents\GitHub repositorios\Imatek Proiektua\Proyecto Imatek\CMS\Views\_ViewImports.cshtml"
using CMS02.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"92048a0fe70248d299448de822f00200358a99da", @"/Views/Profile/Upload.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f6cabc2351844ec70ef5f11cb3fdb0d34016fc58", @"/Views/_ViewImports.cshtml")]
    public class Views_Profile_Upload : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CMS02.Models.DocumentUploadViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Pello Usabiaga\Documents\GitHub repositorios\Imatek Proiektua\Proyecto Imatek\CMS\Views\Profile\Upload.cshtml"
  
    ViewData["Title"] = "Upload";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Upload</h1>\r\n\r\n");
#nullable restore
#line 9 "C:\Users\Pello Usabiaga\Documents\GitHub repositorios\Imatek Proiektua\Proyecto Imatek\CMS\Views\Profile\Upload.cshtml"
 using (Html.BeginForm("UploadSend", "Profile", FormMethod.Post,
    new { enctype = "multipart/form-data" }))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\Pello Usabiaga\Documents\GitHub repositorios\Imatek Proiektua\Proyecto Imatek\CMS\Views\Profile\Upload.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\Pello Usabiaga\Documents\GitHub repositorios\Imatek Proiektua\Proyecto Imatek\CMS\Views\Profile\Upload.cshtml"
                            ;

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col-md-6 col-lg-3\">\r\n            <div class=\"form-group\">\r\n                <p>\r\n                    ");
#nullable restore
#line 17 "C:\Users\Pello Usabiaga\Documents\GitHub repositorios\Imatek Proiektua\Proyecto Imatek\CMS\Views\Profile\Upload.cshtml"
               Write(Html.LabelFor(d => d.FileToUpload));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <br />\r\n                    ");
#nullable restore
#line 19 "C:\Users\Pello Usabiaga\Documents\GitHub repositorios\Imatek Proiektua\Proyecto Imatek\CMS\Views\Profile\Upload.cshtml"
               Write(Html.TextBoxFor(d => d.FileToUpload, new { type = "file" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 20 "C:\Users\Pello Usabiaga\Documents\GitHub repositorios\Imatek Proiektua\Proyecto Imatek\CMS\Views\Profile\Upload.cshtml"
               Write(Html.ValidationMessageFor(d => d.FileToUpload, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </p>\r\n            </div>\r\n            <div class=\"form-group\">\r\n                <p>\r\n                    ");
#nullable restore
#line 25 "C:\Users\Pello Usabiaga\Documents\GitHub repositorios\Imatek Proiektua\Proyecto Imatek\CMS\Views\Profile\Upload.cshtml"
               Write(Html.LabelFor(d => d.Document.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <br />\r\n                    ");
#nullable restore
#line 27 "C:\Users\Pello Usabiaga\Documents\GitHub repositorios\Imatek Proiektua\Proyecto Imatek\CMS\Views\Profile\Upload.cshtml"
               Write(Html.TextBoxFor(d => d.Document.Name, new { type = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 28 "C:\Users\Pello Usabiaga\Documents\GitHub repositorios\Imatek Proiektua\Proyecto Imatek\CMS\Views\Profile\Upload.cshtml"
               Write(Html.ValidationMessageFor(d => d.Document.Name, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </p>\r\n            </div>\r\n            <div class=\"form-group\">\r\n                <p>\r\n                    ");
#nullable restore
#line 33 "C:\Users\Pello Usabiaga\Documents\GitHub repositorios\Imatek Proiektua\Proyecto Imatek\CMS\Views\Profile\Upload.cshtml"
               Write(Html.LabelFor(d => d.Document.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <br />\r\n                    ");
#nullable restore
#line 35 "C:\Users\Pello Usabiaga\Documents\GitHub repositorios\Imatek Proiektua\Proyecto Imatek\CMS\Views\Profile\Upload.cshtml"
               Write(Html.TextBoxFor(d => d.Document.Description, new { type = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 36 "C:\Users\Pello Usabiaga\Documents\GitHub repositorios\Imatek Proiektua\Proyecto Imatek\CMS\Views\Profile\Upload.cshtml"
               Write(Html.ValidationMessageFor(d => d.Document.Description, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </p>\r\n            </div>\r\n            <div class=\"form-group\">\r\n                <p>\r\n                    ");
#nullable restore
#line 41 "C:\Users\Pello Usabiaga\Documents\GitHub repositorios\Imatek Proiektua\Proyecto Imatek\CMS\Views\Profile\Upload.cshtml"
               Write(Html.LabelFor(d => d.Document.ShowDescription));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <br />\r\n                    ");
#nullable restore
#line 43 "C:\Users\Pello Usabiaga\Documents\GitHub repositorios\Imatek Proiektua\Proyecto Imatek\CMS\Views\Profile\Upload.cshtml"
               Write(Html.CheckBoxFor(d => d.Document.ShowDescription, new { type = "checkbox" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 44 "C:\Users\Pello Usabiaga\Documents\GitHub repositorios\Imatek Proiektua\Proyecto Imatek\CMS\Views\Profile\Upload.cshtml"
               Write(Html.ValidationMessageFor(d => d.Document.ShowDescription, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </p>\r\n            </div>\r\n            <div class=\"form-group\">\r\n                <p>\r\n                    ");
#nullable restore
#line 49 "C:\Users\Pello Usabiaga\Documents\GitHub repositorios\Imatek Proiektua\Proyecto Imatek\CMS\Views\Profile\Upload.cshtml"
               Write(Html.LabelFor(d => d.Document.Public));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <br />\r\n                    ");
#nullable restore
#line 51 "C:\Users\Pello Usabiaga\Documents\GitHub repositorios\Imatek Proiektua\Proyecto Imatek\CMS\Views\Profile\Upload.cshtml"
               Write(Html.CheckBoxFor(d => d.Document.Public, new { type = "checkbox" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 52 "C:\Users\Pello Usabiaga\Documents\GitHub repositorios\Imatek Proiektua\Proyecto Imatek\CMS\Views\Profile\Upload.cshtml"
               Write(Html.ValidationMessageFor(d => d.Document.Public, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </p>\r\n            </div>\r\n            <div class=\"form-group\">\r\n                <button type=\"submit\" class=\"btn btn-outline-dark\" value=\"UploadSend\">Upload</button>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 60 "C:\Users\Pello Usabiaga\Documents\GitHub repositorios\Imatek Proiektua\Proyecto Imatek\CMS\Views\Profile\Upload.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 62 "C:\Users\Pello Usabiaga\Documents\GitHub repositorios\Imatek Proiektua\Proyecto Imatek\CMS\Views\Profile\Upload.cshtml"
 if (ViewBag.Mensaje != "1")
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <script>alert(\"");
#nullable restore
#line 64 "C:\Users\Pello Usabiaga\Documents\GitHub repositorios\Imatek Proiektua\Proyecto Imatek\CMS\Views\Profile\Upload.cshtml"
              Write(ViewBag.Mensaje);

#line default
#line hidden
#nullable disable
            WriteLiteral("\");</script>\r\n");
#nullable restore
#line 65 "C:\Users\Pello Usabiaga\Documents\GitHub repositorios\Imatek Proiektua\Proyecto Imatek\CMS\Views\Profile\Upload.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CMS02.Models.DocumentUploadViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
