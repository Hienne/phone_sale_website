namespace bandienthoai.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            ChiTietDonDatHangs = new HashSet<ChiTietDonDatHang>();
            ChiTietPhieuNhaps = new HashSet<ChiTietPhieuNhap>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaSP { get; set; }

        [StringLength(255)]
        [DisplayName("Tên sản phẩm")]
        [Required(ErrorMessage = "Chưa nhập tên sản phẩm")]
        public string TenSP { get; set; }

        [StringLength(255)]
        [DisplayName("Mô tả")]
        [Required(ErrorMessage = "Chưa nhập mô tả")]
        [DataType(DataType.MultilineText)]
        public string MoTa { get; set; }

        public int SLTon { get; set; }

        [DisplayName("Mã nhà sản xuất")]
        public int MaNSX { get; set; }

        public int SoLanMua { get; set; }

        [StringLength(255)]
        public string HinhAnh { get; set; }

        [DisplayName("Mã nhà cung cấp")]
        public int MaNCC { get; set; }

        [DisplayName("Đơn giá")]
        [Required(ErrorMessage = "Chưa nhập đơn giá")]
        public int DonGia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonDatHang> ChiTietDonDatHangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }

        public virtual NhaCungCap NhaCungCap { get; set; }

        public virtual NhaSanXuat NhaSanXuat { get; set; }

        [NotMapped]
        [DisplayName("Hình ảnh")]
        [Required(ErrorMessage = "Chưa chọn hình ảnh")]
        public HttpPostedFileBase UploadHinhAnh { get; set; }
    }
}
