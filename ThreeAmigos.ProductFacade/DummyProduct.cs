using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using ThreeAmigos.ProductFacade.Models;

// TODO: Eventually replace this method with one that calls an API (and change dependancy injection)
namespace ThreeAmigos.ProductFacade
{
    public class DummyProduct : IProductFac
    {
        public string GetProduct(int id)
        {
            var product = Dummy(id);
            return JsonConvert.SerializeObject(product);
        }
        public string GetProducts()
        {
            var ListProduct = new List<Product>();
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

        private Product Dummy(int id)
        {
            switch (id)
            {
                case 1:
                    return (new Product() { ProductId = "1", Name = "Product 1", Category = "Electronic", Brand = "Undercutters", Description = "Example of a long description. Example of a long description. Example of a long description. Example of a long description. Example of a long description.", Price = 1.99, StockLevel = 12 });

                case 2:
                    return (new Product() { ProductId = "2", Name = "Product 2", Category = "Security", Brand = "Undercutters", Description = "Description", Price = 2.99, StockLevel = 1 });

                case 3:
                    return (new Product() { ProductId = "3", Name = "Product 3", Category = "Electronic", Brand = "Dodgy Dealers", Description = "Description", Price = 4.99, StockLevel = 0 });

                case 4:
                    return (new Product() { ProductId = "4", Name = "Product 4", Category = "Furniture", Brand = "Dodgy Dealers", Description = "Description", Price = 5.50, StockLevel = 456 });

                default:
                    throw new Exception();

            }
        }

        public string GetProductName(int id)
        {
            return "Product1";
        }
    }
}
