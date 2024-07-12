using Microsoft.Extensions.DependencyInjection.Extensions;
using Infrastructure.Extensions;
using Serilog;
using VisionRmmApi.Extensions;


//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();




//logging
var builder = WebApplication.CreateBuilder(args);
Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).Enrich.FromLogContext().CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(Log.Logger);
Log.Information("Starting up");

//builder.AddAuthInfrastructure();
builder.Services.AddCors();
builder.AddDbInfrastructure(builder.Configuration);
builder.Host.ConfigureAppSettings();
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
//app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
//app.UseEndpoints(e => e.MapBffManagementEndpoints());
//app.MapFallbackToFile("index.html");

app.MapControllers();
app.Run();

public partial class Program { }

