using DuyA.Admin.EntityFrameworkCore;
using DuyA.Admin.UserProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace DuyA.Admin.Repository
{
    public class UserProfileRepository : EfCoreRepository<AdminDbContext, UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(IDbContextProvider<AdminDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
