﻿using SuporteCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuporteCore.Interfaces.Repository
{
    public interface IAnaliseRepository : IRepository<Analise>
    {
        IQueryable<Analise> GetQueryable();

        void UppAnaise(Analise analise);
    }
}
