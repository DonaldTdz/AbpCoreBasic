using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace AbpBasic.EntityFrameworkCore
{
    public static class AbpBasicDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<AbpBasicDbContext> builder, string connectionString)
        {
            //builder.UseSqlServer(connectionString);
            builder.UseMySql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<AbpBasicDbContext> builder, DbConnection connection)
        {
            //builder.UseSqlServer(connection);
            builder.UseMySql(connection);
        }
    }
}
