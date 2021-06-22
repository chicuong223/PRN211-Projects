using DatabaseFirstDemo.Models;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirstDemo
{
    class Program
    {
        static void FilteredIncludes()
        {
            using var db = new MyStoreContext();
            Console.WriteLine("Enter a minimum for units in stock: ");
            string unitsInStock = Console.ReadLine();
            int stock = int.Parse(unitsInStock);
            IQueryable<Category> cats = db.Categories
                .Include(c => c.Products.Where(p => p.UnitsInStock >= stock));
            foreach(Category c in cats)
            {
                Console.WriteLine($"{c.CategoryName} has {c.Products.Count} products");
                foreach(Product p in c.Products)
                {
                    Console.WriteLine($"--->{p.ProductName} has {p.UnitsInStock} units in stock");
                }
            }
        }
        static void Main(string[] args)
        {
            //MyStoreContext myStore = new MyStoreContext();
            //var products = from p in myStore.Products
            //               select new { p.ProductName, p.CategoryId };
            //foreach(var p in products)
            //{
            //    Console.WriteLine($"ProductName: {p.ProductName}, CategoryID: {p.CategoryId}");
            //}
            //Console.WriteLine("------------------------------------------");
            //IQueryable<Category> cats = myStore.Categories.Include(c => c.Products);
            //foreach(Category c in cats)
            //{
            //    Console.WriteLine($"CategoryID: {c.CategoryId} has {c.Products.Count} products");
            //}
            FilteredIncludes();
            Console.ReadLine();
        }
    }
}
