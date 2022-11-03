using Volo.Abp.Modularity;

namespace AdminSSO;

[DependsOn(
    typeof(AdminSSOApplicationModule),
    typeof(AdminSSODomainTestModule)
    )]
public class AdminSSOApplicationTestModule : AbpModule
{

}
