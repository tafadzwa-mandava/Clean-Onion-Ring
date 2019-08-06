using System.Collections.Generic;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;

namespace Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IAppLogger<ProductService> _logger;
        private readonly IAsyncRepository<Product> _productRepository;

        public ProductService(
            IAppLogger<ProductService> logger,
            IAsyncRepository<Product> productRepository
            )
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            return await _productRepository.AddAsync(product);
        }

        public async Task<int> DeleteProductAsync(Product product)
        {
            return await _productRepository.DeleteAsync(product);
        }

        public async Task DeleteRangeProductAsync(List<Product> products)
        {
            await _productRepository.DeleteRangeAsync(products);
        }

        public async Task<IEnumerable<Product>> GetAllProductItems(int productId)
        {
            var spec = new ProductByIdSpecification(productId);
            return await _productRepository.ListAsync(spec);
        }

        public async Task<Product> GetProductById(int productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            Guard.Against.NullProduct(productId, product);
            return product;
        }

        public async Task<int> SetProductAsync(Product product)
        {
            Guard.Against.Null(product, nameof(product));
            Guard.Against.NullProduct(product.Id, product);
            return await _productRepository.UpdateAsync(product);
        }
    }
}
