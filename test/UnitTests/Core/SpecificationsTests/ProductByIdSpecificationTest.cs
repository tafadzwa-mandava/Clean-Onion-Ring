using Core.Entities;
using Core.Specifications;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace UnitTests.Core.SpecificationsTests
{
    public class ProductByIdSpecificationTest
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(4, 0)]
        public void MatchesExpectedNumberOfItems(int categoryId, int expectedCount)
        {
            var spec = new ProductByIdSpecification(categoryId);

            var result = GetTestItemCollection()
                .AsQueryable()
                .Where(spec.Criteria);

            Assert.Equal(expectedCount, result.Count());
        }

        public List<Product> GetTestItemCollection()
        {
            return new List<Product>()
            {
                new Product() { Id=1, Name = "AAA" },
                new Product() { Id=2, Name = "BBB" },
                new Product() { Id=3, Name = "CCC" }
            };
        }
    }
}
