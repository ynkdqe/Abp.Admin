using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AdminSSO.Data;

/* This is used if database provider does't define
 * IAdminSSODbSchemaMigrator implementation.
 */
public class NullAdminSSODbSchemaMigrator : IAdminSSODbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
