using System.Web.Mvc;

namespace GL.CursoMvc.Infra.CrossCutting.MvcFilters
{
    public class GlobalErrorHandler : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            /* Esse filtro irá capturar todos os erros. Ou seja, todos os erros
             passarão por aqui!!! */
            if (filterContext.Exception != null)
            {
                /* Tratar o erro de alguma forma
                 *  1 - Gravar no EventViewer 
                    2 - Gravar no banco
                    3 - Enviar um email
                    4 - Fazer tudo isso e mais alguma coisa
                 
                 Muitos recursos disponíveis para montar um LOG completo
                 filterContext.Controller.ControllerContext.HttpContext;
                 filterContext.Exception; */
            }
        }
    }
}