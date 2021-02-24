using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoLPBD.DAOs;
using ProjetoLPBD.Models;

namespace ProjetoLPBD.Controllers
{
    public class JogoController : PadraoController<JogoViewModel>
    {
        public JogoController()
        {
            DAO = new JogoDAO();
            GeraProximoId = false;
        }

        protected override void ValidaDados(JogoViewModel model, string operacao)
        {
            if (string.IsNullOrEmpty(model.Nome))
            {
                ModelState.AddModelError("Nome", "Preencha este campo!");
            }
            if (model.Preco <= 0 || model.Preco > 9999)
            {
                ModelState.AddModelError("Preco", "Preço inserido é inválido!");
            }
            if (string.IsNullOrEmpty(model.Descricao))
            {
                ModelState.AddModelError("Descricao", "Preencha este campo!");
            }
            if (model.IdCategoria == 0)
            {
                ModelState.AddModelError("IdCategoria", "Escolha uma categoria!");
            }
            if (model.IdPublicadora == 0)
            {
                ModelState.AddModelError("IdPublicadora", "Escolha uma publicadora!");
            }
            if (model.IdDesenvolvedora == 0)
            {
                ModelState.AddModelError("IdDesenvolvedora", "Escolha uma desenvolvedora!");
            }
            if (model.ImagemEmBase64.Length > 2 * 1024 * 1024)
            {
                ModelState.AddModelError("Imagem", "Escolha uma imagem com menos de 2mb!");
            }

            if (operacao == "C")
            {
                JogoDAO dao = new JogoDAO();

                if (ModelState.IsValid)
                {
                    foreach (JogoViewModel jogo in dao.Listar())
                    {
                        if (jogo.Nome.ToLower() == model.Nome.ToLower())
                        {
                            ModelState.AddModelError("Nome", "Jogo já existe!");
                        }
                    }
                }
            }

            if (ModelState.IsValid)
            {
                //esse A de alterar
                if (operacao == "A" && model.Imagem == null)
                {
                    //essa parte do DAO.Consultar
                    JogoViewModel jogo = DAO.Consultar(model.Id);
                    model.ImagemEmByte = jogo.ImagemEmByte;
                }
                else
                {
                    model.ImagemEmByte = HelperControllers.ConvertImageToByte(model.Imagem);
                }
            }
            
        }

        protected override void PreencheDadosParaView(string operacao, JogoViewModel model)
        {
            base.PreencheDadosParaView(operacao, model);

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
        }       
    }
}
