using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace HPBFramework
{
    public class AuthorizeAttributeExtention : AuthorizeAttribute
    {
        public string AccessDeniedViewName { get; set; }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            var lang = filterContext.RouteData.Values["lang"] ?? Common.GetValueFromConfig("DefaultLang");
            if (filterContext.HttpContext.User.Identity.IsAuthenticated && Membership.isAuthenticated() &&
                filterContext.Result is HttpUnauthorizedResult)
            {
                if (string.IsNullOrWhiteSpace(AccessDeniedViewName))
                    AccessDeniedViewName = "~/" + lang + "/Account/Login";

                filterContext.Result = new RedirectResult(String.Format("{0}", AccessDeniedViewName));
            }
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            Membership.CreateLoginAuthFromSession(httpContext);
            var authroized = base.AuthorizeCore(httpContext);
            if (!authroized || !Membership.isAuthenticated())
            {
                if (authroized)
                {
                    httpContext.GetOwinContext().Authentication.SignOut("ApplicationCookie");
                }
                // the user is not authenticated or the forms authentication
                // cookie has expired
                return false;
            }

            return true;
        }
    }

    public class Membership
    {
        public static object GetCurrentUser()
        {
            try
            {
                return HttpContext.Current.Session["LoginUser"];
            }
            catch (Exception)
            {
            }
            return false;
        }

        public static bool isAuthenticated()
        {
            bool loggedIn = HttpContext.Current.User.Identity.IsAuthenticated;
            bool hasSession = (GetCurrentUser() != null);
            return (loggedIn && hasSession);
        }
        public static void CreateLoginAuthFromSession(HttpContextBase httpContext)
        {
            var user = GetCurrentUser();
            if (user == null)
            {
                return;
            }
            var identity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, (string)user),
            },
            "ApplicationCookie");

            var ctx = httpContext.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignIn(identity);

        }
    }
}