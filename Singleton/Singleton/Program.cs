using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("#1. Trying to get a Singleton instance");
            Singleton firstInstance = Singleton.GetInstance;
            Console.WriteLine("--Invoke Print() method: ");
            firstInstance.Print();
            Console.WriteLine("#2. Trying to get a Singleton instance");
            Singleton secondInstance = Singleton.GetInstance;
            Console.WriteLine($"Number of instances: {secondInstance.GetTotalInstances}");
            Console.WriteLine("--Invoke Print() method");
            secondInstance.Print();
            if (firstInstance.Equals(secondInstance))
            {
                Console.WriteLine("=> firstInstance and secondInstance are the same");
            }
            else
            {
                Console.WriteLine("=> Different Instances exist.");
            }
            Console.Read();
        }
    }
}
