using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace AdminSSO;

[Dependency(ReplaceServices = true)]
public class AdminSSOBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "AdminSSO";
}
