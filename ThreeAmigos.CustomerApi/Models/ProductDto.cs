using System;
using System.ComponentModel.DataAnnotations;

namespace ThreeAmigos.CustomerApi.Models
{
    public class ProductDto
    {
        [Key]
        [Required]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
        public int? StockLevel { get; set; }
    }
}
