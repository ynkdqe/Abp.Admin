using Localization.Resources.AbpUi;
using AdminSSO.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace AdminSSO;

[DependsOn(
    typeof(AdminSSOApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class AdminSSOHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(AdminSSOHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<AdminSSOResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
