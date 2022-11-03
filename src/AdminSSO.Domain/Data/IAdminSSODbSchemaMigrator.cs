using System.Threading.Tasks;

namespace AdminSSO.Data;

public interface IAdminSSODbSchemaMigrator
{
    Task MigrateAsync();
}
