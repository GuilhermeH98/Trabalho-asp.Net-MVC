using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLPBD.Models
{
    public class JogoViewModel : PadraoViewModel
    {
        public string Nome { get; set; }
        public IFormFile Imagem { get; set; }
        public byte[] ImagemEmByte { get; set; }
        public string ImagemEmBase64
        {
            get
            {
                if (ImagemEmByte != null)
                    return Convert.ToBase64String(ImagemEmByte);
                else
                    return string.Empty;
            }
        }
        public double Preco { get; set; }
        public string Descricao { get; set; }
        public int IdCategoria { get; set; }
        public int IdPublicadora { get; set; }
        public int IdDesenvolvedora { get; set; }

        //
        public string NomeCategoria { get; set; }
        public string NomePublicadora { get; set; }
        public string NomeDesenvolvedora { get; set; }
    }
}
