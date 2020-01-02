using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using ThreeAmigos.ProductFacade.Models;

//TODO: Create Facade for each objects that are being called from apis
namespace ThreeAmigos.ProductFacade
{
    public interface IProductFac
    {
        string GetProducts();
        string GetProduct(int id);
        bool InStock(int id, int quantity);
        string GetProductName(int id);
        HttpResponseMessage StoreProductData(string json);
    }
}