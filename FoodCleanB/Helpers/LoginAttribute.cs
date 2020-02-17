using System.Linq;
using System.Web.Mvc;
using FoodCleanB.Database;

namespace FoodCleanB.Helpers
{
    public class LoginAttribute : ActionFilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            string userCookie = filterContext.HttpContext.Request.Cookies["MyFreshFoodCookie"]?.Value;
            
            // Giai ma cookie de lay ma tai khoan
            string maTaiKhoanTrongCookie = EncryptHelper.Base64Decode(userCookie);

            if (userCookie == null || maTaiKhoanTrongCookie == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary(new { controller = "Login", action = "Login" })

                );
            }

            var userId = filterContext.HttpContext.Session.Contents["User"];

            if (userId == null)
            {
                CDLTEntities db = new CDLTEntities();

                TAI_KHOAN user = db.TAI_KHOAN.FirstOrDefault(x => x.MaTaiKhoan == maTaiKhoanTrongCookie);

                if (user != null)
                {
                    filterContext.HttpContext.Session.Contents["User"] = user;
                }
            }
        }
    }
}