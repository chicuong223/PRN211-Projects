using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public abstract class Shape
    {
        public virtual void Draw()
        {
            Console.WriteLine("Drawing Shape");
        }

        public void Print()
        {
            Console.WriteLine("Printing Shape");
        }

        public abstract void DisplayArea();
    }
}
