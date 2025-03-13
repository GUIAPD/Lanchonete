using Lanchonete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanchonete
{
    public class Pedido
    {
        public int Numcomanda { get; set; }
        
        public decimal total { get; set; }     
        
        public List<Produto> Items { get; set; } = new List<Produto>();

        
       
    }
}
