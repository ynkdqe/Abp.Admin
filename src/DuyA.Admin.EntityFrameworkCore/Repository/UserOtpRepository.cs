using DuyA.Admin.EntityFrameworkCore;
using DuyA.Admin.Extensions;
using DuyA.Admin.UserOtps;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace DuyA.Admin.Repository
{
    public class UserOtpRepository : EfCoreRepository<AdminDbContext, UserOtp>, IUserOtpRepository
    {
        readonly AdminDbContext _dbContext;
        public UserOtpRepository(IDbContextProvider<AdminDbContext> dbContextProvider,AdminDbContext dbContext) : base(dbContextProvider)
        {
            _dbContext = dbContext;
        }

        public List<UserOtp> GetAll()
        {
            //_dbContext.LoadStoredProc
            //var db = await GetDbContextAsync();
            var list =  _dbContext.LoadStoredProc("PRC_UserOtp_GetAll").ExecuteStoredProc<UserOtp>().ToList();
            return list;
        }
    }
}
