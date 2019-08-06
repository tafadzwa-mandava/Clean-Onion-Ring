using Core.Entities;

namespace Core.Specifications
{
    public class ProductByIdSpecification : BaseSpecification<Product>
    {
        public ProductByIdSpecification(int productId)
            : base(b => b.Id == productId)
        {
        }
    }
}
