using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorApp10.Server.Data.Migrations
{
    public partial class _001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accout",
                columns: table => new
                {
                    AccoutID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    Quyen = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accout", x => x.AccoutID);
                });

            migrationBuilder.CreateTable(
                name: "CapBacThe",
                columns: table => new
                {
                    CapBacTheID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenCapBac = table.Column<string>(maxLength: 50, nullable: false),
                    TienToiThieu = table.Column<decimal>(type: "money", nullable: false),
                    QuyenLoi = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapBacThe", x => x.CapBacTheID);
                });

            migrationBuilder.CreateTable(
                name: "ChiTieu",
                columns: table => new
                {
                    ChiTieuID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(maxLength: 50, nullable: false),
                    SoTien = table.Column<decimal>(type: "money", nullable: false),
                    ThoiGian = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTieu", x => x.ChiTieuID);
                });

            migrationBuilder.CreateTable(
                name: "MaGiamGia",
                columns: table => new
                {
                    MaGiamGia = table.Column<string>(maxLength: 50, nullable: false),
                    TenChuongTrinh = table.Column<string>(maxLength: 50, nullable: true),
                    NgayBatDau = table.Column<DateTime>(type: "datetime", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime", nullable: false),
                    DieuKienApDung = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaGiamGia", x => x.MaGiamGia);
                });

            migrationBuilder.CreateTable(
                name: "NhomCongDung",
                columns: table => new
                {
                    NhomCongDungID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNhomCongDung = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhomCongDung", x => x.NhomCongDungID);
                });

            migrationBuilder.CreateTable(
                name: "Thu",
                columns: table => new
                {
                    ThuID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoTien = table.Column<decimal>(type: "money", nullable: false),
                    ThoiGian = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thu", x => x.ThuID);
                });

            migrationBuilder.CreateTable(
                name: "ThuongHieu",
                columns: table => new
                {
                    ThuongHieuID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenThuongHieu = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThuongHieu", x => x.ThuongHieuID);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    IDNV = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNV = table.Column<string>(maxLength: 50, nullable: false),
                    SDT = table.Column<int>(nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime", nullable: false),
                    CMND = table.Column<int>(nullable: false),
                    Luong = table.Column<decimal>(type: "money", nullable: true),
                    NgayLam = table.Column<DateTime>(type: "datetime", nullable: true),
                    AccoutID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.IDNV);
                    table.ForeignKey(
                        name: "FK_NhanVien_Accout",
                        column: x => x.AccoutID,
                        principalTable: "Accout",
                        principalColumn: "AccoutID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TheThanhVien",
                columns: table => new
                {
                    TheTVienID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TongChiTieu = table.Column<decimal>(type: "money", nullable: false),
                    Ngaylap = table.Column<DateTime>(type: "datetime", nullable: true),
                    CapbacTheID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheThanhVien", x => x.TheTVienID);
                    table.ForeignKey(
                        name: "FK_TheThanhVien_CapBacThe",
                        column: x => x.CapbacTheID,
                        principalTable: "CapBacThe",
                        principalColumn: "CapBacTheID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CongDung",
                columns: table => new
                {
                    CongDungID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenCongDung = table.Column<string>(maxLength: 50, nullable: false),
                    NhomCongDungID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CongDung", x => x.CongDungID);
                    table.ForeignKey(
                        name: "FK_CongDung_NhomCongDung",
                        column: x => x.NhomCongDungID,
                        principalTable: "NhomCongDung",
                        principalColumn: "NhomCongDungID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    HoaDonID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccoutID = table.Column<int>(nullable: false),
                    NgayLap = table.Column<DateTime>(type: "datetime", nullable: false),
                    MaGiamGia = table.Column<string>(maxLength: 50, nullable: true),
                    TheTVienID = table.Column<int>(nullable: true),
                    TongTien = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon", x => x.HoaDonID);
                    table.ForeignKey(
                        name: "FK_HoaDon_Accout",
                        column: x => x.AccoutID,
                        principalTable: "Accout",
                        principalColumn: "AccoutID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HoaDon_MaGiamGia",
                        column: x => x.MaGiamGia,
                        principalTable: "MaGiamGia",
                        principalColumn: "MaGiamGia",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HoaDon_TheThanhVien",
                        column: x => x.TheTVienID,
                        principalTable: "TheThanhVien",
                        principalColumn: "TheTVienID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    KhachHangID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKhachHang = table.Column<string>(maxLength: 50, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime", nullable: false),
                    SDT = table.Column<int>(nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    TheTVienID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.KhachHangID);
                    table.ForeignKey(
                        name: "FK_KhachHang_TheThanhVien",
                        column: x => x.TheTVienID,
                        principalTable: "TheThanhVien",
                        principalColumn: "TheTVienID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    SanPhamID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenSanPham = table.Column<string>(maxLength: 50, nullable: false),
                    SoLuong = table.Column<int>(nullable: true),
                    DVT = table.Column<string>(maxLength: 50, nullable: true),
                    GiaNhap = table.Column<decimal>(type: "money", nullable: false),
                    GiaBan = table.Column<decimal>(type: "money", nullable: false),
                    MaKe = table.Column<int>(nullable: false),
                    ThuongHieuID = table.Column<int>(nullable: true),
                    CongDungID = table.Column<int>(nullable: false),
                    MoTa = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham", x => x.SanPhamID);
                    table.ForeignKey(
                        name: "FK_SanPham_CongDung",
                        column: x => x.CongDungID,
                        principalTable: "CongDung",
                        principalColumn: "CongDungID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SanPham_ThuongHieu",
                        column: x => x.ThuongHieuID,
                        principalTable: "ThuongHieu",
                        principalColumn: "ThuongHieuID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietHoaDon",
                columns: table => new
                {
                    HoaDonID = table.Column<int>(nullable: false),
                    SanPhamID = table.Column<int>(nullable: false),
                    SoLuong = table.Column<int>(nullable: false),
                    GiaBan = table.Column<decimal>(type: "money", nullable: false),
                    ThanhTien = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietHoaDon", x => new { x.HoaDonID, x.SanPhamID });
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDon_HoaDon",
                        column: x => x.HoaDonID,
                        principalTable: "HoaDon",
                        principalColumn: "HoaDonID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDon_SanPham",
                        column: x => x.SanPhamID,
                        principalTable: "SanPham",
                        principalColumn: "SanPhamID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDon_SanPhamID",
                table: "ChiTietHoaDon",
                column: "SanPhamID");

            migrationBuilder.CreateIndex(
                name: "IX_CongDung_NhomCongDungID",
                table: "CongDung",
                column: "NhomCongDungID");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_AccoutID",
                table: "HoaDon",
                column: "AccoutID");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_MaGiamGia",
                table: "HoaDon",
                column: "MaGiamGia");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_TheTVienID",
                table: "HoaDon",
                column: "TheTVienID");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHang_TheTVienID",
                table: "KhachHang",
                column: "TheTVienID");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_AccoutID",
                table: "NhanVien",
                column: "AccoutID");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_CongDungID",
                table: "SanPham",
                column: "CongDungID");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_ThuongHieuID",
                table: "SanPham",
                column: "ThuongHieuID");

            migrationBuilder.CreateIndex(
                name: "IX_TheThanhVien_CapbacTheID",
                table: "TheThanhVien",
                column: "CapbacTheID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietHoaDon");

            migrationBuilder.DropTable(
                name: "ChiTieu");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "Thu");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropTable(
                name: "Accout");

            migrationBuilder.DropTable(
                name: "MaGiamGia");

            migrationBuilder.DropTable(
                name: "TheThanhVien");

            migrationBuilder.DropTable(
                name: "CongDung");

            migrationBuilder.DropTable(
                name: "ThuongHieu");

            migrationBuilder.DropTable(
                name: "CapBacThe");

            migrationBuilder.DropTable(
                name: "NhomCongDung");
        }
    }
}
