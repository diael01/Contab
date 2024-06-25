using AutoMapper;
using Contracts.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using Repository.Models;

namespace UnitTests
{
    public class BaseUnitTest
    {
        protected ContabContext DBContext;
        protected Mock<IServiceProvider> mockService = new Mock<IServiceProvider>();
        protected IMapper mapper;

        public BaseUnitTest()
        {
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");
            var optionsBuilder = new DbContextOptionsBuilder<ContabContext>();
            IConfiguration cfg = GetTestDataConfiguration();

            var conn = Microsoft
   .Extensions
   .Configuration
   .ConfigurationExtensions
   .GetConnectionString(cfg, "ContabDB");
            //var conn = cfg.GetConnectionString("ConnectionStrings:ContabDB");
            if (conn == null)
                throw new Exception("Connection string not found");
            optionsBuilder.UseSqlServer(conn);
            DBContext = new ContabContext(optionsBuilder.Options);
            if (mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new OrganisationProfile());
                });
                mapper = mappingConfig.CreateMapper();
            }
        }

        public static IConfiguration GetTestDataConfiguration()
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var dir = Directory.GetCurrentDirectory();
            return new ConfigurationBuilder()
                .SetBasePath(dir)
                .AddJsonFile(@"apsettings.json", true, false)
                .AddJsonFile($"appsettings.{environment}.json", true, true)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}
