using System;
using System.Collections.Generic;
using System.Text;

namespace SuporteCore.Util
{
    public class ListPaginacao<T> : List<T>
    {
        public Paginacao Paginacao { get; set; }
    }
}
