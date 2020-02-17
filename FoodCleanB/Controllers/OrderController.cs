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
            TAI_KHOAN user = (TAI_KHOAN)Session["User"];

            // Sản phẩm đã có trong giỏ hàng
            var existed = Db.SanPhamGioHang.SingleOrDefault(b => b.MaTaiKhoan == user.MaTaiKhoan && b.ItemId == itemId);

            // Tăng số lượng của sản phẩm đã có
            if (existed != null)
            {
                existed.SoLuong++;
            }
            else
            {
                // Thêm mới sản phẩm
                var newItem = new UserCartItemModel
                {
                    ItemId = itemId,
                    MaTaiKhoan = user.MaTaiKhoan
                };

                Db.SanPhamGioHang.Add(newItem);
            }

            // Luu lai
            Db.SaveChanges();

            return RedirectToAction("List");
        }

        [Route("gio-hang")]
        [HttpGet]
        public ActionResult List()
        {
            TAI_KHOAN user = (TAI_KHOAN)Session["User"];

            // Lay thong tin gio hang day tu session

            // Lay danh sach item  da co gio hang trong session
            var danhSachGioHang = Db.SanPhamGioHang.Where(b => b.MaTaiKhoan == user.MaTaiKhoan).ToList();

            // Join voi bang Hang de lay ten sản phẩm
            if (danhSachGioHang != null)
            {
            }

            return View();
        }
    }
}