using SuporteCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SuporteCore.Interfaces.Service
{
    public interface IPhoebusService
    {
        void RequestPhoebus(DateTime Date, string init_Time = "00:00:00", string finish_Time = "23:59:59");
        void ValidationBaseByNsu(List<Phoebus> listphoebus);
        Task<Tuple<List<Phoebus>, DateTime?, DateTime?>> FindByPhoebusAsync(DateTime? minDate, DateTime? maxDate, string search);
        Phoebus Create(Phoebus phoebus);
        IEnumerable<Phoebus> GetAll();
        Phoebus GetById(int? id);
        IEnumerable<Phoebus> Get(Expression<Func<Phoebus, bool>> predicado);
        void Delete(Phoebus entity);
    }
}
