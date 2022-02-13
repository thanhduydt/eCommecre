using eCommecre.Areas.Admin.Data;
using eCommecre.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommecre.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly DPContext _context;
        public CategoryController(DPContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.list = listCategory();
            return View();
        }
        //public IActionResult Create(CategoryModel model)
        //{
        //    return View();
        //}
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                List<CategoryModel> list = _context.Category.Where(m => m.Name == model.Name).ToList();
                if (list.Count == 0)
                {

                    _context.Add(model);
                    await _context.SaveChangesAsync();
                    ViewBag.error = "false";
                }
                else
                {
                    ViewBag.eName = "Category đã tồn tại.";
                    ViewBag.error = "true";
                    ModelState.AddModelError(string.Empty, "Tạo mới thất bại.");
                }
            }
                return PartialView("CreatePartial",model);
              
        }
        //public async Task<IActionResult> Edit(int Id)
        //{
        //    var model =await _context.Category.FindAsync(Id);
        //    return View(model);
        //}
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                List<CategoryModel> list = _context.Category.Where(m => m.Name == model.Name).ToList();
                if (list.Count != 0)
                {
                    foreach (var item in list)
                    {
                        if (item.Id == model.Id && item.Name == model.Name)
                        {
                            ViewBag.error = "false";
                            return PartialView("Edit", model);
                        }
                        else
                        {
                            ViewBag.eName = "Category đã tồn tại.";
                            return PartialView("Edit", model);
                        }
                    }
                }
                else
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                    ViewBag.error = "false";
                    return PartialView("Edit", model);
                }
            }
            return PartialView("Edit", model);
        }
        public async Task<IActionResult> Delete(int Id)
        {
            var model = await _context.Category.FindAsync(Id);
            _context.Category.Remove(model);
            await _context.SaveChangesAsync();
            return View("Index",listCategory());
        }
        public List<CategoryModel> listCategory()
        {
            return _context.Category.ToList();
        }
        [HttpGet]
        public async Task<JsonResult> GetCategory(int Id)
        {
            var model = await _context.Category.FindAsync(Id);
           return Json(model);
        }
    }
}
