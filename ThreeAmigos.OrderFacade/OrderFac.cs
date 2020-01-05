using System;
using System.Net.Http;
using ThreeAmigos.OrderFacade.Models;

namespace ThreeAmigos.OrderFacade
{
    public class OrderFac : IOrderFac
    {
        public HttpResponseMessage CreateOrder(string json)
        {
            throw new NotImplementedException();
        }

        public string GetInvoices(int id)
        {
            throw new NotImplementedException();
        }

        private double GetInvoiceCost(Invoice invoice)
        {
            double price = 0.00;

            for (int i = 0; i < invoice.Products.Count; i++)
            {
                price += invoice.Products[i].TotalPrice;
            }

            return price;
        }
    }
}
