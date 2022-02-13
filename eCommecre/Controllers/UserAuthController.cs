using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using eCommecre.Areas.Admin.Models;
using eCommecre.Areas.Admin.Data;
using eCommecre.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace eCommecre.Controllers
{
    public class UserAuthController : Controller
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;
        private readonly DPContext _context;
        public UserAuthController(DPContext context,UserManager<UserModel> userManager,SignInManager<UserModel> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            loginModel.LoginInValid = "true";
            if (ModelState.IsValid)
            {
                //Login bằng username/password 
                var result = await _signInManager.PasswordSignInAsync(loginModel.Email,
                    loginModel.Password, loginModel.RememberMe, true);
                if (!result.Succeeded)
                {
                    //Login bằng email/password
                    var user = await _userManager.FindByEmailAsync(loginModel.Email);
                    if (user != null)
                    {
                        result = await _signInManager.PasswordSignInAsync(user,
                           loginModel.Password, loginModel.RememberMe, true);
                    }
                }

                if (result.Succeeded)
                {
                    loginModel.LoginInValid = "";
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Đăng nhập thất bại.");
                }
            }
            return PartialView("SignInPartial",loginModel);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult>Register(RegisterModel model)
        {
            model.RegisterInValid = "true";
            if (ModelState.IsValid)
            {
                // Tạo AppUser sau đó tạo User mới (cập nhật vào db)
                var user = new UserModel { UserName = model.UserName, Email = model.Email,EmailConfirmed=true };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {

                    //_logger.LogInformation("Vừa tạo mới tài khoản thành công.");

                    // phát sinh token theo thông tin user để xác nhận email
                    // mỗi user dựa vào thông tin sẽ có một mã riêng, mã này nhúng vào link
                    // trong email gửi đi để người dùng xác nhận
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                    // callbackUrl = /Account/ConfirmEmail?userId=useridxx&code=codexxxx
                    // Link trong email người dùng bấm vào, nó sẽ gọi Page: /Acount/ConfirmEmail để xác nhận
                    //var callbackUrl = Url.Page(
                    //    "/Account/ConfirmEmail",
                    //    pageHandler: null,
                    //    values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                    //    protocol: Request.Scheme);

                    //// Gửi email    
                    //await _emailSender.SendEmailAsync(Input.Email, "Xác nhận địa chỉ email",
                    //    $"Hãy xác nhận địa chỉ email bằng cách <a href='{callbackUrl}'>Bấm vào đây</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedEmail)
                    {
                        // Nếu cấu hình phải xác thực email mới được đăng nhập thì chuyển hướng đến trang
                        // RegisterConfirmation - chỉ để hiện thông báo cho biết người dùng cần mở email xác nhận
                     //   return RedirectToPage("RegisterConfirmation", new { email = model.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        // Không cần xác thực - đăng nhập luôn
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        //return LocalRedirect(returnUrl);
                    }
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    model.RegisterInValid = "";
                }
               
                // Có lỗi, đưa các lỗi thêm user vào ModelState để hiện thị ở html heleper: asp-validation-summary
                if(result.Errors.Count()>0)
                {
  
                    foreach (var error in result.Errors)
                    {
                        //   ModelState.AddModelError(string.Empty, error.Description);
                        if (error.Code == "DuplicateUserName")
                        {
                            ViewData["eUserName"] = "Tên đăng nhập '" + user.UserName + "'  đã tồn tại.";
                        }
                        if (error.Code == "DuplicateEmail")
                        {
                            ViewData["eEmail"] = "Email '" + user.Email + "' đã tồn tại.";
                        }
                    }
                }
            }
            return PartialView("RegisterPartial", model);
        }
        public async Task<IActionResult> CreateDataUser()
        {
            for (int i = 1; i < 16; i++)
            {

                UserModel user = new UserModel();
                user.Id = i.ToString();
                user.UserName = "thanhduy" + i;
                user.Email = "ttduy" + i + ".@gmail.com";
                user.EmailConfirmed = true;
                await _userManager.CreateAsync(user, "tduy" + i);
            }

            return View();
        }

    }
}
