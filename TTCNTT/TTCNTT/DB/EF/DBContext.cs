namespace TTCNTT.DB.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }

        public virtual DbSet<BANGDIEM> BANGDIEMs { get; set; }
        public virtual DbSet<CHITIETBANGDIEM> CHITIETBANGDIEMs { get; set; }
        public virtual DbSet<CHITIETLOPHOCSINH> CHITIETLOPHOCSINHs { get; set; }
        public virtual DbSet<CHITIETTHOIKHOABIEU> CHITIETTHOIKHOABIEUx { get; set; }
        public virtual DbSet<DANHGIAKETQUA> DANHGIAKETQUAs { get; set; }
        public virtual DbSet<DANHGIAKETQUACHITIET> DANHGIAKETQUACHITIETs { get; set; }
        public virtual DbSet<HOCKY> HOCKies { get; set; }
        public virtual DbSet<HOCSINH> HOCSINHs { get; set; }
        public virtual DbSet<KETQUARENLUYENCHUNG> KETQUARENLUYENCHUNGs { get; set; }
        public virtual DbSet<LICHSUNGHIHOC> LICHSUNGHIHOCs { get; set; }
        public virtual DbSet<LICHTHI> LICHTHIs { get; set; }
        public virtual DbSet<LOP> LOPs { get; set; }
        public virtual DbSet<MONHOC> MONHOCs { get; set; }
        public virtual DbSet<NGUOIDUNG> NGUOIDUNGs { get; set; }
        public virtual DbSet<NHOMNGUOIDUNG> NHOMNGUOIDUNGs { get; set; }
        public virtual DbSet<QUYEN> QUYENs { get; set; }
        public virtual DbSet<THOIKHOABIEU> THOIKHOABIEUx { get; set; }
        public virtual DbSet<THONGTINPHANHOI> THONGTINPHANHOIs { get; set; }
        public virtual DbSet<THONGTINTRAODOICUAGIADINH> THONGTINTRAODOICUAGIADINHs { get; set; }
        public virtual DbSet<TINTUC> TINTUCs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HOCSINH>()
                .HasMany(e => e.CHITIETLOPHOCSINHs)
                .WithRequired(e => e.HOCSINH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOP>()
                .HasMany(e => e.CHITIETLOPHOCSINHs)
                .WithRequired(e => e.LOP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MONHOC>()
                .HasMany(e => e.CHITIETTHOIKHOABIEUx)
                .WithRequired(e => e.MONHOC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MONHOC>()
                .HasMany(e => e.LICHTHIs)
                .WithOptional(e => e.MONHOC)
                .HasForeignKey(e => e.idmonhoc);

            modelBuilder.Entity<MONHOC>()
                .HasMany(e => e.LICHTHIs1)
                .WithOptional(e => e.MONHOC1)
                .HasForeignKey(e => e.idmonhoc);

            modelBuilder.Entity<THOIKHOABIEU>()
                .HasMany(e => e.CHITIETTHOIKHOABIEUx)
                .WithRequired(e => e.THOIKHOABIEU)
                .WillCascadeOnDelete(false);
        }
    }
}
