namespace WebBanHang.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietDatHang")]
    public partial class ChiTietDatHang
    {
        [Key]
        [StringLength(10)]
        public string SoHoaDon { get; set; }

        [StringLength(10)]
        public string MaSanPham { get; set; }

        [StringLength(10)]
        public string MaKhachHang { get; set; }

        public int? SoLuong { get; set; }

        public int? DonGia { get; set; }

        public int? ThanhTien { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NgayDatHang { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NgayGiaoHang { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
