using Abp.EntityFrameworkCore;
using AbpBasic.DB2.ACTS;
using AbpBasic.DB2.Configuration;
using AbpBasic.DB2.Core;
using AbpBasic.DB2.Web;
using IBM.EntityFrameworkCore;
using IBM.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());
            optionsBuilder.UseDb2(configuration.GetConnectionString(DB2Consts.ConnectionStringName), p => p.SetServerInfo(IBMDBServerType.LUW, IBMDBServerVersion.None));
        }

        public virtual DbSet<ACT> Acts{ get; set; }
    }
}
