using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Interceptors
{       //Bu attribute'u classlara ve methodlara ekleyebilirsin.   Birden fazla ekleyebilirsin. Loglama yaparken hem veri tabanına hemde bir dosyaya loglamak için gibi aynı attribute çağırılabilir. Bu yüzden AllowMultiple=true
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)] // inherite edilen bir noktada da kullanabilirsin.
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; } //hangi validation önce çalışsın

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
