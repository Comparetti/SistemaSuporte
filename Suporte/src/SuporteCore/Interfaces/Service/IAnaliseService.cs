using SuporteCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuporteCore.Interfaces.Service
{
    public interface IAnaliseService
    {
        IEnumerable<Analise> GetAll();
        void Update(Analise analise);
        void Delete(Analise analise);
        void ValidationAnalise();
        void ValidationByNsu(List<Analise> analises);
        Task<Tuple<List<Analise>, DateTime?, DateTime?>> FindByAnaliseAsync(DateTime? minDate, DateTime? maxDate, string search);
    }
}
