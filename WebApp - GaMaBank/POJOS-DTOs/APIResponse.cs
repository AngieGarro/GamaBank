﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POJOS_DTOs
{
    public class APIResponse
    {
        public object Data { get; set; }

        public string Status { get; set; }

        public string Message { get; set; }

        public string TransactionDate { get; set; }
    }
}
