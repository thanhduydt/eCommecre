using eCommecre.Areas.Admin.Data;
using eCommecre.Areas.Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace eCommecre.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        public readonly DPContext _context;
        public readonly UserManager<UserModel> _userManager;
        public UsersController(DPContext context,UserManager<UserModel> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            ViewBag.list = _context.User.ToList();
            return View();
        }
        [HttpPost]
     //   [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserModel model)
        {
            //Khong can xac nhan qua Email 
            model.EmailConfirmed = true;
            var user = await _userManager.CreateAsync(model,model.PasswordHash);
            if (user.Errors.Count() != 0)
            {
                ViewBag.error = "error";
                foreach(var item in user.Errors)
                {
                    if(item.Code== "DuplicateEmail")
                    {
                        ViewBag.eEmail = "Email đã tồn tại";
                    }
                    if (item.Code == "DuplicateUserName")
                    {
                        ViewBag.eUserName = "UserName đã tồn tại";
                    }
                }
            }
            return PartialView("Create",model);
        }
        [HttpPost]
        public JsonResult CheckEmail(string Email)
        {
            var user = _userManager.FindByEmailAsync(Email);
            if (user.Result != null)
            {
                return Json("true");
            }
            return Json("false");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(UserModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            user.Name = model.Name;
            user.Email = model.Email;
            user.UserName = model.UserName;
            user.Address = model.Address;
            user.PhoneNumber = model.PhoneNumber;
            user.UrlImg = model.UrlImg;
            user.Gender = model.Gender;
            var updateUser = await _userManager.UpdateAsync(user);
            if (updateUser.Errors.Count() != 0)
            {
                foreach (var item in updateUser.Errors)
                {
                    if (item.Code == "DuplicateEmail")
                    {
                        ViewBag.eEmail = "Email đã tồn tại";
                    }
                    if (item.Code == "DuplicateUserName")
                    {
                        ViewBag.eUserName = "UserName đã tồn tại";
                    }
                }
            }
            return PartialView("Edit", model);
        }
        [HttpDelete]
        public async Task<JsonResult> Delete(string Id)
        {
            if (Id != null)
            {
                var user = await _userManager.FindByIdAsync(Id);
                await _userManager.DeleteAsync(user);
            }
            return Json("");
        }
        public async Task<String> UploadImgAsync(string Id,IFormFile ful)
        {
            string urlImg = "";
            if (Id != null && ful != null)
            {
                var path = Path.Combine(
                Directory.GetCurrentDirectory(), "wwwroot/img/user-img",Id + "." + ful.FileName.Split(".")[ful.FileName.Split(".").Length - 1]);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await ful.CopyToAsync(stream);
                }
                urlImg =Id + "." + ful.FileName.Split(".")[ful.FileName.Split(".").Length - 1];
            }
            return urlImg;
        }
        [HttpPost]
        public async Task<JsonResult> UploadFile(IFormFile ful)
        {
            if (ful != null)
            {
                var path = Path.Combine(
                         Directory.GetCurrentDirectory(), "wwwroot/img/user-img",ful.FileName.Split()[0]);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await ful.CopyToAsync(stream);
                }
            }
            return Json("");
        }
       
    }
}
