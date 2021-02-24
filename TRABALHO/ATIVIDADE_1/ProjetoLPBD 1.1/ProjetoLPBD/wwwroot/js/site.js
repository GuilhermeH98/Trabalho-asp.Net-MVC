// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function confirmaExclusao(id, controller) {
    if (confirm('Deseja mesmo apagar este registro?'))
        location.href = '/' + controller + '/Apagar?id=' + id;
}

function exibirImagem() {
    var oFReader = new FileReader();
    oFReader.readAsDataURL(document.getElementById("Imagem").files[0]);
    oFReader.onload = function (oFREvent) {
        document.getElementById("imgPreview").src = oFREvent.target.result;
    };
} 

function pesquisaDeCompras() {
    var dataI = document.getElementById("DataInicio").value;
    var dataF = document.getElementById("DataFim").value;
    var precoI = document.getElementById("PrecoInicial").value;
    var precoF = document.getElementById("PrecoFinal").value;

    $.ajax({
        type: 'POST',
        url: "/Compra/Pesquisar",
        cache: false,
        data: { "dataInicio": dataI, "dataFim": dataF, "precoInicial": precoI, "precoFinal": precoF },
        success: function (informacoes) {
            var elemento = document.getElementById("resultadoDaBusca");
            var dados = informacoes;
            elemento.innerHTML = dados;
        }
    })
}

function pesquisaDeUsuarios() {
    var n = document.getElementById("Nome").value;
    var t = document.getElementById("Tipo").value;

    $.ajax({
        type: 'POST',
        url: "/Usuario/Pesquisar",
        cache: false,
        data: { "nome": n, "tipo": t },
        success: function (informacoes) {
            var elemento = document.getElementById("resultadoDaBusca");
            var dados = informacoes;
            elemento.innerHTML = dados;
        }
    })
}

function pesquisaDeJogo() {
    var nom = document.getElementById("Nome").value;
    var prec = document.getElementById("Preco").value;
    var cat = document.getElementById("Categoria").value;
    var publ = document.getElementById("Publicadora").value;
    var desenv = document.getElementById("Desenvolvedora").value;

    $.ajax({
        type: 'POST',
        url: "/Home/Pesquisar",
        cache: false,
        data: { "nome": nom, "preco": prec, "categoria": cat, "publicadora": publ, "desenvolvedora": desenv },
        success: function (dados) {
            document.getElementById("resultadoDaBusca").innerHTML = dados;
        }
    })
}
