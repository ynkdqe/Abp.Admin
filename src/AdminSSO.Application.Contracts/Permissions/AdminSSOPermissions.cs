using Volo.Abp.Reflection;

namespace AdminSSO.Permissions;

public class AdminSSOPermissions
{
    public const string GroupName = "AdminSSO";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(AdminSSOPermissions));
    }

    public static class UserPermissions
    {
        public const string Default = GroupName + ".User";
        public const string All = Default + ".All";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
        public const string View = Default + ".View";
    }

    public static class RolePermissions
    {
        public const string Default = GroupName + ".Role";
        public const string All = Default + ".All";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
        public const string View = Default + ".View";
    }
    public static class ModulePermissions
    {
        public const string Default = GroupName + ".Module";
        public const string All = Default + ".All";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
        public const string View = Default + ".View";
    }
}
