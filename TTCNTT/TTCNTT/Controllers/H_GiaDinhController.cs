using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTCNTT.DB.Dao;

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
    }
}