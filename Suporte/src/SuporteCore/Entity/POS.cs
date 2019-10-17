using System;
using System.Collections.Generic;
using System.Text;

namespace SuporteCore.Entity
{
    public class Pos
    {
        public Pos()
        {
        }
        public int PosId { get; set; }
        public string IdUsuario { get; set; }
        public string  NomeRazao { get; set; }
        public string  Modelo { get; set; }
        public string  NumeroDeSerie { get; set; }
        public string Status { get; set; }
        public string VendidoAlugadoAlocado { get; set; }
        public string Desvinculado { get; set; }
        public double DescontoAluguel { get; set; }
        public int DiaVencimento { get; set; }
        public double ValorAluguel { get; set; }
        public string DescontoEmFaturamento { get; set; }
        public string DescontoSaldoNegativo { get; set; }
        public string AluguelDesativado { get; set; }

    }
}
