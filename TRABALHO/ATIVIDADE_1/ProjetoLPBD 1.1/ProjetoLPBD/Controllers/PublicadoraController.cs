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
    public class PublicadoraController : PadraoController<PublicadoraViewModel>
    {
        public PublicadoraController()
        {
            DAO = new PublicadoraDAO();
            GeraProximoId = false;
        }
        protected override void ValidaDados(PublicadoraViewModel model, string operacao)
        {
            if (string.IsNullOrEmpty(model.Nome))
                ModelState.AddModelError("Nome", "Este campo deve ser preenchido!");

            PublicadoraDAO dao = new PublicadoraDAO();

            if (ModelState.IsValid && operacao == "C")
            {
                foreach (PublicadoraViewModel publicadora in dao.Listar())
                {
                    if (publicadora.Nome.ToLower() == model.Nome.ToLower())
                    {
                        ModelState.AddModelError("Nome", "Publicadora já existe!");
                    }
                }
            }
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (HttpContext.Session.GetString("Administrador") == "False")
            {
                context.Result = RedirectToAction("Loja", "Home");
            }
            base.OnActionExecuting(context);
        }
    }
}