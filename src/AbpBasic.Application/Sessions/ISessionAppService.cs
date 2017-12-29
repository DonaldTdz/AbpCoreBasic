using System.Threading.Tasks;
using Abp.Application.Services;
using AbpBasic.Sessions.Dto;

namespace AbpBasic.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
