namespace TTCNTT.DB.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LICHTHI")]
    public partial class LICHTHI
    {
        [Key]
        public int idlichthi { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaythi { get; set; }

        public TimeSpan? giothi { get; set; }

        public int? idmonhoc { get; set; }

        public int? idhocky { get; set; }

        public virtual HOCKY HOCKY { get; set; }

        public virtual MONHOC MONHOC { get; set; }

        public virtual MONHOC MONHOC1 { get; set; }
    }
}
