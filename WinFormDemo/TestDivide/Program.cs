using System;

namespace TestDivide
{
    abstract class MyClass
    {
        public virtual void Print()
        {
            Console.WriteLine("Father");
        }
    }

    class A : MyClass
    {
        public override void Print()
        {
            Console.WriteLine("Son");
        }
    }

    class Program
    {
        interface IDraw2D
        {
            void draw();
        }
        interface IDraw3D
        {
            void draw();
        }
        class myClass : IDraw2D, IDraw3D
        {
            void IDraw2D.draw()
            {
                Console.WriteLine("2d");
            }

            void IDraw3D.draw()
            {
                Console.WriteLine("3d");
            }
            public void draw()
            {
                Console.WriteLine("draw");
            }
        }
        static void Main(string[] args)
        {
            myClass m = new myClass();
            m.draw();
        }
    }
}
