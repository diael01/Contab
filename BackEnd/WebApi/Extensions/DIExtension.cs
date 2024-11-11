using Contracts.Interfaces.Services;
using Contracts.Mapping;
using Contracts.Settings;
using Repository.Impl;
using Repository.Interfaces;
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
            svc.AddScoped<IBankRepository, BankRepository>();
            svc.AddScoped<IBankService, BankService>();
            svc.AddScoped<IDiseaseRepository, DiseaseRepository>();
            svc.AddScoped<IDiseaseService, DiseaseService>();
            svc.AddScoped<IHolidayRepository, HolidayRepository>();
            svc.AddScoped<IHolidayService, HolidayService>();
            svc.AddScoped<IParamRepository, ParamRepository>();
            svc.AddScoped<IParamService, ParamService>();
            svc.AddAutoMapper(typeof(OrganisationProfile), typeof(EmployeeProfile));//, typeof(DeviceProfile));
            return svc;
        }
    }
}
