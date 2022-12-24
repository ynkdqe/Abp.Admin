using AdminSSO.Cities;
using AdminSSO.Districts;
using AdminSSO.Repository;
using AdminSSO.UserOtps;
using AdminSSO.Users;
using AdminSSO.Wards;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AdminSSO.EntityFrameworkCore;

[DependsOn(
    typeof(AdminSSODomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class AdminSSOEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<AdminSSODbContext>(options =>
        {
            /* Add custom repositories here. Example:
             * options.AddRepository<Question, EfCoreQuestionRepository>();
             */
            options.AddRepository<User, UserRepository>();
            options.AddRepository<UserOtp, UserOtpRepository>();
            options.AddRepository<City, CityRepository>();
            options.AddRepository<Ward, WardRepository>();
            options.AddRepository<District, DistrictRepository>();
        });
    }
}
