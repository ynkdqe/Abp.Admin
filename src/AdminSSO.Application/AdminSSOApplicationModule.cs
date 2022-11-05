using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace AdminSSO;

[DependsOn(
    typeof(AdminSSODomainModule),
    typeof(AdminSSOApplicationContractsModule),
    typeof(AbpAutoMapperModule)
    )]
public class AdminSSOApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<AdminSSOApplicationModule>();
        });
    }
}
