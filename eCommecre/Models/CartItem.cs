using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommecre.Models
{
    public class CartItem
    {
       public int Quantity { get; set; }
       public ProductViewModel ProductViewModel { get; set; }
        public double Total { get; set; }
    }
}
