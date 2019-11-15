﻿// <auto-generated />
using System;
using BlazorApp10.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlazorApp10.Server.Data.Migrations
{
    [DbContext(typeof(QLCuaHangMyPhamContext))]
    partial class QLCuaHangMyPhamContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0-preview3.19554.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlazorApp10.Shared.Model.Accout", b =>
                {
                    b.Property<int>("AccoutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("AccoutID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Quyen")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("AccoutId");

                    b.ToTable("Accout");
                });

            modelBuilder.Entity("BlazorApp10.Shared.Model.CapBacThe", b =>
                {
                    b.Property<int>("CapBacTheId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CapBacTheID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("QuyenLoi")
                        .HasColumnType("ntext");

                    b.Property<string>("TenCapBac")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<decimal>("TienToiThieu")
                        .HasColumnType("money");

                    b.HasKey("CapBacTheId");

                    b.ToTable("CapBacThe");
                });

            modelBuilder.Entity("BlazorApp10.Shared.Model.ChiTietHoaDon", b =>
                {
                    b.Property<int>("HoaDonId")
                        .HasColumnName("HoaDonID")
                        .HasColumnType("int");

                    b.Property<int>("SanPhamId")
                        .HasColumnName("SanPhamID")
                        .HasColumnType("int");

                    b.Property<decimal>("GiaBan")
                        .HasColumnType("money");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<decimal>("ThanhTien")
                        .HasColumnType("money");

                    b.HasKey("HoaDonId", "SanPhamId");

                    b.HasIndex("SanPhamId");

                    b.ToTable("ChiTietHoaDon");
                });

            modelBuilder.Entity("BlazorApp10.Shared.Model.ChiTieu", b =>
                {
                    b.Property<int>("ChiTieuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ChiTieuID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("SoTien")
                        .HasColumnType("money");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("ThoiGian")
                        .HasColumnType("datetime");

                    b.HasKey("ChiTieuId");

                    b.ToTable("ChiTieu");
                });

            modelBuilder.Entity("BlazorApp10.Shared.Model.CongDung", b =>
                {
                    b.Property<int>("CongDungId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CongDungID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NhomCongDungId")
                        .HasColumnName("NhomCongDungID")
                        .HasColumnType("int");

                    b.Property<string>("TenCongDung")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("CongDungId");

                    b.HasIndex("NhomCongDungId");

                    b.ToTable("CongDung");
                });

            modelBuilder.Entity("BlazorApp10.Shared.Model.HoaDon", b =>
                {
                    b.Property<int>("HoaDonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("HoaDonID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccoutId")
                        .HasColumnName("AccoutID")
                        .HasColumnType("int");

                    b.Property<string>("MaGiamGia")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("NgayLap")
                        .HasColumnType("datetime");

                    b.Property<int?>("TheTvienId")
                        .HasColumnName("TheTVienID")
                        .HasColumnType("int");

                    b.Property<decimal>("TongTien")
                        .HasColumnType("money");

                    b.HasKey("HoaDonId");

                    b.HasIndex("AccoutId");

                    b.HasIndex("MaGiamGia");

                    b.HasIndex("TheTvienId");

                    b.ToTable("HoaDon");
                });

            modelBuilder.Entity("BlazorApp10.Shared.Model.KhachHang", b =>
                {
                    b.Property<int>("KhachHangId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("KhachHangID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime");

                    b.Property<int>("Sdt")
                        .HasColumnName("SDT")
                        .HasColumnType("int");

                    b.Property<string>("TenKhachHang")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("TheTvienId")
                        .HasColumnName("TheTVienID")
                        .HasColumnType("int");

                    b.HasKey("KhachHangId");

                    b.HasIndex("TheTvienId");

                    b.ToTable("KhachHang");
                });

            modelBuilder.Entity("BlazorApp10.Shared.Model.MaGiamGia", b =>
                {
                    b.Property<string>("MaGiamGia1")
                        .HasColumnName("MaGiamGia")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("DieuKienApDung")
                        .HasColumnType("ntext");

                    b.Property<DateTime>("NgayBatDau")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("NgayKetThuc")
                        .HasColumnType("datetime");

                    b.Property<string>("TenChuongTrinh")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("MaGiamGia1");

                    b.ToTable("MaGiamGia");
                });

            modelBuilder.Entity("BlazorApp10.Shared.Model.NhanVien", b =>
                {
                    b.Property<int>("Idnv")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IDNV")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccoutId")
                        .HasColumnName("AccoutID")
                        .HasColumnType("int");

                    b.Property<int>("Cmnd")
                        .HasColumnName("CMND")
                        .HasColumnType("int");

                    b.Property<decimal?>("Luong")
                        .HasColumnType("money");

                    b.Property<DateTime?>("NgayLam")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime");

                    b.Property<int>("Sdt")
                        .HasColumnName("SDT")
                        .HasColumnType("int");

                    b.Property<string>("TenNv")
                        .IsRequired()
                        .HasColumnName("TenNV")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Idnv");

                    b.HasIndex("AccoutId");

                    b.ToTable("NhanVien");
                });

            modelBuilder.Entity("BlazorApp10.Shared.Model.NhomCongDung", b =>
                {
                    b.Property<int>("NhomCongDungId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("NhomCongDungID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TenNhomCongDung")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("NhomCongDungId");

                    b.ToTable("NhomCongDung");
                });

            modelBuilder.Entity("BlazorApp10.Shared.Model.SanPham", b =>
                {
                    b.Property<int>("SanPhamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SanPhamID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CongDungId")
                        .HasColumnName("CongDungID")
                        .HasColumnType("int");

                    b.Property<string>("Dvt")
                        .HasColumnName("DVT")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<decimal>("GiaBan")
                        .HasColumnType("money");

                    b.Property<decimal>("GiaNhap")
                        .HasColumnType("money");

                    b.Property<int>("MaKe")
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .HasColumnType("ntext");

                    b.Property<int?>("SoLuong")
                        .HasColumnType("int");

                    b.Property<string>("TenSanPham")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("ThuongHieuId")
                        .HasColumnName("ThuongHieuID")
                        .HasColumnType("int");

                    b.HasKey("SanPhamId");

                    b.HasIndex("CongDungId");

                    b.HasIndex("ThuongHieuId");

                    b.ToTable("SanPham");
                });

            modelBuilder.Entity("BlazorApp10.Shared.Model.TheThanhVien", b =>
                {
                    b.Property<int>("TheTvienId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TheTVienID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CapbacTheId")
                        .HasColumnName("CapbacTheID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Ngaylap")
                        .HasColumnType("datetime");

                    b.Property<decimal>("TongChiTieu")
                        .HasColumnType("money");

                    b.HasKey("TheTvienId");

                    b.HasIndex("CapbacTheId");

                    b.ToTable("TheThanhVien");
                });

            modelBuilder.Entity("BlazorApp10.Shared.Model.Thu", b =>
                {
                    b.Property<int>("ThuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ThuID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("SoTien")
                        .HasColumnType("money");

                    b.Property<DateTime>("ThoiGian")
                        .HasColumnType("datetime");

                    b.HasKey("ThuId");

                    b.ToTable("Thu");
                });

            modelBuilder.Entity("BlazorApp10.Shared.Model.ThuongHieu", b =>
                {
                    b.Property<int>("ThuongHieuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ThuongHieuID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TenThuongHieu")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ThuongHieuId");

                    b.ToTable("ThuongHieu");
                });

            modelBuilder.Entity("BlazorApp10.Shared.Model.ChiTietHoaDon", b =>
                {
                    b.HasOne("BlazorApp10.Shared.Model.HoaDon", "HoaDon")
                        .WithMany("ChiTietHoaDon")
                        .HasForeignKey("HoaDonId")
                        .HasConstraintName("FK_ChiTietHoaDon_HoaDon")
                        .IsRequired();

                    b.HasOne("BlazorApp10.Shared.Model.SanPham", "SanPham")
                        .WithMany("ChiTietHoaDon")
                        .HasForeignKey("SanPhamId")
                        .HasConstraintName("FK_ChiTietHoaDon_SanPham")
                        .IsRequired();
                });

            modelBuilder.Entity("BlazorApp10.Shared.Model.CongDung", b =>
                {
                    b.HasOne("BlazorApp10.Shared.Model.NhomCongDung", "NhomCongDung")
                        .WithMany("CongDung")
                        .HasForeignKey("NhomCongDungId")
                        .HasConstraintName("FK_CongDung_NhomCongDung")
                        .IsRequired();
                });

            modelBuilder.Entity("BlazorApp10.Shared.Model.HoaDon", b =>
                {
                    b.HasOne("BlazorApp10.Shared.Model.Accout", "Accout")
                        .WithMany("HoaDon")
                        .HasForeignKey("AccoutId")
                        .HasConstraintName("FK_HoaDon_Accout")
                        .IsRequired();

                    b.HasOne("BlazorApp10.Shared.Model.MaGiamGia", "MaGiamGiaNavigation")
                        .WithMany("HoaDon")
                        .HasForeignKey("MaGiamGia")
                        .HasConstraintName("FK_HoaDon_MaGiamGia");

                    b.HasOne("BlazorApp10.Shared.Model.TheThanhVien", "TheTvien")
                        .WithMany("HoaDon")
                        .HasForeignKey("TheTvienId")
                        .HasConstraintName("FK_HoaDon_TheThanhVien");
                });

            modelBuilder.Entity("BlazorApp10.Shared.Model.KhachHang", b =>
                {
                    b.HasOne("BlazorApp10.Shared.Model.TheThanhVien", "TheTvien")
                        .WithMany("KhachHang")
                        .HasForeignKey("TheTvienId")
                        .HasConstraintName("FK_KhachHang_TheThanhVien")
                        .IsRequired();
                });

            modelBuilder.Entity("BlazorApp10.Shared.Model.NhanVien", b =>
                {
                    b.HasOne("BlazorApp10.Shared.Model.Accout", "Accout")
                        .WithMany("NhanVien")
                        .HasForeignKey("AccoutId")
                        .HasConstraintName("FK_NhanVien_Accout");
                });

            modelBuilder.Entity("BlazorApp10.Shared.Model.SanPham", b =>
                {
                    b.HasOne("BlazorApp10.Shared.Model.CongDung", "CongDung")
                        .WithMany("SanPham")
                        .HasForeignKey("CongDungId")
                        .HasConstraintName("FK_SanPham_CongDung")
                        .IsRequired();

                    b.HasOne("BlazorApp10.Shared.Model.ThuongHieu", "ThuongHieu")
                        .WithMany("SanPham")
                        .HasForeignKey("ThuongHieuId")
                        .HasConstraintName("FK_SanPham_ThuongHieu");
                });

            modelBuilder.Entity("BlazorApp10.Shared.Model.TheThanhVien", b =>
                {
                    b.HasOne("BlazorApp10.Shared.Model.CapBacThe", "CapbacThe")
                        .WithMany("TheThanhVien")
                        .HasForeignKey("CapbacTheId")
                        .HasConstraintName("FK_TheThanhVien_CapBacThe")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
