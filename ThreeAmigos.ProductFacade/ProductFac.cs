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
        public string GetProduct(int id)
        {
            throw new NotImplementedException();
        }
        // TODO: Redo so that Products are stored in CustomerApi before redirected to product detail page.

        public string GetProductName(int id)
        {
            throw new NotImplementedException();
        }

        // TODO: call StoreApi
        public string GetProducts()
        {
            throw new NotImplementedException();
        }

        // Check if product is currently in stock
        public bool InStock(int id)
        {
            throw new NotImplementedException();
        }

        public HttpResponseMessage StoreProductData(string json)
        {
            throw new NotImplementedException();
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
    }
}
