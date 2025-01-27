using Contracts.Interfaces;
using Contracts.Mapping;
using Contracts.Settings;
using Repository.Impl;
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
            svc.AddScoped<IDiseaseCodeRepository, DiseaseCodeRepository>();
            svc.AddScoped<IIncreaseCodeRepository, IncreaseCodeRepository>();
            svc.AddScoped<IDiseaseRepository, DiseaseRepository>();
            svc.AddScoped<IDiseaseService, DiseaseService>();
            svc.AddScoped<IHolidayRepository, HolidayRepository>();
            svc.AddScoped<IHoliday, HolidayService>();
            svc.AddScoped<IParamRepository, ParamRepository>();
            svc.AddScoped<IParamService, ParamService>();
            svc.AddScoped<IClockingService, ClockingService>();
            svc.AddAutoMapper(typeof(OrganisationProfile), typeof(EmployeeProfile));//, typeof(DeviceProfile));
            return svc;
        }
    }
}
