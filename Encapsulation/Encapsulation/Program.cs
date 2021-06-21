using System;

namespace Encapsulation
{
    class Program
    {
        static void Main(string[] args)
        {
            //Customer obj = new Customer();
            //obj.CustomerId = 1000;

            ////get
            //Console.WriteLine($"ID: {obj.CustomerId}, Name: {obj.CustomerName}");

            ////set
            //obj.CustomerId = 2000;
            //obj.CustomerName = "Chi-Cuong";

            //obj.Print();
            //Console.ReadLine();

            //assign value for x when initializing
            ReadOnly obj2 = new ReadOnly { x = 1 };
            Console.WriteLine($"x: {obj2.x}, y:{obj2.y}");
            //obj.x = 10 -> Error
            //obj.y = 20 -> Error
            ReadOnly obj3 = new ReadOnly();
            Console.WriteLine($"x: {obj3.x}, y:{obj3.y}");
            ReadOnly obj4 = new ReadOnly(30, 50);
            Console.WriteLine($"x: {obj4.x}, y:{obj4.y}");
            Console.ReadLine();


        }
    }
}
