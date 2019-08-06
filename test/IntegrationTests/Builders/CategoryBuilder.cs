using Core.Entities;
using Infrastructure.Data;

namespace IntegrationTests.Builders
{
    public class CategoryBuilder
    {
        private static CategoryBuilder _instance;
        public static CategoryBuilder Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CategoryBuilder();
                }
                return _instance;
            }
        }

        public Category DummyProductCategory()
        {
            return SampleProductCategoryData.Instance.Categories[0];
        }
    }
}
