using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace AdminSSO;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AdminSSOHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class AdminSSOConsoleApiClientModule : AbpModule
{

}
