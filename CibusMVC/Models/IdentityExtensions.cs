using CibusMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace CibusMVC.Models
{

    public static class IdentityExtensions
    {
        public static bool IsAdmin(this IIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException("identity");
            }
             var ci = identity as ClaimsIdentity;
           
            if (ci != null)
            {
                return ci.IsAdmin(); // FindFirstValue("IsAdmin");
            }
            return false;
        }

        public static string GetIdRestaurante(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("IdRestaurante");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }

    }
}
    