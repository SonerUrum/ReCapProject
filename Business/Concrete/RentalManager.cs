using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager :IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            if (IsReturnDateNull(rental.CarId).Success)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }

            return new ErrorResult(Messages.RentalValueInvalid);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int Id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == Id));
        }

        public IResult IsReturnDateNull(int carId)
        {

            var result = _rentalDal.GetAll(r => r.CarId == carId).OrderByDescending(r => r.RentDate).FirstOrDefault();

            try
            {
                if (result.ReturnDate != null)
                {
                    return new SuccessResult();
                }
            }
            catch (Exception)
            {

            }

            return new ErrorResult();
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
