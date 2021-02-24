using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProjetoLPBD.DAOs;
using ProjetoLPBD.Models;

namespace ProjetoLPBD.Controllers
{
    public class CompraController : Controller
    {
        public virtual IActionResult Listar()
        {
            CompraDAO dao = new CompraDAO();
            List<CompraViewModel> lista = dao.Listar();
            return View(lista);
        }

        public PartialViewResult Pesquisar(DateTime dataInicio, DateTime dataFim, double precoInicial, double precoFinal)
        {
            CompraDAO dao = new CompraDAO();
            int idUsuario = Convert.ToInt32(HttpContext.Session.GetString("IdUsuario"));
            List<CompraViewModel> lista = dao.Pesquisar(idUsuario, dataInicio, dataFim, precoInicial, precoFinal);

            foreach (CompraViewModel compra in lista)
            {
                compra.itensCompra = dao.ConsultaItensCompra(compra.Id);
            }

            return PartialView("pvListarCompras", lista);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (HttpContext.Session.GetString("Administrador") == "True")
            {
                context.Result = RedirectToAction("Administradores", "Home");
            }

            if (!HelperControllers.VerificaUserLogado(HttpContext.Session))
                context.Result = RedirectToAction("Index", "Login");
            else
            {
                ViewBag.Administrador = HelperControllers.VerificaAdministrador(HttpContext.Session);
                ViewBag.Logado = true;
                if (ViewBag.Logado)
                {
                    ViewBag.Nome = HttpContext.Session.GetString("Nickname");
                    ViewBag.IdUsuario = @Convert.ToInt32(HttpContext.Session.GetString("IdUsuario"));
                }
                base.OnActionExecuting(context);
            }
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                CompraDAO dao = new CompraDAO();
                dao.Apagar(id);
                return RedirectToAction("Listar");
            }
            catch (Exception erro)
            {
                return RedirectToAction("Listar");
            }
        }
    }

}