using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class CategoryRepository : EfRepository<Category>, ICategoryRepository
    {

        public CategoryRepository(ProductCategoryContext dbContext) : base(dbContext)
        {
        }

        public async Task<Category> GetCategoryByName(string name)
        {
            var categories = await GetCategoriesAsync();
            return categories.Where(category => category.Name.ToLower().Equals(name.ToLower())).FirstOrDefault();
        }

        public IEnumerable<Category> GetCategories()
        {
            return _dbContext.Categories
                .Include(o => o.Products)
                .ToList();
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _dbContext.Categories
                .Include(o => o.Products)
                .ToListAsync();
        }

    }
}
