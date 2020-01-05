﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThreeAmigos.CustomerApp.Models
{
    public class Review
    {
        public int Rating { get; set; }
        public string Description { get; set; }
        public string ProductName { get; set; }
        public string CustomerName { get; set; }
        public int ProductId { get; set; }
    }
}