﻿using SistemaInfra.Data;
using SuporteCore.Entity;
using SuporteCore.Interfaces.Repository;
using System.Collections;
using System.Linq;

namespace SistemaInfra.Repository
{
    public class PhoebusRepository : Repository<Phoebus>, IPhoebusRepository
    {
        public PhoebusRepository(SuporteContext context) : base (context)
        {
        }
        public IQueryable<Phoebus> GetQueryable()
        {
            var result = from obj in _context.Phoebus select obj;
            return result;
        }

        IQueryable<Phoebus> IPhoebusRepository.GetQueryable()
        {
            throw new System.NotImplementedException();
        }
    }
}
