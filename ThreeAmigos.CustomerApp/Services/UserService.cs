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
    // TODO: Look at singleton pattern for CustomerFac
    public static class UserService
    {
        private static CustomerFac customerFac = new CustomerFac();

        public static int GetCustomerId()
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
        public static Customer GetUser()
        {
            string json = null;
            try
            {
                int customerId = GetUserId();
                json = customerFac.GetCustomer(customerId);
            }
            catch
            {
                HttpContext.Current.Response.Redirect("~/Default");
            }

            return JsonConvert.DeserializeObject<Customer>(json);
        }

        public static int GetUserId()
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
            int id = GetCustomerId();
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
            if (response.IsSuccessStatusCode)
            {
                HttpContext.Current.Response.Redirect("~/Default");
            }
            else
            {
                throw new Exception("Received a bad response from the web service.");
            }
        }

        // Request delete for customer
        public static void RequestDelete()
        {
            int customerId = GetCustomerId();

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

        public static bool HasAddressAndTel()
        {
            int id = GetCustomerId();
            if (customerFac.HasAddressAndTel(id))
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