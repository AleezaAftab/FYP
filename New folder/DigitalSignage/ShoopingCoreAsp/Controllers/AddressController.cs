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
    public class AddressController : Controller
    {
        public IActionResult Index()
        {
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            ViewBag.address =  context.getAddress();
            return View();
        }
        public IActionResult Social()
        {
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            ViewBag.social = context.getSocial();
            return View();
        }


        public IActionResult add(Address address)
        {
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            context.saveAddress(address);
            TempData["success"] = "Added Successfully";
            return Redirect(Request.Headers["Referer"].ToString());
        }
        [HttpPost]
        public IActionResult addSocial(Social social)
        {
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            context.saveSocial(social);
            TempData["success"] = "Added Successfully";
            return Redirect(Request.Headers["Referer"].ToString());
        }
        public IActionResult updateSocial(Social social)
        {
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            context.updateSocial(social);
            TempData["success"] = "Updated Successfully";
            return Redirect(Request.Headers["Referer"].ToString());
        }
        public IActionResult update(Address address)
        {
            ShoppingContext context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            context.updateAddress(address);
            TempData["success"] = "Updated Successfully";
            return Redirect(Request.Headers["Referer"].ToString());
        }

    }
}