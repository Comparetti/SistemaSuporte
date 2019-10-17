using SistemaInfra.Data;
using SuporteCore.Entity;
using SuporteCore.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaInfra.Repository
{
    public class ExtratoRepository : Repository<Extrato>, IExtratoRepository
    {
        public ExtratoRepository(SuporteContext context) : base(context)
        {
        }


    }
}
