using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommecre.Areas.Admin.Models
{
    public class BillDetail
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public int IdBill { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("IdProduct")]
        public virtual ProductModel Product { get; set; }
        [ForeignKey("IdBill")]
        public virtual Bill Bill { get; set; }
    }
}
