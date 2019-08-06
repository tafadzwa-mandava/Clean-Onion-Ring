using Core.Entities;
using Core.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class GuardExtension
    {
        public static void NullCategory(this IGuardClause guardClause, int categoryId, Category category)
        {
            if (category == null)
                throw new CategoryNotFoundException(categoryId);
        }

        public static void NullProduct(this IGuardClause guardClause, int productId, Product product)
        {
            if (product == null)
                throw new ProductNotFoundException(productId);
        }
    }
}
