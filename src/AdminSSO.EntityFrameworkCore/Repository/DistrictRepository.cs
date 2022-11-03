﻿using AdminSSO.Cities;
using AdminSSO.Districts;
using AdminSSO.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace AdminSSO.Repository
{
    public class DistrictRepository : EfCoreRepository<AdminSSODbContext, District>, IDistrictRepository
    {
        public DistrictRepository(IDbContextProvider<AdminSSODbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
