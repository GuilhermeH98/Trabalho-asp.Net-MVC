using ProjetoLPBD.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLPBD.DAOs
{
    public class JogoDAO : PadraoDAO<JogoViewModel>
    {
        protected override SqlParameter[] CriaParametros(JogoViewModel model)
        {
            object imgJogo = model.ImagemEmByte;
            if (imgJogo == null)
                imgJogo = DBNull.Value;

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("Id",model.Id),
                new SqlParameter("Nome",model.Nome),
                new SqlParameter("Preco", model.Preco),
                new SqlParameter("Descricao",model.Descricao),
                new SqlParameter("IdCategoria",model.IdCategoria),
                new SqlParameter("IdDesenvolvedora",model.IdDesenvolvedora),
                new SqlParameter("IdPublicadora", model.IdPublicadora),
                new SqlParameter("imgJogo", imgJogo)
            };

            return parametros;
        }

        protected override JogoViewModel MontaModel(DataRow registro)
        {
            JogoViewModel model = new JogoViewModel()
            {
                Id = Convert.ToInt32(registro["idJogo"]),
                Nome = registro["nomeJogo"].ToString(),
                Preco = Convert.ToDouble(registro["precoJogo"]),
                Descricao = registro["descricaoJogo"].ToString(),
                IdCategoria = Convert.ToInt32(registro["idCategoria"]),
                IdDesenvolvedora = Convert.ToInt32(registro["idDesenvolvedora"]),
                IdPublicadora = Convert.ToInt32(registro["idPublicadora"])
            };

            if (registro["imgJogo"] != DBNull.Value)
                model.ImagemEmByte = registro["imgJogo"] as byte[];

            CategoriaDAO categoriaDAO = new CategoriaDAO();
            CategoriaViewModel categoria = categoriaDAO.Consultar(model.IdCategoria);
            model.NomeCategoria = categoria.Descricao;

            PublicadoraDAO publicadoraDAO = new PublicadoraDAO();
            PublicadoraViewModel publicadora = publicadoraDAO.Consultar(model.IdPublicadora);
            model.NomePublicadora = publicadora.Nome;

            DesenvolvedoraDAO desenvolvedoraDAO = new DesenvolvedoraDAO();
            DesenvolvedoraViewModel desenvolvedora = desenvolvedoraDAO.Consultar(model.IdDesenvolvedora);
            model.NomeDesenvolvedora = desenvolvedora.Nome;

            return model;
        }

        protected override void SetTabela()
        {
            Tabela = "Jogo";
        }

        public List<JogoViewModel> Pesquisar(string nome, double preco, int categoria, int publicadora, int desenvolvedora)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("Nome", nome),
                new SqlParameter("Preco", preco),
                new SqlParameter("Categoria", categoria),
                new SqlParameter("Publicadora", publicadora),
                new SqlParameter("Desenvolvedora", desenvolvedora)
            };

            if (string.IsNullOrEmpty(nome))
            {
                parametros[0].Value = "";
            }
            if (preco == 0)
                parametros[1].Value = DBNull.Value;            

            DataTable tabela = HelperDAO.ExecutaProcSelect("sp_pesquisaJogos", parametros);

            List<JogoViewModel> lista = new List<JogoViewModel>();
            foreach (DataRow registro in tabela.Rows)
            {
                lista.Add(MontaModel(registro));
            }
            return lista;
        }
    }
}
