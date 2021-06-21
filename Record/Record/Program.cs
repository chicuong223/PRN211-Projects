using System;

namespace Record
{
    record Customer
    {
        public string Name { get; init; } = "New Customer";
        public int Age { get; init; } = 20;
        public void Print()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Customer cust1 = new Customer() { Name = "Cuong" };
            cust1.Print();

            //Get values from cust1 assign to cust2, change cust2's Age to 25
            Customer cust2 = cust1 with { Age = 25 };
            cust2.Print();
            Customer cust3 = new Customer();
            cust3.Print();
            Customer cust4 = cust3 with { Name = "Jason" };
            cust4.Print();
        }
    }
}
