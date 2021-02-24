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
    public class DesenvolvedoraController : PadraoController<DesenvolvedoraViewModel>
    {
        public DesenvolvedoraController()
        {
            DAO = new DesenvolvedoraDAO();
            GeraProximoId = false;
        }
        protected override void ValidaDados(DesenvolvedoraViewModel model, string operacao)
        {
            if (string.IsNullOrEmpty(model.Nome))
                ModelState.AddModelError("Nome", "Este campo deve ser preenchido!");

            DesenvolvedoraDAO dao = new DesenvolvedoraDAO();

            if (ModelState.IsValid && operacao == "C")
            {
                foreach (DesenvolvedoraViewModel desenvolvedora in dao.Listar())
                {
                    if (desenvolvedora.Nome.ToLower() == model.Nome.ToLower())
                    {
                        ModelState.AddModelError("Nome", "Desenvolvedora já existe!");
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