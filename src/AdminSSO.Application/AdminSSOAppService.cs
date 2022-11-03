using System;
using System.Collections.Generic;
using System.Text;
using AdminSSO.Localization;
using Volo.Abp.Application.Services;

namespace AdminSSO;

/* Inherit your application services from this class.
 */
public abstract class AdminSSOAppService : ApplicationService
{
    protected AdminSSOAppService()
    {
        LocalizationResource = typeof(AdminSSOResource);
    }
}
