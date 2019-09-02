using SuporteCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuporteCore.Util
{
    public class DefaultRequest
    {
        public int page { get; set; } = 0;
        public int total_pages { get; set; } = 0;
        public int total_elements { get; set; } = 0;
        public int size { get; set; } = 100;
        public List<Phoebus> content { get; set; }
    }
}
