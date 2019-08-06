using Core.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Web;
using Xunit;

namespace FunctionalTests.Web.Controllers
{
    public class ApiCategoryControllerList : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        public ApiCategoryControllerList(CustomWebApplicationFactory<Startup> factory)
        {
            Client = factory.CreateClient();
        }

        public HttpClient Client { get; }

        [Fact]
        public async Task ReturnsAllCategories()
        {
            var response = await Client.GetAsync("/api/Category");
            string jsonResult = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();

            var model = JsonConvert.DeserializeObject<List<Category>>(stringResponse);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public async Task ReturnsEmptyJson()
        {
            var response = await Client.GetAsync("/api/Category/0");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            Assert.Equal("[]", stringResponse);
        }

        [Fact]
        public async Task ReturnsCategoryById()
        {
            var response = await Client.GetAsync("/api/Category/1");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();

            var model = JsonConvert.DeserializeObject<List<Category>>(stringResponse);
            Assert.Single(model);
        }
    }
}
