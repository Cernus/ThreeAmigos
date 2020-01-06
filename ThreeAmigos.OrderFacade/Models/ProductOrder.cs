namespace ThreeAmigos.OrderFacade.Models
{
    public class ProductOrder
    {
        public int ProductId { get; set; }
        public double TotalPrice { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
    }
}