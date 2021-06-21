using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPoolDemo
{
    class Printer
    {
        private object threadLock = new object();
        public void PrintNumbers()
        {
            Monitor.Enter(threadLock);
            try
            {
                Console.WriteLine("->{0} is executing PrintNumbers()", Thread.CurrentThread.ManagedThreadId);
                //Print out numbers
                for(int i = 1; i <= 5; i++)
                {
                    Random r = new Random();
                    Thread.Sleep(500 * r.Next(5));
                    Console.WriteLine($"{i, 3}{(i == 5 ? "" : ",")} ");
                }
                Console.WriteLine();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Monitor.Exit(threadLock);
            }
        }
    }
}
