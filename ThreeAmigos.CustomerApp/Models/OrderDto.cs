﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThreeAmigos.CustomerApp.Models
{
    public class OrderDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime TimeOrdered { get; set; }
    }
}