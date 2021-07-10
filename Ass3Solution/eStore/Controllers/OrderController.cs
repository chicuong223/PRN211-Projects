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
    public class OrderController : Controller
    {
        private OrderRepository repository = null;
        public OrderController()
        {
            repository = new OrderRepository();
        }
        // GET: OrderController
        public ActionResult Index()
        {
            if (HttpContext.Session.GetInt32("user") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            int memberID = (int)HttpContext.Session.GetInt32("user");
            if (memberID != 0)
            {
                ViewBag.Error = "You don't have access to this action";
                return View();
            }
            ViewBag.user = HttpContext.Session.GetInt32("user");
            List<Order> lst = repository.GetAllOrders();
            return View(lst);
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                Order order = repository.GetOrderByID(id);
                if (HttpContext.Session.GetInt32("user") == null)
                {
                    return RedirectToAction("Login", "Home");
                }
                int memberID = (int)HttpContext.Session.GetInt32("user");
                if (memberID != order.MemberId && memberID != 0)
                {
                    ViewBag.Error = "You don't have permission to view this order";
                    return View();
                }
                return View(order);
            }
            catch
            {

            }
            return View();
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult GetOrdersByMember(int? id)
        {
            try
            {
                if (id == null)
                    return NotFound();
                var session = HttpContext.Session;
                if (session.GetInt32("user") == null)
                    return RedirectToAction("Login", "Home");
                if (session.GetInt32("user") != 0 && session.GetInt32("user") != id)
                {
                    ViewBag.Error = "You can only view your own orders";
                    return View();
                }
                List<Order> lst = repository.GetOrdersByMember((int)id);
                ViewBag.user = session.GetInt32("user");
                return View("Index", lst);
            }
            catch
            {
                ViewBag.Error = "Error loading orders";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult Report(DateTime start, DateTime end)
        {
            try
            {
                Dictionary<Order, double> dict = repository.GetOrdersByDate(start, end);
                ViewData["start"] = start.ToShortDateString();
                ViewData["end"] = end.ToShortDateString();
                return View(dict);
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
