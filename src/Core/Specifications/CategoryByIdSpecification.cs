using Core.Entities;

namespace Core.Specifications
{
    public class CategoryByIdSpecification: BaseSpecification<Category>
    {
        public CategoryByIdSpecification(int categoryId)
            : base(b => b.Id == categoryId)
        {
            AddInclude(b => b.Products);
        }
    }
}
