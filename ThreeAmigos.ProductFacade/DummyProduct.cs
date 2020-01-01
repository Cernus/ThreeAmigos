using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using ThreeAmigos.ProductFacade.Models;
using System.Threading.Tasks;

// TODO: Eventually replace this method with one that calls an API (and change dependancy injection)
namespace ThreeAmigos.ProductFacade
{
    public class DummyProduct : IProductFac
    {
        public string GetProduct(int id)
        {
            ProductDto product = null;

            var client = CustomerApiClient();
            var uri = "api/Customers/ProductDetail/";

            //Get Product by id from CustomerApi
            HttpResponseMessage response = client.GetAsync(uri + id).Result;
            if(response.IsSuccessStatusCode)
            {
                product = response.Content.ReadAsAsync<ProductDto>().Result;
                client.Dispose();
                return JsonConvert.SerializeObject(product);
            }
            else
            {
                //TODO: Get Product by id from StoreApi
                product = Dummy(id);
                return JsonConvert.SerializeObject(product);
            }

        }
        public string GetProducts()
        {
            var ListProduct = new List<ProductDto>();
            ListProduct.Add(Dummy(1));
            ListProduct.Add(Dummy(2));
            ListProduct.Add(Dummy(3));
            ListProduct.Add(Dummy(4));

            return JsonConvert.SerializeObject(ListProduct);
        }

        public bool InStock(int id)
        {
            return true;
        }

        private ProductDto Dummy(int id)
        {
            switch (id)
            {
                case 1:
                    return (new ProductDto() { ProductId = 1, Name = "Product 1", Category = "Electronic", Brand = "Undercutters", Description = "Example of a long description. Example of a long description. Example of a long description. Example of a long description. Example of a long description.", Price = 1.99, StockLevel = 12 });

                case 2:
                    return (new ProductDto() { ProductId = 2, Name = "Product 2", Category = "Security", Brand = "Undercutters", Description = "Description", Price = 2.99, StockLevel = 1 });

                case 3:
                    return (new ProductDto() { ProductId = 3, Name = "Product 3", Category = "Electronic", Brand = "Dodgy Dealers", Description = "Description", Price = 4.99, StockLevel = 0 });

                case 4:
                    return (new ProductDto() { ProductId = 4, Name = "Product 4", Category = "Furniture", Brand = "Dodgy Dealers", Description = "Description", Price = 5.50, StockLevel = 456 });

                default:
                    throw new Exception();

            }
        }

        public string GetProductName(int id)
        {
            return "Product1";
        }

        // Update the database in CustomerApi with latest Product information
        public HttpResponseMessage StoreProductData(string json)
        {
            // Convert json into list of ProductDtos
            List<ProductDto> productDtos = JsonConvert.DeserializeObject<List<ProductDto>>(json);

            // Create list of all ProductId's in productDtos
            List<int> productIds = new List<int>();

            for (int i = 0; i < productDtos.Count; i++)
            {
                productIds.Add(productDtos[i].ProductId);
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
                    if(validId == id)
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
            //TODO: Direct BaseAddress towards deployed Api
            client.BaseAddress = new System.Uri("https://threeamigoscustomerapi.azurewebsites.net/");
            //client.BaseAddress = new System.Uri("https://localhost:44301/");
            client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
            return client;
        }
    }
}
