using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadDemo
{
    class Printer
    {
        public void PrintNumbers()
        {
            //Display thread info
            Console.WriteLine($"{Thread.CurrentThread.Name} is executing PrintNumbers()");
            //Print out numbers
            for(int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"Second thread: {i}");
                Thread.Sleep(2000);     //delay(2000)
            }
            Console.WriteLine();
        }
    }
}
