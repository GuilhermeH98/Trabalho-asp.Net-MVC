using ProjetoLPBD.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLPBD.DAOs
{
    public class BibliotecaDAO : JogoDAO
    {
        public List<JogoViewModel> Consultar(string idUsuario)
        {
            List<JogoViewModel> lista = new List<JogoViewModel>();

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("idUsuario", idUsuario)
            };
            DataTable tabela =  HelperDAO.ExecutaProcSelect("spConsulta_Biblioteca", parametros);

            foreach (DataRow registro in tabela.Rows)
            {
                lista.Add(MontaModel(registro));
            }

            return lista;
        }
    }
}
