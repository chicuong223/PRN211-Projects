using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoriesPattern
{
    public abstract class AnimalFactory
    {
        public abstract IAnimal CreateAnimal();
    }

    public class LionFactory : AnimalFactory
    {
        public override IAnimal CreateAnimal() => new Lion();
    }

    public class TigerFactory : AnimalFactory
    {
        public override IAnimal CreateAnimal() => new Tiger();
    }
}
