using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car {Id=1,BrandId=2,ColorId=1,DailyPrice=24000,ModelYear=2004,Description="Çok Temiz" } ,
            new Car {Id=2,BrandId=3,ColorId=1,DailyPrice=23000,ModelYear=2014,Description="Çok Temiz değil" },
            new Car {Id=3,BrandId=2,ColorId=1,DailyPrice=44000,ModelYear=2011,Description="Çok iyi durumda" },
            new Car {Id=4,BrandId=4,ColorId=1,DailyPrice=29000,ModelYear=2024,Description="Çok çıtır Temiz" },
            new Car {Id=5,BrandId=5,ColorId=1,DailyPrice=27000,ModelYear=2014,Description="Çok Temiz durumda " }};
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carDelete);

        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetByBrandId(int brandId)
        {

            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carUpdate.BrandId = car.BrandId;
            carUpdate.ColorId = car.ColorId;
            carUpdate.DailyPrice = car.DailyPrice;
            carUpdate.Description = car.Description;
        }
    }
}
