using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTCNTT.DB.EF;
using TTCNTT.Models;

namespace TTCNTT.Controllers
{
    public class HomeController : Controller
    {
        private DBContext _db = new DBContext();
        public ActionResult Index()
        {
            //Session.Add("quyen", "quyengiaovien");
            return View();
        }

        public ActionResult Intro()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //GET: Register

        public ActionResult Register()
        {
            return View();
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User _user)
        {
            if (ModelState.IsValid)
            {
                var check = _db.NGUOIDUNGs.FirstOrDefault(s => s.tendangnhap == _user.Email);
                if (check == null)
                {
                    _db.Configuration.ValidateOnSaveEnabled = false;
                    _db.NGUOIDUNGs.Add(new NGUOIDUNG { 
                        tendangnhap = _user.Email,
                        matkhau = _user.Password,
                        ten = _user.Name,
                    });
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "UserName already exists";
                    return View();
                }


            }
            return View();


        }

        public ActionResult Login()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {


                var f_password = password;
                var data = _db.NGUOIDUNGs.Where(s => s.tendangnhap.Equals(email) && s.matkhau.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["quyen"] = data.FirstOrDefault().NHOMNGUOIDUNG.QUYEN.tenquyen;
                    Session["email"] = data.FirstOrDefault().tendangnhap;
                    Session["tenhienthi"] = data.FirstOrDefault().ten;
                    Session["iduser"] = data.FirstOrDefault().idnguoidung;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }


        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }


    }
}