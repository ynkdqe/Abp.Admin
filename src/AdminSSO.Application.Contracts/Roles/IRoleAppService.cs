using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace AdminSSO.Roles
{
    public interface IRoleAppService : IApplicationService, ISingletonDependency
    {
    }
}
