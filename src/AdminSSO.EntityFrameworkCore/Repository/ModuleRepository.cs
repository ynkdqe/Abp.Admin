using AdminSSO.EntityFrameworkCore;
using AdminSSO.Modules;
using AdminSSO.RoleMapUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace AdminSSO.Repository
{
    public class ModuleRepository : EfCoreRepository<AdminSSODbContext, Module>, IModuleRepository
    {
        public ModuleRepository(IDbContextProvider<AdminSSODbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
