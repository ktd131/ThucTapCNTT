namespace TTCNTT.DB.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TINTUC")]
    public partial class TINTUC
    {
        [Key]
        public int idtintuc { get; set; }

        [StringLength(100)]
        public string tieudetintuc { get; set; }

        public DateTime? ngaythem { get; set; }

        [StringLength(500)]
        public string noidung { get; set; }
    }
}
