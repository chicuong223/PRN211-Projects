using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    class ReadOnly
    {
        //Init-Only Properties
        //We can assign value for x when initializing obj
        public int x { get; init; }

        //Read-Only Auto Properties
        //We can not assign value to y when initializing
        //we have to assign it in constructor
        public int y { get; }
        public ReadOnly()
        {
            x = 10;
            y = 20;
        }

        public ReadOnly(int a, int b)
        {
            x = a;
            y = b;
        }
    }
}
