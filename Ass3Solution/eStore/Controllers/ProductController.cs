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
    public class ProductController : Controller
    {
        private ProductRepository productRepository = null;
        public ProductController() => productRepository = new ProductRepository();
        // GET: ProductController
        public ActionResult Index()
        {
            object session = HttpContext.Session.GetInt32("user");
            if (session == null)
                return RedirectToAction("Login", "Home");
            else
            {
                int memberID = (int)session;
                if (memberID != 0)
                {
                    ViewBag.Error = "You don't have access to this action";
                    return View();
                }
            }

            try
            {
                List<Product> lst = (List<Product>)productRepository.GetProducts();
                return View(lst);
            }
            catch
            {
                ViewBag.Error = "Error loading products";
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int? id)
        {
            int login = CheckLogin();
            if(login == -1)
                return RedirectToAction("Login", "Home");
            if(login == 0)
            {
                ViewBag.Error = "You don't have access to this action";
                return View();
            }
            try
            {
                if (id == null)
                    return NotFound();
                Product pro = productRepository.GetProductByID(id.Value);
                return View(pro);
            }
            catch
            {
                ViewBag.Error = "Error loading product";
                return View();
            }
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            var session = HttpContext.Session.GetInt32("user");
            if (session == null)
                return RedirectToAction("Login", "Home");
            if (session != 0)
                return RedirectToAction("Index", "Home");
            int maxID = productRepository.GetProducts().Max(pro => pro.ProductId) + 1;
            ViewData["proID"] = maxID;
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    productRepository.InsertProduct(product);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Error = "Failed to insert Product";
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            Product pro = productRepository.GetProductByID(id);
            return View(pro);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, Product updatedProduct)
        {
            try
            {
                if(id == null)
                {
                    return NotFound();
                }
                Product product = productRepository.GetProductByID(id.Value);
                if (product == null)
                    return NotFound();
                productRepository.UpdateProduct(updatedProduct);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Error = "Error updating product";
                return View(updatedProduct);
            }
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Product product = productRepository.GetProductByID(id);
                if (product == null)
                    return NotFound();
                productRepository.DeleteProduct(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Error = "Error deleting product";
                return RedirectToAction(nameof(Index));
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
