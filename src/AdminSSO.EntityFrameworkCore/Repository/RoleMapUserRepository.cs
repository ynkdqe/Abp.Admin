using AdminSSO.EntityFrameworkCore;
using AdminSSO.RoleMapUsers;
using AdminSSO.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace AdminSSO.Repository
{
    public class RoleMapUserRepository : EfCoreRepository<AdminSSODbContext, RoleMapUser>, IRoleMapUserRepository
    {
        public RoleMapUserRepository(IDbContextProvider<AdminSSODbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
