using System;
using System.Linq;

namespace LambdasExpression
{

    static class MyClass
    {
        public static bool Check(this int n, Func<int, bool> func)
        {
            bool r = func(n);
            return r;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int a = 2, b = 3;
            bool r;
            r = a.Check(n => n % 2 == 0);
            Console.WriteLine(r);
            r = b.Check(n => n % 2 == 1);
            Console.WriteLine(r);
            Console.ReadLine();

            //LINQ
            string[] names = { "Joe", "Vito", "Henry", "Tommy", "Martin" };
            foreach(string item in names.OrderBy(str => str)){
                Console.WriteLine(item);
            }
            Console.ReadLine();

            var items = from word in names
                        where word.Contains("o")
                        select word;
            foreach(string s in items)
            {
                Console.WriteLine(s);
            }
            Console.ReadLine();
      
        }
    }
}
