﻿using FoodCleanB.Database;
using System.Linq;
using System.Web.Mvc;

namespace FoodCleanB.Helpers
{
    public class GetSessionAttribute : ActionFilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            string userCookie = filterContext.HttpContext.Request.Cookies["MyFoodFreshCookie"]?.Value;

            if (userCookie != null)
            {
                // Giai ma cookie de lay ma tai khoan
                string maTaiKhoanTrongCookie = EncryptHelper.Base64Decode(userCookie);

                var user = filterContext.HttpContext.Session.Contents["User"] as TaiKhoan;

                if (user == null)
                {
                    var db = new CDLTEntities();

                    user = db.TaiKhoan.FirstOrDefault(x => x.MaTaiKhoan.ToString() == maTaiKhoanTrongCookie);

                    if (user != null)
                    {
                        filterContext.HttpContext.Session.Contents["User"] = user;
                    }
                }
            }
        }
    }

    public class LoginAttribute : ActionFilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            var userCookie = filterContext.HttpContext.Request.Cookies["MyFoodFreshCookie"]?.Value;

            // Giai ma cookie de lay ma tai khoan
            string maTaiKhoanTrongCookie = EncryptHelper.Base64Decode(userCookie);

            if (userCookie == null || maTaiKhoanTrongCookie == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary(new { controller = "Login", action = "Login" })

                );
            }
        }
    }
}