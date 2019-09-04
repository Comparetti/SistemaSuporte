using ReflectionIT.Mvc.Paging;
using SuporteCore.Entity;
using SuporteCore.Interfaces.Repository;
using SuporteCore.Interfaces.Service;
using SuporteCore.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SuporteCore.Service
{
    public class IntermeioService : IIntermeioService
    {
        private readonly List<Intermeio> ListIntermeio = new List<Intermeio>();
        private readonly IIntermeioRepository _IntRepository;

        public IntermeioService(IIntermeioRepository repository)
        {
            _IntRepository = repository;
        }
        public IEnumerable<Intermeio> GetAll()
        {
           return _IntRepository.GetAll();
        }
        public async Task<Tuple<List<Intermeio>, DateTime?, DateTime?>> FindByIntermeioAsync(DateTime? minDate, DateTime? maxDate, string search)
        {
            if (!minDate.HasValue)
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            if (!maxDate.HasValue)
                maxDate = DateTime.Now;

            var result = _IntRepository.GetQueryable()
                .Where(r => r.Date_base >= minDate.Value || r.Date_base <= maxDate.Value);

            if (!String.IsNullOrEmpty(search))
            {
                result = result.Where(x =>
                x.Nsu.Contains(search) ||
                x.Terminal.Contains(search) ||
                x.Card_number.Contains(search));
            }
            return new Tuple<List<Intermeio>, DateTime?, DateTime?>(await PagingList.CreateAsync(result.OrderByDescending(x => x.Date_base), 20, 1), minDate, maxDate);
        }
        /// <summary>
        /// Pega todas informações do banco Intermeio
        /// </summary>
        /// <returns></returns>
        public void GetAllBaseIntermeio()
        {
            #region Connection
            string dateTime = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            SqlConnection _con = new SqlConnection(Constante._con);
            string str = Constante.str + dateTime + "' " +
                  "order by pos.DataCadastro desc";
            #endregion
            using (SqlCommand coon = new SqlCommand(str, _con))
            {
                _con.Open();
                SqlDataReader reader = coon.ExecuteReader();
                while (reader.Read())
                {
                    Intermeio intermeio = new Intermeio();
                    intermeio.TransacaoId = Convert.ToString(reader["Id"]);
                    intermeio.Bandeira = Convert.ToString(reader["Bandeira"]);
                    intermeio.CodAutorizacao = Convert.ToString(reader["CodAutorizacao"]);
                    intermeio.Nsu = Convert.ToString(reader["Nsu"]);
                    intermeio.Valor = Convert.ToString(reader["Valor"]);
                    intermeio.Confirmation_date = Convert.ToString(reader["DataCadastro"]);
                    intermeio.Card_number = Convert.ToString(reader["MascaraCartao"]);

                    intermeio.PosId = Convert.ToString(reader["PosId"]);
                    intermeio.Terminal = Convert.ToString(reader["NumeroLogico"]);
                    intermeio.MID = Convert.ToString(reader["MID"]);
                    intermeio.Modelo = Convert.ToString(reader["Modelo"]);
                    intermeio.NumeroDeSerie = Convert.ToString(reader["NumeroDeSerie"]);
                    intermeio.Status = Convert.ToString(reader["Status"]);
                    intermeio.TID = Convert.ToString(reader["TID"]);

                    intermeio.UsuarioId = Convert.ToString(reader["UsuarioId"]);
                    intermeio.CpfCnpj = Convert.ToString(reader["CpfCnpj"]);
                    intermeio.NomeRazao = Convert.ToString(reader["NomeRazao"]);
                    intermeio.SaldoLiberado = Convert.ToString(reader["SaldoLiberado"]);
                    intermeio.Email = Convert.ToString(reader["Email"]);

                    intermeio.Date_base = DateTime.Now;

                    ListIntermeio.Add(intermeio);
                }
                _con.Close();
                ValidationBaseByNsu(ListIntermeio);
            }
        }

        public Intermeio IntermeioByNsu(string nsu)
        {
            throw new NotImplementedException();
        }
        public void ValidationBaseByNsu(List<Intermeio> listIntermeios)
        {
            List<Intermeio> ListInt = new List<Intermeio>();
            var resultNsu = listIntermeios.Select(x => x.Nsu).ToList().Except(_IntRepository.GetAll().Select(x => x.Nsu).ToList());
            Parallel.ForEach(listIntermeios, item =>
            {
                if (resultNsu.Any(x => x == item.Nsu))
                {
                    item.Date_base = DateTime.Now;
                    ListInt.Add(item);
                }
            });
            _IntRepository.Add(ListInt);
        }
    }
}
