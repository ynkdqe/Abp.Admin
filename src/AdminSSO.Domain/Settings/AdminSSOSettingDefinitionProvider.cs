using Volo.Abp.Settings;

namespace AdminSSO.Settings;

public class AdminSSOSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(AdminSSOSettings.MySetting1));
    }
}
