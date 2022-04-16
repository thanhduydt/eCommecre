using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameUnsigned { get; set; }
        public int IdCategory { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public double ImportPrice { get; set; }
        public double Price { get; set; }
        public bool Status { get; set; }
        [ForeignKey("IdCategory")]
        public virtual Category Category { get; set; }
    }
}
