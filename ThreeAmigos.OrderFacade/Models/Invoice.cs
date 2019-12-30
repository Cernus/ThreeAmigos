using System.Collections.Generic;

namespace ThreeAmigos.OrderFacade.Models
{
    public class Invoice
    {
        public int OrderId { get; set; } // Used as reference in the nested gridview
        public string reference { get; set; }
        public double invoiceCost { get; set; }
        public string status { get; set; }
        public List<ProductOrder> products {get; set;}
    }
}