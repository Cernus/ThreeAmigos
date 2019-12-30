using System;

namespace ThreeAmigos.CustomerApp
{
    public class Product
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        // TODO: Format so price leads with a "£"
        public double Price { get; set; }
        public int StockLevel { get; set; }
    }
}