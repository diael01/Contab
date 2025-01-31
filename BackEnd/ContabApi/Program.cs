using Serilog;
using WebApi.Extensions;

//logging
var builder = WebApplication.CreateBuilder(args);
Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).Enrich.FromLogContext().CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(Log.Logger);
Log.Information("Starting up");

builder.AddAuthInfrastructure();
builder.Services.AddCors();
builder.Host.ConfigureAppSettings();
builder.AddDbInfrastructure(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDI(builder.Configuration);
builder.Services.AddHealthChecks();
builder.Services.AddHttpContextAccessor();


var app = builder.Build();
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("localhost:3000"));//app.UseBff();

app.AddMiddleware();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
//app.UseEndpoints(e => e.MapBffManagementEndpoints());
//app.MapFallbackToFile("index.html");

app.MapControllers();
app.Run();

public partial class Program { }
