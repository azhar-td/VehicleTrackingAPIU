#pragma checksum "C:\Users\rafiqmuh\Documents\Visual Studio 2019\VehicleTracking\VehicleTracking\Views\Admin\HomePage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "74b39c339467851f213f45760f5c1716dd8d4c3e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_HomePage), @"mvc.1.0.view", @"/Views/Admin/HomePage.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Admin/HomePage.cshtml", typeof(AspNetCore.Views_Admin_HomePage))]
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
#line 1 "C:\Users\rafiqmuh\Documents\Visual Studio 2019\VehicleTracking\VehicleTracking\Views\_ViewImports.cshtml"
using VehicleTracking;

#line default
#line hidden
#line 2 "C:\Users\rafiqmuh\Documents\Visual Studio 2019\VehicleTracking\VehicleTracking\Views\_ViewImports.cshtml"
using VehicleTracking.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74b39c339467851f213f45760f5c1716dd8d4c3e", @"/Views/Admin/HomePage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d29dd2aff5215aed559bb921a1916810dfde020c", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_HomePage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<VehicleTracking.DTO.VMVehicle>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(51, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\rafiqmuh\Documents\Visual Studio 2019\VehicleTracking\VehicleTracking\Views\Admin\HomePage.cshtml"
  
    ViewData["Title"] = "HomePage";

#line default
#line hidden
            BeginContext(97, 121, true);
            WriteLiteral("\r\n<h1>Welcome Admin HomePage</h1>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(219, 38, false);
#line 13 "C:\Users\rafiqmuh\Documents\Visual Studio 2019\VehicleTracking\VehicleTracking\Views\Admin\HomePage.cshtml"
           Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(257, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(313, 41, false);
#line 16 "C:\Users\rafiqmuh\Documents\Visual Studio 2019\VehicleTracking\VehicleTracking\Views\Admin\HomePage.cshtml"
           Write(Html.DisplayNameFor(model => model.Model));

#line default
#line hidden
            EndContext();
            BeginContext(354, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(410, 42, false);
#line 19 "C:\Users\rafiqmuh\Documents\Visual Studio 2019\VehicleTracking\VehicleTracking\Views\Admin\HomePage.cshtml"
           Write(Html.DisplayNameFor(model => model.RegNum));

#line default
#line hidden
            EndContext();
            BeginContext(452, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 25 "C:\Users\rafiqmuh\Documents\Visual Studio 2019\VehicleTracking\VehicleTracking\Views\Admin\HomePage.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(587, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(648, 37, false);
#line 29 "C:\Users\rafiqmuh\Documents\Visual Studio 2019\VehicleTracking\VehicleTracking\Views\Admin\HomePage.cshtml"
               Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
            EndContext();
            BeginContext(685, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(753, 40, false);
#line 32 "C:\Users\rafiqmuh\Documents\Visual Studio 2019\VehicleTracking\VehicleTracking\Views\Admin\HomePage.cshtml"
               Write(Html.DisplayFor(modelItem => item.Model));

#line default
#line hidden
            EndContext();
            BeginContext(793, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(861, 41, false);
#line 35 "C:\Users\rafiqmuh\Documents\Visual Studio 2019\VehicleTracking\VehicleTracking\Views\Admin\HomePage.cshtml"
               Write(Html.DisplayFor(modelItem => item.RegNum));

#line default
#line hidden
            EndContext();
            BeginContext(902, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(970, 69, false);
#line 38 "C:\Users\rafiqmuh\Documents\Visual Studio 2019\VehicleTracking\VehicleTracking\Views\Admin\HomePage.cshtml"
               Write(Html.ActionLink("Details", "VDetail","Tracking", new {  id=item.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(1039, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 41 "C:\Users\rafiqmuh\Documents\Visual Studio 2019\VehicleTracking\VehicleTracking\Views\Admin\HomePage.cshtml"
        }

#line default
#line hidden
            BeginContext(1094, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<VehicleTracking.DTO.VMVehicle>> Html { get; private set; }
    }
}
#pragma warning restore 1591