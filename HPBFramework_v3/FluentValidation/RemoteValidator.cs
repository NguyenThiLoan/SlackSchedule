using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HPBFramework.FluentValidation
{
    public class RemoteValidator : PropertyValidator
    {
        public string Url { get; private set; }
        public string HttpMethod { get; private set; }
        public string AdditionalFields { get; private set; }

        public RemoteValidator(string errorMessage,
                               string action,
                               string controller,
                               HttpVerbs HttpVerb = HttpVerbs.Get,
                               string additionalFields = "")
              : base(errorMessage)
        {
            var httpContext = HttpContext.Current;

            if (httpContext == null)
            {
                var request = new HttpRequest("/", Common.GetValueFromConfig("DefaultHttpRequestUrl"), "");
                var response = new HttpResponse(new StringWriter());
                httpContext = new HttpContext(request, response);
            }

            var httpContextBase = new HttpContextWrapper(httpContext);
            var routeData = new RouteData();
            var requestContext = new RequestContext(httpContextBase, routeData);

            var helper = new UrlHelper(requestContext);

            Url = helper.Action(action, controller);
            HttpMethod = HttpVerb.ToString();
            AdditionalFields = additionalFields;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            //This is not a server side validation rule. So, should not effect at the server side.
            return true;
        }
    }
}