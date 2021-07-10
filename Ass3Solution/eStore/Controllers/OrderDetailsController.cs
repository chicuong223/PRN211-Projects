using BusinessObjects;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eStore.Controllers
{
    public class OrderDetailsController : Controller
    {
        private OrderDetailRepository repository = new OrderDetailRepository();
        // GET: OrderDetailsController
        public ActionResult Index(int? id)
        {
            int loggedIn = CheckLogin();
            if (loggedIn == -1)
                return RedirectToAction("Login", "Home");
            ViewBag.user = loggedIn;
            List<OrderDetail> lst = repository.GetDetailsByOrderID(id.Value);
            ViewData["OrderID"] = id;
            return View(lst);
        }

        // GET: OrderDetailsController/Create
        public ActionResult Create(int? id)
        {
            int loggedIn = CheckLogin();
            if (loggedIn == -1)
                return RedirectToAction("Login", "Home");
            if(loggedIn == 0)
            {
                ViewBag.Error = "You don't have access to this action";
                return View();
            }
            ProductRepository proRepo = new ProductRepository();
            IEnumerable<Product> proList = proRepo.GetProducts();
            ViewData["ProList"] = proList;
            ViewData["OrderID"] = id;
            return View();
        }

        // POST: OrderDetailsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderDetail detail)
        {
            try
            {
                Product _product = new ProductRepository().GetProductByID(detail.ProductId);
                decimal finalPriceRate = (decimal)(1 - detail.Discount);
                detail.UnitPrice = detail.Quantity * _product.UnitPrice * finalPriceRate;
                repository.AddDetail(detail);
                return RedirectToAction(nameof(Index), new { id = detail.OrderId });
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return RedirectToAction(nameof(Create), new { id = detail.OrderId });
            }
        }

        public int CheckLogin()
        {
            var session = HttpContext.Session.GetInt32("user");
            if (session == null)
                return -1;
            if (session != 0)
                return 0;
            return 1;
        }
    }
}
