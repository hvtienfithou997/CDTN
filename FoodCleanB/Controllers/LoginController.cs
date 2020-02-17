using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using FoodCleanB.Database;
using FoodCleanB.Models;

namespace FoodCleanB.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        CDLTEntities db = new CDLTEntities();

        [HttpGet]
        [Route("dangnhap")]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [Route("dangnhap")]
        public ActionResult Login(LoginModel log)
        {
            var user = (db.TAI_KHOAN.Where(x => x.TenDangNhap == log.TenDangNhap && x.MatKhau == log.MatKhau)).FirstOrDefault();
           
            if (user != null)
            {
                HttpCookie myCookie = new HttpCookie("MyFoodFreshCookie");
                DateTime now = DateTime.Now;

                // Set the cookie value.
                myCookie.Value = user.MaTaiKhoan;
                // Set the cookie expiration date.
                myCookie.Expires = now.AddHours(2);

                // Add the cookie.
                Response.Cookies.Add(myCookie);
                return RedirectToAction("Index","Home");
            }
            

            return View();

        }
        [Route("dangxuat")]
        public ActionResult LogOut()
        {
            Request.Cookies.Clear();
            return RedirectToAction("Login","Login");
        }
    }
}