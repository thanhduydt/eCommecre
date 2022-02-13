using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommecre.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Không được để trống.")]
        [StringLength(100,MinimumLength =3)]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage ="Mật khẩu không được để trống.")]
        [StringLength(100,MinimumLength =3)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="Ghi nhớ.")]
        public bool RememberMe { get; set; }
        public string LoginInValid { get; set; }
    }
}
