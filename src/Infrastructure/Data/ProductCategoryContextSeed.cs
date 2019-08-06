using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ProductCategoryContextSeed
    {
        private readonly ProductCategoryContext _dbContext;

        public ProductCategoryContextSeed(ProductCategoryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public static async Task SeedProductCategoriesAsync(ProductCategoryContext dbContext,
                ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                if (!dbContext.Categories.Any())
                {
                    await dbContext.Categories.AddRangeAsync(SampleProductCategoryData.Instance.Categories);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 3)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<ProductCategoryContextSeed>();
                    log.LogError(ex.Message);
                    await SeedProductCategoriesAsync(dbContext, loggerFactory, retryForAvailability);
                }
            }
        }

    }
}
