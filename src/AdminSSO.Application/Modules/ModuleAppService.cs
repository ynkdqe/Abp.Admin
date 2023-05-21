using AdminSSO.RoleMapModuleDtos;
using AdminSSO.RoleMapModules;
using AdminSSO.RoleMapUsers;
using AdminSSO.Roles;
using AdminSSO.Users;
using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Validation;

namespace AdminSSO.Modules
{
    public class ModuleAppService : AdminSSOAppService, IScopedDependency, IValidationEnabled, IModuleAppService
    {
        IUserRepository _userRepository;
        IConfiguration _configuration;
        private readonly ILogger<UserAppService> _log;
        private readonly IDistributedCache<object> _cacheUser;
        private readonly IRoleRepository _role;
        private readonly IRoleMapModuleRepository _roleMapModule;
        private readonly IModuleRepository _module;
        private readonly IRoleMapUserRepository _roleMapUser;
        private readonly IHttpContextAccessor _contextAccessor;


        public ModuleAppService(
            IUserRepository userRepository,
            ILogger<UserAppService> log,
            IConfiguration configuration,
            IDistributedCache<object> cacheUser,
            IRoleRepository role,
            IRoleMapModuleRepository roleMapModule,
            IModuleRepository module,
            IRoleMapUserRepository roleMapUser,
            IHttpContextAccessor contextAccessor)
        {
            _log = log;
            _configuration = configuration;
            _cacheUser = cacheUser;
            _role = role;
            _roleMapModule = roleMapModule;
            _module = module;
            _roleMapUser = roleMapUser;
            _contextAccessor = contextAccessor;
        }

        public async Task<List<ModuleDto>> GetModuleByUserAsync()
        {
            var moduleQuery = await _module.GetQueryableAsync();

            var result = ObjectMapper.Map<List<Module>, List<ModuleDto>>(await moduleQuery.ToListAsync());
           
            return result;
        }
    }
}
