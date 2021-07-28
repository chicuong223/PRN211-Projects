using System;

namespace ConsoleApp1
{
    class A
    {
        int x;
        public A()
        {
            x = 3;
        }
        public void Print()
        {
            Console.WriteLine(x);
        }
    }

    class B : A
    {
        int x;
        public B()
        {
            x = 2;
        }
        public new void Print()
        {
            Console.WriteLine(x);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            A a = new B();
            a.Print();
        }
    }
}
