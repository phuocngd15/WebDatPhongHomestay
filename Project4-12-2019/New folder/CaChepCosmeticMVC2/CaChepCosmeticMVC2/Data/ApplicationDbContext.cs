using System;
using System.Collections.Generic;
using System.Text;
using CaChepCosmeticMVC2.Models.DataModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CaChepCosmeticMVC2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<CapBacThe> CapBacThes { get; set; }
        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual DbSet<ChiTieu> ChiTieus { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<MaGiamGia> MaGiamGias { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<DanhMucSanPham> DanhMucSanPhams { get; set; }
        public virtual DbSet<TheThanhVien> TheThanhViens { get; set; }
        public virtual DbSet<Thu> Thus { get; set; }
        public virtual DbSet<ThuongHieu> ThuongHieus { get; set; }
        public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ChiTietHoaDon>()
                .HasKey(e => new { e.HoaDonId, e.SanPhamId });

            #region Capbacthe

            modelBuilder.Entity<CapBacThe>().HasData(
                new CapBacThe
                {
                    CapBacTheId = 1,
                    QuyenLoi = "Giam 5% tổng hóa đơn",
                    TienToiThieu = 1000000,
                    TenCapBac = "Vip1",
                    
                },
                new CapBacThe
                {
                    CapBacTheId = 2,
                    QuyenLoi = "Giam 10% tổng hóa đơn",
                    TienToiThieu = 2000000,
                    TenCapBac = "Vip2"
                },

                new CapBacThe
                {
                    CapBacTheId = 3,
                    QuyenLoi = "Giam 15% tổng hóa đơn",
                    TienToiThieu = 5000000,
                    TenCapBac = "Vip3"
                },
                 new CapBacThe
                {
                    CapBacTheId = 4,
                    QuyenLoi = "Giam 0% tổng hóa đơn",
                    TienToiThieu = 0,
                    TenCapBac = "Thành viên mới"
                }
            );

            #endregion

            #region TheThanhVien

            modelBuilder.Entity<TheThanhVien>().HasData(
                new TheThanhVien
                {
                    TheTvienId = 1,
                    Ngaylap = new DateTime(2018, 01,15),
                    TongChiTieu = 2000000,
                    CapbacTheId = 2,
                    KhachHangId = 1
                },
                new TheThanhVien
                {
                    TheTvienId = 2,
                    Ngaylap = new DateTime(2018, 01, 28),
                    TongChiTieu = 50000,
                    CapbacTheId = 3,
                    KhachHangId = 2
                },

                new TheThanhVien
                {
                    TheTvienId = 3,
                    Ngaylap = new DateTime(2018, 02, 07),
                    TongChiTieu = 20000,
                    CapbacTheId = 3,
                }
               
            );

            #endregion

            #region KhachHang
modelBuilder.Entity<KhachHang>().HasData(
                new KhachHang
                {
                    KhachHangId = 1,
                    NgaySinh = new DateTime(1999, 01, 15),
                    TenKhachHang = "Nguyễn Duy Phước",
                    Sdt = 0937536545,
                    Email = "phuocnglt@gmail.com",
                    
                    
                },
                new KhachHang
                {
                    KhachHangId = 2,
                    NgaySinh = new DateTime(1997, 12, 28),
                    TenKhachHang = "Nguyễn T",
                    Sdt = 0937536545,
                    Email = "nglt@gmail.com"
                },

                new KhachHang
                {
                    KhachHangId = 3,
                    NgaySinh = new DateTime(1997, 02, 07),
                    TenKhachHang = "Phan Thị Ngọc Tuyền",
                    Sdt = 01626364802,
                    Email = "phantuyen@gmail.com"
                }
              
            );


            #endregion

            #region Danh Muc San Pham

            modelBuilder.Entity<DanhMucSanPham>().HasData(
                new DanhMucSanPham
                {
                    DanhMucSanPhamId = 1,
                    TenDanhMucSanPham =  "Trang Điểm"

                },
                new DanhMucSanPham
                {
                    DanhMucSanPhamId = 2,
                    TenDanhMucSanPham = "Chăm Sóc Da Mặt"

                },
                new DanhMucSanPham
                {
                    DanhMucSanPhamId = 3,
                    TenDanhMucSanPham = "Chăm Sóc Cơ Thể"

                },
                 new DanhMucSanPham
                {
                    DanhMucSanPhamId = 4,
                    TenDanhMucSanPham = "Chăm Tóc Và Da Đầu"

                }

            );

            #endregion

            #region Loai san pham

            modelBuilder.Entity<LoaiSanPham>().HasData(

            #region Trang Điểm

                new LoaiSanPham
                {
                    LoaiSanPhamId = 1,
                    TenLoaiSanPham = "Trang Điểm Mặt",
                    DanhMucSanPhamId = 1

                },
                new LoaiSanPham
                {
                    LoaiSanPhamId = 2,
                    TenLoaiSanPham = "Trang Điểm Mắt",
                    DanhMucSanPhamId = 1

                },
                new LoaiSanPham
                {
                    LoaiSanPhamId = 3,
                    TenLoaiSanPham = "Trang Điểm Môi",
                    DanhMucSanPhamId = 1

                },
                new LoaiSanPham
                {
                    LoaiSanPhamId = 4,
                    TenLoaiSanPham = "Trang Điểm",
                    DanhMucSanPhamId = 1
                },

            #endregion

            #region "Chăm Sóc Da Mặt"

            new LoaiSanPham
            {
                LoaiSanPhamId = 5,
                TenLoaiSanPham = "Xịt Khoáng",
                DanhMucSanPhamId = 2

            },
            new LoaiSanPham
            {
                LoaiSanPhamId = 6,
                TenLoaiSanPham = "Nước Hoa Hông, Toner",
                DanhMucSanPhamId = 2

            },
            new LoaiSanPham
            {
                LoaiSanPhamId = 7,
                TenLoaiSanPham = "Làm Sạch Da Mặt",
                DanhMucSanPhamId = 2

            },
            new LoaiSanPham
            {
                LoaiSanPhamId = 8,
                TenLoaiSanPham = "Sản Phẩm Trị Mụn",
                DanhMucSanPhamId = 2
            },
            #endregion

            #region "Chăm Sóc Cơ Thể"

                new LoaiSanPham
                {
                    LoaiSanPhamId = 9,
                    TenLoaiSanPham = "Sữa tắm, xà bông, muối tắm",
                    DanhMucSanPhamId = 3

                },
                new LoaiSanPham
                {
                    LoaiSanPhamId = 10,
                    TenLoaiSanPham = "Dưỡng thể",
                    DanhMucSanPhamId = 3

                },

            #endregion

            #region "Chăm Tóc Và Da Đầu"

            new LoaiSanPham
            {
                LoaiSanPhamId =11,
                TenLoaiSanPham = "Dầu Gội, Dầu Xả",
                DanhMucSanPhamId = 4

            },
            new LoaiSanPham
            {
                LoaiSanPhamId = 12,
                TenLoaiSanPham = "Dưỡng tóc, ủ tóc",
                DanhMucSanPhamId = 4

            }

                #endregion


            );

            #endregion

            #region Thuong Hieu

            modelBuilder.Entity<ThuongHieu>().HasData(
                new ThuongHieu
                {
                    ThuongHieuId = 1,
                    TenThuongHieu = "Bbia Last"
                },
                new ThuongHieu
                {
                    ThuongHieuId = 2,
                    TenThuongHieu = "Clear"
                }
                );


            #endregion

            #region SanPham
            modelBuilder.Entity<SanPham>().HasData(
                new SanPham
                {
                    SanPhamId = 1,
                    TenSanPham = "Kem tạo khối Bbia Last Contouring",
                    GiaBan = 150000,
                    ThuongHieuId = 1,
                    Hinh="1",
                    LoaiSanPhamId = 1
                },
                new SanPham
                {
                    SanPhamId = 2,
                    TenSanPham = "Che khuyết điểm Bbia Last Concealer 6.2g",
                    GiaBan = 130000,
                    Hinh = "2",
                    ThuongHieuId = 1,
                    LoaiSanPhamId = 1
                },
                new SanPham
                {
                    SanPhamId = 3,
                    TenSanPham = "Kẻ mắt nước Bbia Last Pen Eyeliner 0.6g ",
                    GiaBan = 150000,
                    Hinh = "3",
                    ThuongHieuId = 1,
                    LoaiSanPhamId = 2

                },
                new SanPham
                {
                    SanPhamId = 4,
                    TenSanPham = "Dầu Gội Sạch Gàu Clear Botanique 9 Thảo Dược.",
                    GiaBan = 170000,
                    Hinh = "4",
                    ThuongHieuId = 2,
                    LoaiSanPhamId = 11

                },
                new SanPham
                {
                    SanPhamId = 5,
                    TenSanPham = "Dầu Gội Sạch Gàu CLEAR Mát Lạnh Bạc Hà",
                    GiaBan = 169000,
                    Hinh = "5",
                    ThuongHieuId = 2,
                    LoaiSanPhamId = 11


                },
                new SanPham
                {
                    SanPhamId = 6,
                    TenSanPham = "Combo Sữa Tắm L'amont En Provence Cherry",
                    GiaBan = 150000,
                    Hinh = "6",
                    ThuongHieuId = null,
                    LoaiSanPhamId = 9,
                    

                },
                new SanPham
                {
                    SanPhamId = 7,
                    TenSanPham = "Sữa Tắm St.Ives Muối Biển 400ml",
                    GiaBan = 150000,
                    Hinh = "7",
                    ThuongHieuId = null,
                    LoaiSanPhamId = 9,


                },
                new SanPham
                {
                    SanPhamId = 8,
                    TenSanPham = "Combo 4 Vedette Dưỡng Da Ngừa Mụn Hiệu Quả",
                    Hinh = "8",
                    GiaBan = 118000,
                    ThuongHieuId = null,
                    LoaiSanPhamId = 8,


                }
            );



            #endregion

            #region Nhan Vien

            modelBuilder.Entity<NhanVien>().HasData(
                new NhanVien
                {
                    NhanVienId = 1,
                    TenNv = "Phan Thị Ngọc Tuyền",
                    Sdt = "01626364802",
                    NgaySinh = new DateTime(1999,02,25),
                    Cmnd = "281212912",
                    Luong = 100000000,
                    NgayLam = new DateTime(2019, 02, 25),
                }, 
                new NhanVien
                {

                    NhanVienId = 2,
                    TenNv = "Nguyễn Duy Phước",
                    Sdt = "0937536545",
                    NgaySinh = new DateTime(1998, 01, 15),
                    Cmnd = "281212910",
                    Luong = 200000000,
                    NgayLam = new DateTime(2019, 02, 25),

                },
                new NhanVien
                {

                    NhanVienId = 3,
                    TenNv = "Phan A",
                    Sdt = "01626364802",
                    NgaySinh = new DateTime(1997, 12, 28),
                    Cmnd = "281212982",
                    NgayLam = new DateTime(2019, 02, 25),

                }
            );

            #endregion

            #region MaGiamGia

            modelBuilder.Entity<MaGiamGia>().HasData(
                new MaGiamGia
                {
                    MaGiamGiaId="VIP1",
                    TenChuongTrinh="Ưu đãi 5% dành cho vip 1",
                    NgayBatDau=new DateTime(2015,12,28),
                    NgayKetThuc = new DateTime(2099, 12, 28),
                    DieuKienApDung = "có thẻ Vip 1"
                },
                new MaGiamGia
                {
                    MaGiamGiaId = "VIP2",
                    TenChuongTrinh = "Ưu đãi 10% dành cho vip 2",
                    NgayBatDau = new DateTime(2015, 12, 28),
                    NgayKetThuc = new DateTime(2099, 12, 28),
                    DieuKienApDung = "có thẻ Vip 2"
                },
                new MaGiamGia
                {
                    MaGiamGiaId = "VIP3",
                    TenChuongTrinh = "Ưu đãi 15% dành cho vip 3",
                    NgayBatDau = new DateTime(2015, 12, 28),
                    NgayKetThuc = new DateTime(2099, 12, 28),
                    DieuKienApDung = "có thẻ Vip 2"
                },
                new MaGiamGia
                {
                    MaGiamGiaId = "MGG001",
                    TenChuongTrinh = "Black Friday",
                    NgayBatDau = new DateTime(2019, 11, 01),
                    NgayKetThuc = new DateTime(2019, 12, 30),
                    DieuKienApDung = "Tổng hóa đơn >= 100.000đ"
                }
                );


            #endregion

            #region ChiTietHoaDon

            modelBuilder.Entity<ChiTietHoaDon>().HasData(
                new ChiTietHoaDon
                {
                    HoaDonId = 1,
                    SanPhamId = 1,
                    SoLuong = 5,
                    GiaBan = 150000,
                    ThanhTien = 750000
                },
                new ChiTietHoaDon
                {
                    HoaDonId = 1,
                    SanPhamId = 2,
                    SoLuong = 5,
                    GiaBan = 130000,
                    ThanhTien = 650000
                },
            new ChiTietHoaDon
            {
                HoaDonId = 2,
                SanPhamId = 1,
                SoLuong = 2,
                GiaBan = 150000,
                ThanhTien = 300000
            },
            new ChiTietHoaDon
            {
                HoaDonId = 2,
                SanPhamId = 2,
                SoLuong = 5,
                GiaBan = 130000,
                ThanhTien = 650000
            });

            #endregion

            #region HoaDon

            modelBuilder.Entity<HoaDon>().HasData(
                new HoaDon
                {
                    HoaDonId = 1,
                    AccoutId = null,
                    TheTvienId = 1,
                    MaGiamGiaId = "VIP2",
                    TongTien = 1260000
                },
                new HoaDon
                {
                    HoaDonId = 2,
                    AccoutId = null,
                    TheTvienId = null,
                    MaGiamGiaId = null,
                    TongTien = 950000
                });


            #endregion
        }
    }
}
