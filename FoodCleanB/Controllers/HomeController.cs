using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodCleanB.Controllers
{
    [Login]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}