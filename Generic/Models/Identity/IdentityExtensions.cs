using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Claims;
using System.Security.Principal;


namespace Generic.Models
{
    public static class IdentityExtensions
    {
        public static string GetNom(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("Nom");
            return (claim.Value != null) ? claim.Value : string.Empty;
        }

        public static string GetPrenom(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("Prenom");
            return (claim.Value != null) ? claim.Value : string.Empty;
        }
    }
}