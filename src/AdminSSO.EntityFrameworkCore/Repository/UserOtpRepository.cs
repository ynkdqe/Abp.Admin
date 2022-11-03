using AdminSSO.EntityFrameworkCore;
using AdminSSO.UserOtps;
using AdminSSO.Extensions;
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
        public UserOtpRepository(IDbContextProvider<AdminSSODbContext> dbContextProvider, AdminSSODbContext dbContext) : base(dbContextProvider)
        {
            _dbContext = dbContext;
        }

        public List<UserOtp> GetAll()
        {
            //_dbContext.LoadStoredProc
            //var db = await GetDbContextAsync();
            var list = _dbContext.LoadStoredProc("PRC_UserOtp_GetAll").ExecuteStoredProc<UserOtp>().ToList();
            return list;
        }
    }
}
