using System;
using System.Collections.Generic;
using System.Text;

namespace SuporteCore.Entity
{
    public class Analise : Base
    {
        public Analise()
        {
        }
        public int AnaliseId { get; set; }
        public string CpfCnpj { get; set; }
        public string NomeRazao { get; set; }
        public int PhoebusId { get; set; }
        public Phoebus Phoebus { get; set; }
    }
}
