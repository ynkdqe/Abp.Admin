using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;

namespace AdminSSO;

[DependsOn(
    typeof(AdminSSODomainSharedModule),
    typeof(AbpObjectExtendingModule)
)]
public class AdminSSOApplicationContractsModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        AdminSSODtoExtensions.Configure();
    }
}
