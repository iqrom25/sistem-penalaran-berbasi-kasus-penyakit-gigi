#pragma checksum "/home/dell/RiderProjects/PBK_dita/PBK_dita/Views/Admin/User/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2ebe6c77f5ec0b62f2fd784a6f0b78a81f95fe92"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_User_Index), @"mvc.1.0.view", @"/Views/Admin/User/Index.cshtml")]
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
#line 1 "/home/dell/RiderProjects/PBK_dita/PBK_dita/Views/_ViewImports.cshtml"
using PBK_dita;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/dell/RiderProjects/PBK_dita/PBK_dita/Views/_ViewImports.cshtml"
using PBK_dita.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2ebe6c77f5ec0b62f2fd784a6f0b78a81f95fe92", @"/Views/Admin/User/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd38c7867ac846f8cb1b90ce92fa2fcd080bab07", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_User_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PBK_dita.Models.User>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
            WriteLiteral("\n");
#nullable restore
#line 4 "/home/dell/RiderProjects/PBK_dita/PBK_dita/Views/Admin/User/Index.cshtml"
  
    ViewData["Title"] = "User";
    ViewData["controller"] = "Admin";
    ViewData["action"] = "Data User";
    Layout = "_LayoutAdmin";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""card mb-4"">
    <div class=""card-header""><strong>Data User</strong></div>
    <div class=""card-body"">
        <table id=""table"" class=""table table-striped"" style=""width:100%"">
            <thead>
            <tr>
                <th>No</th>
                <th>");
#nullable restore
#line 19 "/home/dell/RiderProjects/PBK_dita/PBK_dita/Views/Admin/User/Index.cshtml"
               Write(Html.DisplayNameFor(model => model.Nama));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\n                <th>");
#nullable restore
#line 20 "/home/dell/RiderProjects/PBK_dita/PBK_dita/Views/Admin/User/Index.cshtml"
               Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\n                <th>");
#nullable restore
#line 21 "/home/dell/RiderProjects/PBK_dita/PBK_dita/Views/Admin/User/Index.cshtml"
               Write(Html.DisplayNameFor(model=>model.Umur));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\n                <th>");
#nullable restore
#line 22 "/home/dell/RiderProjects/PBK_dita/PBK_dita/Views/Admin/User/Index.cshtml"
               Write(Html.DisplayNameFor(model=>model.JenisKelamin));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\n                <th>Aksi</th>\n            </tr>\n            </thead>\n");
#nullable restore
#line 26 "/home/dell/RiderProjects/PBK_dita/PBK_dita/Views/Admin/User/Index.cshtml"
              
                if (Model.Count() > 0)
                {
                    int i = 1;

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tbody>\n                    \n");
#nullable restore
#line 32 "/home/dell/RiderProjects/PBK_dita/PBK_dita/Views/Admin/User/Index.cshtml"
                     foreach (var user in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\n                             <td>");
#nullable restore
#line 35 "/home/dell/RiderProjects/PBK_dita/PBK_dita/Views/Admin/User/Index.cshtml"
                            Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                             <td>");
#nullable restore
#line 36 "/home/dell/RiderProjects/PBK_dita/PBK_dita/Views/Admin/User/Index.cshtml"
                            Write(user.Nama);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                             <td>");
#nullable restore
#line 37 "/home/dell/RiderProjects/PBK_dita/PBK_dita/Views/Admin/User/Index.cshtml"
                            Write(user.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                             <td>");
#nullable restore
#line 38 "/home/dell/RiderProjects/PBK_dita/PBK_dita/Views/Admin/User/Index.cshtml"
                            Write(user.Umur);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                              <td>");
#nullable restore
#line 39 "/home/dell/RiderProjects/PBK_dita/PBK_dita/Views/Admin/User/Index.cshtml"
                             Write(user.JenisKelamin);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                            <td>\n");
#nullable restore
#line 42 "/home/dell/RiderProjects/PBK_dita/PBK_dita/Views/Admin/User/Index.cshtml"
                                 if (user.Role == 0)
                                {
                                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <button class=\"btn btn-danger ms-2\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1647, "\"", 1687, 3);
            WriteAttributeValue("", 1657, "onDeleteClick(", 1657, 14, true);
#nullable restore
#line 45 "/home/dell/RiderProjects/PBK_dita/PBK_dita/Views/Admin/User/Index.cshtml"
WriteAttributeValue("", 1671, user.Id, 1671, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1679, ",\'User\')", 1679, 8, true);
            EndWriteAttribute();
            WriteLiteral(">\n                                        <i class=\"bi bi-trash3\"></i>\n                                    </button>\n");
#nullable restore
#line 48 "/home/dell/RiderProjects/PBK_dita/PBK_dita/Views/Admin/User/Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </td>\n                        </tr>\n");
#nullable restore
#line 51 "/home/dell/RiderProjects/PBK_dita/PBK_dita/Views/Admin/User/Index.cshtml"
                        i++;
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                   \n                    </tbody>\n");
#nullable restore
#line 55 "/home/dell/RiderProjects/PBK_dita/PBK_dita/Views/Admin/User/Index.cshtml"
                }
            

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </table>\n    </div>\n</div>\n\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PBK_dita.Models.User>> Html { get; private set; }
    }
}
#pragma warning restore 1591
