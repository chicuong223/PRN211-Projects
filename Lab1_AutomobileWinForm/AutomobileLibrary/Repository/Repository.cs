using AutomobileLibrary.BusinessObjects;
using AutomobileLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.Repository
{
    public class Repository : IRepository
    {
        public Car GetCarByID(int id)
        {
            return CarDBContext.Instance.GetCarByID(id);
        }

        public List<Car> GetCars()
        {
            return CarDBContext.Instance.GetCarList();
        }

        public void InsertCar(Car car)
        {
            CarDBContext.Instance.AddNew(car);
        }

        public void Remove(int id)
        {
            CarDBContext.Instance.Delete(id);
        }

        public void UpdateCar(Car car)
        {
            CarDBContext.Instance.Update(car);
        }
    }
}
