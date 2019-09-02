using SuporteCore.Entity;
using SuporteCore.Interfaces.Repository;
using SuporteCore.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuporteCore.Service
{
    public class AnaliseService : IAnaliseService
    {
        private List<Analise> listAnalise;
        private readonly IIntermeioRepository _IntRepository;
        private readonly IPhoebusRepository _phRepository;
        private readonly IAnaliseRepository _analiRepository;

        public AnaliseService(IIntermeioRepository Intermeiorepository, IPhoebusRepository phoebusRepository, IAnaliseRepository analiseRepository)
        {
            _IntRepository = Intermeiorepository;
            _phRepository = phoebusRepository;
            _analiRepository = analiseRepository;
        }

        public void Delete(Analise analise)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Analise> GetAll()
        {
            throw new NotImplementedException();
            
        }

        public void Update(Analise analise)
        {
            throw new NotImplementedException();
        }

        public void ValidationAnalise()
        {
            var search = _phRepository.GetAll().Select(x => x.Nsu.ToString()).ToList().Except(_IntRepository.GetAll().Select(x => x.Nsu.ToString()).ToList());
            Parallel.ForEach(_phRepository.GetAll().ToList(), ph =>
            {
                if (search.Any(x => x == ph.Nsu.ToString()))
                {
                    Analise analise = new Analise();
                    var usuario = GetUsuario(analise.Nsu);
                    analise.Card_number = ph.Card_number;
                    analise.Confirmation_date = ph.Confirmation_date;
                    analise.Nsu = ph.Nsu;
                    analise.PhoebusId = ph.PhoebusId;
                    analise.Terminal = ph.Terminal;
                    analise.Phoebus = ph;
                    analise.Date_base = DateTime.Now;
                    analise.CpfCnpj = usuario.CpfCnpj;
                    analise.NomeRazao = usuario.NomeRazao;
                    listAnalise.Add(analise);
                }
            });
            _analiRepository.Add(listAnalise);
        }
        public Intermeio GetUsuario(string nsu)
        {
            var intermeio = _IntRepository.GetAll().Where(x => x.Nsu == nsu);
            return intermeio.FirstOrDefault();
        }
    }
}
