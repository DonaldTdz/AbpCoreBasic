using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using AbpBasic.Configuration.Dto;

namespace AbpBasic.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : AbpBasicAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
