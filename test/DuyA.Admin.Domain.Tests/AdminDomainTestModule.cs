using DuyA.Admin.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace DuyA.Admin;

[DependsOn(
    typeof(AdminEntityFrameworkCoreTestModule)
    )]
public class AdminDomainTestModule : AbpModule
{

}
