using AutoMapper;
using Contracts.Interfaces;
using Contracts.Models;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using static CommonTestHelper.CommonHelper;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace IntegrationTests
{
    public abstract class BaseIntegrationTest : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        protected readonly CustomWebApplicationFactory<Program> factory;
        protected readonly HttpClient httpClient;
        protected HttpResponseMessage? health;

        IServiceScope scope;
        IServiceProvider sp;


        public BaseIntegrationTest()
        {
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");
            factory = new CustomWebApplicationFactory<Program>();
            httpClient = factory.CreateClient();

            //httpClient = factory.WithWebHostBuilder(builder =>
            //{
            //    builder.ConfigureServices(services =>
            //    {
            //        //services.RemoveAll(typeof(DbContextOptions<ContabContext>));
            //        services.AddDbContext<ContabContext>(options =>
            //        {
            //            options.UseInMemoryDatabase("TestDatabase");
            //        });
            //    });
            //}).CreateClient();

            scope = factory.Services.CreateScope();
            sp = scope.ServiceProvider;

            var DBContext = sp.GetRequiredService<ContabContext>();
            Assert.IsNotNull(DBContext);
            var orgService = sp.GetRequiredService<IOrg>();
            Assert.IsNotNull(orgService);
            var empService = sp.GetRequiredService<IEmp>();
            Assert.IsNotNull(empService);
            var mapper = sp.GetRequiredService<IMapper>();
            Assert.IsNotNull(mapper);

            SetTestParams(DBContext, orgService, empService, mapper);
        }
    }
}
