using System;

namespace MulticastDelegate
{
    public delegate void MyDelegate(string msg);
    class MyClass
    {
        public static void Print(string message)
        {
            Console.WriteLine($"{message.ToUpper()}");
        }
        public static void Show(string message)
        {
            Console.WriteLine(message.ToLower());
        }
        public static void Display(string message)
        {
            Console.WriteLine(message);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string msg = "Multicast Delegate";
            MyDelegate dele1 = MyClass.Print;
            MyDelegate dele2 = MyClass.Show;
            Console.WriteLine("*** Combining dele1 + dele2 ***");
            MyDelegate dele = dele1 + dele2;
            dele(msg);
            Console.WriteLine("*** dele1 + dele2 + dele3 ***");
            MyDelegate dele3 = MyClass.Display;
            dele += dele3;
            dele(msg);
            Console.WriteLine("-----------------------------");
            Console.WriteLine("** Remove dele2 **");
            dele -= dele2;
            dele("Hello World !");
            Console.ReadLine();

            //Generic Delegate Types
            int a = 15, b = 25, s;
            string strResult;
            //Func delegate takes 2 input params of int type
            //returns a value of int type
            //the rightmost param is the return type of delegate
            Func<int, int, int> sumFunc = Sum;
            //Invoke Sum by Func delegae
            s = sumFunc(a, b);
            strResult = $"{a} + {b} = {s}";
            Console.WriteLine("*** Print method by Action delegate ***");
            Action<string> action = Print;
            action(strResult);
            Console.ReadLine();
        }
        static int Sum(int x, int y) => x + y;
        static void Print(string msg) => Console.WriteLine(msg.ToUpper());
    }
}
