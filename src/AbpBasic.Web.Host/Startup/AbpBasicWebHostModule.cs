using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AbpBasic.Configuration;

namespace AbpBasic.Web.Host.Startup
{
    [DependsOn(
       typeof(AbpBasicWebCoreModule))]
    public class AbpBasicWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public AbpBasicWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpBasicWebHostModule).GetAssembly());
        }
    }
}
