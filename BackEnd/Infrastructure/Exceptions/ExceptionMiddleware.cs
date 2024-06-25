using Contracts.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;

namespace Infrastructure.Exceptions
{
    public class ExceptionMiddleWare
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleWare> logger;
        public ExceptionMiddleWare(RequestDelegate nex, ILogger<ExceptionMiddleWare> log)
        {
            next = nex;
            logger = log;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            } catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            switch (exception)
            {
                case ContabApiException:
                    var ex = exception as ContabApiException;
                    await context.Response.WriteAsync(ex!.ToJson());
                    return;
                case UnauthorizedAccessException:
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    break;
                case ArgumentException or InvalidOperationException:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
            }
            logger.LogError(exception.Message);
            await context.Response.WriteAsync(JsonConvert.SerializeObject(new
            {
                context.Response.StatusCode,
                exception.Message
            }));
        }
    }
}

