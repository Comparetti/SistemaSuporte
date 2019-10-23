using SistemaInfra.Data;
using SuporteCore.Entity;
using SuporteCore.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaInfra.Repository
{
    public class ExtratoRepository : Repository<Extrato>, IExtratoRepository
    {
        public ExtratoRepository(SuporteContext context) : base(context)
        {
        }
        public void AddExtato(Extrato extrato)
        {
            _context.Add(extrato);
        }
        public bool ValidaCnpjBase(string cnpj)
        {
            return  _context.Set<Extrato>().Select(x => x.cpfcnpj).Contains(cnpj);
        }
    }
}
