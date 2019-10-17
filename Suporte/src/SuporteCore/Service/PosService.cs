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
            return _posRepository.GetAll().Where(x => x.Desvinculado.Contains("true"));
        }

        public void RequestPosByIntermeio()
        {
            List<Pos> lstPos = new List<Pos>();
            using (SqlCommand coon = new SqlCommand(Constante.strAluguelPos, _con))
            {
                _con.Open();
                SqlDataReader reader = coon.ExecuteReader();
                while (reader.Read())
                {
                    Pos pos = new Pos();
                    pos.Modelo = Convert.ToString(reader["modelo"]);
                    pos.NomeRazao= Convert.ToString(reader["NomeRazao"]);
                    pos.IdUsuario = Convert.ToString(reader["UsuarioId"]);
                    pos.NumeroDeSerie = Convert.ToString(reader["NumeroDeSerie"]);
                    pos.Status = Convert.ToString(reader["Status"]).Replace("1", "true").Replace("0", "false");
                    pos.VendidoAlugadoAlocado = Convert.ToString(reader["VendidoAlugadoAlocado"]).Replace("1", "true").Replace("0", "false");
                    pos.Desvinculado = Convert.ToString(reader["DesvinculadoPermanentemente"]).Replace("1","true").Replace("0","false");
                    pos.DescontoAluguel = Convert.ToDouble(reader["DescontoAluguel"]);
                    pos.DiaVencimento = Convert.ToInt32(reader["DiaVencimento"]);
                    pos.ValorAluguel = Convert.ToDouble(reader["ValorAluguel"]);
                    pos.DescontoEmFaturamento = Convert.ToString(reader["DescontoEmFaturamento"]).Replace("1", "true").Replace("0", "false");
                    pos.DescontoSaldoNegativo = Convert.ToString(reader["DescontoSaldoNegativo"]).Replace("1", "true").Replace("0", "false");
                    pos.AluguelDesativado = Convert.ToString(reader["AluguelDesativado"]).Replace("1", "true").Replace("0", "false");

                    lstPos.Add(pos);
                }
                _con.Close();
            }
            _posRepository.Add(lstPos);
                 //if (lstPos.Count != _posRepository.AmountPos())
                 //    ValidationBase(lstPos);
        }

        public void ValidationAluguel(List<Pos> lstPos)
        {
            var lstUsuariosId = lstPos.Select(x => x.IdUsuario).ToList();


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
