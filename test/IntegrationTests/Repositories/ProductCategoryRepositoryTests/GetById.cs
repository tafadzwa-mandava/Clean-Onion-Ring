using Infrastructure.Data;
using IntegrationTests.Builders;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace IntegrationTests.Repositories.ProductCategoryRepositoryTests
{
    public class GetById
    {
        private readonly ProductCategoryContext _productCategoryContext;
        private readonly CategoryRepository _categoryRepository;

        private readonly ITestOutputHelper _output;

        public GetById(ITestOutputHelper output)
        {
            _output = output;
            var dbOptions = new DbContextOptionsBuilder<ProductCategoryContext>()
                .UseInMemoryDatabase(databaseName: "TestProductCategory")
                .Options;
            _productCategoryContext = new ProductCategoryContext(dbOptions);
            _categoryRepository = new CategoryRepository(_productCategoryContext);
        }

        [Fact]
        public void GetsExistingCategory()
        {
            var dummyCategory = CategoryBuilder.Instance.DummyProductCategory();
            _productCategoryContext.Categories.Add(dummyCategory);
            _productCategoryContext.SaveChanges();
            int categoryId = dummyCategory.Id;
            _output.WriteLine($"CategoryId: {categoryId}");

            var categoryFromRepo = _categoryRepository.GetById(categoryId);
            Assert.Equal(dummyCategory.Id, categoryFromRepo.Id);
        }
    }
}
