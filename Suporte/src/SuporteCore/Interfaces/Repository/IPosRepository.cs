using SuporteCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuporteCore.Interfaces.Repository
{
    public interface IPosRepository : IRepository<Pos>
    {
        int AmountPos();
        List<string> GetUsuarioId();
    }
}
