using FoodCleanB.Database;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FoodCleanB.Controllers
{
    public class SanPhamController : BaseController
    {
        public PartialViewResult HomeProduct(int? nhomHang)
        {
            IQueryable<SanPham> list;
            if (nhomHang != null)
            {
                list = Db.SanPhams.Where(o => o.MaNhomHang == nhomHang);
            }
            else
            {
                list = Db.SanPhams.Take(10);
            }

            return PartialView(list.ToList());
        }

        [Route("san-pham/{title}-{itemId}")]
        [HttpGet]
        public ActionResult Detail(int itemId, string title)
        {
            var sanPham = Db.SanPhams.FirstOrDefault(o => o.MaHang == itemId);

            return View(sanPham);
        }
        
        [Route("nhom-hang/{title?}-{id?}")]
        [HttpGet]
        public ActionResult List(int? id = null, string title = null)
        {
            List<SanPham> lstSanPham;
            if (id != null)
            {
                var getNameCate = Db.NhomHangs.First(x => x.MaSo == id);
                ViewBag.Category = getNameCate.Ten;
                lstSanPham = getNameCate.SanPhams.ToList();
            }
            else
            {
                lstSanPham = Db.SanPhams.ToList();
            }

            return View(lstSanPham);
        }

        public ActionResult Search(string search)
        {
            if (search != null)
            {
                var result = Db.SanPhams.Where(x => x.TenHang.ToLower().Contains(search.ToLower())).ToList();
                return View("List", result);
            }

            return RedirectToAction("List");
        }
    }
}