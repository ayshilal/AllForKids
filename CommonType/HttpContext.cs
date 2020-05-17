using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Security.Principal;

namespace CommonType
{
    public static class HttpContext
    {
        private static IHttpContextAccessor _contextAccessor;

        public static Microsoft.AspNetCore.Http.HttpContext Current => _contextAccessor.HttpContext;

        internal static void Configure(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public static string GetCustomerId(this IPrincipal user)
        {
            var claim = ((ClaimsIdentity)user.Identity).FindFirst("MembershipId");
            return claim?.Value;
        }
    }
}
