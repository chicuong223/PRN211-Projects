using AutomobileLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.DataAccess
{
    public class CarDBContext
    {
        //Initialize car list
        private static List<Car> CarList = new List<Car>
        {
            new Car{ CarID = 1, CarName = "CRV", Manufacturer = "Honda", Price = 30000, ReleaseYear = 2021},
            new Car{ CarID = 2, CarName = "Ford Focus", Manufacturer = "Ford", Price = 1500, ReleaseYear = 2020}
        };
        //--------------------------------------
        //Using Singleton Pattern
        private static CarDBContext instance = null;
        private static object instanceLock = new object();
        private CarDBContext() { }
        public static CarDBContext Instance
        {
            get
            {
                lock(instanceLock){
                    if(instance == null)
                    {
                        instance = new CarDBContext();
                    }
                    return instance;
                }
            }
        }
        public List<Car> GetCarList() => CarList;
        public Car GetCarByID(int id)
        {
            Car car = CarList.SingleOrDefault(c => c.CarID == id);
            return car;
        }
        public void AddNew(Car car)
        {
            Car c = GetCarByID(car.CarID);
            if(c != null)
            {
                throw new Exception("This car ID already exists!");
            }
            else
            {
                CarList.Add(car);
            }
        }
        public void Update(Car car)
        {
            Car c = GetCarByID(car.CarID);
            if(c != null)
            {
                int index = CarList.IndexOf(c);
                CarList[index] = car;
            }
            else
            {
                throw new Exception("Car not found!");
            }
        }
        public void Delete(int carID)
        {
            Car c = GetCarByID(carID);
            if(c != null)
            {
                CarList.Remove(c);
            }
            else
            {
                throw new Exception("Car not found!");
            }
        }
    }
}
