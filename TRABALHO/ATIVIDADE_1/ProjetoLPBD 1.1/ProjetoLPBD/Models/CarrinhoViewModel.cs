using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLPBD.Models
{
    public class CarrinhoViewModel : PadraoViewModel
    {
        public int IdJogo { get; set; }
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public double Preco { get; set; }
        //Mais???
    }
}
