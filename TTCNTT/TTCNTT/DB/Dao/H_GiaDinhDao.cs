using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TTCNTT.DB.EF;

namespace TTCNTT.DB.Dao
{
    public class H_GiaDinhDao
    {
        DBContext db = null;
        public H_GiaDinhDao()
        {
            db = new DBContext();
        }
        public IEnumerable<THONGTINTRAODOICUAGIADINH> listChat()
        {
            var model = db.THONGTINTRAODOICUAGIADINHs.SqlQuery("select * from THONGTINTRAODOICUAGIADINH where id in (select top(20) id from THONGTINTRAODOICUAGIADINH order by thoigian desc) order by thoigian asc");
            return model.ToList();
        }
    }
}