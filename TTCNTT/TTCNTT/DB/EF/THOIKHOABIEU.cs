namespace TTCNTT.DB.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THOIKHOABIEU")]
    public partial class THOIKHOABIEU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THOIKHOABIEU()
        {
            CHITIETTHOIKHOABIEUx = new HashSet<CHITIETTHOIKHOABIEU>();
        }

        [Key]
        public int idtkb { get; set; }

        public TimeSpan? thoigianbatdau { get; set; }

        public TimeSpan? thoigianketthuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETTHOIKHOABIEU> CHITIETTHOIKHOABIEUx { get; set; }
    }
}
