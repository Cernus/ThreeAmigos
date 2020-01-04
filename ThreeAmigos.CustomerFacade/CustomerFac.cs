using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ThreeAmigos.CustomerFacade
{
    public class CustomerFac : ICustomerFac
    {
        // Get customer by id
        public string GetCustomer(int id)
        {
            Customer customer = null;

            var client = Client();

            // TODO: Handle situations where a customerId that does not exist is sent to CustomerApi

            // Get customer by id from CustomerApi
            HttpResponseMessage response = client.GetAsync("api/customers/detail/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                customer = response.Content.ReadAsAsync<Customer>().Result;
            }
            else
            {
                throw new Exception("Received a bad response from the web service.");
            }

            client.Dispose();
            return JsonConvert.SerializeObject(customer);
        }

        public string GetCustomerUpdate(int id)
        {
            CustomerUpdateDto customerUpdateDto = null;

            var client = Client();

            // TODO: Handle situations where a customerId that does not exist is sent to CustomerApi

            // Get customer by id from CustomerApi
            HttpResponseMessage response = client.GetAsync("api/customers/detail/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                customerUpdateDto = response.Content.ReadAsAsync<CustomerUpdateDto>().Result;
            }
            else
            {
                throw new Exception("Received a bad response from the web service.");
            }

            client.Dispose();
            return JsonConvert.SerializeObject(customerUpdateDto);
        }

        public HttpResponseMessage UpdateCustomer(int id, string json)
        {
            var client = Client();

            var uri = "api/customers/update/" + id;

            CustomerUpdateDto customerUpdateDto = JsonConvert.DeserializeObject<CustomerUpdateDto>(json);
            var response = client.PutAsJsonAsync<CustomerUpdateDto>(uri, customerUpdateDto).Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Received a bad response from the web service.");
            }
            return response;
        }

        public HttpResponseMessage CreateCustomer(string json)
        {
            var client = Client();

            var uri = "api/customers/create";

            CustomerUpdateDto customerUpdateDto = JsonConvert.DeserializeObject<CustomerUpdateDto>(json);
            var response = client.PostAsJsonAsync<CustomerUpdateDto>(uri, customerUpdateDto).Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Received a bad response from the web service.");
            }
            return response;
        }

        // Request deletion for customer
        public HttpResponseMessage RequestDelete(int id)
        {
            var client = Client();

            var uri = "api/customers/RequestDelete/" + id;

            var response = client.PutAsJsonAsync(uri, id).Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Received a bad response from the web service.");
            }
            return response;
        }

        // Check that Customer has an Address and Telephone Number
        public bool HasAddressAndTel(int id)
        {
            var client = Client();

            var uri = "api/customers/HasAddressAndTel/" + id;

            // Get customer by id from CustomerApi
            HttpResponseMessage response = client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                client.Dispose();
                return true;
            }
            else
            {
                client.Dispose();
                return false;
            }
        }

        public int Authenticate(string username, string password)
        {
            var client = Client();

            List<String> authDetails = new List<string>();
            authDetails.Add(username);
            authDetails.Add(password);
            int userId = 0;

            var uri = "api/customers/authenticate/";

            HttpResponseMessage response = client.PostAsJsonAsync(uri, authDetails).Result;

            if (response.IsSuccessStatusCode)
            {
                userId = response.Content.ReadAsAsync<int>().Result;
            }
            else
            {
                throw new Exception("Received a bad response from the web service.");
            }

            client.Dispose();
            return userId;
        }

        // Create a client that is used to communicate with CustomerApi
        private static HttpClient Client()
        {
            //Authenticator = new HttpBasicAuthenticator("user", "password")
            HttpClient client = new HttpClient();
            // TODO: Redirect back to deployed Api
            //client.BaseAddress = new System.Uri("https://threeamigoscustomerapi.azurewebsites.net/");
            client.BaseAddress = new System.Uri("https://localhost:44301/");
            client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
            return client;
        }
    }
}
