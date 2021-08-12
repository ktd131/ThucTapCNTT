using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTCNTT.DB.Dao;
using TTCNTT.DB.EF;

namespace TTCNTT.Controllers
{
    public class H_GiaDinhController : Controller
    {
        // GET: H_GiaDinh
        public ActionResult Index()
        {
            var dao = new H_GiaDinhDao();
            var model = dao.listChat();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(THONGTINTRAODOICUAGIADINH gd )
        {
            var dao = new H_GiaDinhDao();
            if (ModelState.IsValid)//kiem tra xem form co rong hay khong
            {

                bool add = dao.add(gd);
                if (add)
                {
                    ViewBag.text = "Gửi thành công";
                }
                else
                {
                    ViewBag.text = "Gửi thất bại";
                }

            }
            var model = dao.listChat();
            return View(model);
        }
    }
}