using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProductService
    {
        Task<Product> GetProductById(int entryId);
        Task<IEnumerable<Product>> GetAllProductItems(int productId);
        Task <Product> AddProductAsync(Product product);
        Task <int> SetProductAsync(Product product);
        Task <int> DeleteProductAsync(Product product);
        Task DeleteRangeProductAsync(List<Product> product);
    }
}
