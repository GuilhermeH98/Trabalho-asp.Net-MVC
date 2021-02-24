using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLPBD.Models
{
    public class UsuarioViewModel : PadraoViewModel
    {
        public string UserLogin { get; set; }
        public string Senha { get; set; }
        public string Nickname { get; set; }
        public bool Administrador { get; set; }
    }
}
