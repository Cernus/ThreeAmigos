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
            // TODO: Id currently not used
            // TODO: Assign orders to customers (Do not return all products for each id in the query string)

            switch (id)
            {
                case 2:
                    return JsonConvert.SerializeObject(GetOrders2());
                case 3:
                    return JsonConvert.SerializeObject(GetOrders3());
                case 4:
                    return JsonConvert.SerializeObject(GetOrders4());
                default:
                    return null;
            }

            //products1.Add(new ProductOrder()
            //{
            //    ProductId = 1,
            //    Name = "Product1",
            //    Category = "Furniture",
            //    Brand = "Undercutters",
            //    Description = "Description of product",
            //    TotalPrice = 100.99,
            //    Quantity = 3,
            //    OrderId = 0
            //});

            //products1.Add(new ProductOrder()
            //{
            //    ProductId = 2,
            //    Name = "Product2",
            //    Category = "Electronic",
            //    Brand = "Undercutters",
            //    Description = "Description of product",
            //    TotalPrice = 80.00,
            //    Quantity = 1,
            //    OrderId = 0
            //});

            //products1.Add(new ProductOrder()
            //{
            //    ProductId = 3,
            //    Name = "Product3",
            //    Category = "Furniture",
            //    Brand = "Dodby Dealers",
            //    Description = "Description of product",
            //    TotalPrice = 17600.99,
            //    Quantity = 99,
            //    OrderId = 0
            //});

            //products2.Add(new ProductOrder()
            //{
            //    ProductId = 2,
            //    Name = "Product2",
            //    Category = "Furniture",
            //    Brand = "Undercutters",
            //    Description = "Description of product",
            //    TotalPrice = 100.99,
            //    Quantity = 3,
            //    OrderId = 1
            //});

            //products2.Add(new ProductOrder()
            //{
            //    ProductId = 1,
            //    Name = "Product1",
            //    Category = "Electronic",
            //    Brand = "Undercutters",
            //    Description = "Example of a long description. Example of a long description. Example of a long description. Example of a long description. Example of a long description.",
            //    TotalPrice = 80.00,
            //    Quantity = 1,
            //    OrderId = 1
            //});

            //products3.Add(new ProductOrder()
            //{
            //    ProductId = 3,
            //    Name = "Product3",
            //    Category = "Furniture",
            //    Brand = "Undercutters",
            //    Description = "Description of product",
            //    TotalPrice = 100.99,
            //    Quantity = 3,
            //    OrderId = 2
            //});

            //double invoiceCost1 = GetInvoiceCost(invoices[0]);
            //double invoiceCost2 = GetInvoiceCost(invoices[1]);
            //double invoiceCost3 = GetInvoiceCost(invoices[2]);

            //invoices[0].invoiceCost = invoiceCost1;
            //invoices[1].invoiceCost = invoiceCost2;
            //invoices[2].invoiceCost = invoiceCost3;

            //return JsonConvert.SerializeObject(invoices);
        }

        private List<Invoice> GetOrders2()
        {
            List<Invoice> invoices = new List<Invoice>();

            var products1 = new List<ProductOrder>();
            var products2 = new List<ProductOrder>();
            var products3 = new List<ProductOrder>();

            // Add Product to products lists
            products1.Add(new ProductOrder()
            {
                ProductId = 1,
                TotalPrice = 0,
                Quantity = 3,
                OrderId = 0
            });

            products1.Add(new ProductOrder()
            {
                ProductId = 2,
                TotalPrice = 0,
                Quantity = 1,
                OrderId = 0
            });

            products1.Add(new ProductOrder()
            {
                ProductId = 3,
                TotalPrice = 0,
                Quantity = 99,
                OrderId = 0
            });

            products2.Add(new ProductOrder()
            {
                ProductId = 2,
                TotalPrice = 0,
                Quantity = 3,
                OrderId = 1
            });

            products2.Add(new ProductOrder()
            {
                ProductId = 1,
                TotalPrice = 0,
                Quantity = 1,
                OrderId = 1
            });

            products3.Add(new ProductOrder()
            {
                ProductId = 3,
                TotalPrice = 0,
                Quantity = 3,
                OrderId = 2
            });

            // Make Invoices
            invoices.Add(new Invoice()
            {
                OrderId = 0,
                Reference = "ref1",
                Status = "Pending",
                Products = products1,
                OrderDate = new DateTime(2019, 10, 10).ToShortDateString(),
                InvoiceCost = 0
            });

            invoices.Add(new Invoice()
            {
                OrderId = 1,
                Reference = "ref2",
                Status = "Cancelled",
                Products = products2,
                OrderDate = new DateTime(2019, 10, 11).ToShortDateString(),
                InvoiceCost = 0
            });

            invoices.Add(new Invoice()
            {
                OrderId = 2,
                Reference = "ref3",
                Status = "Delivered",
                Products = products3,
                OrderDate = new DateTime(2019, 10, 12).ToShortDateString(),
                InvoiceCost = 0
            });

            return invoices;
        }

        // TODO
        private List<Invoice> GetOrders3()
        {
            List<Invoice> invoices = new List<Invoice>();

            var products1 = new List<ProductOrder>();
            var products2 = new List<ProductOrder>();
            var products3 = new List<ProductOrder>();

            // Add Product to products lists
            products1.Add(new ProductOrder()
            {
                ProductId = 16,
                TotalPrice = 0,
                Quantity = 3,
                OrderId = 0
            });


            products1.Add(new ProductOrder()
            {
                ProductId = 4,
                TotalPrice = 0,
                Quantity = 9,
                OrderId = 0
            });

            products2.Add(new ProductOrder()
            {
                ProductId = 2,
                TotalPrice = 0,
                Quantity = 3,
                OrderId = 1
            });

            products2.Add(new ProductOrder()
            {
                ProductId = 1,
                TotalPrice = 0,
                Quantity = 6,
                OrderId = 1
            });

            products3.Add(new ProductOrder()
            {
                ProductId = 7,
                TotalPrice = 0,
                Quantity = 8,
                OrderId = 2
            });

            // Make Invoices
            invoices.Add(new Invoice()
            {
                OrderId = 0,
                Reference = "ref4",
                Status = "Pending",
                Products = products1,
                OrderDate = new DateTime(2019, 10, 15).ToShortDateString(),
                InvoiceCost = 0
            });

            invoices.Add(new Invoice()
            {
                OrderId = 1,
                Reference = "ref5",
                Status = "Pending",
                Products = products2,
                OrderDate = new DateTime(2019, 01, 21).ToShortDateString(),
                InvoiceCost = 0
            });

            invoices.Add(new Invoice()
            {
                OrderId = 2,
                Reference = "ref6",
                Status = "Delivered",
                Products = products3,
                OrderDate = new DateTime(2019, 11, 02).ToShortDateString(),
                InvoiceCost = 0
            });

            return invoices;
        }

        // TODO
        private List<Invoice> GetOrders4()
        {
            return null;
        }

        // TODO: Delete
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
