using System;
using System.Threading;

namespace ThreadDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread primaryThread = Thread.CurrentThread;
            primaryThread.Name = "Primary";
            Console.WriteLine($"{Thread.CurrentThread.Name} is executing Main()");
            Printer p = new Printer();  //step 2
            Thread backgroundThread = new Thread(new ThreadStart(p.PrintNumbers));  //step 3
            backgroundThread.Name = "Secondary"; //step 4
            backgroundThread.Start(); //step 5
            //Do some additional work
            for(int i = 0; i <= 5; i++)
            {
                Console.WriteLine($"Main thread: {i}");
                Thread.Sleep(1000);
            }
            Console.WriteLine("Main thread has finished");
            Console.ReadLine();
        }
    }
}
