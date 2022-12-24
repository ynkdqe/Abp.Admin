using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace AdminSSO.EntityFrameworkCore;

public class AdminSSOHttpApiHostMigrationsDbContext : AbpDbContext<AdminSSOHttpApiHostMigrationsDbContext>
{
    public AdminSSOHttpApiHostMigrationsDbContext(DbContextOptions<AdminSSOHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureAdminSSO();
    }
}
