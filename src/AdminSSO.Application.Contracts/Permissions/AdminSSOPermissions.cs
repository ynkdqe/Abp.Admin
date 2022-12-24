using Volo.Abp.Reflection;

namespace AdminSSO.Permissions;

public class AdminSSOPermissions
{
    public const string GroupName = "AdminSSO";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(AdminSSOPermissions));
    }
}
