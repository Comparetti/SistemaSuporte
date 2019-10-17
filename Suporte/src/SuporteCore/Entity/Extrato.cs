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
        public int ExtratoAluguelId { get; set; }
        public string  DataCadastro { get; set; }
        public string IdTransacao { get; set; }
        public int CountPos { get; set; }
        public string IdUsuario { get; set; }
        public string NomeRazao { get; set; }
    }
}
