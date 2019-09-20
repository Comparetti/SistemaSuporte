using SuporteCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SuporteCore.Interfaces.Service
{
    public interface IIntermeioService
    {
        void GetAllBaseIntermeio();
        Intermeio IntermeioByNsu(string nsu);
        void ValidationBaseByNsu(List<Intermeio> listIntermeios);
        Task<Tuple<List<Intermeio>, DateTime?, DateTime?>> FindByIntermeioAsync(DateTime? minDate, DateTime? maxDate, string search);
        IEnumerable<Intermeio> GetAll();
        Intermeio GetUsuario(string numSerie);

    }
}
