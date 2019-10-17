using ReflectionIT.Mvc.Paging;
using SuporteCore.Entity;
using SuporteCore.Interfaces.Repository;
using SuporteCore.Interfaces.Service;
using SuporteCore.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuporteCore.Service
{
    public class AnaliseService : IAnaliseService
    {
        private readonly List<Analise> listAnalise = new List<Analise>();
        private readonly IIntermeioRepository _IntRepository;
        private readonly IPhoebusRepository _phRepository;
        private readonly IAnaliseRepository _analiRepository;
        private readonly IIntermeioService _IntermeioService;

        public AnaliseService(IIntermeioRepository Intermeiorepository, IPhoebusRepository phoebusRepository, IAnaliseRepository analiseRepository, IIntermeioService intermeioService)
        {
            _IntRepository = Intermeiorepository;
            _phRepository = phoebusRepository;
            _analiRepository = analiseRepository;
            _IntermeioService = intermeioService;
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
        /// <summary>
        /// Analise as transações que não contem no nosso banco
        /// </summary>
        public void ValidationAnalise()
        {
            var search = _phRepository.GetAll().Select(x => x.Nsu.ToString()).ToList().Except(_IntRepository.GetAll().Select(x => x.Nsu.ToString()).ToList());

            foreach (var ph in _phRepository.GetAll().ToList())
            {
                if (search.Any(x => x == ph.Nsu.ToString()))
                {
                    Analise analise = new Analise();
                    var usuario = GetUsuario(ph.Terminal);
                    analise.Card_number = ph.Card_number;
                    analise.Confirmation_date = ph.Confirmation_date;
                    analise.Nsu = ph.Nsu;
                    analise.PhoebusId = ph.PhoebusId;
                    analise.Terminal = ph.Terminal;
                    analise.Phoebus = ph;
                    analise.Date_base = DateTime.Now;
                    analise.CpfCnpj = usuario.CpfCnpj;
                    analise.NomeRazao = usuario.NomeRazao;
                    analise.Obsservacao = "";
                    listAnalise.Add(analise);
                }
            }
            ValidationByNsu(listAnalise);
        }
        public Intermeio GetUsuario(string terminal)
        {
            var intermeio = _IntRepository.GetAll().Where(x => x.Terminal == terminal).FirstOrDefault();
            if (intermeio == null)
                intermeio = _IntermeioService.GetUsuario(terminal);
            return intermeio;
        }

        public void ValidationByNsu(List<Analise> listAnalise)
        {
            List<Analise> lstIntermeio = new List<Analise>();
            var resultNsu = listAnalise.Select(x => x.Nsu).ToList().Except(_analiRepository.GetAll().Select(x => x.Nsu).ToList());

            Parallel.ForEach(listAnalise, item =>
            {
                if (resultNsu.Any(x => x == item.Nsu))
                {
                    item.Date_base = DateTime.Now;
                    lstIntermeio.Add(item);
                }
            });
            _analiRepository.Add(lstIntermeio);
        }



        public async Task<Tuple<List<Analise>, DateTime?, DateTime?>> FindByAnaliseAsync(DateTime? minDate, DateTime? maxDate, string search)
        {
            if (!minDate.HasValue)
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            if (!maxDate.HasValue)
                maxDate = DateTime.Now;

            var result = _analiRepository.GetQueryable()
                .Where(r => r.Date_base >= minDate.Value || r.Date_base <= maxDate.Value);

            if (!String.IsNullOrEmpty(search))
            {
                result = result.Where(x =>
                x.Nsu.Contains(search) ||
                x.Terminal.Contains(search) ||
                x.Card_number.Contains(search));
            }
            return new Tuple<List<Analise>, DateTime?, DateTime?>(await PagingList.CreateAsync(result.OrderByDescending(x => x.Date_base), 20, 1), minDate, maxDate);
        }

        public ListPaginacao<Analise> QueryPag(UrlQuery urlQuery)
        {
            var lstPaginacao = new ListPaginacao<Analise>();
            var phQuery = _analiRepository.GetAllPh().AsQueryable();


            if (urlQuery.PagNumero.HasValue)
            {
                var qntRegistro = phQuery.Count();
                phQuery = phQuery.Skip((urlQuery.PagNumero.Value - 1) * urlQuery.PagRegistro.Value).Take(urlQuery.PagRegistro.Value);

                var paginacao = new Paginacao();
                paginacao.NumeroPagina = urlQuery.PagNumero.Value;
                paginacao.RegistroPorPagina = urlQuery.PagRegistro.Value;
                paginacao.TotalRegistro = qntRegistro;
                paginacao.TotalPaginas = (int)Math.Ceiling((double)qntRegistro / urlQuery.PagRegistro.Value);

                lstPaginacao.Paginacao = paginacao;
            }
            lstPaginacao.Results.AddRange(phQuery.ToList());

            return lstPaginacao;

        }

    }
}
