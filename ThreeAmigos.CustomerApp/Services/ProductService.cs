using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThreeAmigos.ProductFacade;
using Newtonsoft.Json;

namespace ThreeAmigos.CustomerApp.Services
{
    public static class ProductService
    {
        // TODO: Replace DummyProduct with ProductFac
        private static DummyProduct productFac = new DummyProduct();

        // Get Product by id
        public static Product GetProduct(int id)
        {
            string json;
            try
            {
                json = productFac.GetProduct(id);

            }
            catch
            {
                throw new Exception();
            }

            return JsonConvert.DeserializeObject<Product>(json);
        }

        // Get all products as a list
        public static List<Product> GetProducts()
        {
            // Get all Products as json from Store Service
            var json = productFac.GetProducts();

            // Create/Update database in Customer Api with new Product information
            var response = productFac.StoreProductData(json);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Received a bad response from the web service.");
            }

            // Return as a List of Products
            return JsonConvert.DeserializeObject<List<Product>>(json);
        }

        // Check if product is currently in stock
        public static bool InStock(int id)
        {
            return productFac.InStock(id);
        }

        public static string GetProductName(int id)
        {
            string productName = null;
            return productFac.GetProductName(id);
        }
    }
}