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
    public class BannerController : Controller
    {
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetInt32("admin_id").ToString()))
            {
                return Redirect("admin/login");
            }
            return View("Add");
        }

        public IActionResult AddSplash()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetInt32("admin_id").ToString()))
            {
                return Redirect("admin/login");
            }
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            ViewBag.banners = context.getSplashBanner();

            return View("AddSplashBanner");
        }
        public IActionResult deleteBanner(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetInt32("admin_id").ToString()))
            {
                return Redirect("admin/login");
            }
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            ViewBag.banners = context.deleteBanner(id);
            TempData["success"] = "Deleted Successfully";
            return Redirect(Request.Headers["Referer"].ToString());

        }

        public IActionResult deleteSplashBanner(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetInt32("admin_id").ToString()))
            {
                return Redirect("admin/login");
            }
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            ViewBag.banners = context.deleteSplashBanner(id);
            TempData["success"] = "Deleted Successfully";
            return Redirect(Request.Headers["Referer"].ToString());

        }
        public IActionResult List()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetInt32("admin_id").ToString()))
            {
                return Redirect("admin/login");
            }
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            ViewBag.banners = context.getAllBanners();
            return View("List");
        }
        [HttpPost]
        public IActionResult uploadImage()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetInt32("admin_id").ToString()))
            {
                return Redirect("admin/login");
            }
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("wwwroot", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
                    context.savebanner("images/" + fileName);

                    TempData["success"] = "Updated Successfully";
                }
                else
                {
                    TempData["error"] = "Please upload image again.";
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = $"Internal server error: {ex}";
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult uploadSplashBanner()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetInt32("admin_id").ToString()))
            {
                return Redirect("admin/login");
            }
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("wwwroot", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
                    // String img = "image/ "+ fileName;
                    // String str = "Insert into categories(name,image,status)  values(''" + category.name + "'',''" + img + "'',1)";
                    //  TempData["success"] = HttpUtility.HtmlEncode(category.name);
                    //  return RedirectToAction("Category");
                    context.saveSplashBanner("images/" + fileName);

                    TempData["success"] = "Updated Successfully";
                }
                else
                {
                    TempData["error"] = "Please upload image again.";
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = $"Internal server error: {ex}";
            }
            return Redirect(Request.Headers["Referer"].ToString());

        }
    }
}