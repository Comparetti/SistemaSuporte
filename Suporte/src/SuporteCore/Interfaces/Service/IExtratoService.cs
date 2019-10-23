using SuporteCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuporteCore.Interfaces.Service
{
    public interface IExtratoService
    {
        IEnumerable<Extrato> GetAll();
        void ValidationAluguel();
    }
}
