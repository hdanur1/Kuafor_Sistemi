using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kuafor_Sistemi.Migrations
{
    public partial class degisiklik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KullaniciSoyad",
                table: "Kullanicilars");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KullaniciSoyad",
                table: "Kullanicilars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
