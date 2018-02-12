using AbpBasic.DB2.Configuration;
using AbpBasic.DB2.Core;
using AbpBasic.DB2.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbpBasic.DB2.EntityFrameworkCore 
{
    public class DB2DbContextFactory : IDesignTimeDbContextFactory<DB2DbContext>
    {
        public DB2DbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DB2DbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            DB2DbContextConfigurer.Configure(builder, configuration.GetConnectionString(DB2Consts.ConnectionStringName));

            DB2DbContextConfigurer.Configure(builder, "");

            return new DB2DbContext(builder.Options);
        }
    }
}
