using Ardalis.GuardClauses;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IAppLogger<CategoryService> _logger;
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IAsyncRepository<Product> _productRepository;

        public CategoryService(
            IAppLogger<CategoryService> logger,
            IAsyncRepository<Category> categoryRepository,
            IAsyncRepository<Product> productRepository
            )
        {
            _logger = logger;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public async Task<Category> AddCategoryAsync(Category category)
        {
            return await _categoryRepository.AddAsync(category);
        }

        public async Task<int> DeleteCategoryAsync(Category category)
        {
            var products = category.Products;

            if (products != null)
                await _productRepository.DeleteRangeAsync(products);

            return await _categoryRepository.DeleteAsync(category);
        }

        public async Task DeleteRangeCategoryAsync(List<Category> categories)
        {
            foreach (var category in categories)
            {
                var products = category.Products;
                if (products != null)
                    await _productRepository.DeleteRangeAsync(products);
            }
            await _categoryRepository.DeleteRangeAsync(categories);
        }

        public async Task<IEnumerable<Category>> GetAllCategoryItems(int categoryId)
        {
            var spec = new CategoryByIdSpecification(categoryId);
            return await _categoryRepository.ListAsync(spec);
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _categoryRepository.ListAllAsync();
        }

        public async Task<Category> GetCategoryById(int categoryId)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryId);
            Guard.Against.NullCategory(categoryId, category);
            return category;
        }

        public async Task<int> SetCategoryAsync(Category category)
        {
            Guard.Against.Null(category, nameof(category)); // Default message, you can remove the default guard
            Guard.Against.NullCategory(category.Id, category); // Custom message
            return await _categoryRepository.UpdateAsync(category);
        }
    }
}
