#pragma checksum "C:\Users\Harich\Downloads\ProjetoLPBD 1.2\ProjetoLPBD 1.1\ProjetoLPBD\Views\Home\Administradores.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "44b8e4fae8a0e32e5359d285d610f2bfb0fdceea"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Administradores), @"mvc.1.0.view", @"/Views/Home/Administradores.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Administradores.cshtml", typeof(AspNetCore.Views_Home_Administradores))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44b8e4fae8a0e32e5359d285d610f2bfb0fdceea", @"/Views/Home/Administradores.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"151bfe248a3fd2efdce1a9a4421ca9fb1df2579c", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Administradores : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\Harich\Downloads\ProjetoLPBD 1.2\ProjetoLPBD 1.1\ProjetoLPBD\Views\Home\Administradores.cshtml"
  
    ViewData["Title"] = "Área dos Administradores";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(109, 873, true);
            WriteLiteral(@"
<h2>Área dos Administradores</h2>


<br />
<a class=""btn btn-primary form-control"" href=""/Desenvolvedora/Criar"">Cadastrar novos Desenvolvedores</a>
<br />
<a class=""btn btn-primary form-control"" href=""/Desenvolvedora/Listar"">Listar Desenvolvedores</a>
<br />
<br />
<a class=""btn btn-primary form-control"" href=""/Publicadora/Criar"">Cadastrar novas Publicadoras</a>
<br />
<a class=""btn btn-primary form-control"" href=""/Publicadora/Listar"">Listar Publicadoras</a>
<br />
<br />
<a class=""btn btn-primary form-control"" href=""/Categoria/Criar"">Cadastrar novas Categorias</a>
<br />
<a class=""btn btn-primary form-control"" href=""/Categoria/Listar"">Listar Categorias</a>
<br />
<br />
<a class=""btn btn-primary form-control"" href=""/Jogo/Criar"">Cadastrar novos Jogos</a>
<br />
<a class=""btn btn-primary form-control"" href=""/Jogo/Listar"">Listar Jogos</a>
");
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
