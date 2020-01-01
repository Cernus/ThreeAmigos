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
    public static class CurrentUser
    {
        private static CustomerFac customerFac = new CustomerFac();

        // Return Customer information for current user
        public static Customer GetUser()
        {
            int id = GetCustomerId();
            // Get customer by id from Facade
            var json = customerFac.GetCustomer(id);
            return JsonConvert.DeserializeObject<Customer>(json);
        }

        public static CustomerUpdateDto GetUserUpdate()
        {
            int id = GetCustomerId();
            // Get customer by id from Facade
            var json = customerFac.GetCustomerUpdate(id);
            return JsonConvert.DeserializeObject<CustomerUpdateDto>(json);
        }

        // TODO
        public static int GetCustomerId()
        {
            return 2;
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
            int id = GetCustomerId();
            HttpResponseMessage response = customerFac.RequestDelete(id);
            if (response.IsSuccessStatusCode)
            {
                HttpContext.Current.Response.Redirect("~/Default");
            }
            else
            {
                throw new Exception("Received a bad response from the web service.");
            }
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