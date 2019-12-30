using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThreeAmigos.CustomerApp.Models
{
    public class ReviewDto
    {
        public int Rating { get; set; }
        public string Body { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
    }
}