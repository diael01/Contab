using Contracts.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Extensions
{
    public static class DbExtension
    {
        public static void AddDbInfrastructure(this WebApplicationBuilder builder, IConfiguration cfg)
        {
            var con = builder.Configuration.GetConnectionString("ContabDB");
            builder.Services.AddDbContext<ContabContext>
                (opt => opt.UseSqlServer(con, x => x.UseHierarchyId()));

        }
    }
}
