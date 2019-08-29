using SuporteCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SuporteCore.Interfaces.Service
{
    public interface IIntermeioService
    {
        Intermeio Create(Intermeio intermeio);
        IEnumerable<Intermeio> GetAll();
        Intermeio GetById(int? id);
        IEnumerable<Intermeio> Get(Expression<Func<Intermeio, bool>> predicado);
        void Delete(Intermeio intermeio);
        void IntermeioByNsu(string nsu);
        void ValidationBaseByNsu(List<Intermeio> listIntermeios);
        Task<Tuple<List<Intermeio>, DateTime?, DateTime?>> FindByIntermeioAsync(DateTime? minDate, DateTime? maxDate, string search);
    }
}
