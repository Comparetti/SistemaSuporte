using SistemaInfra.Data;
using SuporteCore.Entity;
using SuporteCore.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SistemaInfra.Repository
{
    public class AnaliseRepository : Repository<Analise>, IAnaliseRepository
    {
        public AnaliseRepository(SuporteContext context) : base(context)
        {
        }
    }
}
