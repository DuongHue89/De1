namespace QuanLyNhanSu
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QLNhanSuDbContext : DbContext
    {
        public QLNhanSuDbContext()
            : base("name=QLNhanSuDbContext")
        {
        }

        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<Luong> Luongs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhongBan> PhongBans { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<ThoiGianCongTac> ThoiGianCongTacs { get; set; }
        public virtual DbSet<TrinhDoHocVan> TrinhDoHocVans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChucVu>()
                .Property(e => e.MaCV)
                .IsUnicode(false);

            modelBuilder.Entity<ChucVu>()
                .HasMany(e => e.ThoiGianCongTacs)
                .WithRequired(e => e.ChucVu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.SDTNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaPB)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaTDHV)
                .IsUnicode(false);
            /*
            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.ThoiGianCongTacs)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);
                */
            modelBuilder.Entity<PhongBan>()
                .Property(e => e.MaPB)
                .IsUnicode(false);

            modelBuilder.Entity<PhongBan>()
                .Property(e => e.SoDienThoaiPB)
                .IsUnicode(false);

            modelBuilder.Entity<ThoiGianCongTac>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<ThoiGianCongTac>()
                .Property(e => e.MaCV)
                .IsUnicode(false);

            modelBuilder.Entity<TrinhDoHocVan>()
                .Property(e => e.MaTDHV)
                .IsUnicode(false);
        }
    }
}
