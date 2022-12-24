using AdminSSO.Localization;
using Volo.Abp.Application.Services;

namespace AdminSSO;

public abstract class AdminSSOAppService : ApplicationService
{
    protected AdminSSOAppService()
    {
        LocalizationResource = typeof(AdminSSOResource);
        ObjectMapperContext = typeof(AdminSSOApplicationModule);
    }
}
