using FoodCleanB.Database;
using FoodCleanB.Helpers;
using FoodCleanB.Models;
using System.Linq;
using System.Web.Mvc;

namespace FoodCleanB.Controllers
{
    [Login]
    public class OrderController : BaseController
    {
        [Route("them/{itemId}")]
        public ActionResult Insert(int itemId)
        {
            TaiKhoan user = (TaiKhoan)Session["User"];

            // Sản phẩm đã có trong giỏ hàng
            var existed = Db.SanPhamGioHangs.SingleOrDefault(b => b.MaTaiKhoan == user.MaTaiKhoan && b.MaHang == itemId);

            // Tăng số lượng của sản phẩm đã có
            if (existed != null)
            {
                existed.SoLuong++;
            }
            else
            {
                // Thêm mới sản phẩm
                var newItem = new SanPhamGioHang
                {
                    MaHang = itemId,
                    MaTaiKhoan = user.MaTaiKhoan
                };

                Db.SanPhamGioHangs.Add(newItem);
            }

            // Luu lai
            Db.SaveChanges();

            return RedirectToAction("List");
        }

        [Route("gio-hang")]
        [HttpGet]
        public ActionResult List()
        {
            TaiKhoan user = (TaiKhoan)Session["User"];

            // Lay thong tin gio hang day tu session

            // Lay danh sach item  da co gio hang trong session
            var danhSachGioHang = Db.SanPhamGioHangs.Where(b => b.MaTaiKhoan == user.MaTaiKhoan).ToList();

            // Join voi bang Hang de lay ten sản phẩm
            if (danhSachGioHang != null)
            {
            }

            return View();
        }
    }
}