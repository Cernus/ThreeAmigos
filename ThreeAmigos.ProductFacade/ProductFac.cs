using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
