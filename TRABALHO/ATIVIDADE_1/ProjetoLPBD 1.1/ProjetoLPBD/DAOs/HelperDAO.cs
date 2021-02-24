using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLPBD.DAOs
{
    public static class HelperDAO
    {
        public static int ExecutaProc(string nomeProc, SqlParameter[] parametros, bool consultaUltimoIdentity = false)
        {
            using (SqlConnection conexao = ConexaoBD.GetConexao())
            {
                using (SqlCommand comando = new SqlCommand(nomeProc, conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    if (parametros != null)
                        comando.Parameters.AddRange(parametros);
                    comando.ExecuteNonQuery();
                    if (consultaUltimoIdentity)
                    {
                        string sql = "select isnull(@@IDENTITY,0)";
                        comando.CommandType = CommandType.Text;
                        comando.CommandText = sql;
                        int pedidoId = Convert.ToInt32(comando.ExecuteScalar());
                        conexao.Close();
                        return pedidoId;
                    }
                    else
                    {
                        conexao.Close();
                        return 0;
                    }
                }
                
            }
        }

        public static DataTable ExecutaProcSelect(string nomeProc, SqlParameter[] parametros)
        {
            using (SqlConnection conexao = ConexaoBD.GetConexao())
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(nomeProc, conexao))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    if (parametros != null)
                        adapter.SelectCommand.Parameters.AddRange(parametros);

                    DataTable tabela = new DataTable();
                    adapter.Fill(tabela);
                    conexao.Close();
                    return tabela;
                }
            }
        }
    }
}
