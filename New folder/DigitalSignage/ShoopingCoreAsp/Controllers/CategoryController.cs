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
    public class CategoryController : Controller
    {
        public IActionResult AjaxList(int id)
        {

            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            ViewBag.subcategory = context.seachByMainCategory(id);
            return View("AjaxList");
        }

        public IActionResult deleteCategory(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetInt32("admin_id").ToString()))
            {
                return Redirect("admin/login");
            }
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            bool status = context.deleteCategory(id);
            if (status)
            {
                TempData["success"] = "Category deleted successfully";
                return RedirectToAction("allCategories");
            }
            else
            {
                TempData["error"] = "Sorry try again";
                return RedirectToAction("allCategories");
            }

        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
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
                    bool status = context.updateCategory(HttpUtility.HtmlEncode(category.name), "images/" + fileName,category.id);

                    if (status)
                    {
                        TempData["success"] = "Category Updated Successfully";
                    }
                    else
                    {
                        TempData["error"] = "Sorry try again " +status.ToString() ;

                    }
                }
                else
                {
                    TempData["error"] = "Please uplaod image";
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = $"Internal server error: {ex}";
            }
            return RedirectToAction("allCategories");

        }
        public IActionResult FindCategory(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetInt32("admin_id").ToString()))
            {
                return Redirect("admin/login");
            }
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            Category category = context.searchCategory(id);
            if (category!=null)
            {
                ViewBag.category = category;
                return View("findCategory");
            }
            else
            {
                TempData["error"] = "Category not found";
                return View("Category");
            }

        }
     

    public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetInt32("admin_id").ToString()))
            {
                return Redirect("admin/login");
            }
            return View("Category");

        }
        public IActionResult SubCategory()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetInt32("admin_id").ToString()))
            {
                return Redirect("admin/login");
            }
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            ViewBag.category = context.getAllCategories();
            return View("SubCategory");

        }

        public IActionResult allCategories()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetInt32("admin_id").ToString()))
            {
                return Redirect("admin/login");
            }
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            ViewBag.listData = context.getAllCategories();
            return View("allCategories");
        }

        [HttpPost]
        public ActionResult addCategory(Category category)
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
                    bool status = context.saveCategory(HttpUtility.HtmlEncode(category.name), "images/" + fileName);

                    if (status)
                    {
                        TempData["success"] = "Category Added Successfully";
                    }
                    else
                    {
                        TempData["error"] = "Sorry try again" ;

                    }
                }
                else
                {
                    TempData["error"] = "Sorry try again";
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = $"Internal server error: {ex}";
            }
              return Redirect(Request.Headers["Referer"].ToString());
        }


        [HttpPost]
        public ActionResult addSubCategory(SubCategory category)
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
                    bool status = context.saveSubCategory(
                        HttpUtility.HtmlEncode(category.name),
                        "images/" + fileName, category.category_id);

                    if (status)
                    {
                        TempData["success"] = "SubCategory Added Successfully";
                    }
                    else
                    {
                        TempData["error"] = "Sorry try again";

                    }
                }
                else
                {
                    TempData["error"] = "Sorry try again";
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = $"Internal server error: {ex}";
            }
            return Redirect(Request.Headers["Referer"].ToString());
        }


        public IActionResult allSubCategories()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetInt32("admin_id").ToString()))
            {
                return Redirect("admin/login");
            }
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            ViewBag.listData = context.getAllSubCategories();
            return View("allSubCategories");
        }
        public IActionResult EditSubCategory(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetInt32("admin_id").ToString()))
            {
                return Redirect("admin/login");
            }

            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            SubCategory categorys = context.searchSubCategory(id);


            if (categorys != null)
            {
                ViewBag.category = context.getAllCategories();
                ViewBag.categoryDetails = categorys;
                return View("EditSubCategory");

            }
            else
            {
                TempData["error"] = "Sorry sub category not found";

                return Redirect(Request.Headers["Referer"].ToString());
            }
        }

        [HttpPost]
        public ActionResult  UpdateSubCategory(SubCategory category)
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
                    bool status = context.updateSubCategory(
                        HttpUtility.HtmlEncode(category.name),
                        "images/" + fileName, category.category_id,category.id);

                    if (status)
                    {
                        TempData["success"] = "SubCategory Updated Successfully";
                    }
                    else
                    {
                        TempData["error"] = "Sorry try again";

                    }
                }
                else
                {
                    TempData["error"] = "Sorry try again";
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = $"Internal server error: {ex}";
            }
            return Redirect(Request.Headers["Referer"].ToString());
        }

        public IActionResult deleteSubCategory(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetInt32("admin_id").ToString()))
            {
                return Redirect("admin/login");
            }
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            bool status = context.deleteSubCategory(id);
            if (status)
            {
                TempData["success"] = "SubCategory deleted successfully";
                return Redirect(Request.Headers["Referer"].ToString());

            }
            else
            {
                TempData["error"] = "Sorry try again";
                return Redirect(Request.Headers["Referer"].ToString());
            }

        }
        public IActionResult Brand()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetInt32("admin_id").ToString()))
            {
                return Redirect("admin/login");
            }
            return View("Brand");

        }
        [HttpPost]
        public IActionResult saveBrand(Brand brand)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetInt32("admin_id").ToString()))
            {
                return Redirect("admin/login");
            }
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            ViewBag.category = context.saveBrand(brand.name);
            TempData["success"] = "Added Successfully";
            return Redirect(Request.Headers["Referer"].ToString());
        }

        public IActionResult BrandList()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetInt32("admin_id").ToString()))
            {
                return Redirect("admin/login");
            }
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            ViewBag.brandList = context.getAllBrands();
            return View("BrandList");

        }
        public IActionResult findBrand(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetInt32("admin_id").ToString()))
            {
                return Redirect("admin/login");
            }
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            Brand brand = context.findBrand(id);

            if (brand!=null)
            {
                ViewBag.brand = context.findBrand(id);
                return View("EditBrands");

            }
            else
            {
                TempData["error"] = "Sorry brand not found";
                return Redirect(Request.Headers["Referer"].ToString());

            }

        }
        [HttpPost]
        public IActionResult updateBrand(Brand brand)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetInt32("admin_id").ToString()))
            {
                return Redirect("admin/login");
            }
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            context.updateBrand(brand.name,brand.id);
            TempData["success"] = "Updated Successfully";
            return Redirect(Request.Headers["Referer"].ToString());
        }
        public IActionResult deleteBrand(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetInt32("admin_id").ToString()))
            {
                return Redirect("admin/login");
            }
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            context.deleteBrand(id);
            TempData["success"] = "Deleted Successfully";
            return Redirect(Request.Headers["Referer"].ToString());
        }

    }

}
