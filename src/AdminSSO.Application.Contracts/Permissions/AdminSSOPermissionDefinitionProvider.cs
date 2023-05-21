using AdminSSO.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AdminSSO.Permissions;

public class AdminSSOPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var user = context.AddGroup(AdminSSOPermissions.GroupName, L("Permission:AdminSSO"));
        user.AddPermission("Admin.User.View", L("View"));
        user.AddPermission("Admin.User.Create", L("Create"));
        user.AddPermission("Admin.User.Update", L("Update"));
        user.AddPermission("Admin.User.Delete", L("Delete"));
        user.AddPermission("Admin.User.GetProfile", L("GetProfile"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AdminSSOResource>(name);
    }
}
