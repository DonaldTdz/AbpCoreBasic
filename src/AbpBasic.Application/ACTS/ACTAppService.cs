using Abp.Application.Services;
using Abp.AutoMapper;
using AbpBasic.ACTS.Dto;
using AbpBasic.DB2.ACTS;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbpBasic.ACTS
{
    public class ACTAppService : ApplicationService, IACTAppService
    {
        private readonly IACTManager _actManager;

        public ACTAppService(IACTManager actManager)
        {
            _actManager = actManager;
        }

        public IList<ACTDto> GetACTListByLikeDesc(string desc)
        {
            var act = _actManager.GetACTListByLikeDesc(desc);
            return act.MapTo<List<ACTDto>>();
        }
    }
}
