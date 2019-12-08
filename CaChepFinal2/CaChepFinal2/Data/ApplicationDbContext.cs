using System;
using System.Collections.Generic;
using System.Text;
using CaChepFinal2.Data.DataModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CaChepFinal2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ChiTietDatPhong>(entity =>
            {
                entity.HasKey(e => new { e.DatPhongId, e.PhongId,e.ThoiGian });

            });

            modelBuilder.Entity<ChiTietDichVuDatPhong>(entity =>
            {
                entity.HasKey(e => new { e.DatPhongId, e.DichVuId });

            });

            modelBuilder.Entity<ChuongTrinh>(entity =>
            {
                entity.Property(e => e.ChuongTrinhName).IsRequired();
            });


            modelBuilder.Entity<DichVu>(entity =>
            {
                entity.Property(e => e.DichVuName).IsRequired();

            });

            modelBuilder.Entity<HinhPhong>(entity =>
            {

                entity.HasOne(d => d.Phong)
                    .WithMany(p => p.HinhPhong)
                    .HasForeignKey(d => d.PhongId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HinhPhong_Phongs");
            });

            modelBuilder.Entity<LoaiDichVu>(entity =>
            {

                entity.Property(e => e.LoaiDichVuName).IsRequired();
            });

            modelBuilder.Entity<LoaiPhong>(entity =>
            {

                entity.Property(e => e.LoaiPhongName).IsRequired();
            });

            modelBuilder.Entity<Phong>(entity =>
            {

                entity.Property(e => e.PhongName).IsRequired();

                entity.HasOne(d => d.ChuongTrinh)
                    .WithMany(p => p.Phongs)
                    .HasForeignKey(d => d.ChuongTrinhId)
                    .HasConstraintName("FK_Phongs_ChuongTrinh");

                entity.HasOne(d => d.LoaiPhong)
                    .WithMany(p => p.Phongs)
                    .HasForeignKey(d => d.LoaiPhongId)
                    .HasConstraintName("FK_Phongs_LoaiPhongs");
            });

            modelBuilder.Entity<TrangThai>(entity =>
            {
                entity.Property(e => e.TrangThaiName).IsRequired();
            });
            modelBuilder.Entity<LoaiDichVu>().HasData(
                new LoaiDichVu
                {
                    Id = 1,
                    LoaiDichVuName = "Thuc An",
                    Description = "notthing",
                },
                new LoaiDichVu
                {
                    Id = 2,
                    LoaiDichVuName = "Nuoc Uong",
                    Description = "notthing",
                }
            );
            modelBuilder.Entity<DichVu>().HasData(
                new DichVu
                {
                    Id = 1,
                    DichVuName = "NuocTangLuc",
                    LoaiDvid = 1,
                    ShortDescription = null,
                    ImageUrl = null,
                    InStock = 100,
                    Price = 15000,

                },
                new DichVu
                {
                    Id = 2,
                    DichVuName = "NuocSuoi",
                    LoaiDvid = 1,
                    ShortDescription = null,
                    ImageUrl = null,
                    InStock = 100,
                    Price = 15000,

                }
            );
            modelBuilder.Entity<ChuongTrinh>().HasData(
                new ChuongTrinh
                {
                    Id = 1,
                    ChuongTrinhName = "notthing",
                    IsTang = false,
                    TiLeThayDoiGia = 0
                },
            new ChuongTrinh
                {
                    Id = 2,
                    ChuongTrinhName = "Lễ Tình Nhân",
                    IsTang = true,
                    TiLeThayDoiGia = 10
                }
            );
            modelBuilder.Entity<LoaiPhong>().HasData(
                new LoaiPhong
                {
                    Id = 1,
                    LoaiPhongName = "Phong Don",
                    
                },
                new LoaiPhong
                {
                    Id = 2,
                    LoaiPhongName = "Phong Doi",

                }
            );
            modelBuilder.Entity<Phong>().HasData(
                new Phong
                {
                    Id = 1,
                    PhongName = "A101",
                    LoaiPhongId = 1,
                    Price = 150000,
                    ShortDescription = "notthing",
                    ChuongTrinhId = 1,

                },
                new Phong
                {
                    Id = 2,
                    PhongName = "A102",
                    LoaiPhongId = 1,
                    Price = 150000,
                    ShortDescription = "notthing",
                    ChuongTrinhId = 1,
                },
                new Phong
                {
                    Id = 3,
                    PhongName = "A103",
                    LoaiPhongId = 2,
                    Price = 150000,
                    ShortDescription = "notthing",
                    ChuongTrinhId = 1,
                },
                new Phong
                {
                    Id = 4,
                    PhongName = "A104",
                    LoaiPhongId = 2,
                    ShortDescription = "notthing",
                    ChuongTrinhId = 1,
                },
                new Phong
                {
                    Id = 5,
                    PhongName = "A105",
                    LoaiPhongId = 1,
                    Price = 150000,
                    ShortDescription = "notthing",
                    ChuongTrinhId = 1,
                },
                new Phong
                {
                    Id = 6,
                    PhongName = "A106",
                    LoaiPhongId = 2,
                    Price = 150000,
                    ShortDescription = "notthing",
                    ChuongTrinhId = 1,
                },
                new Phong
                {
                    Id = 7,
                    PhongName = "A107",
                    LoaiPhongId = 2,
                    Price = 150000,
                    ShortDescription = "notthing",
                    ChuongTrinhId = 1,
                },
                new Phong
                {
                    Id = 8,
                    PhongName = "A108",
                    LoaiPhongId = 2,
                    Price = 150000,
                    ShortDescription = "notthing",
                    ChuongTrinhId = 1,
                }
            );
            modelBuilder.Entity<TrangThai>().HasData(
                new TrangThai
                {
                    Id = 1,
                    TrangThaiName = "Chưa Nhận",

                },
                new TrangThai
                {
                    Id = 2,
                    TrangThaiName = "Đã Nhận",

                },
                new TrangThai
                {
                    Id = 3,
                    TrangThaiName = "Đã Thanh Toán",
                }

            );
            modelBuilder.Entity<DatPhong>().HasData(
                new DatPhong
                {
                    Id = 1,
                    TenNguoiDat = "Nguyen Phuoc",
                    Address = "149",
                    Cmnd = "281212911",
                    Sdt = "0937536545",
                    ThoiGianNhanPhongDuKien = new DateTime(2019, 11, 22),
                    ThoiGianTraPhongDuKien = new DateTime(2019, 11, 24),
                    TienDatCoc = 50000,
                    TongTien = 7000000,

                },
                new DatPhong
                {
                    Id = 2,
                    TenNguoiDat = "Nguyen Truc",
                    Address = "149",
                    Cmnd = "281212910",
                    Sdt = "01264079973",
                    ThoiGianNhanPhongDuKien = new DateTime(2019, 12, 03),
                    ThoiGianTraPhongDuKien = new DateTime(2019, 12,06 ),
                    TienDatCoc = 50000,
                    TongTien = 4000000,
                },
            new DatPhong
            {
                Id = 3,
                TenNguoiDat = "Phan Tuyen",
                Address = "22",
                Cmnd = "281212915",
                Sdt = "01626364802",
                ThoiGianNhanPhongDuKien = new DateTime(2019, 12, 23),
                ThoiGianTraPhongDuKien = new DateTime(2019, 12, 25),
                TienDatCoc = 50000,
                TongTien = 5000000,
            }
            );
            modelBuilder.Entity<ChiTietDatPhong>().HasData(
                new ChiTietDatPhong
                {
                    DatPhongId = 1,
                    PhongId = 1,
                    TrangThaiId = 3,
                    ThoiGian = new DateTime(2019, 11, 22),
                },
                new ChiTietDatPhong
                {

                    DatPhongId = 1,
                    PhongId = 2,
                    TrangThaiId = 3,
                    ThoiGian = new DateTime(2019, 11, 22),
                },
                new ChiTietDatPhong
                {
                    DatPhongId = 1,
                    PhongId = 1,
                    TrangThaiId = 3,
                    ThoiGian = new DateTime(2019, 11, 23),
                },
                new ChiTietDatPhong
                {

                    DatPhongId = 1,
                    PhongId = 2,
                    TrangThaiId = 3,
                    ThoiGian = new DateTime(2019, 11, 23),
                },
                new ChiTietDatPhong
                {
                    DatPhongId = 1,
                    PhongId = 1,
                    TrangThaiId = 3,
                    ThoiGian = new DateTime(2019, 11, 24),
                },
                new ChiTietDatPhong
                {

                    DatPhongId = 1,
                    PhongId = 2,
                    TrangThaiId = 3,
                    ThoiGian = new DateTime(2019, 11, 24),
                },
                new ChiTietDatPhong
                {

                    DatPhongId = 2,
                    PhongId = 3,
                    TrangThaiId = 1,
                    ThoiGian = new DateTime(2019, 12, 03),
                },
                new ChiTietDatPhong
                {

                    DatPhongId = 2,
                    PhongId = 4,
                    TrangThaiId = 1,
                    ThoiGian = new DateTime(2019, 12, 03),
                },
                new ChiTietDatPhong
                {

                    DatPhongId = 2,
                    PhongId = 3,
                    TrangThaiId = 1,
                    ThoiGian = new DateTime(2019, 12, 04),
                },
                new ChiTietDatPhong
                {

                    DatPhongId = 2,
                    PhongId = 4,
                    TrangThaiId = 1,
                    ThoiGian = new DateTime(2019, 12, 04),
                },
                new ChiTietDatPhong
                {

                    DatPhongId = 2,
                    PhongId = 3,
                    TrangThaiId = 1,
                    ThoiGian = new DateTime(2019, 12, 05),
                },
                new ChiTietDatPhong
                {

                    DatPhongId = 2,
                    PhongId = 4,
                    TrangThaiId = 1,
                    ThoiGian = new DateTime(2019, 12, 05),
                },
                new ChiTietDatPhong
                {

                    DatPhongId = 2,
                    PhongId = 3,
                    TrangThaiId = 1,
                    ThoiGian = new DateTime(2019, 12, 06),
                },
                new ChiTietDatPhong
                {

                    DatPhongId = 2,
                    PhongId = 4,
                    TrangThaiId = 1,
                    ThoiGian = new DateTime(2019, 12, 06),
                },
                //ssss
                new ChiTietDatPhong
                {

                    DatPhongId = 3,
                    PhongId = 5,
                    TrangThaiId = 1,
                    ThoiGian = new DateTime(2019, 12, 23),
                }
                ,
                new ChiTietDatPhong
                {

                    DatPhongId = 3,
                    PhongId = 6,
                    TrangThaiId = 1,
                    ThoiGian = new DateTime(2019, 12, 23),
                },
                new ChiTietDatPhong
                {

                    DatPhongId = 3,
                    PhongId = 5,
                    TrangThaiId = 1,
                    ThoiGian = new DateTime(2019, 12, 24),
                }
                ,
                new ChiTietDatPhong
                {

                    DatPhongId = 3,
                    PhongId = 6,
                    TrangThaiId = 1,
                    ThoiGian = new DateTime(2019, 12, 24),
                },
                new ChiTietDatPhong
                {

                    DatPhongId = 3,
                    PhongId = 5,
                    TrangThaiId = 1,
                    ThoiGian = new DateTime(2019, 12, 25),
                }
                ,
                new ChiTietDatPhong
                {

                    DatPhongId = 3,
                    PhongId = 6,
                    TrangThaiId = 1,
                    ThoiGian = new DateTime(2019, 12, 25),
                }

            );
            modelBuilder.Entity<ChiTietDichVuDatPhong>().HasData(
                new ChiTietDichVuDatPhong
                {
                  
                    DatPhongId = 1,
                    DichVuId = 1,
                    SoLuong = 2


                },
                new ChiTietDichVuDatPhong
                {
                    
                    DatPhongId = 1,
                    DichVuId = 2,
                    SoLuong = 2
                }
            );
        }
        public virtual DbSet<ChiTietDatPhong> ChiTietDatPhongs { get; set; }
        public virtual DbSet<ChiTietDichVuDatPhong> ChiTietDichVuDatPhongs { get; set; }
        public virtual DbSet<ChuongTrinh> ChuongTrinhs { get; set; }
        public virtual DbSet<DatPhong> DatPhongs { get; set; }
        public virtual DbSet<DichVu> DichVus { get; set; }
        public virtual DbSet<HinhPhong> HinhPhongs { get; set; }
        public virtual DbSet<LoaiDichVu> LoaiDichVus { get; set; }
        public virtual DbSet<LoaiPhong> LoaiPhongs { get; set; }
        public virtual DbSet<Phong> Phongs { get; set; }
        public virtual DbSet<TrangThai> TrangThais { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
       

    }
}
