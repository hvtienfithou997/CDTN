﻿using FoodCleanB.Database;
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
                list = Db.SanPham.Where(o => o.MaNhomHang == nhomHang);
            }
            else
            {
                list = Db.SanPham.Take(12);
            }

            return PartialView(list.ToList());
        }

        [Route("san-pham/{title}-{itemId}.html")]
        [HttpGet]
        public ActionResult Detail(int ItemId, string title)
        {
            var sanPham = Db.SanPham.FirstOrDefault(o => o.MaHang == ItemId);

            return View(sanPham);
        }
        
        [Route("nhom-hang/{title}-{id}-trang-{page}.html")]
        [HttpGet]
        public ActionResult List(int page = 1, int id = 0, string title = null)
        {
            const int pageSize = 12;

            ViewBag.NhomHang = id;
            ViewBag.NhomHangTen = title;
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;

            List<SanPham> lstSanPham = new List<SanPham>();
            if (id > 0)
            {
                var getNameCate = Db.NhomHang.FirstOrDefault(x => x.MaSo == id);
                if (getNameCate != null)
                {
                    ViewBag.Category = getNameCate.Ten;
                    ViewBag.Total = getNameCate.SanPham.Count();
                    
                    lstSanPham = getNameCate.SanPham.ToList();
                }
            }
            else
            {
                ViewBag.Total = Db.SanPham.Count();
                lstSanPham = Db.SanPham.ToList();
            }

            // Phân trang, [pageSize] sản phẩm mỗi trang
            return View(lstSanPham.Skip(pageSize * (page-1)).Take(pageSize).ToList());
        }

        public ActionResult Search(string search)
        {
            if (search != null)
            {
                var result = Db.SanPham.Where(x => x.TenHang.ToLower().Contains(search.ToLower())).ToList();
                
                return View("List", result);
            }

            return RedirectToAction("List");
        }
    }
}