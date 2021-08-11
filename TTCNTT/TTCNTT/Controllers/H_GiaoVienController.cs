using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTCNTT.DB.Dao;

namespace TTCNTT.Controllers
{
    public class H_GiaoVienController : Controller
    {
        // GET: H_GiaoVien
        public ActionResult Index()
        {
            ViewBag.text = "";
            if(TempData.ContainsKey("check"))
            {
                ViewBag.text = TempData["check"].ToString();
            }    
            var dao = new H_GiaoVienDao();
            var model = dao.ListDiemHocSinh();
            ViewBag.ListHS = dao.ListHocSinh();
            ViewBag.ListMH = dao.ListMonHoc();
            ViewBag.ListHK = dao.ListHocKy();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddBangDiem(int idmonhoc, int idhocsinh, int idhocky, double diem15phutlan1,double diem15phutlan2,double diem45phutlan1,double diem45phutlan2, double diemhocky,string tongkethocky, string ghichu)
        {
            var dao = new H_GiaoVienDao();
            if (ModelState.IsValid)//kiem tra xem form co rong hay khong
            {
                
                bool add = dao.addBangDiem(idmonhoc, idhocsinh, idhocky, diem15phutlan1, diem15phutlan2, diem45phutlan1, diem45phutlan2, diemhocky, tongkethocky, ghichu);
                if (add)
                {
                    TempData["check"] = "Lưu dữ liệu thành công";
                }
                else
                {
                    TempData["check"] = "Lưu dữ liệu không thành công";
                }

            }
             return RedirectToAction("index", "H_GiaoVien"); ;
        }
        [HttpPost]
        public ActionResult EditBangDiem(int idmonhoc, int idhocsinh, int idhocky, double diem15phutlan1, double diem15phutlan2, double diem45phutlan1, double diem45phutlan2, double diemhocky, string tongkethocky, string ghichu,int idbangdiem)
        {
            var dao = new H_GiaoVienDao();
            if (ModelState.IsValid)//kiem tra xem form co rong hay khong
            {

                bool edit = dao.UpdateBangDiem(idmonhoc, idhocsinh, idhocky, diem15phutlan1, diem15phutlan2, diem45phutlan1, diem45phutlan2, diemhocky, tongkethocky, ghichu,idbangdiem);
                if (edit)
                {
                    TempData["check"] = "Lưu dữ liệu thành công";
                }
                else
                {
                    TempData["check"] = "Lưu dữ liệu không thành công";
                }

            }
            return RedirectToAction("index", "H_GiaoVien"); ;
        }
    }
}