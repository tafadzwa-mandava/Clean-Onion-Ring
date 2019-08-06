using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Web;

namespace Infrastructure.Data
{
    public class ProductCategoryContextFactory : IDesignTimeDbContextFactory<ProductCategoryContext>
    {
        private IConfiguration _configuration;

        public ProductCategoryContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ProductCategoryContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProductCategoryContext>();

            if (OperatingSystem.IsWindows())
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("WindowsDefaultConnection"));           
            else
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("LinuxDefaultConnection"));
               
            return new ProductCategoryContext(optionsBuilder.Options);
        }
    }
}
