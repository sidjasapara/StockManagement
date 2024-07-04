using System.Web;
using System.Web.Mvc;

namespace SiddharthJasapara_550
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
