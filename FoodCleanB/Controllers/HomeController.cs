using System.Linq;
using System.Web.Mvc;

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