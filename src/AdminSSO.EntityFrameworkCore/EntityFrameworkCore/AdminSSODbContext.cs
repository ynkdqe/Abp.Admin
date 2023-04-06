using AdminSSO.AuthApps;
using AdminSSO.Cities;
using AdminSSO.Districts;
using AdminSSO.Modules;
using AdminSSO.RoleMapModules;
using AdminSSO.RoleMapUsers;
using AdminSSO.Roles;
using AdminSSO.UserOtps;
using AdminSSO.Users;
using AdminSSO.Wards;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace AdminSSO.EntityFrameworkCore;

[ConnectionStringName(AdminSSODbProperties.ConnectionStringName)]
public class AdminSSODbContext : AbpDbContext<AdminSSODbContext>, IAdminSSODbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */
    #region Entities from the modules

    public DbSet<City> Cities { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<Ward> Wards { get; set; }
    public DbSet<UserOtp> UserOtps { get; set; }
    public DbSet<User> Users { get; set; }
    public virtual DbSet<AuthApp> AuthApps { get; set; }
    public virtual DbSet<Module> Modules { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<RoleMapModule> RoleMapModules { get; set; }
    public virtual DbSet<RoleMapUser> RoleMapUsers { get; set; }

    #endregion
    public AdminSSODbContext(DbContextOptions<AdminSSODbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureAdminSSO();
    }
}
