#pragma checksum "C:\Users\Tóth Péter\Desktop\Eby's shit\Git\MoanaSoftwareTrelloClone\TrelloClone\TrelloClone\Views\Home\_Card.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c20b796f13fbcc193598c7c210c30d7f4073b537"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home__Card), @"mvc.1.0.view", @"/Views/Home/_Card.cshtml")]
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
#line 1 "C:\Users\Tóth Péter\Desktop\Eby's shit\Git\MoanaSoftwareTrelloClone\TrelloClone\TrelloClone\Views\_ViewImports.cshtml"
using TrelloClone;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Tóth Péter\Desktop\Eby's shit\Git\MoanaSoftwareTrelloClone\TrelloClone\TrelloClone\Views\_ViewImports.cshtml"
using TrelloClone.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Tóth Péter\Desktop\Eby's shit\Git\MoanaSoftwareTrelloClone\TrelloClone\TrelloClone\Views\Home\_Card.cshtml"
using TrelloClone.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c20b796f13fbcc193598c7c210c30d7f4073b537", @"/Views/Home/_Card.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d60a92495bf3b4ee2602ef5b0f5d7a75c3cc6b6", @"/Views/_ViewImports.cshtml")]
    public class Views_Home__Card : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<div style=\" border-radius: 10px; padding: 1em; background-color: #ffffff; border-radius: 10px; margin: 5px;\">\r\n    <div OnClick=\"detailsCardModalPopUpToggle(\" ");
#nullable restore
#line 5 "C:\Users\Tóth Péter\Desktop\Eby's shit\Git\MoanaSoftwareTrelloClone\TrelloClone\TrelloClone\Views\Home\_Card.cshtml"
                                           Write(Model.id);

#line default
#line hidden
#nullable disable
            WriteLiteral(" \");\">\r\n        <div style=\"font-size: 18px; font-weight: 500; text-transform: uppercase; color: #5e5e5e;\">");
#nullable restore
#line 6 "C:\Users\Tóth Péter\Desktop\Eby's shit\Git\MoanaSoftwareTrelloClone\TrelloClone\TrelloClone\Views\Home\_Card.cshtml"
                                                                                              Write(Model.title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n        <div style=\"font-size: 14px; color: #969696;\">");
#nullable restore
#line 7 "C:\Users\Tóth Péter\Desktop\Eby's shit\Git\MoanaSoftwareTrelloClone\TrelloClone\TrelloClone\Views\Home\_Card.cshtml"
                                                 Write(Model.description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n    </div>\r\n\r\n</div>");
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
