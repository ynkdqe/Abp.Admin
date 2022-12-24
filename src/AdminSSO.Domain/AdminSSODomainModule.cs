using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace AdminSSO;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(AdminSSODomainSharedModule)
)]
public class AdminSSODomainModule : AbpModule
{

}
