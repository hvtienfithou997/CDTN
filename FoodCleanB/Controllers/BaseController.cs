using System.Web.Mvc;
using FoodCleanB.Database;
using FoodCleanB.Helpers;

namespace FoodCleanB.Controllers
{
    [GetSession]
    public class BaseController : Controller
    {
        protected readonly CDLTEntities1 Db = new CDLTEntities1();
    }
}