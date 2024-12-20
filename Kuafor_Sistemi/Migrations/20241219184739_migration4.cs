using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kuafor_Sistemi.Migrations
{
    public partial class migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CalisanID",
                table: "Randevulars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IslemID",
                table: "Randevulars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KullaniciID",
                table: "Randevulars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KullaniciID",
                table: "Oneris",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Randevulars_CalisanID",
                table: "Randevulars",
                column: "CalisanID");

            migrationBuilder.CreateIndex(
                name: "IX_Randevulars_IslemID",
                table: "Randevulars",
                column: "IslemID");

            migrationBuilder.CreateIndex(
                name: "IX_Randevulars_KullaniciID",
                table: "Randevulars",
                column: "KullaniciID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Randevulars_Calisanlars_CalisanID",
                table: "Randevulars",
                column: "CalisanID",
                principalTable: "Calisanlars",
                principalColumn: "CalisanID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Randevulars_Islemlers_IslemID",
                table: "Randevulars",
                column: "IslemID",
                principalTable: "Islemlers",
                principalColumn: "IslemID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Randevulars_Kullanicilars_KullaniciID",
                table: "Randevulars",
                column: "KullaniciID",
                principalTable: "Kullanicilars",
                principalColumn: "KullaniciID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Oneris_Kullanicilars_KullaniciID",
                table: "Oneris");

            migrationBuilder.DropForeignKey(
                name: "FK_Randevulars_Calisanlars_CalisanID",
                table: "Randevulars");

            migrationBuilder.DropForeignKey(
                name: "FK_Randevulars_Islemlers_IslemID",
                table: "Randevulars");

            migrationBuilder.DropForeignKey(
                name: "FK_Randevulars_Kullanicilars_KullaniciID",
                table: "Randevulars");

            migrationBuilder.DropIndex(
                name: "IX_Randevulars_CalisanID",
                table: "Randevulars");

            migrationBuilder.DropIndex(
                name: "IX_Randevulars_IslemID",
                table: "Randevulars");

            migrationBuilder.DropIndex(
                name: "IX_Randevulars_KullaniciID",
                table: "Randevulars");

            migrationBuilder.DropIndex(
                name: "IX_Oneris_KullaniciID",
                table: "Oneris");

            migrationBuilder.DropColumn(
                name: "CalisanID",
                table: "Randevulars");

            migrationBuilder.DropColumn(
                name: "IslemID",
                table: "Randevulars");

            migrationBuilder.DropColumn(
                name: "KullaniciID",
                table: "Randevulars");

            migrationBuilder.DropColumn(
                name: "KullaniciID",
                table: "Oneris");
        }
    }
}
