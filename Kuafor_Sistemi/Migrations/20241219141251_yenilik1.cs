using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kuafor_Sistemi.Migrations
{
    public partial class yenilik1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "KullaniciID",
                table: "oneris",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_randevulars_CalisanID",
                table: "randevulars",
                column: "CalisanID");

            migrationBuilder.CreateIndex(
                name: "IX_randevulars_IslemID",
                table: "randevulars",
                column: "IslemID");

            migrationBuilder.CreateIndex(
                name: "IX_randevulars_KullaniciID",
                table: "randevulars",
                column: "KullaniciID");

            migrationBuilder.CreateIndex(
                name: "IX_oneris_KullaniciID",
                table: "oneris",
                column: "KullaniciID");

            migrationBuilder.AddForeignKey(
                name: "FK_oneris_kullanicilars_KullaniciID",
                table: "oneris",
                column: "KullaniciID",
                principalTable: "kullanicilars",
                principalColumn: "KullaniciID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_randevulars_calisanlars_CalisanID",
                table: "randevulars",
                column: "CalisanID",
                principalTable: "calisanlars",
                principalColumn: "CalisanID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_randevulars_islemlers_IslemID",
                table: "randevulars",
                column: "IslemID",
                principalTable: "islemlers",
                principalColumn: "IslemID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_randevulars_kullanicilars_KullaniciID",
                table: "randevulars",
                column: "KullaniciID",
                principalTable: "kullanicilars",
                principalColumn: "KullaniciID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_oneris_kullanicilars_KullaniciID",
                table: "oneris");

            migrationBuilder.DropForeignKey(
                name: "FK_randevulars_calisanlars_CalisanID",
                table: "randevulars");

            migrationBuilder.DropForeignKey(
                name: "FK_randevulars_islemlers_IslemID",
                table: "randevulars");

            migrationBuilder.DropForeignKey(
                name: "FK_randevulars_kullanicilars_KullaniciID",
                table: "randevulars");

            migrationBuilder.DropIndex(
                name: "IX_randevulars_CalisanID",
                table: "randevulars");

            migrationBuilder.DropIndex(
                name: "IX_randevulars_IslemID",
                table: "randevulars");

            migrationBuilder.DropIndex(
                name: "IX_randevulars_KullaniciID",
                table: "randevulars");

            migrationBuilder.DropIndex(
                name: "IX_oneris_KullaniciID",
                table: "oneris");

            migrationBuilder.DropColumn(
                name: "CalisanID",
                table: "randevulars");

            migrationBuilder.DropColumn(
                name: "IslemID",
                table: "randevulars");

            migrationBuilder.DropColumn(
                name: "KullaniciID",
                table: "randevulars");

            migrationBuilder.DropColumn(
                name: "KullaniciID",
                table: "oneris");
        }
    }
}
