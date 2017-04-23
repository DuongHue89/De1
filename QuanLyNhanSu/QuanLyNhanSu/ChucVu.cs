namespace QuanLyNhanSu
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChucVu")]
    public partial class ChucVu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChucVu()
        {
            ThoiGianCongTacs = new HashSet<ThoiGianCongTac>();
        }

        [Key]
        [StringLength(10)]
        public string MaCV { get; set; }

        [StringLength(50)]
        public string TenCV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThoiGianCongTac> ThoiGianCongTacs { get; set; }
    }
}
