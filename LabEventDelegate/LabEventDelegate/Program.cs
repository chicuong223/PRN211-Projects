using System;
using System.Collections;

namespace LabEventDelegate
{
    delegate void MyDele(ArrayList arr);
    delegate void RemoveDele(Product pro, ManageProduct mp);
    class Program
    {
        //static void PrintProduct(ArrayList al)
        //{
        //    foreach(Product p in al)
        //    {
        //        Console.WriteLine("Product ID: " + p.ProductID);
        //        Console.WriteLine("Product Name: " + p.ProductName);
        //        Console.WriteLine("Unit Price: " + p.UnitPrice);
        //        Console.WriteLine("Quantity: " + p.Quantity);
        //        Console.WriteLine("Subtotal: " + p.Subtotal);
        //    }
        //}
        static readonly MyDele d = (ArrayList arr) =>
        {
            foreach (Product p in arr)
            {
                Console.WriteLine("Product ID: " + p.ProductID);
                Console.WriteLine("Product Name: " + p.ProductName);
                Console.WriteLine("Unit Price: " + p.UnitPrice);
                Console.WriteLine("Quantity: " + p.Quantity);
                Console.WriteLine("Subtotal: " + p.Subtotal);
            }
        };

        static readonly RemoveDele rd = delegate (Product p, ManageProduct mp)
        {
            if (p != null)
            {
                mp.Remove(p.ProductID);
                Console.WriteLine("Press enter to review product list ");
                Console.ReadLine();
                d.Invoke(mp.GetProductList);
            }
            else
            {
                Console.WriteLine("Product not found. ");
            }
        };

        static void DisplayMessageForRemoveProduct(string message)
        {
            Console.WriteLine(message);
        }
        static void Main(string[] args)
        {
            Product objCaphe = new Product
            {
                ProductID = 1, ProductName = "coffee",
                Quantity = 12, UnitPrice = 3
            };
            Product objMilk = new Product
            {
                ProductID = 2,
                ProductName = "milk",
                Quantity = 4,
                UnitPrice = 23
            };

            ManageProduct mp = new ManageProduct();
            //dang-ky su-kien khi xoa product
            //khi su-kien EventAddProduct cua object mp phat sanh no se goi
            //den DisplayMessageForRemoveProduct de xuat thong-bao
            mp.EventAddProduct += new WarningDelegate(DisplayMessageForRemoveProduct);
            mp.AddNew(objCaphe);
            mp.AddNew(objMilk);
            Console.WriteLine("********* List of products ***********");
            //PrintProduct(mp.GetProductList);
            d.Invoke(mp.GetProductList);
            //Find product that has id = 1;
            Console.WriteLine("*********** Find product by ID *************");
            Console.Write("Enter ID: ");
            int proID = int.Parse(Console.ReadLine());
            Product p = mp.Find(proID);
            rd(p, mp);
            Console.ReadLine();
        }
    }
}
