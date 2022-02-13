using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommecre.Areas.Admin.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public string IdUser { get; set; }
        public string Content { get; set; }
        public bool Status { get; set; }
        [ForeignKey("IdProduct")]
        public virtual ProductModel Product { get; set;}
        [ForeignKey("IdUser")]
        public virtual UserModel User { get; set; }
    }
}
