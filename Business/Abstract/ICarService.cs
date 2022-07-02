using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System;
using System.Text;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetCarsByModelYear(int min,int max);
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<Car> GetById(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);
        IDataResult<List<Car>> GetCarsByDailyPrice(decimal min, decimal max);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
    }
}
