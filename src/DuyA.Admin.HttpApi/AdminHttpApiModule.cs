using Localization.Resources.AbpUi;
using DuyA.Admin.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace DuyA.Admin;

[DependsOn(
    typeof(AdminApplicationContractsModule)
    )]
public class AdminHttpApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        ConfigureLocalization();
    }

    private void ConfigureLocalization()
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<AdminResource>()
                .AddBaseTypes(
                    typeof(AbpUiResource)
                );
        });
    }
}
