#pragma checksum "C:\Users\Harich\Downloads\ProjetoLPBD 1.2\ProjetoLPBD 1.1\ProjetoLPBD\Views\Home\pvBuscaJogo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "90fc554a5a52797628294c052ed7d0ea8ddc9e30"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_pvBuscaJogo), @"mvc.1.0.view", @"/Views/Home/pvBuscaJogo.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/pvBuscaJogo.cshtml", typeof(AspNetCore.Views_Home_pvBuscaJogo))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"90fc554a5a52797628294c052ed7d0ea8ddc9e30", @"/Views/Home/pvBuscaJogo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"151bfe248a3fd2efdce1a9a4421ca9fb1df2579c", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_pvBuscaJogo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<JogoViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(28, 353, true);
            WriteLiteral(@"
<br />
<br />
<br />
<table class=""table table-responsive table-striped"">
    <thead>
        <tr>
            <th></th>
            <th>Nome</th>
            <th>Preço</th>
            <th>Categoria</th>
            <th>Publicadora</th>
            <th>Desenvolvedora</th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 19 "C:\Users\Harich\Downloads\ProjetoLPBD 1.2\ProjetoLPBD 1.1\ProjetoLPBD\Views\Home\pvBuscaJogo.cshtml"
         foreach (JogoViewModel item in Model)
        {

#line default
#line hidden
            BeginContext(440, 50, true);
            WriteLiteral("        <tr>\r\n            <th><img id=\"imgPreview\"");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 490, "\"", 539, 2);
            WriteAttributeValue("", 496, "data:image/jpeg;base64,", 496, 23, true);
#line 22 "C:\Users\Harich\Downloads\ProjetoLPBD 1.2\ProjetoLPBD 1.1\ProjetoLPBD\Views\Home\pvBuscaJogo.cshtml"
WriteAttributeValue("", 519, item.ImagemEmBase64, 519, 20, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(540, 58, true);
            WriteLiteral(" class=\"img-responsive\" width=\"50\"></th>\r\n            <th>");
            EndContext();
            BeginContext(599, 9, false);
#line 23 "C:\Users\Harich\Downloads\ProjetoLPBD 1.2\ProjetoLPBD 1.1\ProjetoLPBD\Views\Home\pvBuscaJogo.cshtml"
           Write(item.Nome);

#line default
#line hidden
            EndContext();
            BeginContext(608, 23, true);
            WriteLiteral("</th>\r\n            <th>");
            EndContext();
            BeginContext(632, 10, false);
#line 24 "C:\Users\Harich\Downloads\ProjetoLPBD 1.2\ProjetoLPBD 1.1\ProjetoLPBD\Views\Home\pvBuscaJogo.cshtml"
           Write(item.Preco);

#line default
#line hidden
            EndContext();
            BeginContext(642, 23, true);
            WriteLiteral("</th>\r\n            <th>");
            EndContext();
            BeginContext(666, 18, false);
#line 25 "C:\Users\Harich\Downloads\ProjetoLPBD 1.2\ProjetoLPBD 1.1\ProjetoLPBD\Views\Home\pvBuscaJogo.cshtml"
           Write(item.NomeCategoria);

#line default
#line hidden
            EndContext();
            BeginContext(684, 23, true);
            WriteLiteral("</th>\r\n            <th>");
            EndContext();
            BeginContext(708, 20, false);
#line 26 "C:\Users\Harich\Downloads\ProjetoLPBD 1.2\ProjetoLPBD 1.1\ProjetoLPBD\Views\Home\pvBuscaJogo.cshtml"
           Write(item.NomePublicadora);

#line default
#line hidden
            EndContext();
            BeginContext(728, 23, true);
            WriteLiteral("</th>\r\n            <th>");
            EndContext();
            BeginContext(752, 23, false);
#line 27 "C:\Users\Harich\Downloads\ProjetoLPBD 1.2\ProjetoLPBD 1.1\ProjetoLPBD\Views\Home\pvBuscaJogo.cshtml"
           Write(item.NomeDesenvolvedora);

#line default
#line hidden
            EndContext();
            BeginContext(775, 49, true);
            WriteLiteral("</th>\r\n            <th><a class=\"btn btn-default\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 824, "\"", 853, 2);
            WriteAttributeValue("", 831, "/Home/Jogo?Id=", 831, 14, true);
#line 28 "C:\Users\Harich\Downloads\ProjetoLPBD 1.2\ProjetoLPBD 1.1\ProjetoLPBD\Views\Home\pvBuscaJogo.cshtml"
WriteAttributeValue("", 845, item.Id, 845, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(854, 32, true);
            WriteLiteral(">Abrir</a></th>\r\n        </tr>\r\n");
            EndContext();
#line 30 "C:\Users\Harich\Downloads\ProjetoLPBD 1.2\ProjetoLPBD 1.1\ProjetoLPBD\Views\Home\pvBuscaJogo.cshtml"
        }

#line default
#line hidden
            BeginContext(897, 34, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n<br />\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<JogoViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
