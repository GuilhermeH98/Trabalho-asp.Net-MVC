using ProjetoLPBD.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLPBD.DAOs
{
    public class CompraDAO : PadraoDAO<CompraViewModel>
    {
        protected override SqlParameter[] CriaParametros(CompraViewModel model)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("Id", model.Id),
                new SqlParameter("formapagamento", DBNull.Value), //Trocar quando for programado!!!!!!!
                new SqlParameter("idUsuario", model.IdUsuario)
            };

            return parametros;
        }

        protected override CompraViewModel MontaModel(DataRow registro)
        {
            CompraViewModel model = new CompraViewModel
            {
                Id = Convert.ToInt32(registro["idCompra"]),
                ValorTotal = Convert.ToDouble(registro["precoTotal"]),
                //formaPagamento 
                Data = Convert.ToDateTime(registro["dataCompra"]),
                IdUsuario = Convert.ToInt32(registro["idUsuario"])
            };

            return model;
        }

        protected override void SetTabela()
        {
            Tabela = "Compra";
            ChaveIdentity = true;
        }

        public List<CompraViewModel> Pesquisar (int idUsuario, DateTime dataInicio, DateTime dataFim, double precoInicial, double precoFinal)
        {            
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("idUsuario", idUsuario),
                new SqlParameter("dataInicio", dataInicio),
                new SqlParameter("dataFim", dataFim.AddHours(23).AddMinutes(59).AddSeconds(59)),
                new SqlParameter("precoInicial", precoInicial),
                new SqlParameter("precoFinal", precoFinal)
            };

            if (parametros[1].Value == null || parametros[1].Value.ToString() == "01/01/0001 00:00:00")
                parametros[1].Value = DBNull.Value;
            if (parametros[2].Value == null || parametros[2].Value.ToString() == "01/01/0001 23:59:59")
                parametros[2].Value = DBNull.Value;
            if(parametros[3].Value == null || (double) parametros[3].Value == 0)
                parametros[3].Value = DBNull.Value;
            if (parametros[4].Value == null || (double)parametros[4].Value == 0)
                parametros[4].Value = DBNull.Value;

            DataTable tabela = HelperDAO.ExecutaProcSelect("sp_PesquisaCompras", parametros);

            List<CompraViewModel> lista = new List<CompraViewModel>();
            foreach (DataRow registro in tabela.Rows)
            {
                lista.Add(MontaModel(registro));
            }
            return lista;
        }

        public List<JogoViewModel> ConsultaItensCompra(int idCompra)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("idCompra", idCompra)
            };

            DataTable tabela = HelperDAO.ExecutaProcSelect("spListagemItensCompra", parametros);

            List<JogoViewModel> lista = new List<JogoViewModel>();
            foreach (DataRow registro in tabela.Rows)
            {
                JogoViewModel jogo = new JogoViewModel();
                jogo.Id = Convert.ToInt32(registro["idJogo"]);
                jogo.Nome = registro["nomeJogo"].ToString();
                lista.Add(jogo);
            }

            return lista;
        }
    }
}
