namespace TTCNTT.DB.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MONHOC")]
    public partial class MONHOC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MONHOC()
        {
            BANGDIEMs = new HashSet<BANGDIEM>();
            CHITIETTHOIKHOABIEUx = new HashSet<CHITIETTHOIKHOABIEU>();
            LICHTHIs = new HashSet<LICHTHI>();
            LICHTHIs1 = new HashSet<LICHTHI>();
        }

        [Key]
        public int idmonhoc { get; set; }

        [StringLength(100)]
        public string tenmonhoc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BANGDIEM> BANGDIEMs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETTHOIKHOABIEU> CHITIETTHOIKHOABIEUx { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LICHTHI> LICHTHIs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LICHTHI> LICHTHIs1 { get; set; }
    }
}
