﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabW12Quotes.Models.Entities
{
    public class Quote
    {
        public int Id { get; set; }
        public string TheQuote { get; set; }
        public string WhoSaidIt { get; set; }

    }
}
