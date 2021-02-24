using ProjetoLPBD.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLPBD.DAOs
{
    public class LoginDAO : UsuarioDAO
    {
        public UsuarioViewModel Consultar(string usuario, string senha)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("login", usuario),
                new SqlParameter("senha", senha)
            };

            DataTable tabela = HelperDAO.ExecutaProcSelect("spConsulta_Usuario", parametros);
            if (tabela.Rows.Count == 0)
                return null;
            else
                return MontaModel(tabela.Rows[0]);
        }
    }
}
