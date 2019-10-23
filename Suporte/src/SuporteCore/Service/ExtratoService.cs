using SuporteCore.Entity;
using SuporteCore.Interfaces.Repository;
using SuporteCore.Interfaces.Service;
using SuporteCore.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace SuporteCore.Service
{

    public class ExtratoService : IExtratoService
    {
        private readonly IExtratoRepository _extratoRepository;
        private readonly IPosRepository _posRepository;
        SqlConnection _con = new SqlConnection();
        string str;
        public ExtratoService(IExtratoRepository extratoRepository, IPosRepository posRepository)
        {
            _posRepository = posRepository;
            _extratoRepository = extratoRepository;
        }
        public void Connection()
        {
            string dateTime = DateTime.Now.AddDays(-20).ToString("yyyy-MM-dd");
            _con = new SqlConnection(Constante._con);
            str = Constante.strExtratoPos + dateTime + "' " +
                  "and us.cpfcnpj = '";
        }
        public IEnumerable<Extrato> GetAll()
        {
            return _extratoRepository.GetAll();
        }

        public void ValidationAluguel()
        {
            List<Extrato> lstextratos = new List<Extrato>();
            

            var lstPos = _posRepository.GetCpfcnpj();


            foreach (var usuario in lstPos)
            {
                if (!_extratoRepository.ValidaCnpjBase(usuario))
                {
                    Extrato extrato = new Extrato();

                    extrato.ListClientePos = _posRepository.GetPosList(usuario);
                    extrato.cpfcnpj = usuario;
                    extrato.NomeRazao = _posRepository.GetNomeRazao(usuario);
                    extrato.DataCadastro = DateTime.Now.ToString("yyyy-MM-dd");
                    extrato.PosCadastradas = lstPos.FindAll(x => x.Equals(usuario)).Count;
                    extrato.TotalAluguel = _posRepository.GetTotalAluguel(usuario);

                    Connection();
                    using (SqlCommand coon = new SqlCommand(str + usuario + "'", _con))
                    {
                        _con.Open();
                        SqlDataReader reader = coon.ExecuteReader();

                        while (reader.Read())
                        {
                            extrato.PosCobradas = extrato.PosCobradas + 1;
                            double valorAluguel = Convert.ToDouble(reader["Valor"]);
                            extrato.TotalRecebido = extrato.TotalRecebido + valorAluguel;
                        }
                        extrato.StatusCobranca = extrato.TotalRecebido == extrato.TotalAluguel ? "Ok" : "Incorreto";
                        lstextratos.Add(extrato);
                    }
                }
            }

            throw new NotImplementedException();
        }
    }
}
