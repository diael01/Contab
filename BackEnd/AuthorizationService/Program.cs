using IdentityModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

//same type of token as backend api
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(o =>
    {
        o.Authority = "https://localhost:5001";
        o.TokenValidationParameters.ValidateAudience = false;
        o.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };
    });

builder.Services.AddAuthorization(o => o.AddPolicy("scopecheck", o =>
    {
        o.RequireClaim(JwtClaimTypes.Scope, "ContabAuthorization");
        o.RequireAuthenticatedUser();
    })
);
builder.Services.AddCors();

var app = builder.Build();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());//todo: specify only be endpoints

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/user/{userId}",
 //[Authorize("scopecheck")] //todo: chec why if i use this policy i get "forbidden" in the api, 
 (int userId, int applicationId) =>
{
    return Results.Ok(new { Role = "admin" });
});
//here the DB can be accesses to get the user claims
//this is just a prototype, implement a controller, services and whole enchilada

app.Run();
