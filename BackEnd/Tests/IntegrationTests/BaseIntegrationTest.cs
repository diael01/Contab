using AutoMapper;
using Contracts.Interfaces;
using Contracts.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository.Models;
using Services;

namespace IntegrationTests
{
    public abstract class BaseIntegrationTest : CustomWebApplicationFactory<Program>
    {
        protected readonly CustomWebApplicationFactory<Program> factory;
        protected readonly HttpClient httpClient;
        protected HttpResponseMessage? health;

        protected ContabContext DBContext;
        protected IOrgService orgService;
        protected IEmpService empService;
        protected IMapper mapper;

        public BaseIntegrationTest()
        {
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");
            factory = new CustomWebApplicationFactory<Program>();
            httpClient = factory.CreateClient();

            IConfiguration cfg = GetTestDataConfiguration();
            var conn = Microsoft
               .Extensions
               .Configuration
               .ConfigurationExtensions
               .GetConnectionString(cfg, "ContabDB");
            if (conn == null)
                throw new Exception("Connection string not found");
            var optionsBuilder = new DbContextOptionsBuilder<ContabContext>();
            optionsBuilder.UseSqlServer(conn, x => x.UseHierarchyId());
            DBContext = new ContabContext(optionsBuilder.Options);
            Assert.IsNotNull(DBContext);

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new OrganisationProfile());
                mc.AddProfile(new EmployeeProfile());
            });
            mapper = mappingConfig.CreateMapper();

            orgService = new OrgService(DBContext, mapper);
            Assert.IsNotNull(orgService);
            empService = new EmpService(DBContext, mapper);
            Assert.IsNotNull(empService);
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
