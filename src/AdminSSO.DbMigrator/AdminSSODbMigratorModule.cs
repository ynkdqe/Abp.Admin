using AdminSSO.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace AdminSSO.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AdminSSOEntityFrameworkCoreModule),
    typeof(AdminSSOApplicationContractsModule)
    )]
public class AdminSSODbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
