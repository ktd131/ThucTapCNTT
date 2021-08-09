namespace TTCNTT.DB.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BANGDIEM")]
    public partial class BANGDIEM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BANGDIEM()
        {
            KETQUARENLUYENCHUNGs = new HashSet<KETQUARENLUYENCHUNG>();
            CHITIETBANGDIEMs = new HashSet<CHITIETBANGDIEM>();
        }

        [Key]
        public int idbangdiem { get; set; }

        [StringLength(100)]
        public string ghichu { get; set; }

        [StringLength(50)]
        public string tongkethocky { get; set; }

        public int? idmonhoc { get; set; }

        public int? idhocky { get; set; }

        public int? idhocsinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KETQUARENLUYENCHUNG> KETQUARENLUYENCHUNGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETBANGDIEM> CHITIETBANGDIEMs { get; set; }

        public virtual HOCKY HOCKY { get; set; }

        public virtual HOCSINH HOCSINH { get; set; }

        public virtual MONHOC MONHOC { get; set; }
    }
}
