using AdminSSO.EntityFrameworkCore;
using AdminSSO.UserOtps;
using AdminSSO.Wards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace AdminSSO.Repository
{
    public class WardRepository : EfCoreRepository<AdminSSODbContext, Ward>, IWardRepository
    {
        readonly AdminSSODbContext _dbContext;
        public WardRepository(IDbContextProvider<AdminSSODbContext> dbContextProvider, AdminSSODbContext dbContext) : base(dbContextProvider)
        {
            _dbContext = dbContext;
        }

    }
}
