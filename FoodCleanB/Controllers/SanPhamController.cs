using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FoodCleanB.Database;

namespace FoodCleanB.Controllers
{
    public class SanPhamController : BaseController
    {
        public PartialViewResult HomeProduct(int? nhomHang)
        {
            IQueryable<SanPham> list;
            if (nhomHang != null)
            {
                 list =  Db.SanPhams.Where(o => o.MaNhomHang == nhomHang);

            }
            else
            {
                list = Db.SanPhams.Take(10);
            }

            return PartialView(list);
        }

        [Route("san-pham/{itemId}-{title}")]
        [HttpGet]
        public ActionResult Detail(int itemId)
        {
            var sanPham = Db.SanPhams.FirstOrDefault(o => o.MaHang == itemId);

            return View(sanPham);
        }
    }
}