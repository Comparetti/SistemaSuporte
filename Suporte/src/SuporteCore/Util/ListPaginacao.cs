using SuporteCore.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuporteCore.Util
{
    public class ListPaginacao<T>
    {
        public List<T> Results { get; set; } = new List<T>();
        public List<LinkDTO> Links { get; set; } = new List<LinkDTO>();
        public Paginacao Paginacao { get; set; }


    }
}
