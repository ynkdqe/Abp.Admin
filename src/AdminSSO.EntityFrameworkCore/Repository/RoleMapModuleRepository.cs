using AdminSSO.EntityFrameworkCore;
using AdminSSO.Modules;
using AdminSSO.RoleMapModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace AdminSSO.Repository
{
    public class RoleMapModuleRepository : EfCoreRepository<AdminSSODbContext, RoleMapModule>, IRoleMapModuleRepository
    {
        public RoleMapModuleRepository(IDbContextProvider<AdminSSODbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
