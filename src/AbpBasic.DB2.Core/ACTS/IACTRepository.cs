using Abp.Domain.Repositories;
using AbpBasic.DB2.ACTS;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbpBasic.DB2.Core.ACTS
{
    public interface IACTRepository : IRepository<ACT, short>
    {
    }
}
