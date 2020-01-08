using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using ThreeAmigos.CustomerFacade;

namespace ThreeAmigos.CustomerApp.Services
{
    public static class UserService
    {
        private static CustomerFac customerFac = new CustomerFac();

        // Return CustomerId for current user
        public static int GetUserId()
        {
            try
            {
                return Int32.Parse(HttpContext.Current.User.Identity.Name);
            }
            catch
            {
                return 0;
            }
        }

        // Return Customer information for customer of current page
        public static Customer GetCustomer()
        {
            string json = null;
            try
            {
                int customerId = GetCustomerId();
                json = customerFac.GetCustomer(customerId);
            }
            catch
            {
                HttpContext.Current.Response.Redirect("~/Default");
            }

            return JsonConvert.DeserializeObject<Customer>(json);
        }

        // Get CustomerId for customer of current page
        public static int GetCustomerId()
        {
            try
            {
                string queryString = HttpContext.Current.Request.QueryString["id"];
                int customerId = Int32.Parse(queryString);
                return customerId;
            }
            catch
            {
                return 0;
            }
        }

        // Return a list of objects containing all customer Id's and names
        public static List<CustomerName> GetCustomerNames()
        {
            string json = null;
            List<CustomerName> customerNames = new List<CustomerName>();
            try
            {
                json = customerFac.GetCustomerNames();
                customerNames = JsonConvert.DeserializeObject<List<CustomerName>>(json);
            }
            catch
            {
                HttpContext.Current.Response.Redirect("~/Default");
            }

            return customerNames;
        }

        public static string GetUserName()
        {
            string customerName = null;

            try
            {
                int customerId = Int32.Parse(HttpContext.Current.User.Identity.Name);
                customerName = customerFac.GetCustomerName(customerId);
            }
            catch
            {
                HttpContext.Current.Response.Redirect("~/Default");
            }

            return customerName;
        }
        public static string GetCustomerName()
        {
            string customerName = null;
            
            try
            {
                int customerId = GetCustomerId();
                customerName = customerFac.GetCustomerName(customerId);
            }
            catch
            {
                HttpContext.Current.Response.Redirect("~/Default");
            }

            return customerName;
        }

        public static CustomerUpdateDto GetUserUpdate()
        {
            string queryString = HttpContext.Current.Request.QueryString["id"];
            int customerId = Int32.Parse(queryString);
            var json = customerFac.GetCustomerUpdate(customerId);
            return JsonConvert.DeserializeObject<CustomerUpdateDto>(json);
        }

        // Update Customer record in database
        public static void UpdateUser(CustomerUpdateDto customerUpdateDto)
        {
            int id = GetUserId();
            string json = JsonConvert.SerializeObject(customerUpdateDto);
            HttpResponseMessage response = customerFac.UpdateCustomer(id, json);
            if (response.IsSuccessStatusCode)
            {
                HttpContext.Current.Response.Redirect("~/Default");
            }
            else
            {
                throw new Exception("Received a bad response from the web service.");
            }
        }

        // Create a new customer in CustomerApi' database
        public static void CreateUser(CustomerUpdateDto customerUpdateDto)
        {
            string json = JsonConvert.SerializeObject(customerUpdateDto);
            HttpResponseMessage response = customerFac.CreateCustomer(json);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Received a bad response from the web service.");
            }
        }

        // Request delete for customer
        public static void RequestDelete()
        {
            int customerId = GetUserId();

            HttpResponseMessage response = customerFac.RequestDelete(customerId); ;
            if (response.IsSuccessStatusCode)
            {
                HttpContext.Current.Response.Redirect("~/Default");
            }
            else
            {
                throw new Exception("Received a bad response from the web service.");
            }

            HttpContext.Current.Response.Redirect("~/Default");
        }

        public static bool HasDeliveryDetails()
        {
            int id = GetUserId();
            if (customerFac.HasDeliveryDetails(id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}