using eCommecre.Areas.Admin.Data;
using eCommecre.Areas.Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommecre.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly DPContext _context;
        public ProductController(DPContext context)
        {
            _context = context;
        }
        public const string listImg = "listImg";
        public IActionResult Index()
        {
            ViewBag.ListCategory = new SelectList(_context.Category, "Id", "Name");
            ViewBag.list = _context.Product.ToList();
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> CreateOrUpdate(ProductModel model)
        {
            if (model.Id == 0)
            {
                model.NameUnsigned = RemoveUnicode(model.Name);
                _context.Add(model);
                await _context.SaveChangesAsync();
                var listImg = GetListImg();
                if (listImg.Count != 0)
                {
                    foreach (ImageCookie item in listImg)
                    {
                        item.ImageModel.IdProduct = model.Id;
                        item.ImageModel.Product = model;
                        _context.Image.Add(item.ImageModel);
                        await _context.SaveChangesAsync();
                    }
                }

            }
            else
            {
                model.NameUnsigned = RemoveUnicode(model.Name);
                _context.Update(model);
                await _context.SaveChangesAsync();
                var listImgCookie = GetListImg();
                var listImg = _context.Image.ToList();
                if (listImgCookie.Count() > 0 || listImg.Count() > 0)
                {
                    foreach (var imgCookie in listImgCookie)
                    {
                        //Them img vao csdl
                        if (imgCookie.ImageModel.Id == 0)
                        {
                            imgCookie.ImageModel.IdProduct = model.Id;
                            imgCookie.ImageModel.Product = model;
                            _context.Add(imgCookie.ImageModel);
                            await _context.SaveChangesAsync();
                        }
                        else if (imgCookie.Id == -1)
                        {
                            //Xoa img trong csdl
                            var modelImg = await _context.Image.FindAsync(imgCookie.ImageModel.Id);
                            _context.Image.Remove(modelImg);
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            var modelImg = await _context.Image.FindAsync(imgCookie.ImageModel.Id);
                            modelImg.Order = imgCookie.ImageModel.Order;
                            //Cap nhat img trong csdl
                            _context.Image.Update(modelImg);
                            await _context.SaveChangesAsync();
                        }
                    }
                }
            }
            ClearListImg();
            return Json("tc");
        }
        [HttpDelete]
        public async Task<JsonResult> DeleteProduct(int Id)
        {
            var prodcut = await _context.Product.FindAsync(Id);
            _context.Product.Remove(prodcut);
            await _context.SaveChangesAsync();
            return Json("tc");
        }
        [HttpGet]
        public JsonResult Edit(int Id)
        {
            var model = _context.Product.Find(Id);
            return Json(model);
        }
        [HttpGet]
        public IActionResult GetListCookie(int Id)
        {
            var listImg = _context.Image.Where(m => m.IdProduct == Id).ToList();
            List<ImageCookie> list = new List<ImageCookie>();
            int id = 1;
            if (listImg.Count > 0)
            {
                foreach (var item in listImg)
                {
                    ImageCookie imageCookie = new ImageCookie();
                    imageCookie.Id = id++;
                    imageCookie.ImageModel = item;
                    list.Add(imageCookie);
                }
                SaveListImgCookie(list);
            }
            ViewBag.ListImg = list;
            ViewBag.Type = "Edit";
            return PartialView("ListImgPartial");
        }
        [HttpPost]
        public IActionResult AddImg(string urlImg)
        {
            ImageCookie model = new ImageCookie();
            ImageModel imageModel = new ImageModel();
            model.ImageModel = imageModel;
            model.ImageModel.Url = urlImg;
            var listImg = GetListImg();
            if (listImg.Count() > 0)
            {
                model.Id = listImg.Max(m=>m.Id)+1;
                model.ImageModel.Order = listImg.Max(m => m.ImageModel.Order)+1;
            }
            else
            {
                model.Id = 1;
                model.ImageModel.Order = 1;
            }
            listImg.Add(model);
            SaveListImgCookie(listImg);
            ViewBag.ListImg = listImg.OrderBy(m => m.ImageModel.Order);
            return PartialView("ListImgPartial");
        }
        [HttpPost]
        public void EditListImg(int Id,int Order)
        {
           var listImg = GetListImg();
            foreach (var item in listImg)
            {
                if (item.Id == Id)
                {
                    item.ImageModel.Order = Order;
                    SaveListImgCookie(listImg);
                 //   ViewBag.ListImg = listImg.OrderBy(m=>m.Order);
                }
            }
        }
        [HttpPost]
        public IActionResult DeleteItemInListImg(int Id)
        {
            var listImg = GetListImg();
            foreach(var item in listImg)
            {
                if (item.Id == Id)
                {
                    //Nếu item không tồn tại trong csdl thì xóa khỏi cookie
                    if (item.ImageModel.IdProduct == 0)
                    {
                        listImg.Remove(item);                    
                    }
                    else
                    {
                        item.Id = -1;
                    }
                    SaveListImgCookie(listImg);
                    ViewBag.ListImg = listImg.OrderBy(m => m.ImageModel.Order);
                    return PartialView("ListImgPartial");
                }
            }
            return PartialView("ListImgPartial");
        }
        List<ImageCookie> GetListImg()
        {
            string cookie =HttpContext.Request.Cookies[listImg];
            if (cookie != null)
            {
                return JsonConvert.DeserializeObject<List<ImageCookie>>(cookie);
            }
            return new List<ImageCookie>();
        }
      public  void ClearListImg()
        {
            HttpContext.Response.Cookies.Delete(listImg);
        }
       public void SaveListImgCookie(List<ImageCookie> list)
        {
            string jsonListImg = JsonConvert.SerializeObject(list);
            HttpContext.Response.Cookies.Append(listImg,jsonListImg);
           
        }
        public static string RemoveUnicode(string text)
        {
            string[] arr1 = new string[] { "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",
                                            "đ",
                                            "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",
                                            "í","ì","ỉ","ĩ","ị",
                                            "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",
                                            "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",
                                            "ý","ỳ","ỷ","ỹ","ỵ",};
            string[] arr2 = new string[] { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
                                            "d",
                                            "e","e","e","e","e","e","e","e","e","e","e",
                                            "i","i","i","i","i",
                                            "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",
                                            "u","u","u","u","u","u","u","u","u","u","u",
                                            "y","y","y","y","y",};
            for (int i = 0; i < arr1.Length; i++)
            {
                text = text.Replace(arr1[i], arr2[i]);
                text = text.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());
            }
            return text;
        }
    }
}
