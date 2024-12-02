using AutoMapper;
using CommonTestHelper;
using Contracts.Interfaces;
using Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using Services;
using static CommonTestHelper.CommonHelper;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace UnitTests
{

    public class BaseUnitTest
    {
        protected Mock<IServiceProvider> mockService = new Mock<IServiceProvider>();

        protected ContabContext DBContext;
        protected IOrg orgService;
        protected IEmp empService;
        protected IMapper mapper;

        public BaseUnitTest() : base()
        {
            mockService = new Mock<IServiceProvider>();
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");

            var conn = Initializer.GetTestDataConnnectionString();

            var optionsBuilder = new DbContextOptionsBuilder<ContabContext>();
            optionsBuilder.UseSqlServer(conn, x => x.UseHierarchyId());
            DBContext = new ContabContext(optionsBuilder.Options);
            Assert.IsNotNull(DBContext);

            mapper = Initializer.CreateAllMaps();

            orgService = new OrgService(DBContext, mapper);
            Assert.IsNotNull(orgService);
            empService = new EmpService(DBContext, mapper);
            Assert.IsNotNull(empService);

            SetTestParams(DBContext, orgService, empService, mapper);
        }


    }
}
