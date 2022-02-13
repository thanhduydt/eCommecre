using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommecre.Areas.Admin.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Tên sản phẩm không được để trống.")]
        public string Name { get; set; }
        public string NameUnsigned { get; set; }
        public int IdCategory { get; set; }
        public string Image { get; set; }
        [Required(ErrorMessage ="Mô tả không được để trống.")]
        public string Description { get; set; }
        public double ImportPrice { get; set; }
        public double Price { get; set; }
        public bool Status { get; set; }
        [ForeignKey("IdCategory")]
        public virtual CategoryModel Category { get; set; }
    }
}
