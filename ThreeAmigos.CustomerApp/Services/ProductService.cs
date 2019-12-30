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
         private static DummyProduct productFac = new DummyProduct();

        // Get all products as a list
        public static List<Product> GetProducts()
        {
            // TODO: Replace DummyProduct with ProductFac
            var json = productFac.GetProducts();
            return JsonConvert.DeserializeObject<List<Product>>(json);
        }

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