using System.Web.Mvc;
using FoodCleanB.Database;

namespace FoodCleanB.Controllers
{
    public class BaseController : Controller
    {
        protected readonly CDLTEntities Db = new CDLTEntities();
    }
}