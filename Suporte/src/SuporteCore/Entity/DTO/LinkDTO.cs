using System;
using System.Collections.Generic;
using System.Text;

namespace SuporteCore.Entity.DTO
{
    public class LinkDTO
    {
        public LinkDTO(string rel, string href, string method)
        {
            Rel = rel;
            Href = href;
            Method = method;
        }
        public string  Rel { get; set; }
        public string  Href { get; set; }
        public string Method { get; set; }

    }
}
