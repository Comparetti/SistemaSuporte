using System;
using System.Collections.Generic;
using System.Text;

namespace SuporteCore.Entity.DTO
{
    public abstract class BaseDTO
    {
        public List<LinkDTO> Links { get; set; } = new List<LinkDTO>();
    }
}
