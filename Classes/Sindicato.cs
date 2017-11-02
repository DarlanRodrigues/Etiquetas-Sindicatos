using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etiquetas.Classes
{
    public class Sindicato
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Rua { get; set; }
        public int Cep { get; set; }
        //numero é string para poder receber sem numero ou S/N
        public String Numero { get; set; }
        public int Bairro { get; set; }
        public Cidade Cidade { get; set; }

    }
}
