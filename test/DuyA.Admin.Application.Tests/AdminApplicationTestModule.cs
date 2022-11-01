using Volo.Abp.Modularity;

namespace DuyA.Admin;

[DependsOn(
    typeof(AdminApplicationModule),
    typeof(AdminDomainTestModule)
    )]
public class AdminApplicationTestModule : AbpModule
{

}
