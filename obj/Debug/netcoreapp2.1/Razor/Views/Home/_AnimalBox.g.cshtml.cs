#pragma checksum "K:\TRTLFarm\TRTLFarm\Views\Home\_AnimalBox.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bfc3fab9f4e9f1bf894ca3dd22fff284881265b3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home__AnimalBox), @"mvc.1.0.view", @"/Views/Home/_AnimalBox.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/_AnimalBox.cshtml", typeof(AspNetCore.Views_Home__AnimalBox))]
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
#line 1 "K:\TRTLFarm\TRTLFarm\Views\Home\_AnimalBox.cshtml"
using TRTLFarm.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bfc3fab9f4e9f1bf894ca3dd22fff284881265b3", @"/Views/Home/_AnimalBox.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c55c83f480404b294dbdc67ac1067aebcecb2dd1", @"/Views/_ViewImports.cshtml")]
    public class Views_Home__AnimalBox : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UserAnimals>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Claim", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "K:\TRTLFarm\TRTLFarm\Views\Home\_AnimalBox.cshtml"
   
    var dateNow = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");

#line default
#line hidden
            BeginContext(117, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(121, 2282, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7519c8a2d6a742e7a10d7ffa7e67f83f", async() => {
                BeginContext(182, 142, true);
                WriteLiteral("\r\n    <div class=\"col-md-4 animalBox\">\r\n        <div class=\"profile-sidebar\">\r\n            <div class=\"profile-userpic\">\r\n                <img");
                EndContext();
                BeginWriteAttribute("src", " src=\"", 324, "\"", 353, 1);
#line 12 "K:\TRTLFarm\TRTLFarm\Views\Home\_AnimalBox.cshtml"
WriteAttributeValue("", 330, Model.Animal.ImagePath, 330, 23, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(354, 23, true);
                WriteLiteral(" class=\"img-responsive\"");
                EndContext();
                BeginWriteAttribute("alt", " alt=\"", 377, "\"", 401, 1);
#line 12 "K:\TRTLFarm\TRTLFarm\Views\Home\_AnimalBox.cshtml"
WriteAttributeValue("", 383, Model.Animal.Name, 383, 18, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(402, 151, true);
                WriteLiteral(">\r\n            </div>\r\n            <div class=\"profile-usertitle\">\r\n                <div class=\"profile-usertitle-name\">\r\n                    You own: ");
                EndContext();
                BeginContext(554, 17, false);
#line 16 "K:\TRTLFarm\TRTLFarm\Views\Home\_AnimalBox.cshtml"
                        Write(Model.AnimalCount);

#line default
#line hidden
                EndContext();
                BeginContext(571, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(573, 17, false);
#line 16 "K:\TRTLFarm\TRTLFarm\Views\Home\_AnimalBox.cshtml"
                                           Write(Model.Animal.Name);

#line default
#line hidden
                EndContext();
                BeginContext(590, 172, true);
                WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"profile-userbuttons\">\r\n                <div class=\"profile-usertitle-name\">\r\n                    <span");
                EndContext();
                BeginWriteAttribute("class", " class=\"", 762, "\"", 788, 2);
                WriteAttributeValue("", 770, "produced-", 770, 9, true);
#line 21 "K:\TRTLFarm\TRTLFarm\Views\Home\_AnimalBox.cshtml"
WriteAttributeValue("", 779, Model.Id, 779, 9, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(789, 9, true);
                WriteLiteral("></span> ");
                EndContext();
                BeginContext(799, 24, false);
#line 21 "K:\TRTLFarm\TRTLFarm\Views\Home\_AnimalBox.cshtml"
                                                        Write(Model.Animal.ProduceName);

#line default
#line hidden
                EndContext();
                BeginContext(823, 183, true);
                WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <script type=\"text/javascript\">\r\n                function RunUpdateAnimalProduction() {\r\n                    ShowProduction(\'");
                EndContext();
                BeginContext(1007, 17, false);
#line 26 "K:\TRTLFarm\TRTLFarm\Views\Home\_AnimalBox.cshtml"
                               Write(Model.AnimalCount);

#line default
#line hidden
                EndContext();
                BeginContext(1024, 4, true);
                WriteLiteral("\', \'");
                EndContext();
                BeginContext(1029, 34, false);
#line 26 "K:\TRTLFarm\TRTLFarm\Views\Home\_AnimalBox.cshtml"
                                                     Write(Model.Animal.ProductionTimeSeconds);

#line default
#line hidden
                EndContext();
                BeginContext(1063, 4, true);
                WriteLiteral("\', \'");
                EndContext();
                BeginContext(1068, 28, false);
#line 26 "K:\TRTLFarm\TRTLFarm\Views\Home\_AnimalBox.cshtml"
                                                                                            Write(Model.Animal.ProductionSpeed);

#line default
#line hidden
                EndContext();
                BeginContext(1096, 4, true);
                WriteLiteral("\', \'");
                EndContext();
                BeginContext(1101, 51, false);
#line 26 "K:\TRTLFarm\TRTLFarm\Views\Home\_AnimalBox.cshtml"
                                                                                                                             Write(Model.LastClaimTime.ToString("dd.MM.yyyy HH:mm:ss"));

#line default
#line hidden
                EndContext();
                BeginContext(1152, 4, true);
                WriteLiteral("\', \'");
                EndContext();
                BeginContext(1157, 8, false);
#line 26 "K:\TRTLFarm\TRTLFarm\Views\Home\_AnimalBox.cshtml"
                                                                                                                                                                                     Write(Model.Id);

#line default
#line hidden
                EndContext();
                BeginContext(1165, 916, true);
                WriteLiteral(@"');
                }

                var myVar = setInterval(RunUpdateAnimalProduction, 250);
                function ShowProduction(AnimalCount, ProductionTimeSeconds, ProductionSpeed, LastClaimTime, id) {
                    var utcMomentNow = moment.utc();
                    var lastClaimDate = moment.utc(LastClaimTime, 'DD.MM.YYYY HH:mm:ss');
                    var difSeconds = moment.duration(utcMomentNow.diff(lastClaimDate)).asSeconds();
                    var produced = (difSeconds / ProductionTimeSeconds) * AnimalCount * parseFloat(ProductionSpeed);
                    $("".produced-"" + id).text(produced.toFixed(5));
                    if (produced.toFixed(5) > 1) {
                        $("".claim-"" + id).removeAttr(""disabled"");
                    }
                }
            </script>
            <div class=""profile-userbuttons"">
                <button type=""submit""");
                EndContext();
                BeginWriteAttribute("class", " class=\"", 2081, "\"", 2127, 5);
                WriteAttributeValue("", 2089, "btn", 2089, 3, true);
                WriteAttributeValue(" ", 2092, "btn-success", 2093, 12, true);
                WriteAttributeValue(" ", 2104, "btn-sm", 2105, 7, true);
                WriteAttributeValue(" ", 2111, "claim-", 2112, 7, true);
#line 42 "K:\TRTLFarm\TRTLFarm\Views\Home\_AnimalBox.cshtml"
WriteAttributeValue("", 2118, Model.Id, 2118, 9, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2128, 69, true);
                WriteLiteral(" disabled>Claim production</button>\r\n            </div>\r\n            ");
                EndContext();
                BeginContext(2197, 43, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ec65e948bed84ee796593892587df85a", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 44 "K:\TRTLFarm\TRTLFarm\Views\Home\_AnimalBox.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.Id);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2240, 14, true);
                WriteLiteral("\r\n            ");
                EndContext();
                BeginContext(2254, 47, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5c51e988834e4abb8295dddc9efaa503", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 45 "K:\TRTLFarm\TRTLFarm\Views\Home\_AnimalBox.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.UserId);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2301, 14, true);
                WriteLiteral("\r\n            ");
                EndContext();
                BeginContext(2315, 49, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "0adde36740884997926062e246d8861f", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 46 "K:\TRTLFarm\TRTLFarm\Views\Home\_AnimalBox.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.AnimalId);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2364, 32, true);
                WriteLiteral("\r\n        </div>\r\n\r\n    </div>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2403, 4, true);
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UserAnimals> Html { get; private set; }
    }
}
#pragma warning restore 1591