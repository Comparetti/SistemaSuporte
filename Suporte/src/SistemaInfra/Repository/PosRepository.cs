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
        public List<string> GetCpfcnpj()
        {
            return _context.Set<Pos>().Select(x => x.Cpfcnpj).ToList();
        }
        public double GetTotalAluguel(string cnpj)
        {
            return _context.Set<Pos>().Where(x => x.Cpfcnpj == cnpj)
                .Where(x => x.DescontoEmFaturamento == "Ativo")
                .Select(x => x.ValorAluguel).Sum();
        }
        public string GetNomeRazao(string cnpj)
        {
            return _context.Set<Pos>().Where(x => x.Cpfcnpj == cnpj).FirstOrDefault().NomeRazao;
                
        }
        public List<Pos> GetPosList(string cnpj)
        {
            return _context.Set<Pos>().Where(x => x.Cpfcnpj == cnpj).ToList();
        }
    }
}
