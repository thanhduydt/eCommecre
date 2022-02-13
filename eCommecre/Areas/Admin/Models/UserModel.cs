using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommecre.Areas.Admin.Models
{
    public class UserModel:IdentityUser
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Birthday { get; set; }
        public string UrlImg { get; set; }
        public string Gender { get; set; }
    }
}
