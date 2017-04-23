namespace QuanLyNhanSu
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThoiGianCongTac")]
    public partial class ThoiGianCongTac
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MaNV { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaCV { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayNhanChuc { get; set; }

        public virtual ChucVu ChucVu { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
