using Infrastructure.Exceptions;
using Infrastructure.Logging;

namespace WebApi.Extensions
{
  public static class MiddlewareBuilder
  {
    public static void AddMiddleware(this WebApplication app)
    {
      app.UseMiddleware<ExceptionMiddleWare>();
      app.UseMiddleware<SerilogMiddleware>();
    }
  }
}
