using Core.Entities;
using Xunit;

namespace UnitTests.Core.EntitiesTests
{
    public class AddCategory
    {
        private string _name = "Bathing Products";

        [Fact]
        public void AddsEntityIfNotPresent()
        {
            /*
            var category = new Category(_name);
            Assert.Equal(_name, category.Name);
            */
        }
    }
}
