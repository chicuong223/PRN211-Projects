using System;

namespace Events
{
    public delegate void PrintDetails(string msg);
    class Program
    {
        //declare an event
        event PrintDetails Print;
        void Show(string msg) => Console.WriteLine(msg.ToUpper());
        static void Main(string[] args)
        {
            Program p = new Program();
            //register with an event
            p.Print += new PrintDetails(p.Show);
            //Raise "Print" event
            p.Print("Hello World");
            Console.ReadLine();
        }
    }
}
