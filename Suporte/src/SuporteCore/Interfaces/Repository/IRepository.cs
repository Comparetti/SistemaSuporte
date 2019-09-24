using SuporteCore.Entity;
using SuporteCore.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SuporteCore.Interfaces.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Add(IEnumerable<T> listEntity);
        IEnumerable<T> GetAll();
        T GetById(int? id);
        T Get(Expression<Func<T, bool>> predicado);
        void Delete(T entity);
    }
}
