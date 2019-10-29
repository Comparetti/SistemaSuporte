using Microsoft.EntityFrameworkCore;
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
        public bool ValidaCnpjBase(string cnpj, string dateTime)
        {
            return  _context.Set<Extrato>().Where(x => x.DataCadastro == dateTime).Select(x => x.cpfcnpj).Contains(cnpj);
        }
        public List<Extrato> GetAllExtratoByPos()
        {
            return _context.Extrato.Include(Extrato => Extrato.ListClientePos).ToList();
        }
    }
}
