using SuporteCore.Entity;
using SuporteCore.Interfaces.Repository;
using SuporteCore.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SuporteCore.Service
{
    public class IntermeioService : IIntermeioService
    {
        public IntermeioService(IPhoebusRepository repository)
        {

        }
        public Intermeio Create(Intermeio intermeio)
        {
            throw new NotImplementedException();
        }

        public void Delete(Intermeio intermeio)
        {
            throw new NotImplementedException();
        }

        public Task<Tuple<List<Intermeio>, DateTime?, DateTime?>> FindByIntermeioAsync(DateTime? minDate, DateTime? maxDate, string search)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Intermeio> Get(Expression<Func<Intermeio, bool>> predicado)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Intermeio> GetAll()
        {
            throw new NotImplementedException();
        }

        public Intermeio GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public void IntermeioByNsu(string nsu)
        {
            throw new NotImplementedException();
        }

        public void ValidationBaseByNsu(List<Intermeio> listIntermeios)
        {
            throw new NotImplementedException();
        }
    }
}
