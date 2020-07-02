using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Qademli.CustomAttributes
{
    public class AuthorizeAttribute : TypeFilterAttribute
    {
        public AuthorizeAttribute(params string[] claim) : base(typeof(AuthorizeFilter))
        {
            Arguments = new object[] { claim };
        }
        public class AuthorizeFilter : IAuthorizationFilter
        {
            readonly string[] _claim;
            private readonly ApplicationDBContext _db;
            public AuthorizeFilter(ApplicationDBContext db,params string[] claim)
            {
                _db = db;
                _claim = claim;
            }

            public void OnAuthorization(AuthorizationFilterContext context)
            {
                var IsAuthenticated = context.HttpContext.User.Identity.IsAuthenticated;
                var RoleAllowed = _claim.FirstOrDefault();

                if (IsAuthenticated)
                {
                    var LoggedInUserRole = context.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
                    if (RoleAllowed == LoggedInUserRole)
                    {
                       // context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized; //Set HTTP 401 
                    }
                    else
                    {
                        context.Result =  new UnauthorizedResult(); //Set HTTP 401 ; 
                    }
                }
                else
                {
                        context.Result = new UnauthorizedResult(); //Set HTTP 401 ;
                }
                return;
            }
        }
    }
}
