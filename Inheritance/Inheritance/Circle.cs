using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Circle:Shape
    {
        double radius;

        public Circle(double radius):base()
        {
            this.radius = radius;
        }
        public override void DisplayArea()
        {
            Console.WriteLine($"Radius: {radius}, Area: {radius*radius*3.14}");
        }

        public override void Draw()
        {
            Console.WriteLine("Drawing a Circle");
        }
    }
}
