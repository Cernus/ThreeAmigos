using System;

namespace ThreeAmigos.OrderFacade.Models
{
    public class Order
    {
        // InvoiceId is generated in InvoiceApi
        // customerId will always be current User's id
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime TimeOrdered { get; set; }
    }
}
