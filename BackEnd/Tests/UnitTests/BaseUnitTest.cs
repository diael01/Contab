using AutoMapper;
using CommonTestHelper;
using Contracts.Interfaces;
using Contracts.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using Repository.Models;
using Services;

namespace UnitTests
{

    public class BaseUnitTest : IDisposable
    {
        protected ContabContext DBContext;
        protected Mock<IServiceProvider> mockService = new Mock<IServiceProvider>();
        protected IMapper mapper;
        protected IOrgService orgService;
        protected IEmpService empService;

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
            if (conn == null)
                throw new Exception("Connection string not found");
            optionsBuilder.UseSqlServer(conn, x => x.UseHierarchyId());
            DBContext = new ContabContext(optionsBuilder.Options);
            if (mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new OrganisationProfile());
                    mc.AddProfile(new EmployeeProfile());
                });
                mapper = mappingConfig.CreateMapper();
            }
            orgService = new OrgService(DBContext, mapper);
            empService = new EmpService(DBContext, mapper);
            CommonHelper.orgService = orgService;
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

        public void Dispose()
        {
            // Do "global" teardown here; Only called once.
        }
    }
}
