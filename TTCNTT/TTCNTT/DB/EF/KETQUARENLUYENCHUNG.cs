namespace TTCNTT.DB.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KETQUARENLUYENCHUNG")]
    public partial class KETQUARENLUYENCHUNG
    {
        [Key]
        public int idkethochoctap { get; set; }

        [StringLength(100)]
        public string ketqua { get; set; }

        [StringLength(100)]
        public string ghichu { get; set; }

        public int? idbangdiem { get; set; }

        public int? iddanhgia { get; set; }

        public virtual BANGDIEM BANGDIEM { get; set; }

        public virtual DANHGIAKETQUA DANHGIAKETQUA { get; set; }
    }
}
