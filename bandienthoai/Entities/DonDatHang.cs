namespace bandienthoai.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonDatHang")]
    public partial class DonDatHang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaDDH { get; set; }

        public DateTime NgayDat { get; set; }

        [StringLength(255)]
        public string DiaChiGiao { get; set; }

        public int MaNguoiDung { get; set; }

        public int? MaTrangThai { get; set; }

        public virtual ChiTietDonDatHang ChiTietDonDatHang { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }

        public virtual TrangThai TrangThai { get; set; }
    }
}
