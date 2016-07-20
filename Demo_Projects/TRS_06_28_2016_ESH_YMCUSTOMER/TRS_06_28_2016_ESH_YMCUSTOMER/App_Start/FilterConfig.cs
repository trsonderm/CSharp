using System.Web;
using System.Web.Mvc;

namespace TRS_06_28_2016_ESH_YMCUSTOMER
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
