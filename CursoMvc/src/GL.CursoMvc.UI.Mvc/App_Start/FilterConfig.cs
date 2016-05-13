using System.Web;
using System.Web.Mvc;
using GL.CursoMvc.Infra.CrossCutting.MvcFilters;

namespace GL.CursoMvc.UI.Mvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new GlobalErrorHandler());
        }
    }
}
