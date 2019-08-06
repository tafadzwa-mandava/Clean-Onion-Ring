using Core.Entities;
using Core.Exceptions;
using Core.Interfaces;
using Core.Services;
using Moq;
using System;
using Xunit;

namespace UnitTests.Core.ServicesTests
{
    public class SetProduct
    {

        private int _invalidId = -1;
        private Mock<IAsyncRepository<Product>> _mockProductRepo;

        public SetProduct()
        {
            _mockProductRepo = new Mock<IAsyncRepository<Product>>();
        }

        [Fact]
        public async void ThrowsGivenInvalidEntryId()
        {
            var productService = new ProductService(null, _mockProductRepo.Object);

            await Assert.ThrowsAsync<ProductNotFoundException>(
                async () => await productService.GetProductById(_invalidId)
            );
        }

        [Fact]
        public async void ThrowsGivenNullEntryServiceArguments()
        {
            var productService = new ProductService(null, _mockProductRepo.Object);

            await Assert.ThrowsAsync<ArgumentNullException>(
                async () => await productService.SetProductAsync(null)
            );
        }

    }
}
