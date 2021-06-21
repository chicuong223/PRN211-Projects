using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoriesPattern
{
    public interface IAnimal
    {
        void AboutMe();
    }

    public class Lion : IAnimal
    {
        public void AboutMe() => Console.WriteLine("This is Lion");
    }

    public class Tiger : IAnimal
    {
        public void AboutMe() => Console.WriteLine("This is Tiger");
    }
}
