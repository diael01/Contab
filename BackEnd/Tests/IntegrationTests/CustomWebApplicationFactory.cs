using Contracts.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Repository.Models;
using Services;
using System.Data.Common;

namespace IntegrationTests
{
    public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
    {
        public string DefaultUserId { get; set; } = "1";

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {

            builder.ConfigureServices(services =>
            {
                services.Configure<TestAuthHandlerOptions>(options => options.DefaultUserId = DefaultUserId);

                services.AddAuthentication(TestAuthHandler.AuthenticationScheme)
                    .AddScheme<TestAuthHandlerOptions, TestAuthHandler>(TestAuthHandler.AuthenticationScheme, options => { });

                services.AddTransient<IOrgService, OrgService>();
                services.AddTransient<IEmpService, EmpService>();

                IConfiguration cfg = GetTestDataConfiguration();
                var conn = Microsoft
                   .Extensions
                   .Configuration
                   .ConfigurationExtensions
                   .GetConnectionString(cfg, "ContabDB");
                if (conn == null)
                    throw new Exception("Connection string not found");
               
               services.AddDbContext<ContabContext>
                    (opt => opt.UseSqlServer(conn, x => x.UseHierarchyId()));
            });
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


