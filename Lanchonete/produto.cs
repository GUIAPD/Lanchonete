using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanchonete
{
    public class Produto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public void cardapio()
        {
            Console.WriteLine($"{ Nome}: {Preco}");
        }
        
    }
}
