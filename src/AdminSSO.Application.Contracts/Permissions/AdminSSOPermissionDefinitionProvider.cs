using AdminSSO.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AdminSSO.Permissions;

public class AdminSSOPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AdminSSOPermissions.GroupName, L("Permission:AdminSSO"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AdminSSOResource>(name);
    }
}
