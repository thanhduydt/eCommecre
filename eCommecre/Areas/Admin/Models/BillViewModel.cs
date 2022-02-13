using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommecre.Areas.Admin.Models
{
    public class BillViewModel
    {
        public Bill Bill { get; set; }
        public List<BillDetail> BillDetails { get; set; }
    }
}
