using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

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
      });
    }
  }
}
