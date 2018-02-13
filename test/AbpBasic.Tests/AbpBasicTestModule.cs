using System;
using Castle.MicroKernel.Registration;
using NSubstitute;
using Abp.AutoMapper;
using Abp.Dependency;
using Abp.Modules;
using Abp.Configuration.Startup;
using Abp.Net.Mail;
using Abp.TestBase;
using Abp.Zero.Configuration;
using Abp.Zero.EntityFrameworkCore;
using AbpBasic.EntityFrameworkCore;
using AbpBasic.Tests.DependencyInjection;
using AbpBasic.DB2.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace AbpBasic.Tests
{
    [DependsOn(
        typeof(AbpBasicApplicationModule),
        typeof(AbpBasicEntityFrameworkModule),
        typeof(DB2EntityFrameworkModule),
        typeof(AbpTestBaseModule)
        )]
    public class AbpBasicTestModule : AbpModule
    {

        private readonly IConfigurationRoot _appConfiguration;
        public AbpBasicTestModule(AbpBasicEntityFrameworkModule abpProjectNameEntityFrameworkModule, DB2EntityFrameworkModule db2EntityFrameworkModule, IConfigurationRoot appConfiguration)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = false;
            db2EntityFrameworkModule.SkipDbContextRegistration = true;
            _appConfiguration = appConfiguration;
        }

       

        //public AbpBasicTestModule(IHostingEnvironment env)
        //{
        //    _env = env;
        //    _appConfiguration = env.GetAppConfiguration();
        //}

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
             AbpBasicConsts.ConnectionStringName
          );

            Configuration.UnitOfWork.Timeout = TimeSpan.FromMinutes(30);
            Configuration.UnitOfWork.IsTransactional = false;

            // Disable static mapper usage since it breaks unit tests (see https://github.com/aspnetboilerplate/aspnetboilerplate/issues/2052)
            Configuration.Modules.AbpAutoMapper().UseStaticMapper = false;

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;

            // Use database for language management
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            RegisterFakeService<AbpZeroDbMigrator<AbpBasicDbContext>>();

            Configuration.ReplaceService<IEmailSender, NullEmailSender>(DependencyLifeStyle.Transient);
        }

        public override void Initialize()
        {
            ServiceCollectionRegistrar.Register(IocManager);
        }

        private void RegisterFakeService<TService>() where TService : class
        {
            IocManager.IocContainer.Register(
                Component.For<TService>()
                    .UsingFactoryMethod(() => Substitute.For<TService>())
                    .LifestyleSingleton()
            );
        }
    }
}
