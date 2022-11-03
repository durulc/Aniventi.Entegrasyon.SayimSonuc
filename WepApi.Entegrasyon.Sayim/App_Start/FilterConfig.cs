using System.Web;
using System.Web.Mvc;

namespace WepApi.Entegrasyon.Sayim
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
