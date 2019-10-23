using SuporteCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuporteCore.Interfaces.Repository
{
    public interface IPosRepository : IRepository<Pos>
    {
        int AmountPos();
        List<string> GetCpfcnpj();
        double GetTotalAluguel(string cnpj);
        string GetNomeRazao(string cnpj);
        List<Pos> GetPosList(string cnpj);
    }
}
