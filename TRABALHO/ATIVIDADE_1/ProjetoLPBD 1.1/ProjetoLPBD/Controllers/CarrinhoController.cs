using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using ProjetoLPBD.DAOs;
using ProjetoLPBD.Models;

namespace ProjetoLPBD.Controllers
{
    public class CarrinhoController : Controller
    {
        public IActionResult AdicionarCarrinho(int jogoId)
        {
            List<CarrinhoViewModel> carrinho = ObtemCarrinhoNoBanco();

            foreach (CarrinhoViewModel item in carrinho)
            {
                if (item.IdJogo == jogoId)
                {
                    //Exibir mensagem para o usuário? Devia haver uma checagem para isso antes, não?
                    throw new Exception("O jogo já existia no carrinho!!!");
                }
            }

            JogoDAO jogoDAO = new JogoDAO();
            JogoViewModel jogoModel = jogoDAO.Consultar(jogoId);

            CarrinhoViewModel carrinhoModel = new CarrinhoViewModel()
            {
                IdJogo = jogoId,
                IdUsuario = Convert.ToInt32(HttpContext.Session.GetString("IdUsuario")),
                Nome = jogoModel.Nome,
                Preco = jogoModel.Preco
            };

            CarrinhoDAO carrinhoDAO = new CarrinhoDAO();
            carrinhoDAO.Inserir(carrinhoModel);

            return RedirectToAction("Visualizar", "Carrinho");
        }

        /*
        private List<CarrinhoViewModel> ObtemCarrinhoNaSession()
        {
            List<CarrinhoViewModel> carrinho = new List<CarrinhoViewModel>();
            string carrinhoJson = HttpContext.Session.GetString("carrinho");
            if (carrinhoJson != null)
                carrinho = JsonConvert.DeserializeObject<List<CarrinhoViewModel>>(carrinhoJson);

            return carrinho;
        }
        */

        private List<CarrinhoViewModel> ObtemCarrinhoNoBanco()
        {
            CarrinhoDAO dao = new CarrinhoDAO();
            int idUsuario = Convert.ToInt32(HttpContext.Session.GetString("IdUsuario"));
            return dao.Listar(idUsuario);

        }

        public IActionResult Visualizar()
        {
            JogoDAO dao = new JogoDAO();
            List<CarrinhoViewModel> carrinho = ObtemCarrinhoNoBanco();

            foreach(CarrinhoViewModel item in carrinho)
            {
                JogoViewModel jogo = dao.Consultar(item.IdJogo);
                //Preenche imagem em base 64
            }

            return View(carrinho);
        }

        public IActionResult EfetuarPedido()
        {
            using (var transacao = new System.Transactions.TransactionScope())
            {
                CompraViewModel compra = new CompraViewModel
                {
                    IdUsuario = Convert.ToInt32(HttpContext.Session.GetString("IdUsuario"))
                };
                CompraDAO compraDAO = new CompraDAO();
                int idCompra = compraDAO.Inserir(compra);
                //A trigger do banco de dados irá automaticamente adicionar os itens do carrinho nesta compra.

                transacao.Complete();
            }

            return RedirectToAction("Loja", "Home");
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
                ViewBag.Logado = true;
                ViewBag.Nome = HttpContext.Session.GetString("Nickname");
                ViewBag.IdUsuario = @Convert.ToInt32(HttpContext.Session.GetString("IdUsuario"));
                base.OnActionExecuting(context);
            }
        }

        public IActionResult Apagar(int id)
        {
            int idUsuario = Convert.ToInt32(HttpContext.Session.GetString("IdUsuario"));
            CarrinhoDAO dao = new CarrinhoDAO();
            dao.Apagar(idUsuario, id);
            return RedirectToAction("Visualizar");
        }
    }
}