using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ThreeAmigos.ProductFacade.Models;

namespace ThreeAmigos.ProductFacade
{
    public class ProductFac : IProductFac
    {
        // Get all Products
        public string GetProducts()
        {
            var productList = new List<ProductDto>();

            var client = StoreServiceClient();

            var uri = "api/stock/";

            // Get all products from StoreService
            HttpResponseMessage response = client.GetAsync(uri).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Received a bad response from the web service.");
            }

            // TODO: Surround in try and catch for all of these in each facade?
            productList = response.Content.ReadAsAsync<List<ProductDto>>().Result;
            client.Dispose();
            return JsonConvert.SerializeObject(productList);
        }

        // Get Product by id
        public string GetProduct(int id)
        {
            ProductDto product = null;

            var client = StoreServiceClient();

            var uri = "api/product?id=";

            //Get Product by id from CustomerApi
            HttpResponseMessage response = client.GetAsync(uri + id).Result;
            if (response.IsSuccessStatusCode)
            {
                product = response.Content.ReadAsAsync<ProductDto>().Result;
            }
            else
            {
                var uri2 = "api/Customers/ProductDetail/";

                // Get product by id from StoreService
                HttpResponseMessage response2 = client.GetAsync(uri2 + id).Result;
                if (response2.IsSuccessStatusCode)
                {
                    product = response2.Content.ReadAsAsync<ProductDto>().Result;
                }
                else
                {
                    throw new Exception("Received a bad response from the web service.");
                }
            }

            client.Dispose();
            return JsonConvert.SerializeObject(product);

        }

        // Get Product Name by Id
        public string GetProductName(int id)
        {
            string productName;

            var client = CustomerApiClient();

            var uri = "api/customers/ProductName/";

            HttpResponseMessage response = client.GetAsync(uri + id).Result;
            if (response.IsSuccessStatusCode)
            {
                productName = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                var client2 = StoreServiceClient();

                var uri2 = "api/productName?id=";

                HttpResponseMessage response2 = client2.GetAsync(uri2 + id).Result;
                if (!response.IsSuccessStatusCode)
                {
                    productName = response2.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    throw new Exception("Received a bad response from the web service.");
                }
            }

            client.Dispose();
            return productName;
        }

        // TODO: Redesign so it checks whether there is enough in stock to match the quantity being ordered
        // Check if product is currently in stock
        public bool InStock(int id, int quantity)
        {
            bool valid = false;

            var client = StoreServiceClient();

            var uri = "api/instock?Id=";

            HttpResponseMessage response = client.GetAsync(uri + id + "&Quantity=" + quantity).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Received a bad response from the web service.");
            }

            valid = response.Content.ReadAsAsync<bool>().Result;

            return valid;
        }

        public HttpResponseMessage DecrementStock(int id, int quantity)
        {
            DecrementProductDto decrementProductDto = new DecrementProductDto
            {
                ProductId = id,
                DecrementBy = quantity
            };

            List<DecrementProductDto> list = new List<DecrementProductDto>();
            list.Add(decrementProductDto);

            var client = StoreServiceClient();

            var uri = "api/store/decrementstock";

            HttpResponseMessage response = client.PostAsJsonAsync<List<DecrementProductDto>>(uri, list).Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Received a bad response from the web service.");
            }
            return response;
        }

        // Save most recent Product data in Customer Api
        public HttpResponseMessage StoreProductData(string json)
        {
            // Convert json into list of ProductDtos
            List<ProductDto> productDtos = JsonConvert.DeserializeObject<List<ProductDto>>(json);

            // Create list of all ProductId's in productDtos
            List<int> productIds = new List<int>();

            for (int i = 0; i < productDtos.Count; i++)
            {
                productIds.Add(productDtos[i].Id);
            }

            // Get all products within database that match id's of products in productDtos
            var client = CustomerApiClient();

            var uri = "api/customers/ProductId/";

            List<int> existingProductIds = new List<int>();

            foreach (int id in productIds)
            {
                // Note: Is this pointing to the deployed version of Customer Api?
                var response = client.GetAsync(uri + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    int? validId = response.Content.ReadAsAsync<int>().Result;
                    if (validId == id)
                    {
                        existingProductIds.Add(id);
                    }
                }
                else
                {
                    throw new Exception("Received a bad response from the web service.");
                }
            }

            // Check if a record for each Product already exists in the database
            var putUri = "api/customers/updateProduct/";
            var postUri = "api/customers/createProduct/";

            for (int i = 0; i < productDtos.Count; i++)
            {
                HttpResponseMessage response;
                if (existingProductIds.Contains(productIds[i]))
                {
                    // Update existing Product record
                    response = client.PutAsJsonAsync<ProductDto>(putUri + productIds[i], productDtos[i]).Result;
                }
                else
                {
                    // Create new Product record
                    response = client.PostAsJsonAsync<ProductDto>(postUri, productDtos[i]).Result;
                }

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Received a bad response from the web service.");
                }
            }

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }

        // Create a client that is used to communicate with CustomerApi
        private static HttpClient CustomerApiClient()
        {
            //Authenticator = new HttpBasicAuthenticator("user", "password")
            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri("https://threeamigoscustomerapi.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
            return client;
        }

        // Create a client that is used to communicate with StoreService
        private static HttpClient StoreServiceClient()
        {
            //Authenticator = new HttpBasicAuthenticator("user", "password")
            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri("https://thamcostoreservice20191203112607.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
            return client;
        }
    }
}
