using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using ThreeAmigos.ProductFacade.Models;

namespace ThreeAmigos.ProductFacade
{
    public interface IProductFac
    {
        string GetProducts();
        string GetProductsFromCustomerApi();
        string GetProduct(int id);
        bool InStock(int id, int quantity);
        string GetProductName(int id);
        HttpResponseMessage StoreProductData(string json);
    }
}