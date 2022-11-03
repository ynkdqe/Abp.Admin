using AdminSSO.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AdminSSO.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AdminSSOController : AbpControllerBase
{
    protected AdminSSOController()
    {
        LocalizationResource = typeof(AdminSSOResource);
    }
}
