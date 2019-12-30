using System;
using System.Collections.Generic;

// TODO: 
namespace ThreeAmigos.CustomerApp.Repositories
{
    public interface IProductRepository : IDisposable
    {
        IEnumerable<Product> GetProducts();
        Product GetProductByID(string productId);
        void Save();
    }
}