using SistemaInfra.Data;
using SuporteCore.Entity;
using SuporteCore.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaInfra.Repository
{
    public class PosRepository : Repository<Pos>, IPosRepository
    {
        public PosRepository(SuporteContext context) : base(context)
        {
        }
        public int AmountPos()
        {
            return _context.Set<Pos>().ToList().Count();
        }
        public List<string> GetUsuarioId()
        {
            return _context.Set<Pos>().Select(x => x.IdUsuario).ToList();
        }
    }
}
