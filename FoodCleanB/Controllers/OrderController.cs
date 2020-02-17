using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodCleanB.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Insert()
        {
            return View();
        }
    }
}