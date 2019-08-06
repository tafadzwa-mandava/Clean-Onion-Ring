using Core.Entities;
using Core.Specifications;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace UnitTests.Core.SpecificationsTests
{
    public class CategoryByIdSpecificationTest
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(4, 0)]
        public void MatchesExpectedNumberOfItems(int categoryId, int expectedCount)
        {
            var spec = new CategoryByIdSpecification(categoryId);

            var result = GetTestItemCollection()
                .AsQueryable()
                .Where(spec.Criteria);

            Assert.Equal(expectedCount, result.Count());
        }

        public List<Category> GetTestItemCollection()
        {
            return new List<Category>()
            {
                new Category() { Id=1, Name = "AAA" },
                new Category() { Id=2, Name = "BBB" },
                new Category() { Id=3, Name = "CCC" }
            };
        }
    }
}
