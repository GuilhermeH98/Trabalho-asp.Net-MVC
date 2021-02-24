using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoLPBD.DAOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoLPBD.Models;

namespace ProjetoLPBD.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult FazLogin(string usuario, string senha)
        {
            LoginDAO dao = new LoginDAO();
            UsuarioViewModel usuarioModel =  dao.Consultar(usuario, senha);

            if (usuarioModel == null) 
            {
                ViewBag.Erro = "Usuário ou senha inválidos!";
                return View("Index");
                
            }
            else
            {
                HttpContext.Session.SetString("Logado", "true");
                HttpContext.Session.SetString("IdUsuario", usuarioModel.Id.ToString());
                HttpContext.Session.SetString("Nickname", usuarioModel.Nickname);
                HttpContext.Session.SetString("Administrador", usuarioModel.Administrador.ToString());

                if (usuarioModel.Administrador)
                {
                    return RedirectToAction("Administradores", "Home");
                }
                else
                {
                    return RedirectToAction("Loja", "Home");
                }                
            }
        }
        public IActionResult LogOff()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Loja", "Home");
        }
    }
}