using AutoMapper;
using Contracts.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Repository.Models;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using static CommonTestHelper.CommonHelper;

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
            scope = factory.Services.CreateScope();
            sp = scope.ServiceProvider;

            var DBContext = sp.GetRequiredService<ContabContext>();
            Assert.IsNotNull(DBContext);
            var orgService = sp.GetRequiredService<IOrgService>();
            Assert.IsNotNull(orgService);
            var empService = sp.GetRequiredService<IEmpService>();
            Assert.IsNotNull(empService);
            var mapper = sp.GetRequiredService<IMapper>();
            Assert.IsNotNull(mapper);

            SetTestParams(DBContext, orgService, empService, mapper);
        }
    }
}
