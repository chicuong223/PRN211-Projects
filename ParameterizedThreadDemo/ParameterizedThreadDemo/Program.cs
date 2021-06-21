using System;
using System.Threading;

namespace ParameterizedThreadDemo
{
    class MyParams
    {
        public int value1 { get; set; }
        public int value2 { get; set; }
    }
    class Program
    {
        static AutoResetEvent waitHandle = new AutoResetEvent(false);
        static void AddNumber(object data)
        {
            if(data is MyParams p)
            {
                Thread.Sleep(1000);
                Console.WriteLine("ID of thread in Add(): {0}", Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine($"{p.value1} + {p.value2} = {p.value1 + p.value2}");
                //Tell other threads we are done
                waitHandle.Set();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("ID of Thread in Main(): {0}", Thread.CurrentThread.ManagedThreadId);
            //Make a MyParams obj to pass to the secondary thread
            MyParams p = new MyParams { value1 = 5, value2 = 15 };
            Thread t = new Thread(new ParameterizedThreadStart(AddNumber));
            //Set to background thread
            t.IsBackground = true;
            t.Start(p);
            //Wait for the wait handle to complete
            //main thread wait for add thread to stop
            waitHandle.WaitOne();
            Console.WriteLine("Main thread: done");
            Console.ReadLine();
        }
    }
}
