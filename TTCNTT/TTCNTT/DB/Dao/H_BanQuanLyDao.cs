using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TTCNTT.DB.DTO;
using TTCNTT.DB.EF;

namespace TTCNTT.DB.Dao
{
    public class H_BanQuanLyDao
    {
        DBContext db = null;
        public H_BanQuanLyDao()
        {
            db = new DBContext();
        }

        public IEnumerable<HOCKY> ListHocKy()
        {
            return db.HOCKies.ToList();
        }
        public IEnumerable<MONHOC> ListMonHoc()
        {
            return db.MONHOCs.ToList();
        }
        public IEnumerable<LichThiDTO> ListLichThi()
        {
            var model = from a in db.LICHTHIs
                        join b in db.MONHOCs on a.idmonhoc equals b.idmonhoc
                        join c in db.HOCKies on a.idhocky equals c.idhocky
                        select new LichThiDTO()
                        {
                            idlichthi = a.idlichthi,
                            ngaythi = a.ngaythi,
                            giothi = a.giothi,
                            idmonhoc = b.idmonhoc,
                            tenmonhoc = b.tenmonhoc,
                            idhocky = c.idhocky,
                            tenhocky = c.tenhocky,
                            namhoc = c.namhoc

                        };
            return model.ToList();
        }
        public bool addLichThi(LICHTHI lt)
        {

            int check = db.BANGDIEMs.Count(x => x.idmonhoc == lt.idlichthi && x.idhocky == lt.idlichthi);
            if (check < 1)
            {
                db.LICHTHIs.Add(lt);
                db.SaveChanges();
                return true;
            }
            return false;

        }
        public bool UpdateLichThi(LICHTHI lt, int idlichthi)
        {
            try// su ly ngoai le
            {
                var checkthaydoi = db.LICHTHIs.Find(idlichthi);
                if (checkthaydoi.idmonhoc == lt.idmonhoc && checkthaydoi.idhocky == lt.idhocky)
                {
                    var update = db.LICHTHIs.Find(idlichthi);
                    update.idmonhoc = lt.idmonhoc;
                    update.idhocky = lt.idhocky;
                    update.ngaythi = lt.ngaythi;
                    update.giothi = lt.giothi;
                    db.Entry(update).State = EntityState.Modified;
                    db.SaveChanges();

                    return true;
                }
                else
                {
                    int check = db.LICHTHIs.Count(x => x.idmonhoc == lt.idmonhoc && x.idhocky == lt.idhocky);
                    if (check < 1)
                    {
                        var update = db.LICHTHIs.Find(idlichthi);
                        update.idmonhoc = lt.idmonhoc;
                        update.idhocky = lt.idhocky;
                        update.ngaythi = lt.ngaythi;
                        update.giothi = lt.giothi;
                        db.Entry(update).State = EntityState.Modified;
                        db.SaveChanges();

                        return true;
                    }
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool DelLichThi(int idlichthi)
        {
            try// su ly ngoai le
            {
                var delete = db.LICHTHIs.Find(idlichthi);
                db.LICHTHIs.Remove(delete);
                db.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}