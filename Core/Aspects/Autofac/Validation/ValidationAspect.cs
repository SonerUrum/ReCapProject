using Castle.DynamicProxy;
using Core.CrossCuttingConserns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception  //aspect methodun başında sonunda hata verdiğinde çalışacak yapıdır. Nerede verirsek orada çalışır
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {                                                                 //CarValidator vb Validator gönderilmediyse hata verir
            if (!typeof(IValidator).IsAssignableFrom(validatorType))     //Gönderilen bir IValidator değilse yani AbstractValidator değilse hata mesajı ver
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType; //eğer hata yoksa _validatorType gönderilen validatorType olur
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); // CarValidator'ın bir instance'ını oluştur
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];  // CarValidator'ın base type'ını bul ona gönderdiği çalışma tipini al
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); //lgili methodun parametrelerinden üstte aldığımız çalışma tipine eşit olanı al
            foreach (var entity in entities)//birden fazla parametre varsa hepsini tek tek gez
            {
                ValidationTool.Validate(validator, entity); //ValidationTool'u kullanarak Validate et
            }
        }
    }
}
