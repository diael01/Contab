using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace WebApi.Extensions
{
  public static class DbExtension
  {
    public static void AddDbInfrastructure(this WebApplicationBuilder builder, 
                                                IConfiguration cfg)
    {
      builder.Services.AddDbContext<ContabContext>
          (opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("ContabDB")));

    }
  }
}
