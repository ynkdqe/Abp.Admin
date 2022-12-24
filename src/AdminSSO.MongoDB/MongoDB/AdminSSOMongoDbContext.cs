using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace AdminSSO.MongoDB;

[ConnectionStringName(AdminSSODbProperties.ConnectionStringName)]
public class AdminSSOMongoDbContext : AbpMongoDbContext, IAdminSSOMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureAdminSSO();
    }
}
