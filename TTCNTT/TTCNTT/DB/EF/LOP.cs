namespace TTCNTT.DB.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOP")]
    public partial class LOP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOP()
        {
            CHITIETLOPHOCSINHs = new HashSet<CHITIETLOPHOCSINH>();
            LICHSUNGHIHOCs = new HashSet<LICHSUNGHIHOC>();
        }

        [Key]
        public int idlop { get; set; }

        [StringLength(100)]
        public string tenlop { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETLOPHOCSINH> CHITIETLOPHOCSINHs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LICHSUNGHIHOC> LICHSUNGHIHOCs { get; set; }
    }
}
