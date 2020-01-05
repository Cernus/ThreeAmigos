using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ThreeAmigos.CustomerApp.Models
{
    public class Invoice
    {
        public int OrderId { get; set; } // Used as reference in the nested gridview
        public string Reference { get; set; }
        public double InvoiceCost { get; set; }
        public string Status { get; set; }
        public string OrderDate { get; set; }
        public List<ProductOrder> Products {get; set;} // TODO: Delete this
    }
}