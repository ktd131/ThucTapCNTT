using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TTCNTT.DB.EF;
using TTCNTT.Models;

namespace TTCNTT.Controllers
{
    public class LamController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Lam
        public ActionResult Index()
        {
            var lICHSUNGHIHOCs = db.LICHSUNGHIHOCs.Include(l => l.HOCSINH).Include(l => l.LOP);
            return View(lICHSUNGHIHOCs.ToList());
        }

        // GET: Lam/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LICHSUNGHIHOC lICHSUNGHIHOC = db.LICHSUNGHIHOCs.Find(id);
            if (lICHSUNGHIHOC == null)
            {
                return HttpNotFound();
            }
            return View(lICHSUNGHIHOC);
        }

        // GET: Lam/Create
        public ActionResult Create()
        {
            ViewBag.idhocsinh = new SelectList(db.HOCSINHs, "idhocsinh", "tenhocsinh");
            ViewBag.idlop = new SelectList(db.LOPs, "idlop", "tenlop");
            return View();
        }

        // POST: Lam/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idlichsunghihoc,lydo,trangthai,cophep,ngaynghi,idhocsinh,idlop,datestart,dateend")] LichSuNghiHocDto lICHSUNGHIHOC)
        {
            if (ModelState.IsValid)
            {
                //if (lICHSUNGHIHOC.datestart > lICHSUNGHIHOC.dateend)
                //    throw new Exception("Start date can not be greater than end date");
                //for(var i = )
                //{
                //    db.LICHSUNGHIHOCs.Add(lICHSUNGHIHOC);
                //    db.SaveChanges();
                //}
               
                return RedirectToAction("Index");
            }

            ViewBag.idhocsinh = new SelectList(db.HOCSINHs, "idhocsinh", "tenhocsinh", lICHSUNGHIHOC.idhocsinh);
            ViewBag.idlop = new SelectList(db.LOPs, "idlop", "tenlop", lICHSUNGHIHOC.idlop);
            return View(lICHSUNGHIHOC);
        }

        // GET: Lam/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LICHSUNGHIHOC lICHSUNGHIHOC = db.LICHSUNGHIHOCs.Find(id);
            if (lICHSUNGHIHOC == null)
            {
                return HttpNotFound();
            }
            ViewBag.idhocsinh = new SelectList(db.HOCSINHs, "idhocsinh", "tenhocsinh", lICHSUNGHIHOC.idhocsinh);
            ViewBag.idlop = new SelectList(db.LOPs, "idlop", "tenlop", lICHSUNGHIHOC.idlop);
            return View(lICHSUNGHIHOC);
        }

        // POST: Lam/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idlichsunghihoc,lydo,trangthai,cophep,ngaynghi,idhocsinh,idlop")] LICHSUNGHIHOC lICHSUNGHIHOC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lICHSUNGHIHOC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idhocsinh = new SelectList(db.HOCSINHs, "idhocsinh", "tenhocsinh", lICHSUNGHIHOC.idhocsinh);
            ViewBag.idlop = new SelectList(db.LOPs, "idlop", "tenlop", lICHSUNGHIHOC.idlop);
            return View(lICHSUNGHIHOC);
        }

        // GET: Lam/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LICHSUNGHIHOC lICHSUNGHIHOC = db.LICHSUNGHIHOCs.Find(id);
            if (lICHSUNGHIHOC == null)
            {
                return HttpNotFound();
            }
            return View(lICHSUNGHIHOC);
        }

        // POST: Lam/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LICHSUNGHIHOC lICHSUNGHIHOC = db.LICHSUNGHIHOCs.Find(id);
            db.LICHSUNGHIHOCs.Remove(lICHSUNGHIHOC);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
