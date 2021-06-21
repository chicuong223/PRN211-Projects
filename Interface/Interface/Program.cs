using System;

namespace Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            //MyClass obj = new MyClass();
            //obj.Display();
            //IFirst first = obj;
            //first.Print();
            //ISecond second = obj;
            //second.Print();
            //Console.ReadLine();
            Rectangle objRectangle = new Rectangle(10.2F, 20.3F);
            ICalculate calculate;
            if(objRectangle is ICalculate)
            {
                calculate = objRectangle as ICalculate;
                Console.WriteLine("Area: {0:F2}", calculate.Area());
            }
            else
            {
                Console.WriteLine("Interface method not implemented");
            }
        }
    }
}
