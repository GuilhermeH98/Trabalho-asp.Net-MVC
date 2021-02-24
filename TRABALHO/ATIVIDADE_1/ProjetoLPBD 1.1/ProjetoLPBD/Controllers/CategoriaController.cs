using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoLPBD.Models;
using ProjetoLPBD.DAOs;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;

namespace ProjetoLPBD.Controllers
{
    public class CategoriaController : PadraoController<CategoriaViewModel>
    {
        public CategoriaController()
        {
            DAO = new CategoriaDAO();
            GeraProximoId = false;
        }

        protected override void ValidaDados(CategoriaViewModel model, string operacao)
        {
            if (string.IsNullOrEmpty(model.Descricao))
            {
                ModelState.AddModelError("Descricao", "Este campo deve ser preenchido!");
            }

            CategoriaDAO dao = new CategoriaDAO();

            if (ModelState.IsValid && operacao == "C")
            {
                foreach (CategoriaViewModel categoria in dao.Listar())
                {
                    if (categoria.Descricao.ToLower() == model.Descricao.ToLower())
                    {
                        ModelState.AddModelError("Descricao", "Categoria já existe!");
                    }
                }
            }           
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            if (HttpContext.Session.GetString("Administrador") == "False")
            {
                context.Result = RedirectToAction("Loja", "Home");
            }            
        }
    }
}