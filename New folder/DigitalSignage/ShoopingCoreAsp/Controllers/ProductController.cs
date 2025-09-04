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
    public class ProductController : Controller
    {
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetInt32("admin_id").ToString()))
            {
                return Redirect("admin/login");
            }
            try
            {
                var file = Request.Form.Files[0];
                var file1 = Request.Form.Files[1];
                var file2 = Request.Form.Files[2];
                var file3 = Request.Form.Files[3];
                var folderName = Path.Combine("wwwroot", "images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fileName1 = ContentDispositionHeaderValue.Parse(file1.ContentDisposition).FileName.Trim('"');
                    var fileName2 = ContentDispositionHeaderValue.Parse(file2.ContentDisposition).FileName.Trim('"');
                    var fileName3 = ContentDispositionHeaderValue.Parse(file3.ContentDisposition).FileName.Trim('"');

                    var fullPath = Path.Combine(pathToSave, fileName);
                    var fullPath1 = Path.Combine(pathToSave, fileName1);
                    var fullPath2 = Path.Combine(pathToSave, fileName2);
                    var fullPath3 = Path.Combine(pathToSave, fileName3);

                    var dbPath = Path.Combine(folderName, fileName);
                    var dbPath1 = Path.Combine(folderName, fileName1);
                    var dbPath2 = Path.Combine(folderName, fileName2);
                    var dbPath3 = Path.Combine(folderName, fileName3);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    using (var stream = new FileStream(fullPath1, FileMode.Create))
                    {
                        file1.CopyTo(stream);
                    }

                    using (var stream = new FileStream(fullPath2, FileMode.Create))
                    {
                        file2.CopyTo(stream);
                    }
                    using (var stream = new FileStream(fullPath3, FileMode.Create))
                    {
                        file3.CopyTo(stream);
                    }

                    ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
                    product.product_image = "images/" + fileName;
                    product.product_image1 = "images/" + fileName1;
                    product.product_image2 = "images/" + fileName2;
                    product.product_image3 = "images/" + fileName3;

                    bool status = context.saveProduct(product);

                    if (status)
                    {
                        TempData["success"] = "Product Added Successfully";
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

        public IActionResult findProduct(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetInt32("admin_id").ToString()))
            {
                return Redirect("admin/login");
            }
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            Product product = context.findProduct(id);

            if (product != null)
            {
                ViewBag.category = context.getAllCategories();
                ViewBag.brands = context.getAllBrands();
                ViewBag.product = product;
                return View("EditProduct");

            }
            else
            {
                TempData["error"] = "Sorry product not found";
                return Redirect(Request.Headers["Referer"].ToString());

            }

        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetInt32("admin_id").ToString()))
            {
                return Redirect("admin/login");
            }
            try
            {
                var file = Request.Form.Files[0];
                var file1 = Request.Form.Files[1];
                var file2 = Request.Form.Files[2];
                var file3 = Request.Form.Files[3];
                var folderName = Path.Combine("wwwroot", "images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fileName1 = ContentDispositionHeaderValue.Parse(file1.ContentDisposition).FileName.Trim('"');
                    var fileName2 = ContentDispositionHeaderValue.Parse(file2.ContentDisposition).FileName.Trim('"');
                    var fileName3 = ContentDispositionHeaderValue.Parse(file3.ContentDisposition).FileName.Trim('"');

                    var fullPath = Path.Combine(pathToSave, fileName);
                    var fullPath1 = Path.Combine(pathToSave, fileName1);
                    var fullPath2 = Path.Combine(pathToSave, fileName2);
                    var fullPath3 = Path.Combine(pathToSave, fileName3);

                    var dbPath = Path.Combine(folderName, fileName);
                    var dbPath1 = Path.Combine(folderName, fileName1);
                    var dbPath2 = Path.Combine(folderName, fileName2);
                    var dbPath3 = Path.Combine(folderName, fileName3);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    using (var stream = new FileStream(fullPath1, FileMode.Create))
                    {
                        file1.CopyTo(stream);
                    }

                    using (var stream = new FileStream(fullPath2, FileMode.Create))
                    {
                        file2.CopyTo(stream);
                    }
                    using (var stream = new FileStream(fullPath3, FileMode.Create))
                    {
                        file3.CopyTo(stream);
                    }

                    ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
                    // String img = "image/ "+ fileName;
                    // String str = "Insert into categories(name,image,status)  values(''" + category.name + "'',''" + img + "'',1)";
                    //  TempData["success"] = HttpUtility.HtmlEncode(category.name);
                    //  return RedirectToAction("Category");
                    product.product_image = "images/" + fileName;
                    bool status = context.updateProduct(product);

                    if (status)
                    {
                        TempData["success"] = "Product Updated Successfully";
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
        public IActionResult deleteProduct(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetInt32("admin_id").ToString()))
            {
                return Redirect("admin/login");
            }
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
              context.deleteProduct(id);

                TempData["success"] = "Deleted successfully";
                return Redirect(Request.Headers["Referer"].ToString());
        }


    }


}