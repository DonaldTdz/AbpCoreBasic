using Abp.Authorization;
using AbpBasic.Authorization.Roles;
using AbpBasic.Authorization.Users;

namespace AbpBasic.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
