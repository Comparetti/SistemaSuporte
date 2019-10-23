using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuporteCore.Entity;
using SuporteCore.Interfaces.Repository;
using SuporteCore.Util;

namespace SuporteCore.Service
{
    public class PosService : IPosService
    {
        private readonly IPosRepository _posRepository;
        SqlConnection _con = new SqlConnection(Constante._con);
        public PosService(IPosRepository posRepository)
        {
            _posRepository = posRepository;
        }
        public IEnumerable<Pos> GetPosAll()
        {
            IEnumerable<Pos> lstPos = _posRepository.GetAll();
            return lstPos;
        }

        public IEnumerable<Pos> GetPosDesativada(bool valida)
        {
            throw new NotImplementedException();
            // return _posRepository.GetAll().Where(x => x.DesvinculadoPermanentemente.Contains("true"));
        }
        public void RequestPosByIntermeio()
        {
            List<Pos> lstPos = new List<Pos>();
            using (SqlCommand coon = new SqlCommand(Constante.strDetalhePos, _con))
            {
                _con.Open();
                SqlDataReader reader = coon.ExecuteReader();
                while (reader.Read())
                {
                    Pos pos = new Pos();
                    pos.DataCadastro = Convert.ToString(reader["DataCadastro"]);

                    pos.Cpfcnpj = Convert.ToString(reader["cpfcnpj"]);
                    pos.NomeRazao = Convert.ToString(reader["NomeRazao"]);

                    pos.Modelo = Convert.ToString(reader["modelo"]);
                    pos.NumeroDeSerie = Convert.ToString(reader["NumeroDeSerie"]);
                    pos.NumeroLogico = Convert.ToString(reader["NumeroLogico"]);

                    pos.ValorAluguel = Convert.ToDouble(reader["ValorAluguel"]);
                    pos.DescontoEmFaturamento = Convert.ToString(reader["DescontoEmFaturamento"]).Replace("False", "Desativada").Replace("True", "Ativo");
                    pos.DiaVencimento = Convert.ToInt32(reader["DiaVencimento"]);
                    pos.AluguelStatus = Convert.ToString(reader["AluguelDesativado"]).Replace("True", "Desativado").Replace("False", "Ativo");
                    pos.PosStatus = Convert.ToString(reader["DesvinculadoPermanentemente"]).Replace("True", "Desativado").Replace("False", "Ativo");
                    lstPos.Add(pos);
                }
                _con.Close();
            }
            if (lstPos.Count != _posRepository.AmountPos())
                ValidationBase(lstPos);
        }

        public void ValidationAluguel(List<Pos> lstPos)
        {
            var lstUsuariosId = lstPos.Select(x => x.Cpfcnpj).ToList();
            throw new NotImplementedException();
        }
        public void ValidationBase(List<Pos> lstPos)
        {
            List<Pos> ListAddPos = new List<Pos>();
            var resultPos = lstPos.Select(x => x.NumeroDeSerie).ToList().Except(_posRepository.GetAll().Select(x => x.NumeroDeSerie).ToList());
            Parallel.ForEach(lstPos, item =>
            {
                if (resultPos.Any(x => x == item.NumeroDeSerie))
                {
                    ListAddPos.Add(item);
                }
            });
            _posRepository.Add(ListAddPos);
        }
    }
}
