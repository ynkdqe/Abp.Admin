using Localization.Resources.AbpUi;
using AdminSSO.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.AspNetCore.Mvc;

namespace AdminSSO;
[DependsOn(
    typeof(AdminSSOApplicationContractsModule),
    //typeof(AbpAccountHttpApiModule)
    //typeof(AbpIdentityHttpApiModule)
    typeof(AbpAspNetCoreMvcModule)
    )]
public class AdminSSOHttpApiModule : AbpModule
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
                .Get<AdminSSOResource>()
                .AddBaseTypes(
                    typeof(AbpUiResource)
                );
        });
    }
}
