using System;
using System.Collections.Generic;
using System.Text;

namespace ThreeAmigos.ProductFacade.Models
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int StockLevel { get; set; }
    }
}
