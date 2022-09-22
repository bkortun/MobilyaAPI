using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.Extensions
{
    public static class ClaimPrincipalExtensions
    {
        public static List<string>? Claims(this ClaimsPrincipal claimPrincipal, string claimType)
        {
            List<string>? result = claimPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
            return result;
        }
        public static List<string>? ClaimRoles(this ClaimsPrincipal claimPrincipal)
        {
            return claimPrincipal?.Claims(ClaimTypes.Role);
        }
        public static int GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            return Convert.ToInt32(claimsPrincipal?.Claims(ClaimTypes.NameIdentifier)?.FirstOrDefault());
        }
    }
}
