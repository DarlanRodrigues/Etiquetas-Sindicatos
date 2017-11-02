using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etiquetas.Classes
{
    public class Cidade
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public Regiao regiao { get; set; }
    }
}
