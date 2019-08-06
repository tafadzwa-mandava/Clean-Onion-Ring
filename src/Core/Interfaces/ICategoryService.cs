using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<IEnumerable<Category>> GetAllCategoryItems(int categoryId);
        Task<Category> GetCategoryById(int categoryId);
        Task<Category> AddCategoryAsync(Category category);
        Task<int> SetCategoryAsync(Category category);
        Task<int> DeleteCategoryAsync(Category category);
        Task DeleteRangeCategoryAsync(List<Category> categories);
    }
}
