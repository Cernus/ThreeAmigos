using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using ThreeAmigos.CustomerApp.Models;
using ThreeAmigos.OrderFacade;
using ThreeAmigos.ProductFacade;

namespace ThreeAmigos.CustomerApp.Services
{
    public static class OrderService
    {
        private static DummyOrder orderFac = new DummyOrder();

        // Create a new customer in InvoiceApi's database
        public static void CreateOrder(OrderDto orderDto)
        {
            string json = JsonConvert.SerializeObject(orderDto);
            HttpResponseMessage response = orderFac.CreateOrder(json);
            if (response.IsSuccessStatusCode)
            {
                HttpContext.Current.Response.Redirect("~/Default");
            }
            else
            {
                throw new Exception("Received a bad response from the web service.");
            }
        }

        public static List<Invoice> GetInvoices(List<Product> products)
        {
            int customerId = UserService.GetCustomerId();

            // Get List of Invoices from Order Service
            string json = orderFac.GetInvoices(customerId);
            List<Invoice> invoices = JsonConvert.DeserializeObject<List<Invoice>>(json);

            // Add Product information to products in invoices
            foreach (Invoice invoice in invoices)
            {
                foreach (ProductOrder productOrder in invoice.Products)
                {
                    int productId = productOrder.ProductId;

                    Product productData = products.FirstOrDefault(p => p.Id == productOrder.ProductId);

                    productOrder.Name = productData.Name;
                    productOrder.Category = productData.CategoryName;
                    productOrder.Brand = productData.BrandName;
                    productOrder.Description = productData.Description;
                    productOrder.TotalPrice = (double)(productData.Price * productOrder.Quantity);
                }
            }

            // TODO: Handle situation where product Id does not exist (return null?)

            return invoices;
        }
    }
}