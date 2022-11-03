using AdminSSO.Cities;
using AdminSSO.EntityFrameworkCore;
using AdminSSO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace AdminSSO.Repository
{
    public class CityRepository : EfCoreRepository<AdminSSODbContext, City>, ICityRepository
    {
        public CityRepository(IDbContextProvider<AdminSSODbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
