using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;

namespace DuyA.Admin;

[DependsOn(
    typeof(AdminDomainSharedModule),
    typeof(AbpDddDomainModule)
)]
public class AdminDomainModule : AbpModule
{
    
}
