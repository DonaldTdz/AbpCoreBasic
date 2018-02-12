using Abp.EntityFrameworkCore;
using AbpBasic.DB2.ACTS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbpBasic.DB2.EntityFrameworkCore
{
    public class DB2DbContext : AbpDbContext
    {
        /* Define a DbSet for each entity of the application */

        public DB2DbContext(DbContextOptions<DB2DbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ACT> Acts{ get; set; }
    }
}
