﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CaChepFinal2.Data.Migrations
{
    public partial class ver1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "ChiTietDatPhongHeaps",
                columns: table => new
                {
                    PhongId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ChiTietDichVuDatPhongHeaps",
                columns: table => new
                {
                    DichVuId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ChuongTrinhs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChuongTrinhName = table.Column<string>(nullable: false),
                    TiLeThayDoiGia = table.Column<int>(nullable: false),
                    IsTang = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChuongTrinhs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DatPhongs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNguoiDat = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Cmnd = table.Column<string>(nullable: true),
                    Sdt = table.Column<string>(nullable: true),
                    TienDatCoc = table.Column<decimal>(type: "Money", nullable: false),
                    ThoiGianNhanPhongDuKien = table.Column<DateTime>(nullable: false),
                    ThoiGianTraPhongDuKien = table.Column<DateTime>(nullable: false),
                    TongTien = table.Column<decimal>(type: "Money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatPhongs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiDichVus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoaiDichVuName = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiDichVus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiPhongs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoaiPhongName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiPhongs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrangThais",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrangThaiName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrangThais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DichVus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DichVuName = table.Column<string>(nullable: false),
                    ShortDescription = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "Money", nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    InStock = table.Column<int>(nullable: true),
                    LoaiDvid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DichVus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DichVus_LoaiDichVus_LoaiDvid",
                        column: x => x.LoaiDvid,
                        principalTable: "LoaiDichVus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phongs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhongName = table.Column<string>(nullable: false),
                    ShortDescription = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "Money", nullable: false),
                    LoaiPhongId = table.Column<int>(nullable: true),
                    ChuongTrinhId = table.Column<int>(nullable: true),
                    HinhUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phongs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phongs_ChuongTrinh",
                        column: x => x.ChuongTrinhId,
                        principalTable: "ChuongTrinhs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Phongs_LoaiPhongs",
                        column: x => x.LoaiPhongId,
                        principalTable: "LoaiPhongs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietDichVuDatPhongs",
                columns: table => new
                {
                    DatPhongId = table.Column<int>(nullable: false),
                    DichVuId = table.Column<int>(nullable: false),
                    SoLuong = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietDichVuDatPhongs", x => new { x.DatPhongId, x.DichVuId });
                    table.ForeignKey(
                        name: "FK_ChiTietDichVuDatPhongs_DatPhongs_DatPhongId",
                        column: x => x.DatPhongId,
                        principalTable: "DatPhongs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietDichVuDatPhongs_DichVus_DichVuId",
                        column: x => x.DichVuId,
                        principalTable: "DichVus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietDatPhongs",
                columns: table => new
                {
                    ThoiGian = table.Column<DateTime>(nullable: false),
                    DatPhongId = table.Column<int>(nullable: false),
                    PhongId = table.Column<int>(nullable: false),
                    TrangThaiId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietDatPhongs", x => new { x.ThoiGian, x.DatPhongId, x.PhongId });
                    table.ForeignKey(
                        name: "FK_ChiTietDatPhongs_DatPhongs_DatPhongId",
                        column: x => x.DatPhongId,
                        principalTable: "DatPhongs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietDatPhongs_Phongs_PhongId",
                        column: x => x.PhongId,
                        principalTable: "Phongs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietDatPhongs_TrangThais_TrangThaiId",
                        column: x => x.TrangThaiId,
                        principalTable: "TrangThais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HinhPhongs",
                columns: table => new
                {
                    HinhId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhongId = table.Column<int>(nullable: false),
                    HinhUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HinhPhongs", x => x.HinhId);
                    table.ForeignKey(
                        name: "FK_HinhPhong_Phongs",
                        column: x => x.PhongId,
                        principalTable: "Phongs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ChuongTrinhs",
                columns: new[] { "Id", "ChuongTrinhName", "IsTang", "TiLeThayDoiGia" },
                values: new object[,]
                {
                    { 1, "notthing", false, 0 },
                    { 2, "Lễ Tình Nhân", true, 10 }
                });

            migrationBuilder.InsertData(
                table: "DatPhongs",
                columns: new[] { "Id", "Address", "Cmnd", "Sdt", "TenNguoiDat", "ThoiGianNhanPhongDuKien", "ThoiGianTraPhongDuKien", "TienDatCoc", "TongTien" },
                values: new object[,]
                {
                    { 1, "149", "281212911", "0937536545", "Nguyen Phuoc", new DateTime(2019, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 50000m, 7000000m },
                    { 2, "149", "281212910", "01264079973", "Nguyen Truc", new DateTime(2019, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 50000m, 4000000m },
                    { 3, "22", "281212915", "01626364802", "Phan Tuyen", new DateTime(2019, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 50000m, 5000000m }
                });

            migrationBuilder.InsertData(
                table: "LoaiDichVus",
                columns: new[] { "Id", "Description", "LoaiDichVuName" },
                values: new object[,]
                {
                    { 1, "notthing", "Thuc An" },
                    { 2, "notthing", "Nuoc Uong" }
                });

            migrationBuilder.InsertData(
                table: "LoaiPhongs",
                columns: new[] { "Id", "LoaiPhongName" },
                values: new object[,]
                {
                    { 1, "Phong Don" },
                    { 2, "Phong Doi" }
                });

            migrationBuilder.InsertData(
                table: "TrangThais",
                columns: new[] { "Id", "TrangThaiName" },
                values: new object[,]
                {
                    { 1, "Chưa Nhận" },
                    { 2, "Đã Nhận" },
                    { 3, "Đã Thanh Toán" }
                });

            migrationBuilder.InsertData(
                table: "DichVus",
                columns: new[] { "Id", "DichVuName", "ImageUrl", "InStock", "LoaiDvid", "Price", "ShortDescription" },
                values: new object[,]
                {
                    { 1, "NuocTangLuc", null, 100, 1, 15000m, null },
                    { 2, "NuocSuoi", null, 100, 1, 15000m, null }
                });

            migrationBuilder.InsertData(
                table: "Phongs",
                columns: new[] { "Id", "ChuongTrinhId", "HinhUrl", "LoaiPhongId", "PhongName", "Price", "ShortDescription" },
                values: new object[,]
                {
                    { 1, 1, null, 1, "A101", 150000m, "notthing" },
                    { 2, 1, null, 1, "A102", 150000m, "notthing" },
                    { 5, 1, null, 1, "A105", 150000m, "notthing" },
                    { 3, 1, null, 2, "A103", 150000m, "notthing" },
                    { 4, 1, null, 2, "A104", 0m, "notthing" },
                    { 6, 1, null, 2, "A106", 150000m, "notthing" },
                    { 7, 1, null, 2, "A107", 150000m, "notthing" },
                    { 8, 1, null, 2, "A108", 150000m, "notthing" }
                });

            migrationBuilder.InsertData(
                table: "ChiTietDatPhongs",
                columns: new[] { "ThoiGian", "DatPhongId", "PhongId", "TrangThaiId" },
                values: new object[,]
                {
                    { new DateTime(2019, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 5, 1 },
                    { new DateTime(2019, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 6, 1 },
                    { new DateTime(2019, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, 1 },
                    { new DateTime(2019, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, 1 },
                    { new DateTime(2019, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, 1 },
                    { new DateTime(2019, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, 1 },
                    { new DateTime(2019, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, 1 },
                    { new DateTime(2019, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, 1 },
                    { new DateTime(2019, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, 1 },
                    { new DateTime(2019, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, 1 },
                    { new DateTime(2019, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 6, 1 },
                    { new DateTime(2019, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 5, 1 },
                    { new DateTime(2019, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 5, 1 },
                    { new DateTime(2019, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 3 },
                    { new DateTime(2019, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 3 },
                    { new DateTime(2019, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 3 },
                    { new DateTime(2019, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 3 },
                    { new DateTime(2019, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 3 },
                    { new DateTime(2019, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 3 },
                    { new DateTime(2019, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 6, 1 }
                });

            migrationBuilder.InsertData(
                table: "ChiTietDichVuDatPhongs",
                columns: new[] { "DatPhongId", "DichVuId", "SoLuong" },
                values: new object[,]
                {
                    { 1, 2, 2 },
                    { 1, 1, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDatPhongs_DatPhongId",
                table: "ChiTietDatPhongs",
                column: "DatPhongId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDatPhongs_PhongId",
                table: "ChiTietDatPhongs",
                column: "PhongId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDatPhongs_TrangThaiId",
                table: "ChiTietDatPhongs",
                column: "TrangThaiId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDichVuDatPhongs_DichVuId",
                table: "ChiTietDichVuDatPhongs",
                column: "DichVuId");

            migrationBuilder.CreateIndex(
                name: "IX_DichVus_LoaiDvid",
                table: "DichVus",
                column: "LoaiDvid");

            migrationBuilder.CreateIndex(
                name: "IX_HinhPhongs_PhongId",
                table: "HinhPhongs",
                column: "PhongId");

            migrationBuilder.CreateIndex(
                name: "IX_Phongs_ChuongTrinhId",
                table: "Phongs",
                column: "ChuongTrinhId");

            migrationBuilder.CreateIndex(
                name: "IX_Phongs_LoaiPhongId",
                table: "Phongs",
                column: "LoaiPhongId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietDatPhongHeaps");

            migrationBuilder.DropTable(
                name: "ChiTietDatPhongs");

            migrationBuilder.DropTable(
                name: "ChiTietDichVuDatPhongHeaps");

            migrationBuilder.DropTable(
                name: "ChiTietDichVuDatPhongs");

            migrationBuilder.DropTable(
                name: "HinhPhongs");

            migrationBuilder.DropTable(
                name: "TrangThais");

            migrationBuilder.DropTable(
                name: "DatPhongs");

            migrationBuilder.DropTable(
                name: "DichVus");

            migrationBuilder.DropTable(
                name: "Phongs");

            migrationBuilder.DropTable(
                name: "LoaiDichVus");

            migrationBuilder.DropTable(
                name: "ChuongTrinhs");

            migrationBuilder.DropTable(
                name: "LoaiPhongs");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
