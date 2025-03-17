using ContabApi.Extensions;
using Serilog;

//logging
var builder = WebApplication.CreateBuilder(args);
Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).Enrich.FromLogContext().CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(Log.Logger);
Log.Information("Starting up");

builder.Services.AddCors();
//builder.AddAuthInfrastructure();1.
builder.Host.ConfigureAppSettings();
builder.AddDbInfrastructure(builder.Configuration);
builder.Services.AddControllers();
//for global policies, create a filter
//builder.Services.AddControllers(o=> o.Filters.Add(new AuthorizeFilter("fullaccess")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDI(builder.Configuration);
builder.Services.AddHealthChecks();
builder.Services.AddHttpContextAccessor();
builder.AddSwagger();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//todo: when UI, use bff
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());//todo: specify only be endpoints
app.AddMiddleware();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();

//2. app.UseAuthorization();
//3. app.MapGet("/user/{userId}", //[Authorize("fullaccess")] //authorize atrirbute works as well
//                    (int userId, int appId) => Results.Ok(new { Role = "admin" }))
//                    .RequireAuthorization("fullaccess", "");

//todo: use bff when UI
//app.UseBff();
//app.UseEndpoints(e => e.MapBffManagementEndpoints());
//app.MapFallbackToFile("index.html");

app.MapControllers();
app.Run();

public partial class Program { }
