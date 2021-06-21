using System;

namespace StaticMethod
{
    static class Utils
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }

        //'this' must be placed before the first parameter
        //let us call the function by calling 'this' parameter name
        public static int Sub(this int a, int b)
        {
            return a - b;
        }
    }

    class MyClass
    {
        public static int x = 1;
        static MyClass()
        {
            x = 2;
            Console.WriteLine("Static Constructor: x = {0}", x);
        }

        public MyClass()
        {
            x++;
            Console.WriteLine("Object Constructor: x = {0}", x);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //MyClass m1 = new MyClass();
            //MyClass.x = 4;
            //MyClass m2 = new MyClass();

            ////extension method
            //int x = 3, y = 2;
            //int r = Utils.Add(x, y);
            //Console.WriteLine("{0} + {1} = {2}", x, y, r);
            //r = x.Sub(y);
            //Console.WriteLine($"{x} - {y} = {r}");
            //Console.ReadLine();

            //anonymous type, only read data from it
            var obj = new { id = 1, name = "Cuong" };
            Console.WriteLine($"ID = {obj.id}, Name = {obj.name}");
        }
    }
}
