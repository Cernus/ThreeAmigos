using System;
using System.ComponentModel.DataAnnotations;

namespace ThreeAmigos.CustomerApi.Models
{
    public class ProductDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
        public int? StockLevel { get; set; }
    }
}
