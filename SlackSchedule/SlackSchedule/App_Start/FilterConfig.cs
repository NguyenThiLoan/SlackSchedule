using HPBFramework;
using System.Web.Mvc;

namespace SlackSchedule
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttributeExtention());
            filters.Add(new AuthorizeAttributeExtention());
        }
    }
}