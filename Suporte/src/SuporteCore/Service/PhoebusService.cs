using ReflectionIT.Mvc.Paging;
using SuporteCore.Entity;
using SuporteCore.Interfaces.Repository;
using SuporteCore.Interfaces.Service;
using SuporteCore.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SuporteCore.Service
{
    public class PhoebusService : IPhoebusService
    {
        private readonly IPhoebusRepository _phRepository;

        public PhoebusService(IPhoebusRepository phoebusRepository)
        {
            _phRepository = phoebusRepository;
        }
        public async Task<Tuple<List<Phoebus>, DateTime?, DateTime?>> FindByPhoebusAsync(DateTime? minDate, DateTime? maxDate, string search)
        {
            if (!minDate.HasValue)
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            if (!maxDate.HasValue)
                maxDate = DateTime.Now;

            var result = _phRepository.GetQueryable()
                .Where(r => r.Date_base >= minDate.Value || r.Date_base <= maxDate.Value);

            if (!String.IsNullOrEmpty(search))
            {
                result = result.Where(ph => 
                ph.Nsu.ToString().Contains(search) ||
                ph.Terminal.Contains(search) ||
                ph.Card_number.Contains(search));
            }
            return new Tuple<List<Phoebus>, DateTime?, DateTime?>(await PagingList.CreateAsync(result.OrderByDescending(x => x.Date_base), 20, 1), minDate, maxDate);
        }
        public IEnumerable<Phoebus> GetAll()
        {
            return _phRepository.GetAll();
        }
        public Phoebus GetByNsu(string nsu)
        {
            return _phRepository.Get(x => x.Nsu == nsu);
        }
        public void RequestPhoebus(DateTime Date, string init_Time = "00:00:00", string finish_Time = "23:59:59")
        {
            var parametros = $"payments?date={Date.ToString("yyyy-MM-dd")}&init_time={init_Time}&finish_time={finish_Time}&page_size=100";
            var result = Util.RequestPhoebus.Get<DefaultRequest>(Constante.UrlEndPoint + parametros);
            //Create Query more pages request Phoebus
            ValidationBaseByNsu(result.content);
        }
        public void ValidationBaseByNsu(List<Phoebus> RequestListPhoebus)
        {
            List<Phoebus> ListAddPhoebus = new List<Phoebus>();
            var resultNsu = RequestListPhoebus.Select(x => x.Nsu).ToList().Except(_phRepository.GetAll().Select(x => x.Nsu).ToList());
            Parallel.ForEach(RequestListPhoebus, item =>
            {
                if (resultNsu.Any(x => x == item.Nsu))
                {
                    item.Date_base = DateTime.Now;
                    ListAddPhoebus.Add(item);
                }
            });
            _phRepository.Add(ListAddPhoebus);
        }
    }
}
