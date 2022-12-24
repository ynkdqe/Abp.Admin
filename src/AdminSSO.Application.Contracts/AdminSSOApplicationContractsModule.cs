using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace AdminSSO;

[DependsOn(
    typeof(AdminSSODomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class AdminSSOApplicationContractsModule : AbpModule
{

}
