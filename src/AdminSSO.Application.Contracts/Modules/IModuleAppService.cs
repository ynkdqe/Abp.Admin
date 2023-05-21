using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace AdminSSO.Modules
{
    public interface IModuleAppService : IApplicationService, ISingletonDependency
    {
        Task<List<ModuleDto>> GetModuleByUserAsync();
    }
}
