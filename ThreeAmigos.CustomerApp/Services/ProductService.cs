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
        //private static DummyProduct productFac = new DummyProduct();
        private static ProductFac productFac = new ProductFac();

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
                throw new Exception("Could not find Product with id = " + id);
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

        // Get all Products from Store Api. If Store Api is down then get all Products from Customer Api
        public static List<Product> GetProductsDefaultStoreApi()
        {
            try
            {
                // Get Products from Store Api
                return GetProducts();
            }
            catch
            {
                try
                {
                    // Get Products from Customer Api
                    var json = productFac.GetProductsFromCustomerApi();
                    return JsonConvert.DeserializeObject<List<Product>>(json);
                }
                catch
                {
                    // Return null if both Services are down
                    return null;
                }
            }
        }

        // Check if product is currently in stock
        public static bool InStock(int id, int quantity)
        {
            return productFac.InStock(id, quantity);
        }

        // Decrement Stock by quantity
        public static void DecrementStock(int id, int quantity)
        {
            productFac.DecrementStock(id, quantity);
            // TODO: Handle response message
        }

        public static string GetProductName(int id)
        {
            string productName = productFac.GetProductName(id);
            return productName;
        }
    }
}