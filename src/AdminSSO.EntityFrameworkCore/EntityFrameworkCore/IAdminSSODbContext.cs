using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace AdminSSO.EntityFrameworkCore;

[ConnectionStringName(AdminSSODbProperties.ConnectionStringName)]
public interface IAdminSSODbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
