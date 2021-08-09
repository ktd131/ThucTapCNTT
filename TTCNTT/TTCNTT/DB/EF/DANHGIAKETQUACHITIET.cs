namespace TTCNTT.DB.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DANHGIAKETQUACHITIET")]
    public partial class DANHGIAKETQUACHITIET
    {
        [Key]
        public int idchitiet { get; set; }

        public DateTime? ngaydanhgia { get; set; }

        [StringLength(100)]
        public string chitiet { get; set; }

        public int? iddanhgia { get; set; }

        public virtual DANHGIAKETQUA DANHGIAKETQUA { get; set; }
    }
}
