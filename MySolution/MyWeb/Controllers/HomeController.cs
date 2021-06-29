using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyWeb.Models;

namespace MyWeb.Controllers
{
    public partial class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
    }
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["Greeting"] = "こんにちは。";
            ViewBag.Product = new Product
            {
                ProductID = 1,
                ProductName = "Coffee",
                Brand = "Trung Nguyen",
                Price = 50000
            };
            return View();
        }

        public IActionResult Hello(int code, string name)
        {
            string result = $"Code: {code} - Name: {name}";
            return Content(result);
        }

        public IActionResult TempDataDemo()
        {
            List<string> stds = new List<string>();
            stds.Add("Joe");
            stds.Add("Marie");
            stds.Add("Dan");
            stds.Add("Joel");
            TempData["StudentData"] = stds;
            return View();
        }

        public IActionResult Privacy()
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
