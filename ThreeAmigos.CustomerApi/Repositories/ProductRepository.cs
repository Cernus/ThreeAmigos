using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThreeAmigos.CustomerApi.Models;

namespace ThreeAmigos.CustomerApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CustomerContext _context;
        public ProductRepository(CustomerContext context)
        {
            _context = context;
        }
        public async Task<ProductDto> GetProduct(int id)
        {
            ProductDto product = await _context.Products
                .Where(p => p.ProductId == id)
                .FirstOrDefaultAsync();

            if (product != null)
            {
                return new ProductDto
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    Category = product.Category,
                    Brand = product.Brand,
                    Description = product.Description,
                    Price = product.Price,
                    StockLevel = product.StockLevel
                };
            }
            else
            {
                return null;
            }
        }

        public async Task<ProductDto> CreateProduct(ProductDto product)
        {
            // Check that a product with this id does not already exist
            ProductDto checkProduct = _context.Products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if(checkProduct != null)
            {
                return null;
            }

            try
            {
                ProductDto entity = new ProductDto();
                entity.ProductId = product.ProductId;
                entity.Name = product.Name;
                entity.Category = product.Category;
                entity.Brand = product.Brand;
                entity.Description = product.Description;
                entity.Price = product.Price;
                entity.StockLevel = product.StockLevel;

                _context.Add(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ProductDto> UpdateProduct(ProductDto product)
        {
            try
            {
                ProductDto entity = _context.Products.FirstOrDefault(p => p.ProductId == product.ProductId);

                // Only update fields that are not null
                if(product.Name != null)
                {
                    entity.Name = product.Name;
                }

                if (product.Category != null)
                {
                    entity.Category = product.Category;
                }

                if (product.Brand != null)
                {
                    entity.Brand = product.Brand;
                }

                if (product.Description != null)
                {
                    entity.Description = product.Description;
                }

                if (product.Price != null)
                {
                    entity.Price = product.Price;
                }

                if (product.StockLevel != null)
                {
                    entity.StockLevel = product.StockLevel;
                }

                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return entity;
            }
            catch
            {
                return null;

            }
        }

        
    }
}
