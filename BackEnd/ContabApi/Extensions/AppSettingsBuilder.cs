

namespace ContabApi.Extensions
{

    public static class WebAppBuilder
    {
        public static IHostBuilder ConfigureAppSettings(this IHostBuilder host)
        {
            host.ConfigureAppConfiguration((ctx, builder) =>
            {
                var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                builder.AddJsonFile("appsettings.json", false, true);
                builder.AddJsonFile($"appsettings.{environment}.json", true, true);
                builder.AddEnvironmentVariables();
            });

            return host;
        }
    }
}
