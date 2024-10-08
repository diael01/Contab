using Contracts.Interfaces;
using Contracts.Mapping;
using Contracts.Settings;
using Services;

namespace WebApi.Extensions
{
    public static class DIExtension
    {
        public static IServiceCollection AddDI(this IServiceCollection svc, IConfiguration cfg)
        {
            var settings = cfg.GetSection("Settings").Get<AppSettings>();
            if (settings != null)
                svc.AddSingleton(settings);
            svc.AddScoped<IOrgService, OrgService>();
            svc.AddScoped<IEmpService, EmpService>();
            svc.AddAutoMapper(typeof(OrganisationProfile), typeof(EmployeeProfile));//, typeof(DeviceProfile));
            return svc;
        }
    }
}
