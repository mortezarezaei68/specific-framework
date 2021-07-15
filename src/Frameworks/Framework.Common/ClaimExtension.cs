using System.Security.Claims;

namespace Framework.Common
{
    public static class ClaimExtension
    {
        public static string GetUserId(this ClaimsPrincipal user)
        {
            if (!(user.Identity is ClaimsIdentity identity)) return null;
            var userId = identity.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return userId;
        }
    }
}