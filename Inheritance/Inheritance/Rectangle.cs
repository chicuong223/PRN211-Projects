using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Rectangle : Shape
    {
        double length;
        double width;

        public Rectangle(double length,double width)
        {
            this.length = length;
            this.width = width;
        }

        public Rectangle()
        {
            length = 0;
            width = 0;
        }
        public override void DisplayArea()
        {
            Console.WriteLine($"Length:{length}, Width:{width}, Area:{length*width}");
        }

        public override void Draw()
        {
            Console.WriteLine("Drawing rectangle");
        }

        public new void Print()
        {
            Console.WriteLine("Printing Rectangle");
        }
    }
}
