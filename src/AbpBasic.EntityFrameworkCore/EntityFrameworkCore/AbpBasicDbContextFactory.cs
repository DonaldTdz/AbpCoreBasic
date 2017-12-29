using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using AbpBasic.Configuration;
using AbpBasic.Web;

namespace AbpBasic.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class AbpBasicDbContextFactory : IDesignTimeDbContextFactory<AbpBasicDbContext>
    {
        public AbpBasicDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AbpBasicDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            AbpBasicDbContextConfigurer.Configure(builder, configuration.GetConnectionString(AbpBasicConsts.ConnectionStringName));

            return new AbpBasicDbContext(builder.Options);
        }
    }
}
