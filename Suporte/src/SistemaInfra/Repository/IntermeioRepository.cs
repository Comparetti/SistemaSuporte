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
    public class IntermeioRepository : Repository<Intermeio>, IIntermeioRepository
    {
        public IntermeioRepository(SuporteContext context) : base(context)
        {
        }
        public IQueryable<Intermeio> GetQueryable()
        {
            var result = from obj in _context.Intermeio select obj;
            return result;
        }
    }
}
