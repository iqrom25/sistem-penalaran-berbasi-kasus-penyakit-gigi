#pragma checksum "/home/dell/RiderProjects/PBK_dita/PBK_dita/Views/Admin/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8dbd9718b274f7c68f80fd8866815d1e721f6ca0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Index), @"mvc.1.0.view", @"/Views/Admin/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8dbd9718b274f7c68f80fd8866815d1e721f6ca0", @"/Views/Admin/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd38c7867ac846f8cb1b90ce92fa2fcd080bab07", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Penyakit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-white"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("text-decoration: none"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Gejala", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "RekamMedis", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "RiwayatKonsultasi", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "User", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "/home/dell/RiderProjects/PBK_dita/PBK_dita/Views/Admin/Index.cshtml"
  
    ViewData["Title"] = "Dashboard";
  ViewData["controller"] = "Admin";
  ViewData["action"] = "Dashboard";
  (int Penyakit,int Gejala, int RekamMedis, int RiwayatKonsultasi, int User) total = ViewBag.total;
    Layout = "_LayoutAdmin";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style>

    .card-icon{
      font-size: 4em;
      color: rgba(255,255,255,0.3);
      margin-right: 10px;
    }
    

</style>

<div class=""container"">
    <div class=""row"">
    <div class=""col-md-3"">
      <div class=""card shadow mb-4 text-white bg-secondary"">
        <div class=""card-body pb-0 d-flex justify-content-between align-items-start"">
          <div>
            <div class=""fs-2 fw-semibold"">");
#nullable restore
#line 28 "/home/dell/RiderProjects/PBK_dita/PBK_dita/Views/Admin/Index.cshtml"
                                     Write(total.Penyakit);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
            <div style=""font-size: 1.2em"">Penyakit</div>
          </div>
          <i class=""bi bi-virus card-icon"" ></i>
        </div>
        <div class=""card-footer d-flex justify-content-center align-items-center"" 
             style=""background-color: rgba(175,175,175,0.57)"">
          ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8dbd9718b274f7c68f80fd8866815d1e721f6ca06573", async() => {
                WriteLiteral(" Lihat info\n            <i class=\"ms-2 bi bi-arrow-right-circle-fill\"></i>\n          ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
        </div>
      </div>
    </div>

      <div class=""col-md-3"">
        <div class=""card shadow mb-4 text-white bg-warning"">
          <div class=""card-body pb-0 d-flex justify-content-between align-items-start"">
            <div>
              <div class=""fs-2 fw-semibold"">");
#nullable restore
#line 46 "/home/dell/RiderProjects/PBK_dita/PBK_dita/Views/Admin/Index.cshtml"
                                       Write(total.Gejala);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
              <div style=""font-size: 1.2em"">Gejala</div>
            </div>
            <i class=""bi bi-bandaid-fill card-icon"" ></i>
          </div>
          <div class=""card-footer d-flex justify-content-center align-items-center""
               style=""background-color: rgba(183,155,31,0.53)"">
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8dbd9718b274f7c68f80fd8866815d1e721f6ca08805", async() => {
                WriteLiteral(" Lihat info  \n              <i class=\"nav-icon bi-arrow-right-circle-fill\"></i>\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
          </div>
        </div>
      </div>
      
      <div class=""col-md-3"">
        <div class=""card shadow mb-4 text-white bg-danger"">
          <div class=""card-body pb-0 d-flex justify-content-between align-items-start"">
            <div>
              <div class=""fs-2 fw-semibold"">");
#nullable restore
#line 64 "/home/dell/RiderProjects/PBK_dita/PBK_dita/Views/Admin/Index.cshtml"
                                       Write(total.RekamMedis);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
              <div style=""font-size: 1.2em"">Rekam Medis</div>
            </div>
            <i class=""nav-icon bi bi-database-check card-icon""></i>
          </div>
          <div class=""card-footer d-flex justify-content-center align-items-center""
               style=""background-color: rgba(183,31,31,0.53)"">
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8dbd9718b274f7c68f80fd8866815d1e721f6ca011073", async() => {
                WriteLiteral(" Lihat info  \n              <i class=\"nav-icon bi-arrow-right-circle-fill\"></i>\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
          </div>
        </div>
      </div>
      
      <div class=""col-md-3"">
        <div class=""card shadow mb-4 text-white bg-primary"">
          <div class=""card-body pb-0 d-flex justify-content-between align-items-start"">
            <div>
              <div class=""fs-2 fw-semibold"">");
#nullable restore
#line 82 "/home/dell/RiderProjects/PBK_dita/PBK_dita/Views/Admin/Index.cshtml"
                                       Write(total.RiwayatKonsultasi);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
              <div style=""font-size: 1em"">Riwayat Konsultasi</div>
            </div>
            <i class=""nav-icon bi bi-clipboard2-check card-icon""></i>
          </div>
          <div class=""card-footer d-flex justify-content-center align-items-center""
               style=""background-color: rgba(31,79,183,0.53)"">
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8dbd9718b274f7c68f80fd8866815d1e721f6ca013357", async() => {
                WriteLiteral(" Lihat info  \n              <i class=\"nav-icon bi-arrow-right-circle-fill\"></i>\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
          </div>
        </div>
      </div>    
      
      <div class=""col-md-3"">
        <div class=""card shadow mb-4 text-white bg-primary"">
          <div class=""card-body pb-0 d-flex justify-content-between align-items-start"">
            <div>
              <div class=""fs-2 fw-semibold"">");
#nullable restore
#line 100 "/home/dell/RiderProjects/PBK_dita/PBK_dita/Views/Admin/Index.cshtml"
                                       Write(total.User);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
              <div style=""font-size: 1em"">User</div>
            </div>
            <i class=""nav-icon bi bi-people-fill card-icon""></i>
          </div>
          <div class=""card-footer d-flex justify-content-center align-items-center""
               style=""background-color: rgba(31,79,183,0.53)"">
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8dbd9718b274f7c68f80fd8866815d1e721f6ca015614", async() => {
                WriteLiteral(" Lihat info  \n              <i class=\"nav-icon bi-arrow-right-circle-fill\"></i>\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n          </div>\n        </div>\n      </div>  \n      \n    </div>\n</div>\n\n\n\n");
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