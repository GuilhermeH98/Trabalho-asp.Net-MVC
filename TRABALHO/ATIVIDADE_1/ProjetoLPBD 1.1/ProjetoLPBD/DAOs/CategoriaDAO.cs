using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ProjetoLPBD.Models;

namespace ProjetoLPBD.DAOs
{
    public class CategoriaDAO : PadraoDAO<CategoriaViewModel>
    {
        protected override SqlParameter[] CriaParametros(CategoriaViewModel model)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("Id",model.Id),
                new SqlParameter("Descricao", model.Descricao)
            };

            return parametros;
        }

        protected override CategoriaViewModel MontaModel(DataRow registro)
        {
            CategoriaViewModel model = new CategoriaViewModel()
            {
                Id = Convert.ToInt32(registro["idCategoria"]),
                Descricao = registro["descricaoCategoria"].ToString()
            };

            return model;
        }

        protected override void SetTabela()
        {
            Tabela = "Categoria";
        }
    }
}
