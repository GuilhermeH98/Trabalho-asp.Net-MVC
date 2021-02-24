using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoLPBD.DAOs;
using ProjetoLPBD.Models;

namespace ProjetoLPBD.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Administradores() //Não pode ficar aqui. Usuario não logado não pode ver essa tela
        {
            return View();
        }

        public IActionResult Loja()
        {
            JogoDAO DAO = new JogoDAO();
            List<JogoViewModel> lista = DAO.Listar();
            return View(lista);
        }

        public IActionResult Jogo(int id)
        {            
            string idUsuario = HttpContext.Session.GetString("IdUsuario");
            if (string.IsNullOrEmpty(idUsuario))
                idUsuario = "0";

            BibliotecaDAO bDao = new BibliotecaDAO();
            List<JogoViewModel> jogos = bDao.Consultar(idUsuario);

            CarrinhoDAO cDao = new CarrinhoDAO();
            List<CarrinhoViewModel> carrinho = cDao.Listar(Convert.ToInt32(idUsuario));

            foreach (JogoViewModel jogo in jogos)
            {
                if (jogo.Id == id)
                {
                    ViewBag.Possui = true;
                    break;
                }
            }

            foreach(CarrinhoViewModel item in carrinho)
            {
                if(item.IdJogo == id)
                {
                    ViewBag.EstaCarrinho = true;
                    break;
                }
            }

            JogoDAO DAO = new JogoDAO();
            JogoViewModel model = DAO.Consultar(id);
            return View(model);
        }

        public IActionResult Busca()
        {
            //Preencher informações para ListBox de Categorias
            CategoriaDAO categoriaDAO = new CategoriaDAO();

            ViewBag.Categorias = new List<SelectListItem>();
            ViewBag.Categorias.Add(new SelectListItem("Selecione uma categoria", "0"));

            foreach (CategoriaViewModel categoria in categoriaDAO.Listar())
            {
                ViewBag.Categorias.Add(new SelectListItem(categoria.Descricao, categoria.Id.ToString()));
            }

            //Preencher informações para ListBox de Publicadoras
            PublicadoraDAO publicadoraDAO = new PublicadoraDAO();

            ViewBag.Publicadoras = new List<SelectListItem>();
            ViewBag.Publicadoras.Add(new SelectListItem("Selecione uma publicadora", "0"));

            foreach (PublicadoraViewModel publicadora in publicadoraDAO.Listar())
            {
                ViewBag.Publicadoras.Add(new SelectListItem(publicadora.Nome, publicadora.Id.ToString()));
            }

            //Preencher informações para ListBox de Desenvolvedoras
            DesenvolvedoraDAO desenvolvedoraDAO = new DesenvolvedoraDAO();

            ViewBag.Desenvolvedoras = new List<SelectListItem>();
            ViewBag.Desenvolvedoras.Add(new SelectListItem("Selecione uma desenvolvedora", "0"));

            foreach (DesenvolvedoraViewModel desenvolvedora in desenvolvedoraDAO.Listar())
            {
                ViewBag.Desenvolvedoras.Add(new SelectListItem(desenvolvedora.Nome, desenvolvedora.Id.ToString()));
            }

            return View();
        }

        public PartialViewResult Pesquisar(string nome, double preco, int categoria, int publicadora, int desenvolvedora)
        {
            JogoDAO dao = new JogoDAO();
            List<JogoViewModel> lista = dao.Pesquisar(nome, preco, categoria, publicadora, desenvolvedora);

            return PartialView("pvBuscaJogo", lista);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewBag.Logado = HelperControllers.VerificaUserLogado(HttpContext.Session);
            ViewBag.Administrador = HelperControllers.VerificaAdministrador(HttpContext.Session);
            if (ViewBag.Logado)
            {
                ViewBag.Nome = HttpContext.Session.GetString("Nickname");
                ViewBag.IdUsuario = @Convert.ToInt32(HttpContext.Session.GetString("IdUsuario"));
            }
            base.OnActionExecuting(context);
        }
    }
}
