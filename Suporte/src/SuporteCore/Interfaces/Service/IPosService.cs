using SuporteCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuporteCore.Service
{
    public interface IPosService
    {
        IEnumerable<Pos> GetPosAll();

        IEnumerable<Pos> GetPosDesativada(bool valida);

        void ValidationBase(List<Pos> lstPos);
        void RequestPosByIntermeio();

    }
}
