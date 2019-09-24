using System;
using System.Collections.Generic;
using System.Text;

namespace SuporteCore.Entity.DTO
{
    public class AnaliseDTO : BaseDTO
    {
        public AnaliseDTO()
        {
        }

        public int AnaliseId { get; set; }
        public string CpfCnpj { get; set; }
        public string NomeRazao { get; set; }
        public int PhoebusId { get; set; }
        public Phoebus Phoebus { get; set; }
        public string Obsservacao { get; set; }
    }
}
