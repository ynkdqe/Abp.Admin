using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace AdminSSO;

[DependsOn(
    typeof(AdminSSOApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class AdminSSOHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(AdminSSOApplicationContractsModule).Assembly,
            AdminSSORemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AdminSSOHttpApiClientModule>();
        });

    }
}
