using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ThreeAmigos.OrderFacade.Models;
using Newtonsoft.Json;

namespace ThreeAmigos.OrderFacade
{
    public class DummyOrder : IOrderFac
    {
        public HttpResponseMessage CreateOrder(string json)
        {
            throw new NotImplementedException();
        }

        public string GetInvoices(int id)
        {
            // TODO: Assign orders to customers (Do not return all products for each id in the query string)
            
            var invoices = new List<Invoice>();

            var products1 = new List<ProductOrder>();
            var products2 = new List<ProductOrder>();
            var products3 = new List<ProductOrder>();

            // Add Product to products lists
            products1.Add(new ProductOrder()
            {
                ProductId = 1,
                Name = "Product1",
                Category = "Furniture",
                Brand = "Undercutters",
                Description = "Description of product",
                TotalPrice = 100.99,
                Quantity = 3,
                OrderId = 0
            });

            products1.Add(new ProductOrder()
            {
                ProductId = 2,
                Name = "Product2",
                Category = "Electronic",
                Brand = "Undercutters",
                Description = "Description of product",
                TotalPrice = 80.00,
                Quantity = 1,
                OrderId = 0
            });

            products1.Add(new ProductOrder()
            {
                ProductId = 3,
                Name = "Product3",
                Category = "Furniture",
                Brand = "Dodby Dealers",
                Description = "Description of product",
                TotalPrice = 17600.99,
                Quantity = 99,
                OrderId = 0
            });

            products2.Add(new ProductOrder()
            {
                ProductId = 2,
                Name = "Product2",
                Category = "Furniture",
                Brand = "Undercutters",
                Description = "Description of product",
                TotalPrice = 100.99,
                Quantity = 3,
                OrderId = 1
            });

            products2.Add(new ProductOrder()
            {
                ProductId = 1,
                Name = "Product1",
                Category = "Electronic",
                Brand = "Undercutters",
                Description = "Example of a long description. Example of a long description. Example of a long description. Example of a long description. Example of a long description.",
                TotalPrice = 80.00,
                Quantity = 1,
                OrderId = 1
            });

            products3.Add(new ProductOrder()
            {
                ProductId = 3,
                Name = "Product3",
                Category = "Furniture",
                Brand = "Undercutters",
                Description = "Description of product",
                TotalPrice = 100.99,
                Quantity = 3,
                OrderId = 2
            });

            // Make Invoices
            invoices.Add(new Invoice()
            {
                OrderId = 1,
                reference = "ref1",
                status = "Pending",
                products = products1
            });

            invoices.Add(new Invoice()
            {
                OrderId = 2,
                reference = "ref2",
                status = "Cancelled",
                products = products2
            });

            invoices.Add(new Invoice()
            {
                OrderId = 3,
                reference = "ref3",
                status = "Delivered",
                products = products3
            });

            double invoiceCost1 = GetInvoiceCost(invoices[0]);
            double invoiceCost2 = GetInvoiceCost(invoices[1]);
            double invoiceCost3 = GetInvoiceCost(invoices[2]);

            invoices[0].invoiceCost = invoiceCost1;
            invoices[1].invoiceCost = invoiceCost2;
            invoices[2].invoiceCost = invoiceCost3;

            return JsonConvert.SerializeObject(invoices);
        }

        private double GetInvoiceCost(Invoice invoice)
        {
            double price = 0.00;

            for(int i = 0; i < invoice.products.Count; i++)
            {
                price += invoice.products[i].TotalPrice;
            }

            return price;
        }
    }
}
