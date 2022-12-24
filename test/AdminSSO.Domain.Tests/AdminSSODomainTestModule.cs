using AdminSSO.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AdminSSO;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(AdminSSOEntityFrameworkCoreTestModule)
    )]
public class AdminSSODomainTestModule : AbpModule
{

}
