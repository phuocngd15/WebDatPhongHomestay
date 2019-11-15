using System;
using BlazorApp10.Shared.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlazorApp10.Server.Models
{
    public partial class QLCuaHangMyPhamContext : DbContext
    {
        public QLCuaHangMyPhamContext()
        {
        }

        public QLCuaHangMyPhamContext(DbContextOptions<QLCuaHangMyPhamContext> options)
            : base(options)
        {
        }

        public  DbSet<Accout> Accout { get; set; }
        public  DbSet<CapBacThe> CapBacThe { get; set; }
        public  DbSet<ChiTietHoaDon> ChiTietHoaDon { get; set; }
        public  DbSet<ChiTieu> ChiTieu { get; set; }
        public  DbSet<CongDung> CongDung { get; set; }
        public  DbSet<HoaDon> HoaDon { get; set; }
        public  DbSet<KhachHang> KhachHang { get; set; }
        public  DbSet<MaGiamGia> MaGiamGia { get; set; }
        public  DbSet<NhanVien> NhanVien { get; set; }
        public  DbSet<NhomCongDung> NhomCongDung { get; set; }
        public  DbSet<SanPham> SanPham { get; set; }
        public  DbSet<TheThanhVien> TheThanhVien { get; set; }
        public  DbSet<Thu> Thu { get; set; }
        public  DbSet<ThuongHieu> ThuongHieu { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=JACKIELEIV\\SQLEXPRESS;Database=QLCuaHangMyPham4;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accout>(entity =>
            {
                entity.Property(e => e.AccoutId).HasColumnName("AccoutID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Quyen)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CapBacThe>(entity =>
            {
                entity.Property(e => e.CapBacTheId).HasColumnName("CapBacTheID");

                entity.Property(e => e.QuyenLoi).HasColumnType("ntext");

                entity.Property(e => e.TenCapBac)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TienToiThieu).HasColumnType("money");
            });

            modelBuilder.Entity<ChiTietHoaDon>(entity =>
            {
                entity.HasKey(e => new { e.HoaDonId, e.SanPhamId });

                entity.Property(e => e.HoaDonId).HasColumnName("HoaDonID");

                entity.Property(e => e.SanPhamId).HasColumnName("SanPhamID");

                entity.Property(e => e.GiaBan).HasColumnType("money");

                entity.Property(e => e.ThanhTien).HasColumnType("money");

                entity.HasOne(d => d.HoaDon)
                    .WithMany(p => p.ChiTietHoaDon)
                    .HasForeignKey(d => d.HoaDonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietHoaDon_HoaDon");

                entity.HasOne(d => d.SanPham)
                    .WithMany(p => p.ChiTietHoaDon)
                    .HasForeignKey(d => d.SanPhamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietHoaDon_SanPham");
            });

            modelBuilder.Entity<ChiTieu>(entity =>
            {
                entity.Property(e => e.ChiTieuId).HasColumnName("ChiTieuID");

                entity.Property(e => e.SoTien).HasColumnType("money");

                entity.Property(e => e.Ten)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ThoiGian).HasColumnType("datetime");
            });

            modelBuilder.Entity<CongDung>(entity =>
            {
                entity.Property(e => e.CongDungId).HasColumnName("CongDungID");

                entity.Property(e => e.NhomCongDungId).HasColumnName("NhomCongDungID");

                entity.Property(e => e.TenCongDung)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.NhomCongDung)
                    .WithMany(p => p.CongDung)
                    .HasForeignKey(d => d.NhomCongDungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CongDung_NhomCongDung");
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.Property(e => e.HoaDonId).HasColumnName("HoaDonID");

                entity.Property(e => e.AccoutId).HasColumnName("AccoutID");

                entity.Property(e => e.MaGiamGia).HasMaxLength(50);

                entity.Property(e => e.NgayLap).HasColumnType("datetime");

                entity.Property(e => e.TheTvienId).HasColumnName("TheTVienID");

                entity.Property(e => e.TongTien).HasColumnType("money");

                entity.HasOne(d => d.Accout)
                    .WithMany(p => p.HoaDon)
                    .HasForeignKey(d => d.AccoutId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HoaDon_Accout");

                entity.HasOne(d => d.MaGiamGiaNavigation)
                    .WithMany(p => p.HoaDon)
                    .HasForeignKey(d => d.MaGiamGia)
                    .HasConstraintName("FK_HoaDon_MaGiamGia");

                entity.HasOne(d => d.TheTvien)
                    .WithMany(p => p.HoaDon)
                    .HasForeignKey(d => d.TheTvienId)
                    .HasConstraintName("FK_HoaDon_TheThanhVien");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.Property(e => e.KhachHangId).HasColumnName("KhachHangID");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.NgaySinh).HasColumnType("datetime");

                entity.Property(e => e.Sdt).HasColumnName("SDT");

                entity.Property(e => e.TenKhachHang)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TheTvienId).HasColumnName("TheTVienID");

                entity.HasOne(d => d.TheTvien)
                    .WithMany(p => p.KhachHang)
                    .HasForeignKey(d => d.TheTvienId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KhachHang_TheThanhVien");
            });

            modelBuilder.Entity<MaGiamGia>(entity =>
            {
                entity.HasKey(e => e.MaGiamGia1);

                entity.Property(e => e.MaGiamGia1)
                    .HasColumnName("MaGiamGia")
                    .HasMaxLength(50);

                entity.Property(e => e.DieuKienApDung).HasColumnType("ntext");

                entity.Property(e => e.NgayBatDau).HasColumnType("datetime");

                entity.Property(e => e.NgayKetThuc).HasColumnType("datetime");

                entity.Property(e => e.TenChuongTrinh).HasMaxLength(50);
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.Idnv);

                entity.Property(e => e.Idnv).HasColumnName("IDNV");

                entity.Property(e => e.AccoutId).HasColumnName("AccoutID");

                entity.Property(e => e.Cmnd).HasColumnName("CMND");

                entity.Property(e => e.Luong).HasColumnType("money");

                entity.Property(e => e.NgayLam).HasColumnType("datetime");

                entity.Property(e => e.NgaySinh).HasColumnType("datetime");

                entity.Property(e => e.Sdt).HasColumnName("SDT");

                entity.Property(e => e.TenNv)
                    .IsRequired()
                    .HasColumnName("TenNV")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Accout)
                    .WithMany(p => p.NhanVien)
                    .HasForeignKey(d => d.AccoutId)
                    .HasConstraintName("FK_NhanVien_Accout");
            });

            modelBuilder.Entity<NhomCongDung>(entity =>
            {
                entity.Property(e => e.NhomCongDungId).HasColumnName("NhomCongDungID");

                entity.Property(e => e.TenNhomCongDung)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.Property(e => e.SanPhamId).HasColumnName("SanPhamID");

                entity.Property(e => e.CongDungId).HasColumnName("CongDungID");

                entity.Property(e => e.Dvt)
                    .HasColumnName("DVT")
                    .HasMaxLength(50);

                entity.Property(e => e.GiaBan).HasColumnType("money");

                entity.Property(e => e.GiaNhap).HasColumnType("money");

                entity.Property(e => e.MoTa).HasColumnType("ntext");

                entity.Property(e => e.TenSanPham)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ThuongHieuId).HasColumnName("ThuongHieuID");

                entity.HasOne(d => d.CongDung)
                    .WithMany(p => p.SanPham)
                    .HasForeignKey(d => d.CongDungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SanPham_CongDung");

                entity.HasOne(d => d.ThuongHieu)
                    .WithMany(p => p.SanPham)
                    .HasForeignKey(d => d.ThuongHieuId)
                    .HasConstraintName("FK_SanPham_ThuongHieu");
            });

            modelBuilder.Entity<TheThanhVien>(entity =>
            {
                entity.HasKey(e => e.TheTvienId);

                entity.Property(e => e.TheTvienId).HasColumnName("TheTVienID");

                entity.Property(e => e.CapbacTheId).HasColumnName("CapbacTheID");

                entity.Property(e => e.Ngaylap).HasColumnType("datetime");

                entity.Property(e => e.TongChiTieu).HasColumnType("money");

                entity.HasOne(d => d.CapbacThe)
                    .WithMany(p => p.TheThanhVien)
                    .HasForeignKey(d => d.CapbacTheId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TheThanhVien_CapBacThe");
            });

            modelBuilder.Entity<Thu>(entity =>
            {
                entity.Property(e => e.ThuId).HasColumnName("ThuID");

                entity.Property(e => e.SoTien).HasColumnType("money");

                entity.Property(e => e.ThoiGian).HasColumnType("datetime");
            });

            modelBuilder.Entity<ThuongHieu>(entity =>
            {
                entity.Property(e => e.ThuongHieuId).HasColumnName("ThuongHieuID");

                entity.Property(e => e.TenThuongHieu)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
