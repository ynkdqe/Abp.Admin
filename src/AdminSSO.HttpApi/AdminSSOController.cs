using AdminSSO.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AdminSSO;

public abstract class AdminSSOController : AbpControllerBase
{
    protected AdminSSOController()
    {
        LocalizationResource = typeof(AdminSSOResource);
    }
}
