using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace SiddharthJasapara_550.Api.JWT
{
    public class JwtAuthorizeAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            string token = null;
            var authHeader = actionContext.Request.Headers.Authorization;
            if (authHeader != null)
            {
                token = authHeader.Scheme;
            }
            if (String.IsNullOrEmpty(token))
            {
                var cookie = HttpContext.Current.Request.Cookies["jwt"];
                if ((cookie != null))
                {
                    token = cookie.Value;
                    // Token is valid, continue with the request
                }
            }
            if (Authentication.ValidateToken(token) != null)
            {
                base.OnAuthorization(actionContext);
                return;

            }
            //var token = actionContext.Request.Headers.GetCookies("jwt").FirstOrDefault();
            HandleUnauthorizedRequest(actionContext);
        }

        private void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, "Access denied");

        }
    }
}