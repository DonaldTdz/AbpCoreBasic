using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbpBasic.DB2.ACTS
{
    public interface IACTManager : IDomainService
    {
        IList<ACT> GetACTListByLikeDesc(string desc);
    }
}
