#pragma checksum "K:\TRTLFarm\TRTLFarm\Views\Market\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "09e6ddd7d88822f30a39abb9c19094c96e61ffa8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Market_Index), @"mvc.1.0.view", @"/Views/Market/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Market/Index.cshtml", typeof(AspNetCore.Views_Market_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"09e6ddd7d88822f30a39abb9c19094c96e61ffa8", @"/Views/Market/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c55c83f480404b294dbdc67ac1067aebcecb2dd1", @"/Views/_ViewImports.cshtml")]
    public class Views_Market_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Animal>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("animal_Quantity"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "number", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Market", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Buy", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "K:\TRTLFarm\TRTLFarm\Views\Market\Index.cshtml"
  
    ViewData["Title"] = "Market";

#line default
#line hidden
            BeginContext(63, 144, true);
            WriteLiteral("\r\n<section class=\"text-center my-5\">\r\n    <h2 class=\"h1-responsive font-weight-bold my-5\">Here you can buy new or more production units</h2>\r\n\r\n");
            EndContext();
#line 9 "K:\TRTLFarm\TRTLFarm\Views\Market\Index.cshtml"
     if (TempData["ERROR"] != null)
    {

#line default
#line hidden
            BeginContext(251, 67, true);
            WriteLiteral("        <div class=\"alert alert-danger\" role=\"alert\">\r\n            ");
            EndContext();
            BeginContext(319, 28, false);
#line 12 "K:\TRTLFarm\TRTLFarm\Views\Market\Index.cshtml"
       Write(TempData["ERROR"].ToString());

#line default
#line hidden
            EndContext();
            BeginContext(347, 18, true);
            WriteLiteral("\r\n        </div>\r\n");
            EndContext();
#line 14 "K:\TRTLFarm\TRTLFarm\Views\Market\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(372, 4, true);
            WriteLiteral("    ");
            EndContext();
#line 15 "K:\TRTLFarm\TRTLFarm\Views\Market\Index.cshtml"
     if (TempData["SUCCESS"] != null)
    {

#line default
#line hidden
            BeginContext(418, 68, true);
            WriteLiteral("        <div class=\"alert alert-success\" role=\"alert\">\r\n            ");
            EndContext();
            BeginContext(487, 30, false);
#line 18 "K:\TRTLFarm\TRTLFarm\Views\Market\Index.cshtml"
       Write(TempData["SUCCESS"].ToString());

#line default
#line hidden
            EndContext();
            BeginContext(517, 18, true);
            WriteLiteral("\r\n        </div>\r\n");
            EndContext();
#line 20 "K:\TRTLFarm\TRTLFarm\Views\Market\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(542, 25, true);
            WriteLiteral("\r\n    <div class=\"row\">\r\n");
            EndContext();
#line 23 "K:\TRTLFarm\TRTLFarm\Views\Market\Index.cshtml"
         foreach (var animal in Model)
        {

#line default
#line hidden
            BeginContext(618, 12, true);
            WriteLiteral("            ");
            EndContext();
            BeginContext(630, 1993, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e055d2044a224debb6116848cfd758b6", async() => {
                BeginContext(691, 190, true);
                WriteLiteral("\r\n                <div class=\"col-md-4 animalBox\">\r\n                    <div class=\"profile-sidebar\">\r\n                        <div class=\"profile-userpic\">\r\n                            <img");
                EndContext();
                BeginWriteAttribute("src", " src=\"", 881, "\"", 904, 1);
#line 29 "K:\TRTLFarm\TRTLFarm\Views\Market\Index.cshtml"
WriteAttributeValue("", 887, animal.ImagePath, 887, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(905, 23, true);
                WriteLiteral(" class=\"img-responsive\"");
                EndContext();
                BeginWriteAttribute("alt", " alt=\"", 928, "\"", 946, 1);
#line 29 "K:\TRTLFarm\TRTLFarm\Views\Market\Index.cshtml"
WriteAttributeValue("", 934, animal.Name, 934, 12, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(947, 190, true);
                WriteLiteral(">\r\n                        </div>\r\n                        <div class=\"profile-usertitle\">\r\n                            <div class=\"profile-usertitle-name\">\r\n                                ");
                EndContext();
                BeginContext(1138, 11, false);
#line 33 "K:\TRTLFarm\TRTLFarm\Views\Market\Index.cshtml"
                           Write(animal.Name);

#line default
#line hidden
                EndContext();
                BeginContext(1149, 147, true);
                WriteLiteral("\r\n                            </div>\r\n                            <div class=\"profile-usertitle-job\">\r\n                                Production: ");
                EndContext();
                BeginContext(1297, 22, false);
#line 36 "K:\TRTLFarm\TRTLFarm\Views\Market\Index.cshtml"
                                       Write(animal.ProductionSpeed);

#line default
#line hidden
                EndContext();
                BeginContext(1319, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(1321, 21, false);
#line 36 "K:\TRTLFarm\TRTLFarm\Views\Market\Index.cshtml"
                                                               Write(animal.ProductionUnit);

#line default
#line hidden
                EndContext();
                BeginContext(1342, 136, true);
                WriteLiteral("\r\n                            </div>\r\n                            <div class=\"profile-usertitle-name\">\r\n                                ");
                EndContext();
                BeginContext(1479, 26, false);
#line 39 "K:\TRTLFarm\TRTLFarm\Views\Market\Index.cshtml"
                           Write(animal.Price.ToString("F"));

#line default
#line hidden
                EndContext();
                BeginContext(1505, 232, true);
                WriteLiteral(" TRTL\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"profile-userbuttons\">\r\n                            <div class=\"profile-usertitle-name\">\r\n                                ");
                EndContext();
                BeginContext(1737, 115, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "112af6fe0f384784b78c1e88f56f5299", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
#line 44 "K:\TRTLFarm\TRTLFarm\Views\Market\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => animal.Quantity);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                BeginWriteTagHelperAttribute();
#line 44 "K:\TRTLFarm\TRTLFarm\Views\Market\Index.cshtml"
                                                                                                                             Write(animal.Price);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("data-unitPrice", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1852, 261, true);
                WriteLiteral(@"
                            </div>
                        </div>
                        <div class=""profile-usertitle"">
                            <div class=""profile-usertitle-name"">
                                Subtotal: <span class=""subTotalBuy"">");
                EndContext();
                BeginContext(2114, 26, false);
#line 49 "K:\TRTLFarm\TRTLFarm\Views\Market\Index.cshtml"
                                                               Write(animal.Price.ToString("F"));

#line default
#line hidden
                EndContext();
                BeginContext(2140, 292, true);
                WriteLiteral(@"</span> TRTL
                            </div>
                        </div>
                        <div class=""profile-userbuttons"">
                            <button type=""submit"" class=""btn btn-success btn-sm"">Buy</button>
                        </div>
                        ");
                EndContext();
                BeginContext(2432, 44, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "77e428fcfede47dbba962dfb1437c8b6", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 55 "K:\TRTLFarm\TRTLFarm\Views\Market\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => animal.Id);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2476, 26, true);
                WriteLiteral("\r\n                        ");
                EndContext();
                BeginContext(2502, 46, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "406814f082f04c7d8df1891429552643", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 56 "K:\TRTLFarm\TRTLFarm\Views\Market\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => animal.Name);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2548, 68, true);
                WriteLiteral("\r\n                    </div>\r\n\r\n                </div>\r\n            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2623, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 61 "K:\TRTLFarm\TRTLFarm\Views\Market\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(2636, 26, true);
            WriteLiteral("\r\n    </div>\r\n</section>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Animal>> Html { get; private set; }
    }
}
#pragma warning restore 1591
