﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SuporteCore.Util
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int ExpiracaoHoras { get; set; }
        public string  Emissor { get; set; }
        public string  ValidoEm { get; set; }
    }
}
