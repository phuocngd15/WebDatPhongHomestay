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

            });

            modelBuilder.Entity<ChuongTrinh>(entity =>
            {
                entity.Property(e => e.TenChuongTrinh).IsRequired();
            });


            modelBuilder.Entity<DichVu>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();

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

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<LoaiPhong>(entity =>
            {

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Phong>(entity =>
            {

                entity.Property(e => e.Name).IsRequired();

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
                entity.Property(e => e.Name).IsRequired();
            });
            modelBuilder.Entity<LoaiDichVu>().HasData(
                new LoaiDichVu
                {
                    Id = 1,
                    Name = "Thuc An",
                    Description = "notthing",
                },
                new LoaiDichVu
                {
                    Id = 2,
                    Name = "Nuoc Uong",
                    Description = "notthing",
                }
            );
            modelBuilder.Entity<DichVu>().HasData(
                new DichVu
                {
                    Id = 1,
                    Name = "NuocTangLuc",
                    LoaiDvid = 1,
                    ShortDescription = null,
                    ImageUrl = null,
                    InStock = 100,
                    Price = 15000,

                },
                new DichVu
                {
                    Id = 2,
                    Name = "NuocSuoi",
                    LoaiDvid = 1,
                    ShortDescription = null,
                    ImageUrl = null,
                    InStock = 100,
                    Price = 15000,

                }
            );
            modelBuilder.Entity<LoaiPhong>().HasData(
                new LoaiPhong
                {
                    Id = 1,
                    Name = "Phong Don",
                    
                },
                new LoaiPhong
                {
                    Id = 2,
                    Name = "Phong Doi",

                }
            );
            modelBuilder.Entity<Phong>().HasData(
                new Phong
                {
                    Id = 1,
                    Name = "A101",
                    LoaiPhongId = 1,
                    Price = 150000,
                    ShortDescription = "notthing",
                    ChuongTrinhId = null,

                },
                new Phong
                {
                    Id = 2,
                    Name = "A102",
                    LoaiPhongId = 1,
                    Price = 150000,
                    ShortDescription = "notthing",
                    ChuongTrinhId = null,
                },
                new Phong
                {
                    Id = 3,
                    Name = "A103",
                    LoaiPhongId = 2,
                    Price = 150000,
                    ShortDescription = "notthing",
                    ChuongTrinhId = null,
                },
                new Phong
                {
                    Id = 4,
                    Name = "A104",
                    LoaiPhongId = 2,
                    ShortDescription = "notthing",
                    ChuongTrinhId = null,
                },
                new Phong
                {
                    Id = 5,
                    Name = "A105",
                    LoaiPhongId = 1,
                    Price = 150000,
                    ShortDescription = "notthing",
                    ChuongTrinhId = null,
                },
                new Phong
                {
                    Id = 6,
                    Name = "A106",
                    LoaiPhongId = 2,
                    Price = 150000,
                    ShortDescription = "notthing",
                    ChuongTrinhId = null,
                },
                new Phong
                {
                    Id = 7,
                    Name = "A107",
                    LoaiPhongId = 2,
                    Price = 150000,
                    ShortDescription = "notthing",
                    ChuongTrinhId = null,
                },
                new Phong
                {
                    Id = 8,
                    Name = "A108",
                    LoaiPhongId = 2,
                    Price = 150000,
                    ShortDescription = "notthing",
                    ChuongTrinhId = null,
                }
            );
            modelBuilder.Entity<TrangThai>().HasData(
                new TrangThai
                {
                    Id = 1,
                    Name = "Chưa Nhận",

                },
                new TrangThai
                {
                    Id = 2,
                    Name = "Đã Nhận",

                },
                new TrangThai
                {
                    Id = 3,
                    Name = "Đã Thanh Toán",
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
                    Id = 1,
                    DatPhongId = 1,
                    DichVuId = 1,
                    SoLuong = 2


                },
                new ChiTietDichVuDatPhong
                {
                    Id = 2,
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
        //modelBuilder.Entity<LoaiDV>().HasData(
        //    new LoaiDV
        //    {
        //        Id = 1,
        //        Name = "Thuc An",
        //        Description = "notthing",
        //        ImageUrl = null,
        //    },
        //    new LoaiDV
        //    {
        //        Id = 2,
        //        Name = "Nuoc Uong",
        //        Description = "notthing",
        //        ImageUrl = null,
        //    }
        //);
        //modelBuilder.Entity<DichVu>().HasData(
        //    new DichVu
        //    {
        //        Id = 1,
        //        Name = "NuocTangLuc",
        //        LoaiDVId = 1,
        //        ShortDescription = null,
        //        ImageUrl = null,
        //        InStock = 100,
        //        Price = 15000,

        //    },
        //    new DichVu
        //    {
        //        Id = 2,
        //        Name = "NuocSuoi",
        //        LoaiDVId = 1,
        //        ShortDescription = null,
        //        ImageUrl = null,
        //        InStock = 100,
        //        Price = 15000,

        //    }
        //);
        //modelBuilder.Entity<LoaiPhong>().HasData(
        //    new LoaiPhong
        //    {
        //        Id = 1,
        //        Name = "Phong Don",
        //        Description = null,
        //        ImageUrl = null,


        //    },
        //    new LoaiPhong
        //    {
        //        Id = 2,
        //        Name = "Phong Doi",
        //        Description = null,
        //        ImageUrl = null,


        //    }
        //);
        //modelBuilder.Entity<Phong>().HasData(
        //    new Phong
        //    {
        //        Id = 1,
        //        Name = "A101",
        //        LoaiPhongId = 1,
        //        Price = 150000,
        //        ShortDescription = null,
        //        TrangThai = 1,
        //        ImageUrl = null,

        //    },
        //    new Phong
        //    {
        //        Id = 2,
        //        Name = "A102",
        //        LoaiPhongId = 1,
        //        Price = 150000,
        //        ShortDescription = null,
        //        TrangThai = 1,
        //        ImageUrl = null
        //    },
        //    new Phong
        //    {
        //        Id = 3,
        //        Name = "A103",
        //        LoaiPhongId = 2,
        //        Price = 150000,
        //        ShortDescription = null,
        //        TrangThai = 1,
        //        ImageUrl = null
        //    },
        //    new Phong
        //    {
        //        Id = 4,
        //        Name = "A104",
        //        LoaiPhongId = 2,
        //        Price = 170000,
        //        ShortDescription = null,
        //        TrangThai = 1,
        //        ImageUrl = null
        //    }
        //);
        //modelBuilder.Entity<TrangThai>().HasData(
        //    new TrangThai
        //    {
        //        Id = 1,
        //        Name = "Chưa Nhận",

        //    },
        //    new TrangThai
        //    {
        //        Id = 2,
        //        Name = "Đã Nhận",

        //    },
        //    new TrangThai
        //    {
        //        Id = 3,
        //        Name = "Đã Thanh Toán",
        //    }

        //);
        //modelBuilder.Entity<DatPhong>().HasData(
        //    new DatPhong
        //    {
        //        Id = 1,
        //        TenNguoiDat = "Nguyen Phuoc",
        //        Address = "149",
        //        CMND = "281212911",
        //        TrangThaiId = 1,
        //        SDT = "0937536545",
        //        ThoiGianNhanPhongDuKien = new DateTime(2019,11,22),
        //        ThoiGianTraPhongDuKien = new DateTime(2019, 11, 24),

        //    },
        //    new DatPhong
        //    {
        //        Id = 2,
        //        TenNguoiDat = "Nguyen Truc",
        //        Address = "149",
        //        CMND = "281212910",
        //        TrangThaiId = 1,
        //        SDT = "01264079970",
        //        ThoiGianNhanPhongDuKien = new DateTime(2019, 11, 23),
        //        ThoiGianTraPhongDuKien = new DateTime(2019, 11, 25),

        //    },
        //new DatPhong
        //    {
        //        Id = 3,
        //        TenNguoiDat = "Nguyen Truc2",
        //        Address = "22",
        //        CMND = "281212915",
        //        TrangThaiId = 2,
        //        SDT = "01264079970",
        //        ThoiGianNhanPhongDuKien = new DateTime(2019, 11, 23),
        //        ThoiGianTraPhongDuKien = new DateTime(2019, 11, 25),

        //    }
        //);
        //modelBuilder.Entity<ChiTietPhongDatPhong>().HasData(
        //    new ChiTietPhongDatPhong
        //    {
        //        Id = 1,
        //        DatPhongId = 1,
        //        PhongId = 1,
        //        GiaTienMotNgay = 150000,
        //        TongSoNgay = 3,

        //    },
        //    new ChiTietPhongDatPhong
        //    {
        //        Id = 2,
        //        DatPhongId = 1,
        //        PhongId = 2,
        //        GiaTienMotNgay = 150000,
        //        TongSoNgay = 2,

        //    }
        //);
        //modelBuilder.Entity<ChiTietDichVuDatPhong>().HasData(
        //    new ChiTietDichVuDatPhong
        //    {
        //        Id = 1,
        //        DatPhongId = 1,
        //        DichVuId = 1,
        //        SoLuong = 2


        //    },
        //    new ChiTietDichVuDatPhong
        //    {
        //        Id = 2,
        //        DatPhongId = 1,
        //        DichVuId = 2,
        //        SoLuong = 2


        //    }
        //);

    }
}
