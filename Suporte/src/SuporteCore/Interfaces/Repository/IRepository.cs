using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SuporteCore.Interfaces.Repository
{
    public interface IRepository<T> where T : class
    {
        T Create(T entity);
        IEnumerable<T> GetAll();
        T GetById(int? id);
        IEnumerable<T> Get(Expression<Func<T, bool>> predicado);
        void Delete(T entity);
    }
}
