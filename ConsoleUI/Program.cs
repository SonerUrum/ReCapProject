using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //CarCrudTest();
            //AddUserTest();
            //DeleteCarTest();
        }


        //private static void BrandTest()
        //{
        //    BrandManager BrandManager = new BrandManager(new EfBrandDal());
        //    foreach (var brand in BrandManager.GetById(3))
        //    {
        //        Console.WriteLine(brand.Name);
        //    }
        //}


        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName + "  -----  " + car.BrandName + "  -----  " + car.ColorName);
                }
            }
            else Console.WriteLine(result.Message);
        }


        //private static void AddUserTest()
        //{
        //    UserManager userManager = new UserManager(new EfUserDal());
        //    userManager.Add(new User { 
        //        Firstname = "Duran",
        //        LastName = "Emmi",
        //        Email ="duranemmi@gmail.com",
        //        Password ="12345678"
            
        //    });
        //}
        private static void DeleteCarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Delete(new Car {
            Id =5
            });
        }
        private static void CarCrudTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            //Create
            carManager.Add(
                new Car
                {
                    
                    CarName = "test5",
                    BrandId = 7,
                    ColorId = 1,
                    DailyPrice = 1500,
                    ModelYear = 2018,
                    Description = "B tipi Ehliyet gerektirir"
                });

            carManager.Add(
                new Car
                {
                    
                    CarName = "test4",
                    BrandId = 5,
                    ColorId = 2,
                    DailyPrice = 1250,
                    ModelYear = 2022,
                    Description = "B tipi Ehliyet gerektirir"
                });

            carManager.Add(
                new Car
                {
                    
                    CarName = "test3",
                    BrandId = 4,
                    ColorId = 3,
                    DailyPrice = 1000,
                    ModelYear = 2018,
                    Description = "B tipi Ehliyet gerektirir"
                });

            carManager.Add(
                new Car
                {
                    
                    CarName = "test2",
                    BrandId = 2,
                    ColorId = 4,
                    DailyPrice = 800,
                    ModelYear = 2019,
                    Description = "B tipi Ehliyet gerektirir"
                });

            //Update
            carManager.Add(
                new Car
                {
                    
                    CarName = "test1",
                    BrandId = 7,
                    ColorId = 5,
                    ModelYear = 2023,
                    DailyPrice = 1750,
                    Description = "B tipi Ehliyet gerektirir"
                });

            //Delete
            //carManager.Delete(new Car { Id = 5 });

            //Read
            //GetAll()
        }
    }
}
