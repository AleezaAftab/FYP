using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

using Rotativa.AspNetCore;
using ShoopingCoreAsp.data;
using ShoopingCoreAsp.Models;
using ShoopingCoreAsp.utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
//using Rotativa.AspNetCore; // Add this at the top





namespace ShoopingCoreAsp.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetInt32("admin_id").ToString()))
            {
                return Redirect("admin/login");
            }
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            ViewBag.orders = context.getAllOrders();
            return View();
        }

        public IActionResult other()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetInt32("admin_id").ToString()))
            {
                return Redirect("admin/login");
            }
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            ViewBag.orders = context.otherOrders();
            return View("Other");
        }
        public IActionResult Details()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetInt32("admin_id").ToString()))
            {
                return Redirect("admin/login");
            }
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            ViewBag.orders = context.otherOrders();
            return View("Index");
        }

        public IActionResult orderProductLists(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetInt32("admin_id").ToString()))
            {
                return Redirect("admin/login");
            }
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            ViewBag.orders = context.orderProductLists(id);
            ViewBag.order = context.searchOrder(id);


            return View("Details");
        }
        
        public IActionResult updateOrderStatus(int id, string status)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetInt32("admin_id").ToString()))
            {
                return Redirect("admin/login");
            }

            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            context.updateOrderStatus(id,status);
            TempData["success"] = "Updated Successfully";
            return Redirect(Request.Headers["Referer"].ToString());
        }

       

public IActionResult DownloadInvoice(int id)
    {
        ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;

        var orderProducts = context.orderProductLists(id);

            return new ViewAsPdf("InvoicePdf", orderProducts)
            {
                FileName = "Invoice.pdf",
                PageMargins = new Rotativa.AspNetCore.Options.Margins(5, 5, 5, 5),
                CustomSwitches = "--disable-smart-shrinking",
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait
            };


        }

    }
}