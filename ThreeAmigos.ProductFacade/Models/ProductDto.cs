using System;
using System.Collections.Generic;
using System.Text;

namespace ThreeAmigos.ProductFacade.Models
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int StockLevel { get; set; }
    }
}
