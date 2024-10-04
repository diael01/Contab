using AutoMapper;
using Contracts.Interfaces;
using Repository.Models;

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

        public BaseIntegrationTest()
        {
            factory = new CustomWebApplicationFactory<Program>();
            httpClient = factory.CreateClient();
            orgService = (IOrgService)factory.Services.GetService(typeof(IOrgService));
            Assert.IsNotNull(orgService);
            empService = (IEmpService)factory.Services.GetService(typeof(IEmpService));
            Assert.IsNotNull(empService);
            DBContext = (ContabContext)factory.Services.GetService(typeof(ContabContext));
            Assert.IsNotNull(DBContext);
        }
    }
}
