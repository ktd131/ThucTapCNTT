namespace TTCNTT.DB.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THONGTINPHANHOI")]
    public partial class THONGTINPHANHOI
    {
        public int id { get; set; }

        [StringLength(100)]
        public string noidung { get; set; }

        public DateTime? thoigian { get; set; }

        public int? idnguoidung { get; set; }
    }
}
