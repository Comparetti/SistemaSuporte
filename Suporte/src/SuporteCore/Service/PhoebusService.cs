using SuporteCore.Entity;
using SuporteCore.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SuporteCore.Service
{
    public class PhoebusService : IPhoebusService
    {
        public Phoebus Create(Phoebus phoebus)
        {
            throw new NotImplementedException();
        }

        public void Delete(Phoebus entity)
        {
            throw new NotImplementedException();
        }

        public Task<Tuple<List<Phoebus>, DateTime?, DateTime?>> FindByPhoebusAsync(DateTime? minDate, DateTime? maxDate, string search)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Phoebus> Get(Expression<Func<Phoebus, bool>> predicado)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Phoebus> GetAll()
        {
            throw new NotImplementedException();
        }

        public Phoebus GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public void RequestPhoebus(DateTime Date, string init_Time = "00:00:00", string finish_Time = "23:59:59")
        {
            throw new NotImplementedException();
        }

        public void ValidationBaseByNsu(List<Phoebus> listphoebus)
        {
            throw new NotImplementedException();
        }
    }
}
