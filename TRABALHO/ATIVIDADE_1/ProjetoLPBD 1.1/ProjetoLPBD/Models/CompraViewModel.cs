using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLPBD.Models
{
    public class CompraViewModel : PadraoViewModel
    {
        public DateTime Data { get; set; }
        public int IdUsuario { get; set; }
        public double ValorTotal { get; set; }

        public List<JogoViewModel> itensCompra;
    }
}
