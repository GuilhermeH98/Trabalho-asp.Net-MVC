using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoLPBD.DAOs;
using ProjetoLPBD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;

namespace ProjetoLPBD.Controllers
{
    public class UsuarioController : PadraoController<UsuarioViewModel>
    {
        public UsuarioController()
        {
            DAO = new UsuarioDAO();
            GeraProximoId = false;
        }

        protected override void ValidaDados(UsuarioViewModel model, string operacao)
        {
            //Validar se o login não existe no banco

            if (string.IsNullOrEmpty(model.UserLogin) || model.UserLogin.Length < 3 || model.UserLogin.IndexOf('@') == -1)
            {
                ModelState.AddModelError("UserLogin", "Preencha com seu e-mail!");
            }            
            if (string.IsNullOrEmpty(model.Senha))
            {
                ModelState.AddModelError("Senha", "Campo senha deve ser preenchido!");
            }
            if (string.IsNullOrEmpty(model.Nickname))
            {
                ModelState.AddModelError("Nickname", "Campo nome deve ser preenchido!");
            }
           
            if (ModelState.IsValid && operacao == "C")
            {
                UsuarioDAO dao = new UsuarioDAO();
                foreach (UsuarioViewModel usuario in dao.Listar())
                {
                    if (usuario.UserLogin.ToLower() == model.UserLogin.ToLower())
                    {
                        ModelState.AddModelError("UserLogin", "E-mail já está cadastrado!");
                    }
                    if (usuario.Nickname == model.Nickname)
                    {
                        ModelState.AddModelError("Nickname", "Este nome já está em uso!");
                    }
                }
            }
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
        }


        //fazer o salvar

        public override IActionResult Salvar(UsuarioViewModel model, string operacao)
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

                    return RedirectToAction("Index","Login");
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

        public override IActionResult Listar()
        {
            ViewBag.Tipos = new List<SelectListItem>()
            {
                new SelectListItem("Ambos", "0"),
                new SelectListItem("Usuario", "1"),
                new SelectListItem("Administrador", "2")
            };
            return base.Listar();
        }

        public PartialViewResult Pesquisar(string nome, int tipo)
        {
            UsuarioDAO dao = new UsuarioDAO();
            List<UsuarioViewModel> lista = dao.Pesquisar(nome, tipo);

            return PartialView("pvListarUsuario", lista);
        }

        public override IActionResult Alterar(int id)
        {
            ViewBag.Operacao = "A";
            UsuarioViewModel model = DAO.Consultar(id);
            if (model == null)
                throw new Exception("Algo de muito errado não está certo!!!");
            else
            {
                PreencheDadosParaView("A", model);
                return View("Alterar", model);
            }
        }

        public override IActionResult Apagar(int id)
        {
            DAO.Apagar(id);
            HttpContext.Session.Clear();
            return RedirectToAction("Loja", "Home");
        }

        public IActionResult SalvarAlteracao(UsuarioViewModel model)
        {
            try
            {
                ValidaDados(model, "A");
                if (ModelState.IsValid)
                {
                    DAO.Alterar(model);

                    HttpContext.Session.SetString("Nickname", model.Nickname);
                    if (model.Administrador)
                    {
                        return RedirectToAction("Administradores", "Home");
                    }
                    else
                    {
                        return RedirectToAction("Loja", "Home");
                    }                    
                }
                else
                {
                    PreencheDadosParaView("A", model);
                    return View("Alterar", model);
                }
            }
            catch (Exception erro)
            {
                ViewBag.Erro = "Ocorreu um erro: " + erro.Message;
                PreencheDadosParaView("A", model);
                return View("Cadastro", model);
            }
        }
    }
}