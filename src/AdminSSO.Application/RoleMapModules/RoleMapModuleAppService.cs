using AdminSSO.Modules;
using AdminSSO.RoleMapModuleDtos;
using AdminSSO.RoleMapUsers;
using AdminSSO.Roles;
using AdminSSO.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Validation;

namespace AdminSSO.RoleMapModules
{
    public class RoleMapModuleAppService : AdminSSOAppService, IScopedDependency, IValidationEnabled, IRoleMapModuleAppService
    {
        IUserRepository _userRepository;
        IConfiguration _configuration;
        private readonly ILogger<UserAppService> _log;
        private readonly IDistributedCache<object> _cacheUser;
        private readonly IRoleRepository _role;
        private readonly IRoleMapModuleRepository _roleMapModule;
        private readonly IModuleRepository _module;
        private readonly IRoleMapUserRepository _roleMapUser;
        public RoleMapModuleAppService(
            IUserRepository userRepository,
            ILogger<UserAppService> log,
            IConfiguration configuration,
            IDistributedCache<object> cacheUser,
            IRoleRepository role,
            IRoleMapModuleRepository roleMapModule,
            IModuleRepository module,
            IRoleMapUserRepository roleMapUser) 
        {
            _userRepository = userRepository;
            _log = log;
            _configuration = configuration;
            _cacheUser = cacheUser;
            _role = role;
            _roleMapModule = roleMapModule;
            _module = module;
            _roleMapUser = roleMapUser;
        }

        public async Task<List<ModuleByRoleDto>> GetRoleByUser(int userId)
        {
            var queryRoleMapUser = await _roleMapUser.GetQueryableAsync();
            
            var queryRole = await _role.GetQueryableAsync();
            var queryModule = await _module.GetQueryableAsync();
            var queryRoleMapModule = await _roleMapModule.GetQueryableAsync();
            var queryUser = await _userRepository.GetQueryableAsync();

            var userRole = await _roleMapUser.GetAsync(c=>c.UserId == userId);
            if (userRole != null)
            {
                return await (from a in queryRoleMapModule
                              join b in queryRole on a.RoleId equals b.Id
                              join c in queryModule on a.ModuleId equals c.Id
                              where a.RoleId == userRole.Id && b.IsActived == true && b.IsDeleted == false && c.IsActived == true && c.IsDeleted == false
                              select new ModuleByRoleDto
                              {
                                  Id = a.Id,
                                  RoleModule = !string.IsNullOrEmpty(a.ActionOfRole) ? a.ActionOfRole : c.Action,
                                  RoleCode = b.RoleCode,
                                  RoleId = a.RoleId.Value
                              }).ToListAsync();

            }
            else
                return null;
           
        }
    }
}
