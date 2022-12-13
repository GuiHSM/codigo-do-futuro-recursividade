using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursividade.Models
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }

        override public string ToString()
        {
            return "Nome: " + this.Nome + ",Telefone: " + this.Telefone;
        }
    }
}
