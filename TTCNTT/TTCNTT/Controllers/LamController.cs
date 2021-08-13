using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
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
            var lICHSUNGHIHOCs = db.LICHSUNGHIHOCs.Include(l => l.HOCSINH).Include(l => l.LOP).OrderBy(x=>x.ngaynghi);
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
                //    
                ////throw new Exception("Start date can not be greater than end date");
                for (var i = lICHSUNGHIHOC.datestart.Date; i <= lICHSUNGHIHOC.dateend.Date; i = i.AddDays(1))
                {
                    db.LICHSUNGHIHOCs.Add(new LICHSUNGHIHOC
                    {
                        idhocsinh = lICHSUNGHIHOC.idhocsinh,
                        idlop = lICHSUNGHIHOC.idlop,
                        cophep = lICHSUNGHIHOC.cophep,
                        lydo = lICHSUNGHIHOC.lydo,
                        ngaynghi = i,
                        trangthai = "0"
                    });
                    db.SaveChanges();
                }

                //return RedirectToAction("Index");
                return Redirect("/home/index");
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

        public ActionResult DiemDanh(int page = 1, int pageSize = 10, DateTime? date = null)
        {
            if (!date.HasValue)
                date = DateTime.Now.Date;
            var diemdanhs = db.HOCSINHs
                //.Where(x => x.LICHSUNGHIHOCs.Any(y=>y.ngaynghi == date.Date && y.cophep.HasValue))
                .Select(x => new DiemDanhDto
                {
                    idhocsinh = x.idhocsinh,
                    tenhocsinh = x.tenhocsinh,
                    namsinh = x.namsinh,
                    diemdanhnghi = x.LICHSUNGHIHOCs.Any(y => y.ngaynghi == date.Value),
                    trangthai = !x.LICHSUNGHIHOCs.Any(y => y.ngaynghi == date.Value) ? "đang học" :
                                x.LICHSUNGHIHOCs.Any(y => y.ngaynghi == date.Value && y.cophep != false) ?
                                "nghỉ có phép" : "nghỉ không phép"
                }).OrderBy(x => x.tenhocsinh).ToPagedList(page, pageSize);
            ViewBag.listLop = new SelectList(db.LOPs, "idlop", "tenlop");
            var trangthais = new List<string>() { "nghỉ", "đang học" };
            ViewBag.listTrangthai = new SelectList(trangthais, "trangthai", "tentrangthai");
            return View(diemdanhs);
        }

        // POST: Lam/DaoNguocNghi/
        [ActionName("DaoNguocNghi")]
        //[ValidateAntiForgeryToken]
        public ActionResult DaoNguocNghi(int id)
        {
            var now = DateTime.Now.Date;
            var hs = db.HOCSINHs.Find(id);
            var checkNghi = db.LICHSUNGHIHOCs
                .Where(x => x.idhocsinh == id /*&& x.ngaynghi.HasValue*/
                && x.ngaynghi.Value.Year == now.Year
                && x.ngaynghi.Value.Month == now.Month
                && x.ngaynghi.Value.Day == now.Day);
            if (checkNghi.Count() < 1)
            {
                db.LICHSUNGHIHOCs.Add(new LICHSUNGHIHOC
                {
                    idhocsinh = id,
                    cophep = false,
                    idlop = hs.CHITIETLOPHOCSINHs.FirstOrDefault().idlop,
                    ngaynghi = now,
                    trangthai = "0"
                });
            }
            else
            {
                //if (string.IsNullOrEmpty(checkNghi.FirstOrDefault().trangthai))
                //{
                //    checkNghi.FirstOrDefault().trangthai = "0";
                //}
                //else
                //{
                //    checkNghi.FirstOrDefault().trangthai = null;
                //}
                var xoaLichSus = db.LICHSUNGHIHOCs.Where(x => x.idhocsinh == id && x.ngaynghi.Value.Year == now.Year
                && x.ngaynghi.Value.Month == now.Month
                && x.ngaynghi.Value.Day == now.Day);
                db.LICHSUNGHIHOCs.RemoveRange(xoaLichSus);
            }

            // dao
            //if()
            //db.LICHSUNGHIHOCs.Remove(lICHSUNGHIHOC);
            db.SaveChanges();
            return RedirectToAction("DiemDanh");
        }

        // GET: Lam/Delete/5
        public ActionResult ChapNhan(int? id)
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
            lICHSUNGHIHOC.cophep = true;
            lICHSUNGHIHOC.trangthai = "1";
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        // GET: Lam/Delete/5
        public ActionResult TuChoi(int? id)
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
            lICHSUNGHIHOC.cophep = false;
            lICHSUNGHIHOC.trangthai = "2";
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
