namespace WebBanHang.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WebBanHangDbContext : DbContext
    {
        public WebBanHangDbContext()
            : base("name=WebBanHangDbContext")
        {
        }

        public virtual DbSet<ChatLieu> ChatLieux { get; set; }
        public virtual DbSet<ChiTietDatHang> ChiTietDatHangs { get; set; }
        public virtual DbSet<DoiTuong> DoiTuongs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<KichCo> KichCoes { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<NhaSanXuat> NhaSanXuats { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<TheLoai> TheLoais { get; set; }
        public virtual DbSet<USER> USERS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChatLieu>()
                .Property(e => e.MaChatLieu)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietDatHang>()
                .Property(e => e.SoHoaDon)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietDatHang>()
                .Property(e => e.MaSanPham)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietDatHang>()
                .Property(e => e.MaKhachHang)
                .IsUnicode(false);

            modelBuilder.Entity<DoiTuong>()
                .Property(e => e.MaDoiTuong)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.MaKhachHang)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.DienThoaiKhach)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.TenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<KichCo>()
                .Property(e => e.MaKichCo)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.DienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<NhaSanXuat>()
                .Property(e => e.MaNhaSanXuat)
                .IsUnicode(false);

            modelBuilder.Entity<NhaSanXuat>()
                .Property(e => e.DienThoaiNhaSanXuat)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.MaSanPham)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.MaDoiTuong)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.MaTheLoai)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.MaKichCo)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.MaChatLieu)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.MaNhaSanXuat)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.HinhMinhHoa)
                .IsUnicode(false);

            modelBuilder.Entity<TheLoai>()
                .Property(e => e.MaTheLoai)
                .IsUnicode(false);
        }
    }
}
