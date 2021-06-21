using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    class Customer
    {
        public int Id;
        //full properties
        public int CustomerId
        {
            get { return Id; }
            set { Id = value; }
        }

        //automatic properties
        public string CustomerName { get; set; } = "New Customer";

        public void Print()
        {
            Console.WriteLine($"ID: {CustomerId}, Name: {CustomerName}");
        }
    }
}
