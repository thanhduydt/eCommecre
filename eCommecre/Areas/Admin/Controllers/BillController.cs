using eCommecre.Areas.Admin.Data;
using eCommecre.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommecre.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BillController : Controller
    {
        private readonly DPContext _context;
        public BillController(DPContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var bill = _context.Bill.Include(m => m.User).ToList();
            return View(bill);
        }
        [HttpGet]
        public IActionResult GetBill(int id)
        {
            
            var bill = _context.Bill.Find(id);
            var user = _context.User.Find(bill.IdUser);
            bill.User = user;
            List<BillDetail> list = new List<BillDetail>();
            foreach(var item in _context.BillDetail.Include(m=>m.Product))
            {
                if (item.IdBill == id)
                {
                    list.Add(item);
                }
            }
            ViewBag.Bill = bill;
            ViewBag.ListProduct = list;
            return PartialView("BillDetail");
        }
        [HttpPost]
        public async Task<JsonResult> UpdateStatus(int id,int status)
        {
            var bill = _context.Bill.Find(id);
            bill.Status = status;
            _context.Bill.Update(bill);
            await _context.SaveChangesAsync();
            return Json("");
        }
    }
}
