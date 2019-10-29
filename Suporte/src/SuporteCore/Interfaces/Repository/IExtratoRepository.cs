using SuporteCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuporteCore.Interfaces.Repository
{
    public interface IExtratoRepository : IRepository<Extrato>
    {
        bool ValidaCnpjBase(string cnpj, string dateTime);
        List<Extrato> GetAllExtratoByPos();

    }
}
