using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommecre.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage="Email không được để trống.")]
        [EmailAddress(ErrorMessage ="Không phải địa chỉ email.")]
        [Display(Name ="Email")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Tên đăng nhập không được để trống.")]
        [StringLength(100,ErrorMessage ="{0} dài từ {2} đến {1} ký tự.",MinimumLength =3)]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Mật khẩu không được để trống.")]
        [StringLength(100, ErrorMessage = "{0} dài từ {2} đến {1} ký tự.", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Display(Name ="Mật khẩu")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Nhập lại mật khẩu")]
        [Compare("Password", ErrorMessage = "Mật khẩu không giống nhau")]
        public string ConfirmPassword { get; set; }
        public string RegisterInValid { get; set; }
    }
}
