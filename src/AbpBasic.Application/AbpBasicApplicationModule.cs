using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AbpBasic.Authorization;

namespace AbpBasic
{
    [DependsOn(
        typeof(AbpBasicCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class AbpBasicApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<AbpBasicAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(AbpBasicApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
