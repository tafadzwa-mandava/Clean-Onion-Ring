using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ProductRepository : EfRepository<Product>, IProductRepository
    {

        public ProductRepository(ProductCategoryContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Product> GetProducts()
        {
            return _dbContext.Products.ToList();
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryId(int id)
        {
            var products = await GetProductsAsync();
            return products.Where(product => product.CategoryId == id);
        }

        public async Task<Product> GetProductByName(string name)
        {
            var products = await GetProductsAsync();
            return products.Where(product => product.Name.ToLower().Equals(name.ToLower())).FirstOrDefault();
        }
    }
}
