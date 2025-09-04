using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using ShoopingCoreAsp.data;
using ShoopingCoreAsp.Models;
using ShoopingCoreAsp.utils;

namespace ShoopingCoreAsp.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetInt32("admin_id").ToString()))
            {
                return Redirect("admin/login");
            }
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            ViewBag.products = context.GetAlert();
            return View();
        }

        public IActionResult logout()
        {
            HttpContext.Session.Remove("admin_id");
            return Redirect("login");

        }

        public IActionResult Login()
        {

            return View();
        }


        [HttpPost]
        public ActionResult LoginAction(Admin admin)
        {

            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            Admin check = context.loginAdmin(admin.email, admin.password);
            if (check != null)
            {
                HttpContext.Session.SetInt32("admin_id", check.id);
                HttpContext.Session.SetString("admin_username", check.username);
                HttpContext.Session.SetString("admin_email", check.email);
            }
            else
            {
                TempData["error"] = "Incorrect email or password";
            }

            return RedirectToAction("Index");
        }
        public IActionResult Profile()
        {
            return View("Profile");

        }
        [HttpPost]
        public IActionResult ResetPassword(PasswordReset reset)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetInt32("admin_id").ToString()))
            {
                return Redirect("admin/login");
            }
            if(reset.confirm_password != reset.new_password)
            {
                TempData["error"] = "New and confirm password not match";
            }
            else
            {
                ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;

                int id = (int)HttpContext.Session.GetInt32("admin_id");
                int status = context.UpdatePassword(Encryptor.MD5Hash(reset.old_password), Encryptor.MD5Hash(reset.new_password),id);

                if (status > 0)
                {
                    TempData["success"] = "Password updated successfully";

                }
                else
                {
                    TempData["error"] = "Old password is incorrect";
                }
            }
            return Redirect(Request.Headers["Referer"].ToString());

        }


        public IActionResult Dashboard()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetInt32("admin_id").ToString()))
            {
                return Redirect("admin/login");
            }
            return View();
        }

        public IActionResult ProductPage()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetInt32("admin_id").ToString()))
            {
                return Redirect("admin/login");
            }
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            ViewBag.category = context.getAllCategories();
            ViewBag.brands = context.getAllBrands();
            return View("product/ProductPage");
        }

        public IActionResult ProductList()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetInt32("admin_id").ToString()))
            {
                return Redirect("admin/login");
            }
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            ViewBag.products = context.getAllProducts();
            return View("product/ProductList");
        }
    }
}