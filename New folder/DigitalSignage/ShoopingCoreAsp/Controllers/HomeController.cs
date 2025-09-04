using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoopingCoreAsp.data;
using ShoopingCoreAsp.Models;
using Microsoft.AspNetCore.Http;

namespace ShoopingCoreAsp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetInt32("cart").ToString()))
            {
                Random random = new Random();
                int number = random.Next(30);
                HttpContext.Session.SetInt32("cart", number);
            }

            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            ViewBag.category = context.getAllCategories();
            ViewBag.bestPro = context.is_best_deal();
            ViewBag.topPro = context.is_top_rated();
            ViewBag.banners = context.getAllBanners();
            ViewBag.splash = context.getSplashBanner();
            ViewBag.hotPro = context.is_hot_deal();
            return View();
        }
        [HttpPost]
        public IActionResult search(Product product)
        {
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            ViewBag.products = context.SearchProducts(product.product_name);
            ViewBag.category = context.getAllCategories();
            ViewBag.brands = context.getAllBrands();

            return View("Products");
        }
        public IActionResult Track()
        {
            ViewBag.order = null;
            return View("Track");
        }

        [HttpPost]
        public IActionResult searchOrder(Orders orders)
        {
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            ViewBag.order = context.searchOrder(orders.id);
            ViewBag.prods = context.orderProductLists(orders.id);
            if (ViewBag.order == null)
            {
                TempData["error"] = "Sorry your order not found";
                return Redirect(Request.Headers["Referer"].ToString());
            }
            return View("Track");
        }
        public IActionResult SubCategories(int id)
        {
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            List<SubCategory> category = context.seachByMainCategory(id);
            ViewBag.category = category;
            return View();
        }

        public IActionResult Products(int id)
        {
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            ViewBag.products = context.getAllProductsByCategory(id);
            ViewBag.category = context.getAllCategories();
            ViewBag.brands = context.getAllBrands();
            return View();
        }

        public IActionResult ProductDetails(int id)
        {
            
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            var product = context.searchSingleProduct(id);

            if (product != null)
            {
                ViewBag.category = context.getAllCategories();
                ViewBag.productsCat = context.getAllProductsByCategory(product.sub_cate_id);
                ViewBag.product = product;
                return View();
            }
            else
            {
                TempData["error"] = "Sorry Product not found";
                return Redirect(Request.Headers["Referer"].ToString());
            }
        }

        public IActionResult getAllProductsByBrand(int id)
        {
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            ViewBag.products = context.getAllProductsByBrand(id);
            ViewBag.category = context.getAllCategories();
            ViewBag.brands = context.getAllBrands();
            return View("Products");
        }

        public int SaveWishList(int product_id)
        {
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            context.saveWishList(product_id);
            return 200;
        }
        public IActionResult ajax_category()
        {
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            ViewBag.category = context.getAllCategories();
            return View("cat_menu_ajax");
        }
        public IActionResult getAllCategoriesLIMIT7()
        {
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            ViewBag.category = context.getAllCategoriesLIMIT7();
            return View("cat_menu_ajax2");
        }
        public IActionResult getFooterAddress()
        {
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            ViewBag.address = context.getAddress();
            ViewBag.social = context.getSocial();
            return View("footer_address");
        }
        public IActionResult WhishList()
        {
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            ViewBag.wish_list = context.getAllWhishList();
            return View();
        }
        public IActionResult DeleteWhishList(int id)
        {
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            context.deleteWishList(id);
            TempData["success"] = "Deleted Successfully";
            return Redirect(Request.Headers["Referer"].ToString());

        }

        public IActionResult deleteCat(int id)
        {
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            context.deleteCat(id);
            TempData["success"] = "Deleted Successfully";
            return Redirect(Request.Headers["Referer"].ToString());

        }

        //public int AddtoCart(int product_id)
        //{
        //    if (string.IsNullOrEmpty(HttpContext.Session.GetInt32("cart").ToString()))
        //    {
        //        Random random = new Random();
        //        int number = random.Next(30);
        //        HttpContext.Session.SetInt32("cart", number);
        //    }

        //    ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
        //    int status = context.saveAddtoCart(product_id, HttpContext.Session.GetInt32("cart").ToString());
        //    return status;
        //}

        public int AddtoCart(int product_id)
        {
            int? cartSession = HttpContext.Session.GetInt32("cart");

            if (!cartSession.HasValue)
            {
                Random random = new Random();
                int number = random.Next(10000, 99999); // Ensure uniqueness
                HttpContext.Session.SetInt32("cart", number);
                cartSession = number;
            }

            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            int status = context.saveAddtoCart(product_id, cartSession.ToString());

            return status;
        }



        public IActionResult CartList()
        {
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            ViewBag.carts_list = context.getAllCart(HttpContext.Session.GetInt32("cart").ToString());
            return View();
        }
        public int CountCart()
        {
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            return context.countAddtoCart(HttpContext.Session.GetInt32("cart").ToString());

        }
        public IActionResult compareProduct(int category_id, int price)
        {
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            ViewBag.products = context.compareProduct(category_id, price);
            ViewBag.category = context.getAllCategories();
            ViewBag.brands = context.getAllBrands();
            return View("compare");
        }

        public IActionResult updateCart(AddToCart cart)
        {
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            bool status =  context.updateCartList(cart.quantity, cart.id, cart.product_id);
            if(status)
            {
                TempData["success"] = "Updated Successfully";
            }
            else
            {
                TempData["error"] = "Quantity not available";

            }
            return Redirect(Request.Headers["Referer"].ToString());
        }
        public IActionResult Privacy()
        {

            return View();
        }

        public IActionResult ContactUs()
        {
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            ViewBag.address = context.getAddress();
            return View("Contact");
        }

        public IActionResult AboutUS()
        {

            return View("About");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }
}
