using Microsoft.EntityFrameworkCore.Migrations;

namespace CaChepFinal2.Data.Migrations
{
    public partial class addHinhUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HinhUrl",
                table: "Phongs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HinhUrl",
                table: "Phongs");
        }
    }
}
