using AdminSSO.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AdminSSO;

[DependsOn(
    typeof(AdminSSOEntityFrameworkCoreTestModule)
    )]
public class AdminSSODomainTestModule : AbpModule
{

}
