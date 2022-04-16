using eCommecre.Areas.Admin.Data;
using eCommecre.Areas.Admin.Models;
using eCommecre.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace eCommecre.Controllers
{
    public class HomeController : Controller
    {
        private readonly DPContext _context;
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<UserModel> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public const string CARTKEY = "cart";
        public HomeController(ILogger<HomeController> logger, UserManager<UserModel> userManager, RoleManager<IdentityRole> roleManager, DPContext context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            //San pham moi 
            ViewBag.ListPhoneNew = GetProductByCategory(1).OrderBy(m=>m.Product.Id).Take(5);
            ViewBag.ListTableNew = GetProductByCategory(2).OrderBy(m => m.Product.Id).Take(5);
            ViewBag.ListLaptopNew = GetProductByCategory(3).OrderBy(m => m.Product.Id).Take(5);

            ViewBag.ListPhone = GetProductByCategory(1);
            ViewBag.Cart = GetCartItems();
            ViewBag.Total = Total();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Category(int id)
        {
            id = 1;
            var t = GetProductByCategory(id);
            ViewBag.ListProduct = GetProductByCategory(id);
            ViewBag.Cart = GetCartItems();
            ViewBag.Total = Total();
            return View();
        }
        public ProductViewModel GetProduct(int Id)
        {
            ProductViewModel productViewModel = new ProductViewModel();
            List<ImageModel> imageModels = new List<ImageModel>();
            var product = _context.Product.Find(Id);
            productViewModel.Product = product;
            foreach(var item in _context.Image)
            {
                if (item.IdProduct == Id)
                {
                    imageModels.Add(item);
                }
            }
            productViewModel.ListImg = imageModels;
            return productViewModel;
        }
        public List<ProductViewModel> GetProductByCategory(int idCategory)
        {
            List<ProductViewModel> listProudct = new List<ProductViewModel>();
            var list = _context.Product.Where(m => m.IdCategory == idCategory).ToList();
            if (list != null)
            {
                foreach(var item in list)
                {
                    listProudct.Add(GetProduct(item.Id));
                }
            }
            return listProudct;
        }
        public IActionResult Product(int id)
        {
            ProductViewModel productViewModel = new ProductViewModel();
            List<ImageModel> listImg = new List<ImageModel>();
            var product = _context.Product.Find(id);
            foreach(var img in _context.Image.ToList())
            {
                    if(img.IdProduct==product.Id)
                {
                    listImg.Add(img);
                }
            }
            productViewModel.Product = product;
            productViewModel.ListImg = listImg;
            ViewBag.Product = productViewModel;
            ViewBag.Cart = GetCartItems();
            ViewBag.Total = Total();
            return View();
        }
        public List<CartItem> GetCartItems()
        {
            var session = HttpContext.Session;
            string jsoncart = session.GetString(CARTKEY);
            if (jsoncart != null)
            {
                return JsonConvert.DeserializeObject<List<CartItem>>(jsoncart);
            }
            return new List<CartItem>();
        }
        public void ClearCart()
        {
            var session = HttpContext.Session;
            session.Remove(CARTKEY);
        }
        public void SaveCartSession(List<CartItem> list)
        {
            var session = HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject(list);
            session.SetString(CARTKEY, jsoncart);
        }
        public IActionResult ViewCart()
        {
            ViewBag.Cart = GetCartItems();
            ViewBag.Total = Total();
            return View();
        }
        [HttpPost]
        public IActionResult AddToCart(int id)
        {
            var product = GetProduct(id);
            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.ProductViewModel.Product.Id == id);
            if (cartitem != null)
            {
                //Đã tồn tại, tăng thêm 1
                cartitem.Quantity++;
                cartitem.Total = cartitem.Quantity * cartitem.ProductViewModel.Product.Price;
            }
            else
            {
                //Thêm mới
                cart.Add(new CartItem() { Quantity = 1, ProductViewModel = product,Total=product.Product.Price });
            }
            SaveCartSession(cart);
            ViewBag.Cart = cart.ToList();
            ViewBag.Total = Total();
            return PartialView("_CartModal");
        }
        public IActionResult UpdateCart(int id,int quantity)
        {
            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.ProductViewModel.Product.Id == id);
            if (cartitem != null)
            {
                cartitem.Quantity = quantity;
                cartitem.Total = quantity * cartitem.ProductViewModel.Product.Price;
            }
            SaveCartSession(cart);
            return View();
        }
        [HttpPost]
        public IActionResult RemoveProductFromCart(int id)
        {
            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.ProductViewModel.Product.Id == id);
            if (cartitem != null)
            {
                cart.Remove(cartitem);
            }
            SaveCartSession(cart);
            ViewBag.Cart = cart;
            ViewBag.Total = Total();
            return PartialView("_CartModal");
        }
        [HttpPost]
        public IActionResult PlusQuantity(int id)
        {
            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.ProductViewModel.Product.Id == id);
            if (cartitem != null)
            {
                cartitem.Quantity++;
                cartitem.Total = cartitem.Quantity * cartitem.ProductViewModel.Product.Price;
            }
            SaveCartSession(cart);
            ViewBag.Cart = cart;
            ViewBag.Total = Total();
            return PartialView("ViewCart");
        }
        [HttpPost]
        public IActionResult MinusQuantity(int id)
        {
            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.ProductViewModel.Product.Id == id);
            if (cartitem != null)
            {
                if (cartitem.Quantity == 1)
                {
                    cart.Remove(cartitem);
                }
                else
                {
                    cartitem.Quantity--;
                    cartitem.Total = cartitem.Quantity * cartitem.ProductViewModel.Product.Price;
                }
            }
            SaveCartSession(cart);
            ViewBag.Cart = cart;
            ViewBag.Total = Total();
            return PartialView("ViewCart");
        }
        public double Total()
        {
            double total = 0;
            var cart = GetCartItems();
            if (cart != null)
            {
                total = cart.Sum(m => m.Total);
            }
            return total;
        }
        public IActionResult Checkout()
        {
            var user = _userManager.GetUserAsync(User);
            Bill model = new Bill();
            model.IdUser = user.Result.Id;
            model.User = user.Result;
            model.ReceivingAddress = user.Result.Address;
       //     model.ReceivingPhoneNmber = user.Result.PhoneNumber;
            ViewBag.Cart = GetCartItems();
            ViewBag.Total = Total();
            return View();
        }
        public async Task<IActionResult> Order(Bill model)
        {
            var user = _userManager.GetUserAsync(User);
            var cart = GetCartItems();
            model.IdUser = user.Result.Id;
            model.Total = Total();
            model.DateTime = DateTime.Now;
            _context.Add(model);
            await _context.SaveChangesAsync();
            foreach(var item in cart)
            {
                BillDetail billDetail = new BillDetail();
                billDetail.IdBill = model.Id;
                billDetail.IdProduct = item.ProductViewModel.Product.Id;
                billDetail.Quantity = item.Quantity;
                _context.Add(billDetail);
                await _context.SaveChangesAsync();
            }
            ClearCart();
            return RedirectToAction("Index");
        }

        public IActionResult Wishlist()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
