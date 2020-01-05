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

        public async Task<List<ProductDto>> GetProducts()
        {
            List<ProductDto> products = await _context.Products.ToListAsync();

            var ProductDto = products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                CategoryName = p.CategoryName,
                BrandName = p.BrandName,
                Description = p.Description,
                Price = p.Price,
                StockLevel = p.StockLevel
            }).ToList();

            return products;
        }

        public async Task<ProductDto> GetProduct(int id)
        {
            ProductDto product = await _context.Products
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            if (product != null)
            {
                return new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    CategoryName = product.CategoryName,
                    BrandName = product.BrandName,
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
            ProductDto checkProduct = _context.Products.FirstOrDefault(p => p.Id == product.Id);
            if (checkProduct != null)
            {
                return null;
            }

            try
            {
                ProductDto entity = new ProductDto();
                entity.Id = product.Id;
                entity.Name = product.Name;
                entity.CategoryName = product.CategoryName;
                entity.BrandName = product.BrandName;
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
                ProductDto entity = _context.Products.FirstOrDefault(p => p.Id == product.Id);

                // Only update fields that are not null
                if (product.Name != null)
                {
                    entity.Name = product.Name;
                }

                if (product.CategoryName != null)
                {
                    entity.CategoryName = product.CategoryName;
                }

                if (product.BrandName != null)
                {
                    entity.BrandName = product.BrandName;
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
