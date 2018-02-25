using Abp.Domain.Repositories;
using Abp.Domain.Services;
using AbpBasic.DB2.Core.ACTS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbpBasic.DB2.ACTS
{
    public class ACTManager : IDomainService, IACTManager
    {
        private readonly IACTRepository _actRepository;

        public ACTManager(IACTRepository actRepository)
        {
            _actRepository = actRepository;
        }

        public IList<ACT> GetACTListByLikeDesc(string desc)
        {
            var query = _actRepository.GetAll().Where(a => a.ACTDESC.Contains(desc));
            return query.ToList();
        }
    }
}
