#pragma checksum "C:\Users\Harich\Downloads\ProjetoLPBD 1.2\ProjetoLPBD 1.1\ProjetoLPBD\Views\Compra\Listar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "04a16b202b68323e7127301e4457142c1a2bb26b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Compra_Listar), @"mvc.1.0.view", @"/Views/Compra/Listar.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Compra/Listar.cshtml", typeof(AspNetCore.Views_Compra_Listar))]
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
#line 1 "C:\Users\Harich\Downloads\ProjetoLPBD 1.2\ProjetoLPBD 1.1\ProjetoLPBD\Views\_ViewImports.cshtml"
using ProjetoLPBD;

#line default
#line hidden
#line 2 "C:\Users\Harich\Downloads\ProjetoLPBD 1.2\ProjetoLPBD 1.1\ProjetoLPBD\Views\_ViewImports.cshtml"
using ProjetoLPBD.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"04a16b202b68323e7127301e4457142c1a2bb26b", @"/Views/Compra/Listar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"151bfe248a3fd2efdce1a9a4421ca9fb1df2579c", @"/Views/_ViewImports.cshtml")]
    public class Views_Compra_Listar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\Harich\Downloads\ProjetoLPBD 1.2\ProjetoLPBD 1.1\ProjetoLPBD\Views\Compra\Listar.cshtml"
  
    ViewData["Title"] = "Lista Compras";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(98, 108, true);
            WriteLiteral("\r\n<h2>Lista de Compras</h2>\r\n<fieldset>\r\n    <legend>Filtrar Por: </legend>\r\n    <div class=\"row\">\r\n        ");
            EndContext();
            BeginContext(206, 1169, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "447c7a364d39435292af8f1bbd3793f7", async() => {
                BeginContext(212, 1156, true);
                WriteLiteral(@"
            <div class=""col-md-3"">
                <label for=""DataInicio"" class=""control-label"">Data da Compra - Inicio :</label>
                <input type=""date"" name=""DataInicio"" id=""DataInicio"" class=""form-control"" />
            </div>
            <div class=""col-md-3"">
                <label for=""DataFim"" class=""control-label"">Fim</label>
                <input type=""date"" name=""DataFim"" id=""DataFim"" class=""form-control"" />
            </div>
            <div class=""col-md-2"">
                <label for=""PrecoInicial"" class=""control-label"">Preço da Compra - Inicio </label>
                <input type=""number"" name=""PrecoInicial"" id=""PrecoInicial"" class=""form-control"" />
            </div>
            <div class=""col-md-2"">
                <label for=""PrecoFinal"" class=""control-label"">Fim</label>
                <input type=""number"" name=""PrecoFinal"" id=""PrecoFinal"" class=""form-control"" />
            </div>
            <div class=""col-md-2"">
                <br />
                <");
                WriteLiteral("input name=\"botao\" type=\"button\" value=\"Buscar\" onclick=\"pesquisaDeCompras()\" class=\"btn btn-default\">\r\n            </div>\r\n        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1375, 68, true);
            WriteLiteral("\r\n    </div>\r\n</fieldset>\r\n\r\n<div id=\"resultadoDaBusca\">\r\n\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
