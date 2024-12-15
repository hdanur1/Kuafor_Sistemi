using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kuafor_Sistemi.Migrations
{
    public partial class kuafor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    AdminID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admins", x => x.AdminID);
                });

            migrationBuilder.CreateTable(
                name: "calisanlars",
                columns: table => new
                {
                    CalisanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalisanAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CalisanSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Uzmanlik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MusaitlikBaslangic = table.Column<TimeSpan>(type: "time", nullable: false),
                    MusaitlikBitis = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_calisanlars", x => x.CalisanID);
                });

            migrationBuilder.CreateTable(
                name: "islemlers",
                columns: table => new
                {
                    IslemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IslemAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ucret = table.Column<float>(type: "real", nullable: false),
                    Sure = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_islemlers", x => x.IslemID);
                });

            migrationBuilder.CreateTable(
                name: "kullanicilars",
                columns: table => new
                {
                    KullaniciID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KullaniciSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kullanicilars", x => x.KullaniciID);
                });

            migrationBuilder.CreateTable(
                name: "oneris",
                columns: table => new
                {
                    OneriID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciID = table.Column<int>(type: "int", nullable: false),
                    FotoURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OneriMetni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oneris", x => x.OneriID);
                });

            migrationBuilder.CreateTable(
                name: "randevulars",
                columns: table => new
                {
                    RandevuID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalisanID = table.Column<int>(type: "int", nullable: false),
                    KullaniciID = table.Column<int>(type: "int", nullable: false),
                    IslemID = table.Column<int>(type: "int", nullable: false),
                    TarihSaat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToplamUcret = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_randevulars", x => x.RandevuID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admins");

            migrationBuilder.DropTable(
                name: "calisanlars");

            migrationBuilder.DropTable(
                name: "islemlers");

            migrationBuilder.DropTable(
                name: "kullanicilars");

            migrationBuilder.DropTable(
                name: "oneris");

            migrationBuilder.DropTable(
                name: "randevulars");
        }
    }
}
