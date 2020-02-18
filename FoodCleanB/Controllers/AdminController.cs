using FoodCleanB.Database;
using FoodCleanB.Helpers;
using System;
using System.Linq;
using System.Web.Mvc;

namespace FoodCleanB.Controllers
{
    [Login]
    [Admin]
    public class AdminController : BaseController
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        #region Nhóm hàng hóa

        [HttpGet]
        public ActionResult NhomHang()
        {
            var nhoms = Db.NhomHangs.ToList();
            return View(nhoms);
        }

        [HttpGet]
        public ActionResult ThemNhomHang()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemNhomHang(NhomHang m)
        {
            if (m.Ten == null || m.Ten.Trim().Length == 0)
            {
                ModelState.AddModelError("Ten", "Tên nhóm bị bỏ trống.");
                return View(m);
            }

            if (Db.NhomHangs.Any(o => o.Ten == m.Ten))
            {
                ModelState.AddModelError("Ten", "Nhóm này đã tồn tại.");
                return View(m);
            }

            Db.NhomHangs.Add(m);
            Db.SaveChanges();
            TempData["Message"] = $"Thêm thành công {m.Ten}";

            return RedirectToAction("NhomHang");
        }

        #endregion Nhóm hàng hóa

        #region Sản phẩm

        [HttpGet]
        public ActionResult SanPham()
        {
            var list = Db.SanPhams.ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult ThemSanPham()
        {
            ViewBag.NhaCungCap = Db.NhaCungCaps.Select(o => new SelectListItem { Value = o.MaSo.ToString(), Text = o.Ten }).ToList();
            ViewBag.NhomHang = Db.NhomHangs.Select(o => new SelectListItem { Value = o.MaSo.ToString(), Text = o.Ten }).ToList();

            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemSanPham(SanPham m)
        {
            if (m?.TenHang == null || m.TenHang.Trim().Length == 0)
            {
                ModelState.AddModelError("TenHang", "Tên sản phẩm bị bỏ trống.");
            }

            if (m == null || !ModelState.IsValid)
            {
                ViewBag.NhaCungCap = Db.NhaCungCaps.Select(o => new SelectListItem { Value = o.MaSo.ToString(), Text = o.Ten }).ToList();
                ViewBag.NhomHang = Db.NhomHangs.Select(o => new SelectListItem { Value = o.MaSo.ToString(), Text = o.Ten }).ToList();

                return View(m);
            }

            try
            {
                m.Sku = Guid.NewGuid();
                m.TenHang = m.TenHang?.Trim();

                Db.SanPhams.Add(m);
                Db.SaveChanges();

                TempData["Message"] = $"Thêm thành công {m.MaHang}";

                return RedirectToAction("SanPham");
            }
            catch (Exception ex)
            {
                TempData["Message"] = (ex.InnerException ?? ex).Message;

                return RedirectToAction("SanPham");
            }
        }

        // GET: Admin/Edit/5
        public ActionResult EditSanPham(int maHang)
        {
            ViewBag.NhaCungCap = Db.NhaCungCaps.Select(o => new SelectListItem { Value = o.MaSo.ToString(), Text = o.Ten }).ToList();
            ViewBag.NhomHang = Db.NhomHangs.Select(o => new SelectListItem { Value = o.MaSo.ToString(), Text = o.Ten }).ToList();
            var item = Db.SanPhams.FirstOrDefault(o => o.MaHang == maHang);

            if (item == null)
            {
                TempData["Message"] = $"Không có sản phẩm với mã số {maHang}";

                return RedirectToAction("SanPham");
            }

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSanPham(SanPham m)
        {
            if (m?.TenHang == null || m.TenHang.Trim().Length == 0)
            {
                ModelState.AddModelError("TenHang", "Tên sản phẩm bị bỏ trống.");
            }

            if (m == null || !ModelState.IsValid)
            {
                ViewBag.NhaCungCap = Db.NhaCungCaps.Select(o => new SelectListItem { Value = o.MaSo.ToString(), Text = o.Ten }).ToList();
                ViewBag.NhomHang = Db.NhomHangs.Select(o => new SelectListItem { Value = o.MaSo.ToString(), Text = o.Ten }).ToList();
                return View(m);
            }

            try
            {
                // Tìm sản phẩm
                SanPham existed = Db.SanPhams.FirstOrDefault(o => o.MaHang == m.MaHang);
                if (existed == null)
                {
                    TempData["Message"] = $"Không có sản phẩm với mã số {m.MaHang}";

                    return RedirectToAction("SanPham");
                }

                existed.TenHang = m.TenHang?.Trim();
                existed.AnhSanPham = m.AnhSanPham;
                existed.MaNhaCungCap = m.MaNhaCungCap;
                existed.MaNhomHang = m.MaNhomHang;
                existed.GiaThanh = m.GiaThanh;
                existed.KhoiLuong = m.KhoiLuong;
                existed.MoTa = m.MoTa;
                existed.KhuyenMai = m.KhuyenMai;
                existed.SoLuong = m.SoLuong;
                existed.TheTich = m.TheTich;

                Db.SaveChanges();
                TempData["Message"] = $"Cập nhật xong mã số {m.MaHang}";

                return RedirectToAction("SanPham");
            }
            catch (Exception ex)
            {
                TempData["Message"] = (ex.InnerException ?? ex).Message;

                return RedirectToAction("SanPham");
            }
        }

        // GET: Admin/Delete/5
        public ActionResult DeleteSanPham(int maHang)
        {
            // Tìm sản phẩm
            SanPham existed = Db.SanPhams.FirstOrDefault(o => o.MaHang == maHang);
            if (existed == null)
            {
                TempData["Message"] = $"Không có sản phẩm với mã số {maHang}";

                return RedirectToAction("SanPham");
            }

            Db.SanPhams.Remove(existed);
            Db.SaveChanges();

            TempData["Message"] = $"Đã xóa mã số {maHang}";

            return RedirectToAction("SanPham");
        }

        #endregion Sản phẩm

        [HttpGet]
        public ActionResult NhaCungCap()
        {
            var nhaCungCap = Db.NhaCungCaps.ToList();
            return View(nhaCungCap);
        }

        [HttpGet]
        public ActionResult ThemNhaCungCap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ThemNhaCungCap(NhaCungCap m)
        {
            if (!ModelState.IsValid)
            {
                //
                return View(m);
            }

            m.MaSo = Guid.NewGuid();

            Db.NhaCungCaps.Add(m);
            Db.SaveChanges();

            TempData["Message"] = $"Thêm thành công {m.Ten}";
            return RedirectToAction("NhaCungCap");
        }

        public ActionResult Coupon()
        {
            throw new NotImplementedException();
        }
    }
}