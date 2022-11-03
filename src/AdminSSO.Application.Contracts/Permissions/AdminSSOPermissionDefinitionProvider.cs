using AdminSSO.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AdminSSO.Permissions;

public class AdminSSOPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AdminSSOPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(AdminSSOPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AdminSSOResource>(name);
    }
}
