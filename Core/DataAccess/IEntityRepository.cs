using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.Entities;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T:class,IEntity, new() //T sadece entity nesne olabilmesi için T bir class veya onu implement eden bir nesne olabilir. IEntity olmaması için new() deriz interface newlenemez
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null); // ürünleri filtreleyerek getirme. markaya göre fiyata göre vb
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
