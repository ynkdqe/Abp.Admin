using Volo.Abp;
using Volo.Abp.MongoDB;

namespace AdminSSO.MongoDB;

public static class AdminSSOMongoDbContextExtensions
{
    public static void ConfigureAdminSSO(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
