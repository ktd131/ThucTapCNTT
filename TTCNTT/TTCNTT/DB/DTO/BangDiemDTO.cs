using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TTCNTT.DB.DTO
{
    public class BangDiemDTO
    {
        public int idbangdiem { get; set; }
        public int idhocsinh { get; set; }
        public string tenhocsinh { get; set; }
        public int idmonhoc { get; set; }
        public string tenmonhoc { get; set; }
        public int idhocky { get; set; }
        public string tenhocky { get; set; }
        public string namhoc { get; set; }
        public string tongkethocky { get; set; }
        public string ghichu { get; set; }
        public double? diem15phutlan1 { get; set; }

        public double? diem15phutlan2 { get; set; }

        public double? diem45phutlan1 { get; set; }

        public double? diem45phutlan2 { get; set; }

        public double? diemhocky { get; set; }

    }
}