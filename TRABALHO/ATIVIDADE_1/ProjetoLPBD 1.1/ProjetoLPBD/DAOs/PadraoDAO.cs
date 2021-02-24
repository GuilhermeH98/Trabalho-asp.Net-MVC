using ProjetoLPBD.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLPBD.DAOs
{
    public abstract class PadraoDAO<T> where T : PadraoViewModel
    {
        protected PadraoDAO()
        {
            SetTabela();
        }
        protected string Tabela { get; set; }
        protected string Chave { get; set; } = "id";
        protected abstract SqlParameter[] CriaParametros(T model);
        protected abstract T MontaModel(DataRow registro);
        protected abstract void SetTabela();
        protected bool ChaveIdentity { get; set; } = false;

        public virtual int Inserir(T model)
        {
            return HelperDAO.ExecutaProc("spInsert_" + Tabela, CriaParametros(model), ChaveIdentity);
        }

        public virtual void Alterar(T model)
        {
            HelperDAO.ExecutaProc("spUpdate_" + Tabela, CriaParametros(model));
        }

        public virtual void Apagar(int id)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("id", id),
                new SqlParameter("tabela", Tabela)
            };
            HelperDAO.ExecutaProc("spDelete", parametros);
        }

        public virtual T Consultar(int id)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("id", id),
                new SqlParameter("tabela", Tabela)
            };

            DataTable tabela = HelperDAO.ExecutaProcSelect("spConsulta", parametros);
            if (tabela.Rows.Count == 0)
                return null;
            else
                return MontaModel(tabela.Rows[0]);

        }

        public virtual int ProximoId()
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("Tabela", Tabela)
            };
            DataTable tabela = HelperDAO.ExecutaProcSelect("spProximoId", parametros);
            return Convert.ToInt32(tabela.Rows[0][0]);
        }

        public virtual List<T> Listar()
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("tabela", Tabela),
                new SqlParameter("ordem", "1")
            };
            DataTable tabela = HelperDAO.ExecutaProcSelect("spListagem", parametros);
            List<T> lista = new List<T>();
            foreach (DataRow registro in tabela.Rows)
            {
                lista.Add(MontaModel(registro));
            }
            return lista;
        }
    }
}
