#pragma checksum "K:\TRTLFarm\TRTLFarm\Views\Shared\Components\FooterStats\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "83846273346cc6c2ca4d8e03976acb772b510a28"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_FooterStats_Default), @"mvc.1.0.view", @"/Views/Shared/Components/FooterStats/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/FooterStats/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_FooterStats_Default))]
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
#line 1 "K:\TRTLFarm\TRTLFarm\Views\_ViewImports.cshtml"
using TRTLFarm;

#line default
#line hidden
#line 2 "K:\TRTLFarm\TRTLFarm\Views\_ViewImports.cshtml"
using TRTLFarm.Models;

#line default
#line hidden
#line 1 "K:\TRTLFarm\TRTLFarm\Views\Shared\Components\FooterStats\Default.cshtml"
using TRTLFarm.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"83846273346cc6c2ca4d8e03976acb772b510a28", @"/Views/Shared/Components/FooterStats/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c55c83f480404b294dbdc67ac1067aebcecb2dd1", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_FooterStats_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FooterStats>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(48, 80, true);
            WriteLiteral("\r\n<div class=\"footer-copyright\">\r\n    <span style=\"float:left;\">Active players: ");
            EndContext();
            BeginContext(129, 19, false);
#line 5 "K:\TRTLFarm\TRTLFarm\Views\Shared\Components\FooterStats\Default.cshtml"
                                         Write(Model.ActivePlayers);

#line default
#line hidden
            EndContext();
            BeginContext(148, 54, true);
            WriteLiteral("</span>\r\n    <span style=\"float:right;\">Game balance: ");
            EndContext();
            BeginContext(203, 19, false);
#line 6 "K:\TRTLFarm\TRTLFarm\Views\Shared\Components\FooterStats\Default.cshtml"
                                        Write(Model.WalletBalance);

#line default
#line hidden
            EndContext();
            BeginContext(222, 22, true);
            WriteLiteral(" TRTL</span>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FooterStats> Html { get; private set; }
    }
}
#pragma warning restore 1591
