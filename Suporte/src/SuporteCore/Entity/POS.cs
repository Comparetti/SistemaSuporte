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
        public string  DataCadastro { get; set; }
        public string  NomeRazao { get; set; }
        public string Cpfcnpj { get; set; }
        public string  NumeroDeSerie { get; set; }
        public string NumeroLogico { get; set; }
        public string  Modelo { get; set; }
        public double ValorAluguel { get; set; }
        public int DiaVencimento { get; set; }
        public string DescontoEmFaturamento { get; set; }
        public string AluguelStatus { get; set; }
        public string PosStatus { get; set; }

    }
}
