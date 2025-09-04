//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using ShoopingCoreAsp.data;
//using ShoopingCoreAsp.Models;
//using Microsoft.AspNetCore.Http;

//namespace ShoopingCoreAsp.Controllers
//{
//    public class CheckOutController : Controller
//    {
//        public IActionResult Index()
//        {
//            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
//            List<AddToCart>  list =  context.getAllCart(HttpContext.Session.GetInt32("cart").ToString());
//            if(list.Count > 0)
//            {
//                return View();
//            }
//            {
//                TempData["error"] = "Sorry  not product found in cart";
//                return Redirect("/Home/Index");
//            }
//        }

//        public IActionResult OrderCompleted()
//        {
//            return View("OrderId");
//        }
//        [HttpPost]
//        public IActionResult sendRequest(Orders order)
//        {
//            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
//            int id  = context.saveOrders(order);
//            string session = HttpContext.Session.GetInt32("cart").ToString();
//            var data =   context.getAllCart(session);
//            foreach (var item in data)
//            {

//                var product = new OrderProducts();
//                product.order_id = id.ToString();
//                product.product_id = item.product_id;
//                product.product_price = item.product_price.ToString();
//                product.quantity = item.quantity.ToString();
//                context.saveOrderProducts(product);
//                context.updateProductQuantity(item.quantity, item.product_id);
//            }
//            context.deleteCatBySession(session);
//            TempData["orderID"] = id.ToString();
//            return Redirect("OrderCompleted");
//        }

//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using ShoopingCoreAsp.data;
using ShoopingCoreAsp.Models;
using ShoopingCoreAsp.Paypal;

namespace ShoopingCoreAsp.Controllers
{
    public class CheckOutController : Controller
    {
        private readonly PayPalSettings _paypalSettings;

        public CheckOutController(IOptions<PayPalSettings> options)
        {
            _paypalSettings = options.Value;
        }

        // Existing Index action
        public IActionResult Index()
        {
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            var session = HttpContext.Session.GetInt32("cart")?.ToString();
            if (string.IsNullOrEmpty(session)) return Redirect("/Home/Index");

            List<AddToCart> list = context.getAllCart(session);
            if (list.Count > 0)
            {
                return View();
            }
            TempData["error"] = "Sorry, no products found in cart";
            return Redirect("/Home/Index");
        }

        // ✅ New PayPal checkout action
        public IActionResult PayPalCheckout()
        {
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            var session = HttpContext.Session.GetInt32("cart")?.ToString();
            if (string.IsNullOrEmpty(session)) return Redirect("/Home/Index");

            List<AddToCart> list = context.getAllCart(session);
            if (list != null)
            {
                decimal total = list.Sum(item => item.product_price * item.quantity);
                ViewBag.TotalAmount = total.ToString("F2");
                ViewBag.PayPalClientId = _paypalSettings.ClientId;
                return View(); // PayPalCheckout.cshtml
            }

            TempData["error"] = "No products found in cart";
            return Redirect("/Home/Index");
        }

        // ✅ New PayPal finalization after onApprove
        [HttpPost]
        public IActionResult ExecutePayPalPayment()
        {
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            var session = HttpContext.Session.GetInt32("cart")?.ToString();
            var userId = HttpContext.Session.GetInt32("user");

            if (string.IsNullOrEmpty(session) || userId == null)
                return BadRequest("Invalid session");

            Orders order = new Orders
            {
                id = userId.Value,
                order_date = DateTime.Now,
                status = "Paid",
                //order_type = "PayPal"
            };


           


            int id = context.saveOrders(order);
            var data = context.getAllCart(session);
            foreach (var item in data)
            {
                var product = new OrderProducts
                {
                    order_id = id.ToString(),
                    product_id = item.product_id,
                    product_price = item.product_price.ToString(),
                    quantity = item.quantity.ToString()
                };
                context.saveOrderProducts(product);
                context.updateProductQuantity(item.quantity, item.product_id);
            }

            context.deleteCatBySession(session);
            TempData["orderID"] = id.ToString();

            return Ok();
        }

        public IActionResult OrderCompleted()
        {
            return View("OrderId");
        }

        // ✅ Original order submission action (e.g., for COD)
        [HttpPost]
        public IActionResult sendRequest(Orders order)
        {
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;


            

            int id = context.saveOrders(order);
            string session = HttpContext.Session.GetInt32("cart")?.ToString();
            var data = context.getAllCart(session);
            foreach (var item in data)
            {
                var product = new OrderProducts();
                product.order_id = id.ToString();
                product.product_id = item.product_id;
                product.product_price = item.product_price.ToString();
                product.quantity = item.quantity.ToString();
                context.saveOrderProducts(product);
                context.updateProductQuantity(item.quantity, item.product_id);
            }
            context.deleteCatBySession(session);
            TempData["orderID"] = id.ToString();
            return Redirect("PayPalCheckout");
        }
    }
}
