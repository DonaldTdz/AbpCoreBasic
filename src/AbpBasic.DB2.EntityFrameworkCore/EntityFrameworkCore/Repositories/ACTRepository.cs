using Abp.EntityFrameworkCore;
using AbpBasic.DB2.ACTS;
using AbpBasic.DB2.Core.ACTS;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbpBasic.DB2.EntityFrameworkCore.Repositories
{
    public class ACTRepository : DB2RepositoryBase<ACT, short>, IACTRepository
    {
        protected ACTRepository(IDbContextProvider<DB2DbContext> dbContextProvider)
           : base(dbContextProvider)
        {
        }
        public override string GetIdName()
        {
            return "ACTNO";
        }
    }
}
