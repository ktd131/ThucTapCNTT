namespace TTCNTT.DB.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NGUOIDUNG")]
    public partial class NGUOIDUNG
    {
        [Key]
        public int idnguoidung { get; set; }

        [StringLength(100)]
        public string ten { get; set; }

        [StringLength(50)]
        public string tendangnhap { get; set; }

        [StringLength(50)]
        public string matkhau { get; set; }

        public int? dienthoai { get; set; }

        public int? idnhomnguoidung { get; set; }

        public virtual NHOMNGUOIDUNG NHOMNGUOIDUNG { get; set; }
    }
}
