using DataAccess1.Abstract;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess1.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;
        public InMemoryCarDal()
        {
            _car = new List<Car> 
            {
                new Car{Id=1,BrandId=1,ModelYear=2021,DailyPrice=28000,Description="Opel Corsa"},
                new Car{Id=2,BrandId=2,ModelYear=2020,DailyPrice=88000,Description="Fiat Doblo"},
                new Car{Id=3,BrandId=3,ModelYear=2021,DailyPrice=58000,Description="Honda S200"},
                new Car{Id=4,BrandId=4,ModelYear=2021,DailyPrice=98000,Description="Chevrolet Camaro"},
                new Car{Id=5,BrandId=5,ModelYear=2019,DailyPrice=18000,Description="Fiat Punto"},
            };
        }
        public void Add(Car car)
        {
           _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete;
            carToDelete = _car.SingleOrDefault(c=>c.Id == car.Id);
            _car.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetById(int CarId)
        {
            return _car.Where(p => p.Id == CarId).ToList();
        }

        public void Update(Car car)
        {
            //gönderilen araba id'sine sahip olan listedeki arabayı  bul
            Car carToUpdate;
            carToUpdate = _car.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.Id = car.Id;
            
        }
    }
}
