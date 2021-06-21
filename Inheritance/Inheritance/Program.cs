using System;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            //Manager jack = new Manager(1000, "Jack", "jack@gmail.com");
            //Console.WriteLine(jack);
            //Console.ReadLine();

            //Shape p = new Shape(); -> Error because Shape is an abstract class

            Shape p = new Circle(5);
            p.Draw();
            p.DisplayArea();
            p.Print();
            Console.ReadLine();

            //Can only access Print() of Shape because p is of type Shape
            p = new Rectangle(10, 6);
            p.Draw();
            p.DisplayArea();
            p.Print();
            Console.ReadLine();

            Rectangle r = new Rectangle();
            r.Draw();
            r.Print();
            r.DisplayArea();
            Console.ReadLine();

        }
    }
}
