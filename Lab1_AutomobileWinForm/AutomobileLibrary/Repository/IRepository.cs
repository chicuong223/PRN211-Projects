using AutomobileLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.Repository
{
    public interface IRepository
    {
        List<Car> GetCars();
        Car GetCarByID(int id);
        void InsertCar(Car car);
        void UpdateCar(Car car);
        void Remove(int id);
    }
}
