using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace ThreeAmigos.CustomerApp.Repositories
{
    public class ProductRepository : IProductRepository, IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Product GetProductByID(string productId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProducts()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}