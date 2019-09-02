using SistemaInfra.Data;
using SuporteCore.Entity;
using SuporteCore.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SistemaInfra.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly SuporteContext _context;
        public Repository(SuporteContext context)
        {
            _context = context;
        }
        public IEnumerable<T> Add(IEnumerable<T> listEntity)
        {
            _context.Set<T>().AddRange(listEntity);
            _context.SaveChanges();
            return listEntity;
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicado)
        {
            return _context.Set<T>().Where(predicado).AsEnumerable();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsEnumerable();
        }
        public T GetById(int? id)
        {
            return _context.Set<T>().Find(id);
        }

        T IRepository<T>.Get(Expression<Func<T, bool>> predicado)
        {
            throw new NotImplementedException();
        }
    }
}
