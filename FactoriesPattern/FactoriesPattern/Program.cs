using System;
using System.Collections.Generic;

namespace FactoriesPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            List<AnimalFactory> animalFactoryList = new List<AnimalFactory>
            {
                new TigerFactory(),
                new LionFactory()
            };
            foreach (var animal in animalFactoryList)
            {
                animal.CreateAnimal().AboutMe();
            }
        }
    }
}
