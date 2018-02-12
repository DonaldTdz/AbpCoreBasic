using Abp.Modules;
using Abp.Reflection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbpBasic.DB2.Core
{
    public class DB2CoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            //AbpBasicLocalizationConfigurer.Configure(Configuration.Localization);

            // Enable this line to create a multi-tenant application.
            //Configuration.MultiTenancy.IsEnabled = AbpBasicConsts.MultiTenancyEnabled;

            // Configure roles
            //AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            //Configuration.Settings.Providers.Add<AppSettingProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DB2CoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            //IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}
