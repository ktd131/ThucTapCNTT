namespace TTCNTT.DB.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETBANGDIEM")]
    public partial class CHITIETBANGDIEM
    {
        [Key]
        public int idchitietbangdiem { get; set; }

        public double? diem15phutlan1 { get; set; }

        public double? diem15phutlan2 { get; set; }

        public double? diem45phutlan1 { get; set; }

        public double? diem45phutlan2 { get; set; }

        public double? diemhocky { get; set; }

        public int? idbangdiem { get; set; }

        public virtual BANGDIEM BANGDIEM { get; set; }
    }
}
