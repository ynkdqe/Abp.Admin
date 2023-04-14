using AdminSSO.Cities;
using AdminSSO.EntityFrameworkCore;
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
    public class RoleRepository : EfCoreRepository<AdminSSODbContext, Role>, IRoleRepository
    {
        public RoleRepository(IDbContextProvider<AdminSSODbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
