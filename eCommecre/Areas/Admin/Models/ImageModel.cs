using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommecre.Areas.Admin.Models
{
    public class ImageModel
    {
        [Key]
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public int Order { get; set; }
        public string Url { get; set; }
        public bool Status { get; set; }
        [ForeignKey("IdProduct")]
        public virtual ProductModel Product { get; set; }
    }
}
