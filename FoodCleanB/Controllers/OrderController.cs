using FoodCleanB.Database;
using FoodCleanB.Helpers;
using FoodCleanB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FoodCleanB.Controllers
{
    [Login]
    public class OrderController : BaseController
    {
        [ChildActionOnly]
        public PartialViewResult CartCount()
        {
            TaiKhoan user = (TaiKhoan)Session["User"];
            var list = Db.SanPhamGioHang.Where(a => a.MaTaiKhoan == user.MaTaiKhoan);
            if (list.Any())
            {
                ViewBag.CartCount = list.Sum(o => o.SoLuong);
            }

            return PartialView("Cart");
        }

        [Route("them-vao-gio-hang")]
        [HttpPost]
        public ActionResult Insert(int itemId)
        {
            var tonKho = Db.SanPham.FirstOrDefault(o => o.MaHang == itemId);

            // Het hang
            if (tonKho == null || tonKho.SoLuong == 0)
            {
                return Json(new { Code = 0, Message = "Hết hàng" }, JsonRequestBehavior.AllowGet);
            }

            TaiKhoan user = (TaiKhoan)Session["User"];

            // Sản phẩm đã có trong giỏ hàng
            var existed = Db.SanPhamGioHang.SingleOrDefault(b => b.MaTaiKhoan == user.MaTaiKhoan && b.MaHang == itemId);

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
                    MaTaiKhoan = user.MaTaiKhoan,
                    SoLuong = 1
                };

                Db.SanPhamGioHang.Add(newItem);
            }

            try
            {
                // Luu lai
                Db.SaveChanges();
                return Json(new { Code = 1, Message = "Thêm thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { Code = 0, Message = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [Route("gio-hang.html")]
        [HttpGet]
        public ActionResult List()
        {
            TaiKhoan user = (TaiKhoan)Session["User"];

            // Lay thong tin gio hang day tu session

            // Lay danh sach item  da co gio hang trong session
            // Join voi bang Hang de lay ten sản phẩm
            var danhSachGioHang = Db.SanPhamGioHang.Where(b => b.MaTaiKhoan == user.MaTaiKhoan)
                .Join(Db.SanPham,
                    cart => cart.MaHang,
                    s => s.MaHang,
                    (cart, s) => new UserCartItemModel
                    {
                        ItemId = s.MaHang,
                        SoLuong = cart.SoLuong,
                        AnhSanPham = s.AnhSanPham,
                        TenHang = s.TenHang,
                        GiaThanh = s.GiaThanh - (s.KhuyenMai ?? 0),
                        MaNhaCungCap = s.MaNhaCungCap
                    });

            return View(danhSachGioHang);
        }

        public ActionResult Delete(int id)
        {
            TaiKhoan user = (TaiKhoan)Session["User"];
            var existed = Db.SanPhamGioHang.FirstOrDefault(o => o.MaHang == id && o.MaTaiKhoan == user.MaTaiKhoan);

            if (existed != null)
            {
                Db.SanPhamGioHang.Remove(existed);
                Db.SaveChanges();
                TempData["Message"] = "Xóa sản phẩm thành công!";
            }

            return RedirectToAction("List");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult DatHang()
        {
            TaiKhoan user = (TaiKhoan)Session["User"];

            var thongtinShiping = Db.ThongTinKhachHang.Where(o => o.MaTaiKhoan == user.MaTaiKhoan).ToList();

            if (thongtinShiping.Count == 0)
            {
                TempData["Message"] = "Thêm địa chỉ nhận hàng";
                return RedirectToAction("AddShipping", "User");
            }

            // Tìm sản phẩm trong giỏ
            var SanPhamGioHang = Db.SanPhamGioHang.Where(o => o.MaTaiKhoan == user.MaTaiKhoan).ToList();

            var itemInOrder = new List<ChiTietDonHang>();

            foreach (var sanPhamGioHang in SanPhamGioHang)
            {
                // Kiểm tra số lượng tồn kho đủ để giao hàng
                var sanPhamKho = Db.SanPham.FirstOrDefault(o => o.MaHang == sanPhamGioHang.MaHang && o.SoLuong >= sanPhamGioHang.SoLuong);

                // Còn hàng
                if (sanPhamKho != null)
                {
                    sanPhamKho.SoLuong -= sanPhamGioHang.SoLuong;

                    itemInOrder.Add(new ChiTietDonHang
                    {
                        MaSo = Guid.NewGuid(),
                        MaHang = sanPhamGioHang.MaHang,
                        SoLuong = sanPhamGioHang.SoLuong,
                        ThanhTien = (sanPhamGioHang.SanPham.GiaThanh - (sanPhamGioHang.SanPham.KhuyenMai ?? 0)) * sanPhamGioHang.SoLuong
                    });
                }
            }

            // Tạo đơn hàng
            var daiChiShip = thongtinShiping.First(o => o.MacDinh == true);

            var donHang = new DonHang
            {
                MaSo = Guid.NewGuid(),
                MaTaiKhoan = user.MaTaiKhoan,
                Ten = daiChiShip.Ten,
                SDT = daiChiShip.SDT,
                DiaChi = daiChiShip.DiaChi,
                NgayLap = DateTimeOffset.Now,
                TongTien = itemInOrder.Sum(o => o.ThanhTien).GetValueOrDefault(),
                ChiTietDonHang = itemInOrder
            };

            try
            {
                // Lưu
                Db.DonHang.Add(donHang);
                Db.SaveChanges();
            }
            catch (Exception e)
            {
                TempData["Message"] = e.Message;
                return RedirectToAction("List");
            }

            // Xóa sản phẩm trong giỏ hàng sau khi đã đặt hàng
            Db.SanPhamGioHang.RemoveRange(SanPhamGioHang);
            Db.SaveChanges();
            // THông báo ở View danh sách đơn hàng
            TempData["Message"] = "Đặt hàng thành công, chúng tôi sẽ sớm liên hệ với bạn.";

            return RedirectToAction("Order", "User");
        }
    }
}