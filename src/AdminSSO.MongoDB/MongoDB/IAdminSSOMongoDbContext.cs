using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace AdminSSO.MongoDB;

[ConnectionStringName(AdminSSODbProperties.ConnectionStringName)]
public interface IAdminSSOMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
