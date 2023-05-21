using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace AdminSSO.RoleMapModuleDtos
{
    public interface IRoleMapModuleAppService : IApplicationService, ISingletonDependency
    {
        Task<List<string>> GetRoleByUser(int userId);
    }
}
