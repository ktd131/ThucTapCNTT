namespace TTCNTT.DB.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOCSINH")]
    public partial class HOCSINH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOCSINH()
        {
            BANGDIEMs = new HashSet<BANGDIEM>();
            CHITIETLOPHOCSINHs = new HashSet<CHITIETLOPHOCSINH>();
            DANHGIAKETQUAs = new HashSet<DANHGIAKETQUA>();
            LICHSUNGHIHOCs = new HashSet<LICHSUNGHIHOC>();
        }

        [Key]
        public int idhocsinh { get; set; }

        [StringLength(100)]
        public string tenhocsinh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? namsinh { get; set; }

        public int? dienthoai { get; set; }

        [StringLength(50)]
        public string diachi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BANGDIEM> BANGDIEMs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETLOPHOCSINH> CHITIETLOPHOCSINHs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DANHGIAKETQUA> DANHGIAKETQUAs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LICHSUNGHIHOC> LICHSUNGHIHOCs { get; set; }
    }
}
