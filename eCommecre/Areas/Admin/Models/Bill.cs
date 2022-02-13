using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommecre.Areas.Admin.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public string IdUser { get; set; }
        public DateTime DateTime { get; set; }
        public double Total { get; set; }
        public string ReceivingAddress { get; set; }
        public double ReceivingPhoneNmber { get; set; }
        public int Status { get; set; }
        [ForeignKey("IdUser")]
        public virtual UserModel User { get; set; }
    }
}
