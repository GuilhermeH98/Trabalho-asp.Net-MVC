#pragma checksum "C:\Users\Harich\Downloads\ProjetoLPBD 1.2\ProjetoLPBD 1.1\ProjetoLPBD\Views\Carrinho\Visualizar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5c231350f1b5790a598a0581e0fdae65e714a008"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Carrinho_Visualizar), @"mvc.1.0.view", @"/Views/Carrinho/Visualizar.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Carrinho/Visualizar.cshtml", typeof(AspNetCore.Views_Carrinho_Visualizar))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c231350f1b5790a598a0581e0fdae65e714a008", @"/Views/Carrinho/Visualizar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"151bfe248a3fd2efdce1a9a4421ca9fb1df2579c", @"/Views/_ViewImports.cshtml")]
    public class Views_Carrinho_Visualizar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<CarrinhoViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Harich\Downloads\ProjetoLPBD 1.2\ProjetoLPBD 1.1\ProjetoLPBD\Views\Carrinho\Visualizar.cshtml"
  
    ViewData["Title"] = "Visualizar";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(125, 217, true);
            WriteLiteral("\r\n<h2>Carrinho de Compras</h2>\r\n<br />\r\n\r\n<table class=\"table table-responsive table-striped\">\r\n    <tr>\r\n        <th>Jogo</th>\r\n        <th>Adicionado em</th>\r\n        <th>Preço</th>\r\n        <th></th>\r\n    </tr>\r\n\r\n");
            EndContext();
#line 18 "C:\Users\Harich\Downloads\ProjetoLPBD 1.2\ProjetoLPBD 1.1\ProjetoLPBD\Views\Carrinho\Visualizar.cshtml"
     foreach (CarrinhoViewModel item in Model)
    {

#line default
#line hidden
            BeginContext(397, 30, true);
            WriteLiteral("        <tr>\r\n            <td>");
            EndContext();
            BeginContext(428, 9, false);
#line 21 "C:\Users\Harich\Downloads\ProjetoLPBD 1.2\ProjetoLPBD 1.1\ProjetoLPBD\Views\Carrinho\Visualizar.cshtml"
           Write(item.Nome);

#line default
#line hidden
            EndContext();
            BeginContext(437, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(461, 9, false);
#line 22 "C:\Users\Harich\Downloads\ProjetoLPBD 1.2\ProjetoLPBD 1.1\ProjetoLPBD\Views\Carrinho\Visualizar.cshtml"
           Write(item.Data);

#line default
#line hidden
            EndContext();
            BeginContext(470, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(494, 29, false);
#line 23 "C:\Users\Harich\Downloads\ProjetoLPBD 1.2\ProjetoLPBD 1.1\ProjetoLPBD\Views\Carrinho\Visualizar.cshtml"
           Write(item.Preco.ToString("R$#.00"));

#line default
#line hidden
            EndContext();
            BeginContext(523, 48, true);
            WriteLiteral("</td>\r\n            <th><a class=\"btn btn-danger\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 571, "\"", 631, 4);
            WriteAttributeValue("", 578, "javascript:confirmaExclusao(", 578, 28, true);
#line 24 "C:\Users\Harich\Downloads\ProjetoLPBD 1.2\ProjetoLPBD 1.1\ProjetoLPBD\Views\Carrinho\Visualizar.cshtml"
WriteAttributeValue("", 606, item.IdJogo, 606, 12, false);

#line default
#line hidden
            WriteAttributeValue("", 618, ",", 618, 1, true);
            WriteAttributeValue(" ", 619, "\'Carrinho\')", 620, 12, true);
            EndWriteAttribute();
            BeginContext(632, 33, true);
            WriteLiteral(">Apagar</a></th>\r\n        </tr>\r\n");
            EndContext();
#line 26 "C:\Users\Harich\Downloads\ProjetoLPBD 1.2\ProjetoLPBD 1.1\ProjetoLPBD\Views\Carrinho\Visualizar.cshtml"
    }

#line default
#line hidden
            BeginContext(672, 81, true);
            WriteLiteral("\r\n</table>\r\n<br />\r\n\r\n<a class=\"btn btn-default\" href=\"/Home/Loja\">Retornar</a>\r\n");
            EndContext();
#line 32 "C:\Users\Harich\Downloads\ProjetoLPBD 1.2\ProjetoLPBD 1.1\ProjetoLPBD\Views\Carrinho\Visualizar.cshtml"
 if (Model.Count > 0)
{

#line default
#line hidden
            BeginContext(779, 84, true);
            WriteLiteral("    <a class=\"btn btn-success\" href=\"/Carrinho/EfetuarPedido\">Finalizar Compra</a>\r\n");
            EndContext();
#line 35 "C:\Users\Harich\Downloads\ProjetoLPBD 1.2\ProjetoLPBD 1.1\ProjetoLPBD\Views\Carrinho\Visualizar.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<CarrinhoViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
