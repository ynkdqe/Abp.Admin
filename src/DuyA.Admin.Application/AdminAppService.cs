﻿using System;
using System.Collections.Generic;
using System.Text;
using DuyA.Admin.Localization;
using Volo.Abp.Application.Services;

namespace DuyA.Admin;

/* Inherit your application services from this class.
 */
public abstract class AdminAppService : ApplicationService
{
    protected AdminAppService()
    {
        LocalizationResource = typeof(AdminResource);
        ObjectMapperContext = typeof(AdminApplicationModule);
    }
}
