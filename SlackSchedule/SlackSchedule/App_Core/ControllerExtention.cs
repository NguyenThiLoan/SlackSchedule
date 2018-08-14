using HPBFramework;
using HPBFramework.Logger;
using SlackSchedule.Services.IServices;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace SlackSchedule
{
    public class ControllerExtention : HPBFramework.ControllerExtention
    {
        private static string _cookieLangName = "LangForMultiLanguageDemo";
        public ICommonService _commonService;

        public ControllerExtention(ILoggingService loggingService, ICommonService commonService) : base(loggingService)
        {
            _loggingService = loggingService;
            _commonService = commonService;
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string cultureOnCookie = GetCultureOnCookie(filterContext.HttpContext.Request);
            string cultureOnURL = filterContext.RouteData.Values.ContainsKey("lang")
                ? filterContext.RouteData.Values["lang"].ToString()
                : GlobalHelper.DefaultCulture;
            string culture = (cultureOnCookie == string.Empty)
                ? (filterContext.RouteData.Values["lang"].ToString())
                : cultureOnCookie;

            if (cultureOnURL != culture)
            {
                filterContext.HttpContext.Response.RedirectToRoute("LocalizedDefault",
                new
                {
                    lang = culture,
                    controller = filterContext.RouteData.Values["controller"],
                    action = filterContext.RouteData.Values["action"]
                });
                return;
            }

            SetCurrentCultureOnThread(culture);

            if (culture != MultiLanguageViewEngine.CurrentCulture)
            {
                (ViewEngines.Engines[0] as MultiLanguageViewEngine).SetCurrentCulture(culture);
            }

            base.OnActionExecuting(filterContext);
        }

        private static void SetCurrentCultureOnThread(string lang)
        {
            if (string.IsNullOrEmpty(lang))
                lang = GlobalHelper.DefaultCulture;
            switch (lang)
            {
                case "vi":
                    break;
                case "en":
                    lang = "en-US";
                    break;
                case "ja":
                    break;
                default:
                    break;
            }
            var cultureInfo = new System.Globalization.CultureInfo(lang);
            System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfo;
            System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo;
        }

        public static String GetCultureOnCookie(HttpRequestBase request)
        {
            var cookie = request.Cookies[_cookieLangName];
            string culture = string.Empty;
            if (cookie != null)
            {
                culture = cookie.Value;
            }
            return culture;
        }

        #region COMMON FUNCTION
        protected void setTempMessage(string message)
        {
            TempData["TempMessage"] = message;
        }
        protected string getTempMessage(bool isKeep = false)
        {
            var msg = TempData["TempMessage"] as string;
            if (isKeep)
            {
                TempData.Keep("TempMessage");
            }
            return msg;
        }
        #endregion
    }

    public class GlobalHelper
    {
        public static string CurrentCulture
        {
            get
            {
                return Thread.CurrentThread.CurrentUICulture.Name;
            }
        }

        public static string DefaultCulture
        {
            get
            {
                Configuration config = WebConfigurationManager.OpenWebConfiguration("/");
                GlobalizationSection section = (GlobalizationSection)config.GetSection("system.web/globalization");
                return section.UICulture;
            }
        }
    }
}

