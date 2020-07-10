namespace bandienthoai.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("NguoiDung")]
    public partial class NguoiDung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NguoiDung()
        {
            DonDatHangs = new HashSet<DonDatHang>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaNguoiDung { get; set; }

        [StringLength(100)]
        [DisplayName("Họ tên")]
        public string HoTen { get; set; }

        [StringLength(100)]
        [DisplayName("Tài khoản")]
        public string TaiKhoan { get; set; }

        [StringLength(20)]
        public string MatKhau { get; set; }

        [StringLength(255)]
        [DisplayName("Địa chỉ")]
        public string DiaChi { get; set; }

        [StringLength(255)]
        [DisplayName("Email")]
        public string Email { get; set; }

        [StringLength(10)]
        [DisplayName("Số điện thoại")]
        public string SDT { get; set; }

        public int? MaLND { get; set; }

        [StringLength(15)]
        [DisplayName("Giới tính")]
        public string GioiTinh { get; set; }

        [StringLength(255)]
        public string HinhAnh { get; set; }

        [DisplayName("Ngày sinh")]
        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "01-01-1960", "01-01-2015",
            ErrorMessage = "Ngày sinh phải từ 01-01-1960 đến 01-01-2015")]
        public DateTime NgaySinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonDatHang> DonDatHangs { get; set; }

        public virtual LoaiNguoiDung LoaiNguoiDung { get; set; }

        [NotMapped]
        [DisplayName("Hình ảnh")]
        public HttpPostedFileBase UploadHinhAnh { get; set; }
    }
}
