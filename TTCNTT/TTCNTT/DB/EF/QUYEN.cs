namespace TTCNTT.DB.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QUYEN")]
    public partial class QUYEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QUYEN()
        {
            NHOMNGUOIDUNGs = new HashSet<NHOMNGUOIDUNG>();
        }

        [Key]
        public int idquyen { get; set; }

        [StringLength(100)]
        public string tenquyen { get; set; }

        [StringLength(50)]
        public string ghichu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NHOMNGUOIDUNG> NHOMNGUOIDUNGs { get; set; }
    }
}
