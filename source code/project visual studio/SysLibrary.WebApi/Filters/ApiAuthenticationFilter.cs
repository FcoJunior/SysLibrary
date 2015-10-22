using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace SysLibrary.WebApi.Filters
{
    public class ApiAuthenticationFilter : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var authRequest = actionContext.Request.Headers.Authorization;
            var authHeaderValue = authRequest.Parameter;



            base.OnAuthorization(actionContext);
        }


    }
}