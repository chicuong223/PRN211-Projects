using System;

namespace Delegates
{
    //1. Declare a delegate
    public delegate int MyDelegate(int n1, int n2);
    class Program
    {
        static int Add(int n1, int n2) => n1 + n2;
        static int Sub(int n1, int n2) => n1 - n2;
        static void Main(string[] args)
        {
            int n1 = 25;
            int n2 = 15;
            int result;
            //2. set target method, pass method name into constructor
            MyDelegate obj1 = new MyDelegate(Add);
            //3. Invoke method, pass same parameters of method into obj1
            result = obj1(n1, n2);
            Console.WriteLine($"{n1} + {n2} = {result}");
            //set target method
            MyDelegate obj2 = new MyDelegate(Sub);
            result = obj2.Invoke(n1, n2);
            Console.WriteLine($"{n1} - {n2} = {result}");
        }
    }
}
