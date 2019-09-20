using System;
using System.Collections.Generic;
using System.Text;

namespace SuporteCore.Util
{
    public class Paginacao
    {
        public int? NumeroPagina { get; set; }
        public int? RegistroPorPagina { get; set; }
        public int? TotalRegistro { get; set; }
        public int? TotalPaginas { get; set; }
    }
}
