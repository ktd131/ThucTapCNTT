using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TTCNTT.DB.DTO
{
    public class LichThiDTO
    {
        public int idlichthi { get; set; }
        public DateTime? ngaythi { get; set; }

        public string giothi { get; set; }

        public int idmonhoc { get; set; }
        public string tenmonhoc { get; set; }
        public int idhocky { get; set; }
        public string tenhocky { get; set; }
        public string namhoc { get; set; }
    }
}