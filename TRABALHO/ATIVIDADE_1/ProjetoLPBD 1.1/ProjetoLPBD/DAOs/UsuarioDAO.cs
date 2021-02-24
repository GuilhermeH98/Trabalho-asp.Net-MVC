using ProjetoLPBD.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLPBD.DAOs
{
    public class UsuarioDAO : PadraoDAO<UsuarioViewModel>
    {
        protected override SqlParameter[] CriaParametros(UsuarioViewModel model)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("Id", model.Id),
                new SqlParameter("Nickname",model.Nickname),
                new SqlParameter("UserLogin", model.UserLogin),
                new SqlParameter("Senha", model.Senha),
                new SqlParameter("Administrador", model.Administrador)
            };

            return parametros;
        }

        protected override UsuarioViewModel MontaModel(DataRow registro)
        {
            UsuarioViewModel model = new UsuarioViewModel()
            {
                Id = Convert.ToInt32(registro["IdUsuario"]),
                Nickname = registro["Nickname"].ToString(),
                UserLogin = registro["userLogin"].ToString(),
                Senha = registro["Senha"].ToString(),
                Administrador = Convert.ToBoolean(registro["Administrador"])
            };

            return model;
        }

        protected override void SetTabela()
        {
            Tabela = "Usuario";
        }

        public List<UsuarioViewModel> Pesquisar(string nome, int tipo)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("Nome", nome),
                new SqlParameter("Tipo", tipo)
            };

            if (string.IsNullOrEmpty(nome))
            {
                parametros[0].Value = "";
            }

            DataTable tabela = HelperDAO.ExecutaProcSelect("sp_PesquisaUsuarios", parametros);

            List<UsuarioViewModel> lista = new List<UsuarioViewModel>();
            foreach (DataRow registro in tabela.Rows)
            {
                lista.Add(MontaModel(registro));
            }
            return lista;
        }
    }
}
