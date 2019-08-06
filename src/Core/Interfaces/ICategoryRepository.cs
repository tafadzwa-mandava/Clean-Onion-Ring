using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryByName(string name);
    }
}
