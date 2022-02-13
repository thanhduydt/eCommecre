using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommecre.Areas.Admin.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên loại sản phẩm không được để trống.")]
        public string Name { get; set; }
    }
}
