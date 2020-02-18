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
        [Route("them-vao-gio-hang/{itemId}")]
        [HttpGet]
        public ActionResult Insert(int itemId)
        {
            var outOfStock = Db.SanPhams.FirstOrDefault(o => o.MaHang == itemId);

            // Het hang
            if (outOfStock == null || outOfStock.SoLuong == 0)
            {
                return Json(new { Code = 0, Message = "Hết hàng" }, JsonRequestBehavior.AllowGet);
            }

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

            return Json(new {  Code = 1, Message = "Thêm thành công" }, JsonRequestBehavior.AllowGet);
        }

        [Route("gio-hang")]
        [HttpGet]
        public ActionResult List()
        {
            TaiKhoan user = (TaiKhoan)Session["User"];

            // Lay thong tin gio hang day tu session

            // Lay danh sach item  da co gio hang trong session
            // Join voi bang Hang de lay ten sản phẩm
            var danhSachGioHang = Db.SanPhamGioHangs.Where(b => b.MaTaiKhoan == user.MaTaiKhoan)
                .Join(Db.SanPhams,
                    cart => cart.MaHang,
                    s => s.MaHang,
                    (cart, s) => new UserCartItemModel
                    {
                        ItemId = s.MaHang,
                        SoLuong = cart.SoLuong,
                        AnhSanPham = s.AnhSanPham,
                        TenHang = s.TenHang,
                        GiaThanh = s.GiaThanh,
                        MaNhaCungCap = s.MaNhaCungCap
                    });

            return View(danhSachGioHang);
        }

        public ActionResult Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}