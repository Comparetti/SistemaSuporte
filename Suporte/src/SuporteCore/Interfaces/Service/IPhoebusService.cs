using SuporteCore.Entity;
using SuporteCore.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SuporteCore.Interfaces.Service
{
    public interface IPhoebusService
    {
        void RequestPhoebus(DateTime Date, string init_Time = "00:00:00", string finish_Time = "23:59:59");
        void ValidationBaseByNsu(List<Phoebus> listphoebus);
        Task<Tuple<List<Phoebus>, DateTime?, DateTime?>> FindByPhoebusAsync(DateTime? minDate, DateTime? maxDate, string search);
        IEnumerable<Phoebus> GetAll();
        Phoebus GetByNsu(string nsu);
        ListPaginacao<Phoebus> PhQueryPag(UrlQuery urlQuery);
    }
}
