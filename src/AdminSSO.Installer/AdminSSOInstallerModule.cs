using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace AdminSSO;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class AdminSSOInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AdminSSOInstallerModule>();
        });
    }
}
