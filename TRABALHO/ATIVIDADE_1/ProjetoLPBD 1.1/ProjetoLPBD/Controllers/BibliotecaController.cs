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
    public class BibliotecaController : Controller
    {
        public virtual IActionResult Listar()
        {
            BibliotecaDAO dao = new BibliotecaDAO();
            List<JogoViewModel> jogos = dao.Consultar(HttpContext.Session.GetString("IdUsuario"));

            return View(jogos);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(HttpContext.Session.GetString("Administrador") == "True")
            {
                context.Result = RedirectToAction("Administradores", "Home");
            }

            if (!HelperControllers.VerificaUserLogado(HttpContext.Session))
                context.Result = RedirectToAction("Index", "Login");
            else
            {
                ViewBag.Logado = true;
                ViewBag.Nome = HttpContext.Session.GetString("Nickname");
                ViewBag.IdUsuario = @Convert.ToInt32(HttpContext.Session.GetString("IdUsuario"));
                base.OnActionExecuting(context);
            }
        }
    }
}