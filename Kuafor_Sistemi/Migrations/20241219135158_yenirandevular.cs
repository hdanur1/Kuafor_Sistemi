using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kuafor_Sistemi.Migrations
{
    public partial class yenirandevular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CalisanID",
                table: "randevulars");

            migrationBuilder.DropColumn(
                name: "IslemID",
                table: "randevulars");

            migrationBuilder.DropColumn(
                name: "KullaniciID",
                table: "randevulars");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CalisanID",
                table: "randevulars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IslemID",
                table: "randevulars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KullaniciID",
                table: "randevulars",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
