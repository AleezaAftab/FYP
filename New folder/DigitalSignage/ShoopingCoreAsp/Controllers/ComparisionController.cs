using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoopingCoreAsp.Controllers
{
    public class ComparisionController : Controller
    {
        public IActionResult Index(int product_id)
        {
            if (product_id == 22)
            {
                HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc2 = web.Load("https://www.telemart.pk/samsung-galaxy-z-fold-2-5g-12gb-256gb-dual-sim-pta-approved-price-in-pakistan.html");
                foreach (var item in doc2.DocumentNode.SelectNodes("//h1[@class='product-title']"))
                {
                    ViewBag.t = item.InnerText;
                }

                HtmlAgilityPack.HtmlDocument doc1 = web.Load("https://www.telemart.pk/samsung-galaxy-z-fold-2-5g-12gb-256gb-dual-sim-pta-approved-price-in-pakistan.html");
                foreach (var item in doc1.DocumentNode.SelectNodes("//span[@id='pprice']"))
                {
                    ViewBag.s = item.InnerText;
                }

                ViewBag.i = "https://www.telemart.pk/uploads/product_image/product_122481_1.jpg";
                return View();
            }

            if (product_id == 30)
            {
                HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc2 = web.Load("https://www.telemart.pk/haier-hrf-622ibs-side-by-side-inverter-refrigerator-with-official-warranty.html");
                foreach (var item in doc2.DocumentNode.SelectNodes("//h1[@class='product-title']"))
                {
                    ViewBag.t = item.InnerText;
                }

                HtmlAgilityPack.HtmlDocument doc1 = web.Load("https://www.telemart.pk/haier-hrf-622ibs-side-by-side-inverter-refrigerator-with-official-warranty.html");
                foreach (var item in doc1.DocumentNode.SelectNodes("//span[@id='pprice']"))
                {
                    ViewBag.s = item.InnerText;
                }

                ViewBag.i= "https://www.telemart.pk/uploads/product_image/product_115779_1.jpg";

                return View();
            }

            if (product_id == 35)
            {
                HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc2 = web.Load("https://www.telemart.pk/hp-15s-du20100-core-i3-10th-gen-4gb-ram-1tb-hdd-15-6-inch-win-10-black.html");
                foreach (var item in doc2.DocumentNode.SelectNodes("//h1[@class='product-title']"))
                {
                    ViewBag.t = item.InnerText;
                }

                HtmlAgilityPack.HtmlDocument doc1 = web.Load("https://www.telemart.pk/hp-15s-du20100-core-i3-10th-gen-4gb-ram-1tb-hdd-15-6-inch-win-10-black.html");
                foreach (var item in doc1.DocumentNode.SelectNodes("//span[@id='pprice']"))
                {
                    ViewBag.s = item.InnerText;
                }

                ViewBag.i = "https://www.telemart.pk/uploads/product_image/product_124125_1.jpg";
                return View();
            }

            if (product_id == 26)
            {
                HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc2 = web.Load("https://www.telemart.pk/apple-iphone-12-mini-128gb-single-sim-esim-price-in-pakistan.html");
                foreach (var item in doc2.DocumentNode.SelectNodes("//h1[@class='product-title']"))
                {
                    ViewBag.t = item.InnerText;
                }

                HtmlAgilityPack.HtmlDocument doc1 = web.Load("https://www.telemart.pk/apple-iphone-12-mini-128gb-single-sim-esim-price-in-pakistan.html");
                foreach (var item in doc1.DocumentNode.SelectNodes("//span[@id='pprice']"))
                {
                    ViewBag.s = item.InnerText;
                }

                ViewBag.i = "https://www.telemart.pk/uploads/product_image/product_123611_1.jpg";
                return View();
            }

            if (product_id == 27)
            {
                HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc2 = web.Load("https://www.telemart.pk/apple-iphone-12-pro-256gb-single-sim-esim-price-in-pakistan.html");
                foreach (var item in doc2.DocumentNode.SelectNodes("//h1[@class='product-title']"))
                {
                    ViewBag.t = item.InnerText;
                }

                HtmlAgilityPack.HtmlDocument doc1 = web.Load("https://www.telemart.pk/apple-iphone-12-pro-256gb-single-sim-esim-price-in-pakistan.html");
                foreach (var item in doc1.DocumentNode.SelectNodes("//span[@id='pprice']"))
                {
                    ViewBag.s = item.InnerText;
                }

                ViewBag.i = "https://www.telemart.pk/uploads/product_image/product_123624_1.jpg";
                return View();
            }

            if (product_id == 23)
            {
                HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc2 = web.Load("https://www.telemart.pk/samsung-galaxy-a72-8gb-128gb-dual-sim-with-official-warranty-price-in-pakistan.html");
                foreach (var item in doc2.DocumentNode.SelectNodes("//h1[@class='product-title']"))
                {
                    ViewBag.t = item.InnerText;
                }

                HtmlAgilityPack.HtmlDocument doc1 = web.Load("https://www.telemart.pk/samsung-galaxy-a72-8gb-128gb-dual-sim-with-official-warranty-price-in-pakistan.html");
                foreach (var item in doc1.DocumentNode.SelectNodes("//span[@id='pprice']"))
                {
                    ViewBag.s = item.InnerText;
                }

                ViewBag.i = "https://www.telemart.pk/uploads/product_image/product_137070_1.jpg";
                return View();
            }

            if (product_id == 34)
            {
                HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc2 = web.Load("https://www.telemart.pk/canon-eos-800d-dslr-camera-with-ef-s-18-55-f-is-stm-lens-price-in-pakistan.html");
                foreach (var item in doc2.DocumentNode.SelectNodes("//h1[@class='product-title']"))
                {
                    ViewBag.t = item.InnerText;
                }

                HtmlAgilityPack.HtmlDocument doc1 = web.Load("https://www.telemart.pk/canon-eos-800d-dslr-camera-with-ef-s-18-55-f-is-stm-lens-price-in-pakistan.html");
                foreach (var item in doc1.DocumentNode.SelectNodes("//span[@id='pprice']"))
                {
                    ViewBag.s = item.InnerText;
                }

                ViewBag.i = "https://www.telemart.pk/uploads/product_image/product_117240_1.jpg";
                return View();
            }

            if (product_id == 33)
            {
                HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc2 = web.Load("https://www.telemart.pk/hp-usb-2-0-16gb-price-in-pakistan.html");
                foreach (var item in doc2.DocumentNode.SelectNodes("//h1[@class='product-title']"))
                {
                    ViewBag.t = item.InnerText;
                }

                HtmlAgilityPack.HtmlDocument doc1 = web.Load("https://www.telemart.pk/hp-usb-2-0-16gb-price-in-pakistan.html");
                foreach (var item in doc1.DocumentNode.SelectNodes("//span[@id='pprice']"))
                {
                    ViewBag.s = item.InnerText;
                }

                ViewBag.i = "https://www.telemart.pk/uploads/product_image/product_126974_1.jpg";
                return View();
            }

            if (product_id == 28)
            {
                HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc2 = web.Load("https://www.telemart.pk/dawlance-powercon-30-1-5-ton-air-conditioner-with-official-warranty-price-in-pakistan.html");
                foreach (var item in doc2.DocumentNode.SelectNodes("//h1[@class='product-title']"))
                {
                    ViewBag.t = item.InnerText;
                }

                HtmlAgilityPack.HtmlDocument doc1 = web.Load("https://www.telemart.pk/dawlance-powercon-30-1-5-ton-air-conditioner-with-official-warranty-price-in-pakistan.html");
                foreach (var item in doc1.DocumentNode.SelectNodes("//span[@id='pprice']"))
                {
                    ViewBag.s = item.InnerText;
                }

                ViewBag.i = "https://www.telemart.pk/uploads/product_image/product_111462_1.jpg";
                return View();
            }
            return View();
        }
    }
}
