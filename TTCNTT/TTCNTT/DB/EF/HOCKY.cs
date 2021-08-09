namespace TTCNTT.DB.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOCKY")]
    public partial class HOCKY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOCKY()
        {
            BANGDIEMs = new HashSet<BANGDIEM>();
            DANHGIAKETQUAs = new HashSet<DANHGIAKETQUA>();
            LICHTHIs = new HashSet<LICHTHI>();
        }

        [Key]
        public int idhocky { get; set; }

        [StringLength(100)]
        public string tenhocky { get; set; }

        [StringLength(50)]
        public string namhoc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BANGDIEM> BANGDIEMs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DANHGIAKETQUA> DANHGIAKETQUAs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LICHTHI> LICHTHIs { get; set; }
    }
}
