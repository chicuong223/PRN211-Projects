using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public interface IFirst
    {
        void Print();
        void Display();
    }

    public interface ISecond
    {
        void Print();
    }

    public interface ICalculate
    {
        double Area();
    }

    public class Rectangle : ICalculate
    {
        float length;
        float width;
        public Rectangle(float x, float y)
        {
            length = x;
            width = y;
        }

        public double Area()
        {
            return length * width;
        }
    }

    public class MyClass : IFirst, ISecond
    {
        public void Display()
        {
            Console.WriteLine("Display Method");
        }

        //Explicitly Implementing Interfaces
        void IFirst.Print()
        {
            Console.WriteLine("IFirst print");
        }

        void ISecond.Print()
        {
            Console.WriteLine("ISecond print");
        }
    }
}
