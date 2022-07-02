using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.CarName).MinimumLength(2); // araba ismi minimum 2 karakter olabilir.
            RuleFor(c => c.CarName).NotEmpty(); //araba ismi boş olamaz.
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0); // dailyprice 0'dan büyük olmalıdır.
        }
    }
}
