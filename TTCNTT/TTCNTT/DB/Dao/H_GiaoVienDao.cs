using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TTCNTT.DB.DTO;
using TTCNTT.DB.EF;

namespace TTCNTT.DB.Dao
{
    public class H_GiaoVienDao
    {
        DBContext db =null;
        public H_GiaoVienDao()
        {
            db = new DBContext();
        }
        public IEnumerable<HOCSINH> ListHocSinh()
        {
            return db.HOCSINHs.ToList();
        }
        public IEnumerable<HOCKY> ListHocKy()
        {
            return db.HOCKies.ToList();
        }
        public IEnumerable<MONHOC> ListMonHoc()
        {
            return db.MONHOCs.ToList();
        }
        public IEnumerable<BangDiemDTO> ListDiemHocSinh(int page,int pageSize)
        {
            var model = from a in db.BANGDIEMs
                        join b in db.HOCSINHs on a.idhocsinh equals b.idhocsinh
                        join c in db.MONHOCs on a.idmonhoc equals c.idmonhoc
                        join d in db.HOCKies on a.idhocky equals d.idhocky
                        join e in db.CHITIETBANGDIEMs on a.idbangdiem equals e.idbangdiem
                        select new BangDiemDTO()
                        {
                            idbangdiem = a.idbangdiem,
                            idhocsinh = b.idhocsinh,
                            tenhocsinh = b.tenhocsinh,
                            idmonhoc=c.idmonhoc,
                            idhocky=d.idhocky,
                            tenmonhoc = c.tenmonhoc,
                            tenhocky = d.tenhocky,
                            namhoc = d.namhoc,
                            tongkethocky = a.tongkethocky,
                            ghichu = a.ghichu,
                            diem15phutlan1=e.diem15phutlan1,
                            diem15phutlan2=e.diem15phutlan2,
                            diem45phutlan1=e.diem45phutlan1,
                            diem45phutlan2=e.diem45phutlan2,
                            diemhocky=e.diemhocky
                            
                        };
            return model.OrderByDescending(x => x.idbangdiem).ToPagedList(page, pageSize); ;
        }
        public bool addBangDiem(int idmonhoc, int idhocsinh, int idhocky, double diem15phutlan1, double diem15phutlan2, double diem45phutlan1, double diem45phutlan2, double diemhocky, string tongkethocky, string ghichu)
        {

            int check = db.BANGDIEMs.Count(x => x.idmonhoc == idmonhoc&&x.idhocsinh==idhocsinh&&x.idhocky==idhocky);
            if (check < 1)
            {
                BANGDIEM bd = new BANGDIEM();
                bd.idhocsinh = idhocsinh;
                bd.idmonhoc = idmonhoc;
                bd.idhocky = idhocky;
                bd.tongkethocky = tongkethocky;
                bd.ghichu = ghichu;
                db.BANGDIEMs.Add(bd);
                db.SaveChanges();
                CHITIETBANGDIEM ct = new CHITIETBANGDIEM();
                ct.diem15phutlan1 = diem15phutlan1;
                ct.diem15phutlan2 = diem15phutlan2;
                ct.diem45phutlan1 = diem45phutlan1;
                ct.diem45phutlan2 = diem45phutlan2;
                ct.diemhocky = diemhocky;
                ct.idbangdiem = bd.idbangdiem;
                db.CHITIETBANGDIEMs.Add(ct);
                db.SaveChanges();
                return true;
            }
            return false;

        }
        public bool UpdateBangDiem(int idmonhoc, int idhocsinh, int idhocky, double diem15phutlan1, double diem15phutlan2, double diem45phutlan1, double diem45phutlan2, double diemhocky, string tongkethocky, string ghichu,int idbangdiem)
        {
            try// su ly ngoai le
            {
                var checkthaydoi = db.BANGDIEMs.Find(idbangdiem);
                if (checkthaydoi.idmonhoc == idmonhoc && checkthaydoi.idhocsinh == idhocsinh && checkthaydoi.idhocky == idhocky)
                {
                    var updatebangdiem = db.BANGDIEMs.Find(idbangdiem);
                    updatebangdiem.idmonhoc = idmonhoc;
                    updatebangdiem.idhocsinh = idhocsinh;
                    updatebangdiem.idhocky = idhocky;
                    updatebangdiem.tongkethocky = tongkethocky;
                    updatebangdiem.ghichu = ghichu;
                    db.Entry(updatebangdiem).State = EntityState.Modified;
                    db.SaveChanges();
                    var updatechitiet = db.CHITIETBANGDIEMs.Where(x => x.idbangdiem == idbangdiem).FirstOrDefault<CHITIETBANGDIEM>();
                    updatechitiet.diem15phutlan1 = diem15phutlan1;
                    updatechitiet.diem15phutlan2 = diem15phutlan2;
                    updatechitiet.diem45phutlan1 = diem45phutlan1;
                    updatechitiet.diem45phutlan2 = diem45phutlan2;
                    updatechitiet.diemhocky = diemhocky;
                    db.Entry(updatechitiet).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    int check = db.BANGDIEMs.Count(x => x.idmonhoc == idmonhoc && x.idhocsinh == idhocsinh && x.idhocky == idhocky);
                    if (check < 1)
                    {
                        var updatebangdiem = db.BANGDIEMs.Find(idbangdiem);
                        updatebangdiem.idmonhoc = idmonhoc;
                        updatebangdiem.idhocsinh = idhocsinh;
                        updatebangdiem.idhocky = idhocky;
                        updatebangdiem.tongkethocky = tongkethocky;
                        updatebangdiem.ghichu = ghichu;
                        db.Entry(updatebangdiem).State = EntityState.Modified;
                        db.SaveChanges();
                        var updatechitiet = db.CHITIETBANGDIEMs.Where(x => x.idbangdiem == idbangdiem).FirstOrDefault<CHITIETBANGDIEM>();
                        updatechitiet.diem15phutlan1 = diem15phutlan1;
                        updatechitiet.diem15phutlan2 = diem15phutlan2;
                        updatechitiet.diem45phutlan1 = diem45phutlan1;
                        updatechitiet.diem45phutlan2 = diem45phutlan2;
                        updatechitiet.diemhocky = diemhocky;
                        db.Entry(updatechitiet).State = EntityState.Modified;
                        db.SaveChanges();
                        return true;
                    }
                }
               return false;

            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}