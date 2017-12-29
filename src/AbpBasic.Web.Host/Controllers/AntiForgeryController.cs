using Microsoft.AspNetCore.Antiforgery;
using AbpBasic.Controllers;

namespace AbpBasic.Web.Host.Controllers
{
    public class AntiForgeryController : AbpBasicControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
