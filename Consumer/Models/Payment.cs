﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer.Models
{
    public class Payment
    {
        public string cardNumber { get; set; }
        public string expiryDate { get; set; }
        public string cvv { get; set; }
    }
}
