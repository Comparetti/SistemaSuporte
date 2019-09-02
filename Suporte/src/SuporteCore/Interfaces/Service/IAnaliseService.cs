using SuporteCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuporteCore.Interfaces.Service
{
    public interface IAnaliseService
    {
        IEnumerable<Analise> GetAll();
        void Update(Analise analise);
        void Delete(Analise analise);
        void ValidationAnalise();
    }
}
