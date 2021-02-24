using ProjetoLPBD.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLPBD.DAOs
{
    public class DesenvolvedoraDAO : PadraoDAO<DesenvolvedoraViewModel>
    {
        protected override SqlParameter[] CriaParametros(DesenvolvedoraViewModel model)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("Id", model.Id),
                new SqlParameter("NomeDesenvolvedora", model.Nome)
            };

            return parametros;
        }

        protected override DesenvolvedoraViewModel MontaModel(DataRow registro)
        {
            DesenvolvedoraViewModel model = new DesenvolvedoraViewModel()
            {
                Id = Convert.ToInt32(registro["IdDesenvolvedora"]),
                Nome = registro["NomeDesenvolvedora"].ToString()
            };

            return model;
        }

        protected override void SetTabela()
        {
            Tabela = "Desenvolvedora";
        }
    }
}
