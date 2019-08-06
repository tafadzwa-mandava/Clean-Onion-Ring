using Core.Entities;
using Core.Exceptions;
using Core.Interfaces;
using Core.Services;
using Moq;
using System;
using Xunit;

namespace UnitTests.Core.ServicesTests
{
    public class SetCategory
    {
        private int _invalidId = -1;
        private Mock<IAsyncRepository<Category>> _mockCategoryRepo;
        private Mock<IAsyncRepository<Product>> _mockProductRepo;

        public SetCategory()
        {
            _mockCategoryRepo = new Mock<IAsyncRepository<Category>>();
        }

        [Fact]
        public async void ThrowsGivenInvalidEntryId()
        {
            var categoryService = new CategoryService(null, _mockCategoryRepo.Object, _mockProductRepo.Object);

            await Assert.ThrowsAsync<CategoryNotFoundException>(
                async () => await categoryService.GetCategoryById(_invalidId)
            );
        }

        [Fact]
        public async void ThrowsGivenNullEntryServiceArguments()
        {
            var categoryService = new CategoryService(null, _mockCategoryRepo.Object, _mockProductRepo.Object);

            await Assert.ThrowsAsync<ArgumentNullException>(
                async () => await categoryService.SetCategoryAsync(null)
            );
        }
    }
}
