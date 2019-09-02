using SuporteCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuporteCore.Interfaces.Repository
{
    public interface IIntermeioRepository : IRepository<Intermeio>
    {
        IQueryable<Intermeio> GetQueryable();
    }
}
