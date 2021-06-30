using AutomobileLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.Repository
{
    public class CarRepository : ICarRepository
    {
        public bool DeleteCar(Car car)
        {
            return CarDAO.Instance.Delete(car);
        }

        public Car GetCarByID(int carID)
        {
            return CarDAO.Instance.GetCarByID(carID);
        }

        public IEnumerable<Car> GetCars()
        {
            return CarDAO.Instance.GetCarList();
        }

        public bool InsertCar(Car car)
        {
            return CarDAO.Instance.AddNew(car);
        }

        public bool UpdateCar(Car car)
        {
            return CarDAO.Instance.Update(car);
        }
    }
}
