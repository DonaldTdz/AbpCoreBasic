using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using AbpBasic.Authorization.Roles;
using AbpBasic.Authorization.Users;
using AbpBasic.MultiTenancy;

namespace AbpBasic.EntityFrameworkCore
{
    public class AbpBasicDbContext : AbpZeroDbContext<Tenant, Role, User, AbpBasicDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public AbpBasicDbContext(DbContextOptions<AbpBasicDbContext> options)
            : base(options)
        {
        }
    }
}
