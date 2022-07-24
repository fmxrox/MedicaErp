using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Security.Claims;

namespace MedicaERP.Web.Filters
{
    public class CheckPermissions : Attribute, IAuthorizationFilter
    {
        private readonly string _permission;
        public CheckPermissions(string permission)//sprawdzam czy zalogowany ma dostep
        {
            _permission = permission;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            bool isAuthorized = CheckUsersPermissions(context.HttpContext.User, _permission);
            if (!isAuthorized)
            {
                context.Result = new UnauthorizedResult();
            }
        }

        private bool CheckUsersPermissions(ClaimsPrincipal user, string permission)
        {
            //polacz z baza danych i pobranie uzytkownika
            //czy uytkjownik ma dostep do akcji
            return permission == "Read";
        }
    }
}
