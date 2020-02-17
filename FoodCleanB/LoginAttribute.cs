using System.Web.Mvc;

namespace FoodCleanB
{
    public class LoginAttribute : ActionFilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            var getCookie = filterContext.HttpContext.Request.Cookies["MyFreshFoodCookie"];
            if (getCookie != null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary(new { controller = "Login", action = "Login" })

                );
            }
        }
    }
}