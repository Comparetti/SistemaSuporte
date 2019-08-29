using System;
using System.Collections.Generic;
using System.Text;

namespace SuporteCore.Entity
{
    public class Intermeio : Base
    {
        public Intermeio()
        {
        }
        public int IntermeioId { get; set; }
        public string TransacaoId { get; set; }
        public string Bandeira { get; set; }
        public string CodAutorizacao { get; set; }
        public string Valor { get; set; }
        public string PosId { get; set; }
        public string Modelo { get; set; }
        public string NumeroDeSerie { get; set; }
        public string TID { get; set; }
        public string MID { get; set; }
        public string UsuarioId { get; set; }
        public string CpfCnpj { get; set; }
        public string NomeRazao { get; set; }
        public string Status { get; set; }
        public string SaldoLiberado { get; set; }
        public string Email { get; set; }
    }
}
