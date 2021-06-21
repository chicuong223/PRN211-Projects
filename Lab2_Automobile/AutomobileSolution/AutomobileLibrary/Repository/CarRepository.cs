using AutomobileLibrary.BusinessObject;
using AutomobileLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.Repository
{
    public class CarRepository : IRepository
    {
        public void DeleteCar(int carID)
        {
            CarDBContext.Instance.Remove(carID);
        }

        public Car GetCarByID(int carID)
        {
            return CarDBContext.Instance.GetCarByID(carID);
        }

        public IEnumerable<Car> GetCars()
        {
            return CarDBContext.Instance.GetCarList();
        }

        public void InsertCar(Car car)
        {
            CarDBContext.Instance.AddNew(car);
        }

        public void UpdateCar(Car car)
        {
            CarDBContext.Instance.Update(car);
        }
    }
}
