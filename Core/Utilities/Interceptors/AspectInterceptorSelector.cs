using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute> //Git classın attribute'larını oku
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)                              //Git methodun attribute'larını oku
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);                                    //Onları bir listeye koy 
           // classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));             otomatik olarak sistemdeki bütün methodları loga dahil et
            
            return classAttributes.OrderBy(x => x.Priority).ToArray();   //yalnız MethodInterceptionBaseAttribute classında verilen önceliklere göre sırala
        }
    }
}
