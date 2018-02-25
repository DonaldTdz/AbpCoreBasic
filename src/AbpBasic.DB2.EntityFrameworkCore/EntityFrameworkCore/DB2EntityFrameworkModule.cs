using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AbpBasic.DB2.Configuration;
using AbpBasic.DB2.Core;
using AbpBasic.DB2.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbpBasic.DB2.EntityFrameworkCore
{
    [DependsOn(
        typeof(DB2CoreModule),
        typeof(AbpEntityFrameworkCoreModule))]
    public class DB2EntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            /*if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<DB2DbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        DB2DbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        DB2DbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }*/

            //Configuration.Modules.AbpEfCore().AddDbContext<DB2DbContext>(options =>
            //{
            //    var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());
            //    DB2DbContextConfigurer.Configure(options.DbContextOptions, configuration.GetConnectionString(DB2Consts.ConnectionStringName));
            //});

            Configuration.Modules.AbpEfCore().AddDbContext<DB2DbContext>(options => 
            {
                //var builder = new DbContextOptionsBuilder<DB2DbContext>();
                //var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());
                //DB2DbContextConfigurer.Configure(builder, configuration.GetConnectionString(DB2Consts.ConnectionStringName));
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DB2EntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                //SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
