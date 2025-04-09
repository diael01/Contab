using AutoMapper;
using Contracts.Mapping;
using Microsoft.Extensions.Configuration;

namespace CommonTestHelper
{
    public static class Initializer
    {
        public static IMapper CreateAllMaps()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new OrganisationProfile());
                mc.AddProfile(new EmployeeProfile());
                mc.AddProfile(new ParamProfile());
            });
            return mappingConfig.CreateMapper();
        }
        public static string GetTestDataConnnectionString()
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var dir = Directory.GetCurrentDirectory();
            var cfg = new ConfigurationBuilder()
                .SetBasePath(dir)
                .AddJsonFile(@"apsettings.json", true, false)
                .AddJsonFile($"appsettings.{environment}.json", true, true)
                .AddEnvironmentVariables()
                .Build();
            var conn = Microsoft
               .Extensions
               .Configuration
               .ConfigurationExtensions
               .GetConnectionString(cfg, "ContabDB");
            if (conn == null)
                throw new Exception("Connection string not found");
            return conn;
        }
    }
}
