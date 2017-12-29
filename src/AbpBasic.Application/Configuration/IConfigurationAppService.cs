using System.Threading.Tasks;
using AbpBasic.Configuration.Dto;

namespace AbpBasic.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
