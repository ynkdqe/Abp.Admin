using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using DuyA.Admin.Cities;
using DuyA.Admin.Districts;
using DuyA.Admin.UserOtps;
using DuyA.Admin.UserProfiles;
using DuyA.Admin.Wards;

namespace DuyA.Admin.EntityFrameworkCore
{
    [ConnectionStringName(AdminConsts.ConnectionStringName)]
    public interface IAdminDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
        DbSet<City> Cities { get; set; }
        DbSet<District> Districts { get; set; }
        DbSet<Ward> Wards { get; set; }
        DbSet<UserOtp> UserOtps { get; set; }
        DbSet<UserProfile> UserProfiles { get; set; }
    }
}
