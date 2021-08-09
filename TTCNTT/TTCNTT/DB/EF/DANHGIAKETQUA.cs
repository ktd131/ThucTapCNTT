namespace TTCNTT.DB.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DANHGIAKETQUA")]
    public partial class DANHGIAKETQUA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DANHGIAKETQUA()
        {
            DANHGIAKETQUACHITIETs = new HashSet<DANHGIAKETQUACHITIET>();
            KETQUARENLUYENCHUNGs = new HashSet<KETQUARENLUYENCHUNG>();
        }

        [Key]
        public int iddanhgia { get; set; }

        [StringLength(100)]
        public string ketqua { get; set; }

        public int? idhocsinh { get; set; }

        public int? idhocky { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DANHGIAKETQUACHITIET> DANHGIAKETQUACHITIETs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KETQUARENLUYENCHUNG> KETQUARENLUYENCHUNGs { get; set; }

        public virtual HOCKY HOCKY { get; set; }

        public virtual HOCSINH HOCSINH { get; set; }
    }
}
