using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoLPBD.DAOs;
using ProjetoLPBD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ProjetoLPBD.Controllers
{
    abstract public class PadraoController<T> : Controller where T : PadraoViewModel
    {
        protected PadraoDAO<T> DAO { get; set; }
        protected bool GeraProximoId { get; set; }

        public virtual IActionResult Listar()
        {
            List<T> lista = DAO.Listar();
            return View(lista);
        }

        public IActionResult Criar()
        {
            ViewBag.Operacao = "C";
            T model = Activator.CreateInstance(typeof(T)) as T;
            PreencheDadosParaView("C", model);
            return View("Cadastro", model);
        }

        protected virtual void PreencheDadosParaView(string operacao, T model)
        {
            if (GeraProximoId && operacao == "C")
                model.Id = DAO.ProximoId();
        }

        public virtual IActionResult Salvar(T model, string operacao)
        {
            try
            {
                ValidaDados(model, operacao);
                if (ModelState.IsValid)
                {
                    if (operacao == "C")
                        DAO.Inserir(model);
                    else
                        DAO.Alterar(model);

                    return RedirectToAction("Listar");
                }
                else
                {
                    ViewBag.Operacao = operacao;
                    PreencheDadosParaView(operacao, model);
                    return View("Cadastro", model);
                }
            }
            catch (Exception erro)
            {
                ViewBag.Erro = "Ocorreu um erro: " + erro.Message;
                ViewBag.Operacao = operacao;
                PreencheDadosParaView(operacao, model);
                return View("Cadastro", model);
            }
        }

        protected abstract void ValidaDados(T model, string operacao);

        public virtual IActionResult Alterar(int id)
        {
            try
            {
                ViewBag.Operacao = "A";
                T model = DAO.Consultar(id);
                if (model == null)
                    return RedirectToAction("Listar");
                else
                {
                    PreencheDadosParaView("A", model);
                    return View("Cadastro", model);
                }
            }
            catch
            {
                return RedirectToAction("Listar");
            }
        }

        public virtual IActionResult Apagar(int id)
        {
            try
            {
                DAO.Apagar(id);
                return RedirectToAction("Listar");
            }
            catch
            {
                List<T> lista = DAO.Listar();
                ViewBag.Erro = "Ocorreu um erro. Verifique se esse registro já está sendo usado!";
                return View("Listar", lista);
            }
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!HelperControllers.VerificaUserLogado(HttpContext.Session))
                context.Result = RedirectToAction("Index", "Login");
            else
            {
                ViewBag.Administrador = HelperControllers.VerificaAdministrador(HttpContext.Session);
                ViewBag.Nome = HttpContext.Session.GetString("Nickname");
                ViewBag.Logado = true;
                ViewBag.IdUsuario = @Convert.ToInt32(HttpContext.Session.GetString("IdUsuario"));
                base.OnActionExecuting(context);
            }
        }
    }
}