using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLPBD.DAOs
{
    public class ConexaoBD
    {
        public static SqlConnection GetConexao()
        {
            string strCon = "Data Source=SQL5097.site4now.net;Initial Catalog=DB_A6AD05_N2LPBD;User Id=DB_A6AD05_N2LPBD_admin;Password=Senhadobanc0";
            SqlConnection conexao = new SqlConnection(strCon);
            conexao.Open();
            return conexao;
        }
    }
}
