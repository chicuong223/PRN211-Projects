using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWeb.Controllers
{
    public class CarController : Controller
    {
        private readonly MyStockContext context;
        public CarController(MyStockContext context) => this.context = context;
        // GET: CarController
        public ActionResult Index()
        {
            var model = context.Cars.ToList();
            return View(model);
        }

        // GET: CarController/Details/5
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var car = context.Cars.FirstOrDefault(c => c.CarId == id);
            if(car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // GET: CarController/Create
        public ActionResult Create()
        {
            int carID = context.Cars.Max(car => car.CarId) + 1;
            ViewBag.carID = carID;
            return View();
        }

        // POST: CarController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Car car)
        {
            if (ModelState.IsValid)
            {
                context.Add(car);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: CarController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var car = context.Cars.Find(id);
            if (car == null)
            {
                return NotFound();
            }
            return View();
        }

        // POST: CarController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, Car car)
        {
            if (id != car.CarId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                context.Update(car);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: CarController/Delete/5
        public ActionResult Delete(int id)
        {
            var car = context.Cars.Find(id);
            context.Cars.Remove(car);
            return RedirectToAction(nameof(Index));
        }
    }
}
