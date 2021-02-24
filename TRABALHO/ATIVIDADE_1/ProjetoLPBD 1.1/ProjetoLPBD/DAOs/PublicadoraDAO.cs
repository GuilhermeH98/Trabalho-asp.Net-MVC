using ProjetoLPBD.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLPBD.DAOs
{
    public class PublicadoraDAO : PadraoDAO<PublicadoraViewModel>
    {
        protected override SqlParameter[] CriaParametros(PublicadoraViewModel model)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("Id", model.Id),
                new SqlParameter("NomePublicadora", model.Nome)
            };

            return parametros;
        }

        protected override PublicadoraViewModel MontaModel(DataRow registro)
        {
            PublicadoraViewModel model = new PublicadoraViewModel()
            {
                Id = Convert.ToInt32(registro["idPublicadora"]),
                Nome = registro["nomePublicadora"].ToString()
            };

            return model;
        }

        protected override void SetTabela()
        {
            Tabela = "Publicadora";
        }
    }
}
