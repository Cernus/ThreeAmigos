using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web;
using ThreeAmigos.CustomerApp.Models;
using ThreeAmigos.OrderFacade;

namespace ThreeAmigos.CustomerApp.Services
{
    public static class OrderService
    {
        private static OrderFac orderFac = new OrderFac();

        // Create a new customer in InvoiceApi's database
        public static void CreateOrder(OrderDto orderDto)
        {
            // TODO: Decrement Stock in Store service

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

        public static List<Invoice> GetInvoices()
        {
            DummyOrder dummy = new DummyOrder();
            // TODO: Put method into OrderService
            string json = dummy.GetInvoices(1);
            return JsonConvert.DeserializeObject<List<Invoice>>(json);
        }
    }
}