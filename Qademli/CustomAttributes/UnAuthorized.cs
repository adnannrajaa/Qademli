using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Qademli.CustomAttributes
{
    public class UnAuthorizedAttribute : TypeFilterAttribute
    {
        public UnAuthorizedAttribute() : base(typeof(UnauthorizedFilter))
        {
            //Empty constructor
        }
    }
    public class UnauthorizedFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {

        }
    }
}
