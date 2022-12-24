namespace AdminSSO;

public static class AdminSSODbProperties
{
    public static string DbTablePrefix { get; set; } = "AdminSSO";

    public static string DbSchema { get; set; } = null;

    public const string ConnectionStringName = "AdminSSO";
}
