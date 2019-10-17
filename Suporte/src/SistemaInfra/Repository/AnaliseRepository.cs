using Microsoft.EntityFrameworkCore;
using SistemaInfra.Data;
using SuporteCore.Entity;
using SuporteCore.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SistemaInfra.Repository
{
    public class AnaliseRepository : Repository<Analise>, IAnaliseRepository
    {
        public AnaliseRepository(SuporteContext context) : base(context)
        {
        }
        public void UppAnaise(Analise analise)
        {
            _context.Analise.Update(analise);
            _context.SaveChanges();
        }
        public IQueryable<Analise> GetQueryable()
        {
            var result = from obj in _context.Analise select obj;
            return result;
        }
        public IEnumerable<Analise> GetAllPh()
        {
            var t = _context.Analise
                .Include("Phoebus")
                .AsEnumerable();
            return t;
        }

    }
}
