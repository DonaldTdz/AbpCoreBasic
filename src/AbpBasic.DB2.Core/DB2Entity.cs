using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbpBasic.DB2.Core
{
    public abstract class DB2Entity<TPrimaryKey> : Entity<TPrimaryKey>
    {
        public abstract string GetIdName();
    }

    public abstract class DB2Entity : DB2Entity<int>
    {

    }
}
