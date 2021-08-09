namespace TTCNTT.DB.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LICHSUNGHIHOC")]
    public partial class LICHSUNGHIHOC
    {
        [Key]
        public int idlichsunghihoc { get; set; }

        [StringLength(100)]
        public string lydo { get; set; }

        [StringLength(50)]
        public string trangthai { get; set; }

        public bool? cophep { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaynghi { get; set; }

        public int? idhocsinh { get; set; }

        public int? idlop { get; set; }

        public virtual HOCSINH HOCSINH { get; set; }

        public virtual LOP LOP { get; set; }
    }
}
