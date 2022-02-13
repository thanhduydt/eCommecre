using eCommecre.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommecre.Models
{
    public class ProductViewModel
    {
        public ProductModel Product { get; set; }
        public List<ImageModel> ListImg { get; set; }
    }
}
