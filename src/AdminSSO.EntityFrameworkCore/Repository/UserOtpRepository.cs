using AdminSSO.EntityFrameworkCore;
using AdminSSO.UserOtps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace AdminSSO.Repository
{
    public class UserOtpRepository : EfCoreRepository<AdminSSODbContext, UserOtp>, IUserOtpRepository
    {
        readonly AdminSSODbContext _dbContext;
        private readonly IDbContextProvider<AdminSSODbContext> _dbContextProvider;
        public UserOtpRepository(IDbContextProvider<AdminSSODbContext> dbContextProvider, AdminSSODbContext dbContext) : base(dbContextProvider)
        {
            _dbContext = dbContext;
            _dbContextProvider = dbContextProvider;
        }

        public List<UserOtp> GetAll()
        {
            //_dbContext.LoadStoredProc
            //var db = await GetDbContextAsync();
            return null;
        }
    }
}
