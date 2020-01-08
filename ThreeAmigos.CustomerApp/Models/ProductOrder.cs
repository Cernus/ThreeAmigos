namespace ThreeAmigos.CustomerApp.Models
{
    public class ProductOrder
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public double TotalPrice { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
    }
}