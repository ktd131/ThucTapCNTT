namespace TTCNTT.DB.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETTHOIKHOABIEU")]
    public partial class CHITIETTHOIKHOABIEU
    {
        public int? sotiet { get; set; }

        [Column(TypeName = "date")]
        public DateTime? thu { get; set; }

        public int? sothututiet { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idmonhoc { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idtkb { get; set; }

        public virtual MONHOC MONHOC { get; set; }

        public virtual THOIKHOABIEU THOIKHOABIEU { get; set; }
    }
}
