using AutomobileLibrary.BusinessObject;
using AutomobileLibrary.DataAccess;
using System;
using System.Collections.Generic;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            CarDBContext dao = CarDBContext.Instance;
            foreach(Car car in dao.GetCarList())
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
