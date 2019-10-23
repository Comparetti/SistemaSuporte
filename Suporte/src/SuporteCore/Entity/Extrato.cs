using System;
using System.Collections.Generic;
using System.Text;

namespace SuporteCore.Entity
{
    public class Extrato
    {
        public Extrato()
        {
        }
        public int ExtratoId { get; set; }
        public string  DataCadastro { get; set; }
        public string  cpfcnpj { get; set; }
        public string  NomeRazao { get; set; }
        public int PosCadastradas { get; set; }
        public int PosCobradas { get; set; }
        public double  TotalAluguel { get; set; }
        public double TotalRecebido { get; set; }
        public string StatusCobranca { get; set; }
        public List<Pos> ListClientePos { get; set; }
    }
}
