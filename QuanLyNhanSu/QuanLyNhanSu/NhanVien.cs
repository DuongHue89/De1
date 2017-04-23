namespace QuanLyNhanSu
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            //ThoiGianCongTacs = new HashSet<ThoiGianCongTac>();
        }

        [Key]
        [StringLength(10)]
        public string MaNV { get; set; }

        [StringLength(50)]
        public string HoTen { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(50)]
        public string QueQuan { get; set; }

        [StringLength(20)]
        public string GioiTinh { get; set; }

        [StringLength(100)]
        public string DanToc { get; set; }

        [StringLength(20)]
        public string SDTNhanVien { get; set; }

        [StringLength(10)]
        public string MaPB { get; set; }

        [StringLength(10)]
        public string MaTDHV { get; set; }

        public int? BacLuong { get; set; }

        //public virtual Luong Luong { get; set; }

        //public virtual PhongBan PhongBan { get; set; }

        //public virtual TrinhDoHocVan TrinhDoHocVan { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<ThoiGianCongTac> ThoiGianCongTacs { get; set; }
    }
}
