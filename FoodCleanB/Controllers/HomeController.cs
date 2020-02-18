using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodCleanB.Controllers;
using FoodCleanB.Helpers;

namespace FoodCleanB.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.NhomHang = Db.NhomHangs.ToList();

            return View();
        }
    }
}