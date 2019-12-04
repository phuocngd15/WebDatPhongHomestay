using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CaChepCosmeticMVC2.Data.Migrations
{
    public partial class ver2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CapBacThes",
                columns: table => new
                {
                    CapBacTheId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenCapBac = table.Column<string>(nullable: true),
                    TienToiThieu = table.Column<decimal>(nullable: false),
                    QuyenLoi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapBacThes", x => x.CapBacTheId);
                });

            migrationBuilder.CreateTable(
                name: "ChiTieus",
                columns: table => new
                {
                    ChiTieuId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(nullable: true),
                    SoTien = table.Column<decimal>(nullable: false),
                    ThoiGian = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTieus", x => x.ChiTieuId);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucSanPhams",
                columns: table => new
                {
                    DanhMucSanPhamId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDanhMucSanPham = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucSanPhams", x => x.DanhMucSanPhamId);
                });

            migrationBuilder.CreateTable(
                name: "KhachHangs",
                columns: table => new
                {
                    KhachHangId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKhachHang = table.Column<string>(nullable: true),
                    NgaySinh = table.Column<DateTime>(nullable: false),
                    Sdt = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHangs", x => x.KhachHangId);
                });

            migrationBuilder.CreateTable(
                name: "MaGiamGias",
                columns: table => new
                {
                    MaGiamGiaId = table.Column<string>(nullable: false),
                    TenChuongTrinh = table.Column<string>(nullable: true),
                    NgayBatDau = table.Column<DateTime>(nullable: false),
                    NgayKetThuc = table.Column<DateTime>(nullable: false),
                    DieuKienApDung = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaGiamGias", x => x.MaGiamGiaId);
                });

            migrationBuilder.CreateTable(
                name: "NhanViens",
                columns: table => new
                {
                    NhanVienId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNv = table.Column<string>(nullable: true),
                    Sdt = table.Column<string>(nullable: true),
                    NgaySinh = table.Column<DateTime>(nullable: false),
                    Cmnd = table.Column<string>(nullable: true),
                    Luong = table.Column<decimal>(nullable: true),
                    NgayLam = table.Column<DateTime>(nullable: true),
                    AccoutId = table.Column<int>(nullable: true),
                    AccountBanId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanViens", x => x.NhanVienId);
                    table.ForeignKey(
                        name: "FK_NhanViens_AspNetUsers_AccountBanId",
                        column: x => x.AccountBanId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ThuongHieus",
                columns: table => new
                {
                    ThuongHieuId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenThuongHieu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThuongHieus", x => x.ThuongHieuId);
                });

            migrationBuilder.CreateTable(
                name: "Thus",
                columns: table => new
                {
                    ThuId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoTien = table.Column<decimal>(nullable: false),
                    ThoiGian = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thus", x => x.ThuId);
                });

            migrationBuilder.CreateTable(
                name: "LoaiSanPhams",
                columns: table => new
                {
                    LoaiSanPhamId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiSanPham = table.Column<string>(nullable: true),
                    DanhMucSanPhamId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiSanPhams", x => x.LoaiSanPhamId);
                    table.ForeignKey(
                        name: "FK_LoaiSanPhams_DanhMucSanPhams_DanhMucSanPhamId",
                        column: x => x.DanhMucSanPhamId,
                        principalTable: "DanhMucSanPhams",
                        principalColumn: "DanhMucSanPhamId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TheThanhViens",
                columns: table => new
                {
                    TheTvienId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TongChiTieu = table.Column<decimal>(nullable: false),
                    Ngaylap = table.Column<DateTime>(nullable: true),
                    CapbacTheId = table.Column<int>(nullable: false),
                    KhachHangId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheThanhViens", x => x.TheTvienId);
                    table.ForeignKey(
                        name: "FK_TheThanhViens_CapBacThes_CapbacTheId",
                        column: x => x.CapbacTheId,
                        principalTable: "CapBacThes",
                        principalColumn: "CapBacTheId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TheThanhViens_KhachHangs_KhachHangId",
                        column: x => x.KhachHangId,
                        principalTable: "KhachHangs",
                        principalColumn: "KhachHangId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SanPhams",
                columns: table => new
                {
                    SanPhamId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenSanPham = table.Column<string>(nullable: true),
                    Hinh = table.Column<string>(nullable: true),
                    GiaBan = table.Column<decimal>(nullable: false),
                    ThuongHieuId = table.Column<int>(nullable: true),
                    LoaiSanPhamId = table.Column<int>(nullable: true),
                    MoTa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhams", x => x.SanPhamId);
                    table.ForeignKey(
                        name: "FK_SanPhams_LoaiSanPhams_LoaiSanPhamId",
                        column: x => x.LoaiSanPhamId,
                        principalTable: "LoaiSanPhams",
                        principalColumn: "LoaiSanPhamId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SanPhams_ThuongHieus_ThuongHieuId",
                        column: x => x.ThuongHieuId,
                        principalTable: "ThuongHieus",
                        principalColumn: "ThuongHieuId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HoaDons",
                columns: table => new
                {
                    HoaDonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccoutId = table.Column<int>(nullable: true),
                    NgayLap = table.Column<DateTime>(nullable: false),
                    MaGiamGiaId = table.Column<string>(nullable: true),
                    TheTvienId = table.Column<int>(nullable: true),
                    TongTien = table.Column<decimal>(nullable: false),
                    AccountBanId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDons", x => x.HoaDonId);
                    table.ForeignKey(
                        name: "FK_HoaDons_AspNetUsers_AccountBanId",
                        column: x => x.AccountBanId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HoaDons_MaGiamGias_MaGiamGiaId",
                        column: x => x.MaGiamGiaId,
                        principalTable: "MaGiamGias",
                        principalColumn: "MaGiamGiaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HoaDons_TheThanhViens_TheTvienId",
                        column: x => x.TheTvienId,
                        principalTable: "TheThanhViens",
                        principalColumn: "TheTvienId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietHoaDons",
                columns: table => new
                {
                    HoaDonId = table.Column<int>(nullable: false),
                    SanPhamId = table.Column<int>(nullable: false),
                    SoLuong = table.Column<int>(nullable: false),
                    GiaBan = table.Column<decimal>(nullable: false),
                    ThanhTien = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietHoaDons", x => new { x.HoaDonId, x.SanPhamId });
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDons_HoaDons_HoaDonId",
                        column: x => x.HoaDonId,
                        principalTable: "HoaDons",
                        principalColumn: "HoaDonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDons_SanPhams_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "SanPhams",
                        principalColumn: "SanPhamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CapBacThes",
                columns: new[] { "CapBacTheId", "QuyenLoi", "TenCapBac", "TienToiThieu" },
                values: new object[,]
                {
                    { 1, "Giam 5% tổng hóa đơn", "Vip1", 1000000m },
                    { 2, "Giam 10% tổng hóa đơn", "Vip2", 2000000m },
                    { 3, "Giam 15% tổng hóa đơn", "Vip3", 5000000m },
                    { 4, "Giam 0% tổng hóa đơn", "Thành viên mới", 0m }
                });

            migrationBuilder.InsertData(
                table: "DanhMucSanPhams",
                columns: new[] { "DanhMucSanPhamId", "TenDanhMucSanPham" },
                values: new object[,]
                {
                    { 1, "Trang Điểm" },
                    { 2, "Chăm Sóc Da Mặt" },
                    { 3, "Chăm Sóc Cơ Thể" },
                    { 4, "Chăm Tóc Và Da Đầu" }
                });

            migrationBuilder.InsertData(
                table: "HoaDons",
                columns: new[] { "HoaDonId", "AccountBanId", "AccoutId", "MaGiamGiaId", "NgayLap", "TheTvienId", "TongTien" },
                values: new object[] { 2, null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 950000m });

            migrationBuilder.InsertData(
                table: "KhachHangs",
                columns: new[] { "KhachHangId", "Email", "NgaySinh", "Sdt", "TenKhachHang" },
                values: new object[,]
                {
                    { 3, "phantuyen@gmail.com", new DateTime(1997, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1626364802, "Phan Thị Ngọc Tuyền" },
                    { 2, "nglt@gmail.com", new DateTime(1997, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 937536545, "Nguyễn T" },
                    { 1, "phuocnglt@gmail.com", new DateTime(1999, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 937536545, "Nguyễn Duy Phước" }
                });

            migrationBuilder.InsertData(
                table: "MaGiamGias",
                columns: new[] { "MaGiamGiaId", "DieuKienApDung", "NgayBatDau", "NgayKetThuc", "TenChuongTrinh" },
                values: new object[,]
                {
                    { "VIP1", "có thẻ Vip 1", new DateTime(2015, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ưu đãi 5% dành cho vip 1" },
                    { "VIP2", "có thẻ Vip 2", new DateTime(2015, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ưu đãi 10% dành cho vip 2" },
                    { "VIP3", "có thẻ Vip 2", new DateTime(2015, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ưu đãi 15% dành cho vip 3" },
                    { "MGG001", "Tổng hóa đơn >= 100.000đ", new DateTime(2019, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Black Friday" }
                });

            migrationBuilder.InsertData(
                table: "NhanViens",
                columns: new[] { "NhanVienId", "AccountBanId", "AccoutId", "Cmnd", "Luong", "NgayLam", "NgaySinh", "Sdt", "TenNv" },
                values: new object[,]
                {
                    { 1, null, null, "281212912", 100000000m, new DateTime(2019, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1999, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "01626364802", "Phan Thị Ngọc Tuyền" },
                    { 2, null, null, "281212910", 200000000m, new DateTime(2019, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1998, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "0937536545", "Nguyễn Duy Phước" },
                    { 3, null, null, "281212982", null, new DateTime(2019, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1997, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "01626364802", "Phan A" }
                });

            migrationBuilder.InsertData(
                table: "ThuongHieus",
                columns: new[] { "ThuongHieuId", "TenThuongHieu" },
                values: new object[,]
                {
                    { 1, "Bbia Last" },
                    { 2, "Clear" }
                });

            migrationBuilder.InsertData(
                table: "LoaiSanPhams",
                columns: new[] { "LoaiSanPhamId", "DanhMucSanPhamId", "TenLoaiSanPham" },
                values: new object[,]
                {
                    { 1, 1, "Trang Điểm Mặt" },
                    { 2, 1, "Trang Điểm Mắt" },
                    { 3, 1, "Trang Điểm Môi" },
                    { 4, 1, "Trang Điểm" },
                    { 5, 2, "Xịt Khoáng" },
                    { 6, 2, "Nước Hoa Hông, Toner" },
                    { 7, 2, "Làm Sạch Da Mặt" },
                    { 8, 2, "Sản Phẩm Trị Mụn" },
                    { 9, 3, "Sữa tắm, xà bông, muối tắm" },
                    { 10, 3, "Dưỡng thể" },
                    { 11, 4, "Dầu Gội, Dầu Xả" },
                    { 12, 4, "Dưỡng tóc, ủ tóc" }
                });

            migrationBuilder.InsertData(
                table: "TheThanhViens",
                columns: new[] { "TheTvienId", "CapbacTheId", "KhachHangId", "Ngaylap", "TongChiTieu" },
                values: new object[,]
                {
                    { 3, 3, null, new DateTime(2018, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 20000m },
                    { 1, 2, 1, new DateTime(2018, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2000000m },
                    { 2, 3, 2, new DateTime(2018, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 50000m }
                });

            migrationBuilder.InsertData(
                table: "HoaDons",
                columns: new[] { "HoaDonId", "AccountBanId", "AccoutId", "MaGiamGiaId", "NgayLap", "TheTvienId", "TongTien" },
                values: new object[] { 1, null, null, "VIP2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1260000m });

            migrationBuilder.InsertData(
                table: "SanPhams",
                columns: new[] { "SanPhamId", "GiaBan", "Hinh", "LoaiSanPhamId", "MoTa", "TenSanPham", "ThuongHieuId" },
                values: new object[,]
                {
                    { 1, 150000m, "1", 1, null, "Kem tạo khối Bbia Last Contouring", 1 },
                    { 2, 130000m, "2", 1, null, "Che khuyết điểm Bbia Last Concealer 6.2g", 1 },
                    { 3, 150000m, "3", 2, null, "Kẻ mắt nước Bbia Last Pen Eyeliner 0.6g ", 1 },
                    { 8, 118000m, "8", 8, null, "Combo 4 Vedette Dưỡng Da Ngừa Mụn Hiệu Quả", null },
                    { 6, 150000m, "6", 9, null, "Combo Sữa Tắm L'amont En Provence Cherry", null },
                    { 7, 150000m, "7", 9, null, "Sữa Tắm St.Ives Muối Biển 400ml", null },
                    { 4, 170000m, "4", 11, null, "Dầu Gội Sạch Gàu Clear Botanique 9 Thảo Dược.", 2 },
                    { 5, 169000m, "5", 11, null, "Dầu Gội Sạch Gàu CLEAR Mát Lạnh Bạc Hà", 2 }
                });

            migrationBuilder.InsertData(
                table: "ChiTietHoaDons",
                columns: new[] { "HoaDonId", "SanPhamId", "GiaBan", "SoLuong", "ThanhTien" },
                values: new object[,]
                {
                    { 2, 1, 150000m, 2, 300000m },
                    { 2, 2, 130000m, 5, 650000m },
                    { 1, 1, 150000m, 5, 750000m },
                    { 1, 2, 130000m, 5, 650000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDons_SanPhamId",
                table: "ChiTietHoaDons",
                column: "SanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_AccountBanId",
                table: "HoaDons",
                column: "AccountBanId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_MaGiamGiaId",
                table: "HoaDons",
                column: "MaGiamGiaId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_TheTvienId",
                table: "HoaDons",
                column: "TheTvienId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiSanPhams_DanhMucSanPhamId",
                table: "LoaiSanPhams",
                column: "DanhMucSanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_NhanViens_AccountBanId",
                table: "NhanViens",
                column: "AccountBanId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_LoaiSanPhamId",
                table: "SanPhams",
                column: "LoaiSanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_ThuongHieuId",
                table: "SanPhams",
                column: "ThuongHieuId");

            migrationBuilder.CreateIndex(
                name: "IX_TheThanhViens_CapbacTheId",
                table: "TheThanhViens",
                column: "CapbacTheId");

            migrationBuilder.CreateIndex(
                name: "IX_TheThanhViens_KhachHangId",
                table: "TheThanhViens",
                column: "KhachHangId",
                unique: true,
                filter: "[KhachHangId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietHoaDons");

            migrationBuilder.DropTable(
                name: "ChiTieus");

            migrationBuilder.DropTable(
                name: "NhanViens");

            migrationBuilder.DropTable(
                name: "Thus");

            migrationBuilder.DropTable(
                name: "HoaDons");

            migrationBuilder.DropTable(
                name: "SanPhams");

            migrationBuilder.DropTable(
                name: "MaGiamGias");

            migrationBuilder.DropTable(
                name: "TheThanhViens");

            migrationBuilder.DropTable(
                name: "LoaiSanPhams");

            migrationBuilder.DropTable(
                name: "ThuongHieus");

            migrationBuilder.DropTable(
                name: "CapBacThes");

            migrationBuilder.DropTable(
                name: "KhachHangs");

            migrationBuilder.DropTable(
                name: "DanhMucSanPhams");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
