using Microsoft.AspNetCore.Http;
using ProjetoLPBD.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLPBD.DAOs
{
    public class CarrinhoDAO : PadraoDAO<CarrinhoViewModel>
    {
        protected override SqlParameter[] CriaParametros(CarrinhoViewModel model)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("idJogo", model.IdJogo),
                new SqlParameter("idUsuario", model.IdUsuario),
                new SqlParameter("preco", model.Preco)
            };

            return parametros;
        }

        protected override CarrinhoViewModel MontaModel(DataRow registro)
        {
            CarrinhoViewModel model = new CarrinhoViewModel()
            {
                IdJogo = Convert.ToInt32(registro["idJogo"]),
                Data = Convert.ToDateTime(registro["dataAdicao"]),
                Preco = Convert.ToDouble(registro["precoItem"])
            };

            JogoDAO jogoDAO = new JogoDAO();
            model.Nome = jogoDAO.Consultar(model.IdJogo).Nome;

            return model;
        }

        protected override void SetTabela()
        {
            Tabela = "itemCarrinho";
        }

        public List<CarrinhoViewModel> Listar(int IdUsuario)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("idUsuario", IdUsuario)
            };
            DataTable tabela = HelperDAO.ExecutaProcSelect("spListagemCarrinho", parametros);
            List<CarrinhoViewModel> lista = new List<CarrinhoViewModel>();
            foreach (DataRow registro in tabela.Rows)
            {
                lista.Add(MontaModel(registro));
            }
            return lista;
        }

        public virtual void Apagar(int idUsuario, int idJogo)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("idUsuario", idUsuario),
                new SqlParameter("idJogo", idJogo)
            };
            HelperDAO.ExecutaProc("spDeleteItemCarrinho", parametros);
        }
    }
}
