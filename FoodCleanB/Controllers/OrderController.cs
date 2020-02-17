using System.Collections.Generic;
using System.Web.Mvc;
using FoodCleanB.Database;
using FoodCleanB.Helpers;
using FoodCleanB.Models;

namespace FoodCleanB.Controllers
{
    [Login]
    public class OrderController : Controller
    {
        [Route("them/{itemId}")]
        public ActionResult Insert(int itemId)
        {
            TAI_KHOAN user = (TAI_KHOAN) Session["User"];

            var cartKey = $"UserCart_{user.MaTaiKhoan}";
            
            // Lay danh sach item  da co gio hang trong session
            var danhSachGioHang = Session[cartKey] as List<UserCartItemModel> ?? new List<UserCartItemModel>();

            var  existed = danhSachGioHang.Find(o => o.ItemId == itemId);

            if (existed != null)
            {
                existed.SoLuong++;
            }
            else
            {
                var newItem = new UserCartItemModel
                {
                    ItemId = itemId
                };
                danhSachGioHang.Add(newItem);
            }

            // Luu lai 
            Session[cartKey] = danhSachGioHang;

            return RedirectToAction("List");
        }

        [Route("gio-hang")]
        [HttpGet]
        public ActionResult List()
        {
            TAI_KHOAN user = (TAI_KHOAN) Session["User"];

            // Lay thong tin gio hang day tu session
            var cartKey = $"UserCart_{user.MaTaiKhoan}";

            // Lay danh sach item  da co gio hang trong session
            var danhSachGioHang = Session[cartKey] as List<UserCartItemModel>;

            // Join voi bang Hang de lay ten hang
            if (danhSachGioHang != null)
            {

            }

            return View();
        }
    }
}