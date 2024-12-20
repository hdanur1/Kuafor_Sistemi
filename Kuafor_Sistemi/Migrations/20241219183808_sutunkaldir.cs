using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kuafor_Sistemi.Migrations
{
    public partial class sutunkaldir : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Oneris_Kullanicilars_KullaniciID",
                table: "Oneris");

            migrationBuilder.DropIndex(
                name: "IX_Oneris_KullaniciID",
                table: "Oneris");

            migrationBuilder.DropColumn(
                name: "KullaniciID",
                table: "Oneris");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KullaniciID",
                table: "Oneris",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Oneris_KullaniciID",
                table: "Oneris",
                column: "KullaniciID");

            migrationBuilder.AddForeignKey(
                name: "FK_Oneris_Kullanicilars_KullaniciID",
                table: "Oneris",
                column: "KullaniciID",
                principalTable: "Kullanicilars",
                principalColumn: "KullaniciID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
