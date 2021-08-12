using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTCNTT.DB.Dao;
using TTCNTT.DB.EF;

namespace TTCNTT.Controllers
{
    public class H_BanQuanLyController : Controller
    {
        // GET: H_BanQuanLy
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            ViewBag.text = "";
            if (TempData.ContainsKey("check"))
            {
                ViewBag.text = TempData["check"].ToString();
            }
            var dao = new H_BanQuanLyDao();
            var model = dao.ListLichThi(page, pageSize);
            ViewBag.ListMH = dao.ListMonHoc();
            ViewBag.ListHK = dao.ListHocKy();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddLichThi(LICHTHI lt)
        {
            var dao = new H_BanQuanLyDao();
            if (ModelState.IsValid)//kiem tra xem form co rong hay khong
            {

                bool add = dao.addLichThi(lt);
                if (add)
                {
                    TempData["check"] = "Lưu dữ liệu thành công";
                }
                else
                {
                    TempData["check"] = "Lưu dữ liệu không thành công";
                }

            }
            else
            {
                TempData["check"] = "Lỗi do chưa nhập đủ thông tin";
            }
            return RedirectToAction("index", "H_BanQuanLy"); ;
        }
        [HttpPost]
        public ActionResult EditLichThi(LICHTHI lt,int idlichthi)
        {
            var dao = new H_BanQuanLyDao();
            if (ModelState.IsValid)//kiem tra xem form co rong hay khong
            {

                bool edit = dao.UpdateLichThi(lt,idlichthi);
                if (edit)
                {
                    TempData["check"] = "Lưu dữ liệu thành công";
                }
                else
                {
                    TempData["check"] = "Lưu dữ liệu không thành công";
                }

            }
            return RedirectToAction("index", "H_BanQuanLy"); ;
        }
        [HttpGet]
        public ActionResult Del(int idlichthi)
        {
            var dao = new H_BanQuanLyDao();
           
                bool edit = dao.DelLichThi(idlichthi);
                if (edit)
                {
                    TempData["check"] = "Xóa dữ liệu thành công";
                }
                else
                {
                    TempData["check"] = "Xóa liệu không thành công";
                }
            return RedirectToAction("index", "H_BanQuanLy"); ;
        }
    }
}