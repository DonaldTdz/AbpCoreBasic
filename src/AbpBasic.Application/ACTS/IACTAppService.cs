using Abp.Application.Services;
using AbpBasic.ACTS.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbpBasic.ACTS
{
    public interface IACTAppService : IApplicationService
    {
        IList<ACTDto> GetACTListByLikeDesc(string desc);
    }
}
