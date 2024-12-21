using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace webOdevi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "musteriler",
                columns: table => new
                {
                    musteriid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    musteriadi = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    musterisoyadi = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    musteritelefon = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    eposta = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    sifre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_musteriler", x => x.musteriid);
                });

            migrationBuilder.CreateTable(
                name: "personel",
                columns: table => new
                {
                    personelid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    personeladi = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    personelsoyadi = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    pozisyon = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    personeltelefon = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    personeleposta = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    isebaslamatarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personel", x => x.personelid);
                });

            migrationBuilder.CreateTable(
                name: "services",
                columns: table => new
                {
                    hizmetid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    hizmetadi = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    fiyat = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_services", x => x.hizmetid);
                });

            migrationBuilder.CreateTable(
                name: "uygunluk",
                columns: table => new
                {
                    uygunlukid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    personelid = table.Column<int>(type: "integer", nullable: false),
                    tarih = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    baslangicsaati = table.Column<TimeSpan>(type: "interval", nullable: false),
                    bitissaati = table.Column<TimeSpan>(type: "interval", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uygunluk", x => x.uygunlukid);
                    table.ForeignKey(
                        name: "FK_uygunluk_personel_personelid",
                        column: x => x.personelid,
                        principalTable: "personel",
                        principalColumn: "personelid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "randevular",
                columns: table => new
                {
                    randevuid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    musteriid = table.Column<int>(type: "integer", nullable: false),
                    personelid = table.Column<int>(type: "integer", nullable: false),
                    hizmetid = table.Column<int>(type: "integer", nullable: false),
                    randevutarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    baslangicsaati = table.Column<TimeSpan>(type: "interval", nullable: false),
                    bitissaati = table.Column<TimeSpan>(type: "interval", nullable: false),
                    durum = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_randevular", x => x.randevuid);
                    table.ForeignKey(
                        name: "FK_randevular_musteriler_musteriid",
                        column: x => x.musteriid,
                        principalTable: "musteriler",
                        principalColumn: "musteriid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_randevular_personel_personelid",
                        column: x => x.personelid,
                        principalTable: "personel",
                        principalColumn: "personelid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_randevular_services_hizmetid",
                        column: x => x.hizmetid,
                        principalTable: "services",
                        principalColumn: "hizmetid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "randevuonay",
                columns: table => new
                {
                    onayid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    randevuid = table.Column<int>(type: "integer", nullable: false),
                    onaydurum = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    onaytarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    onaylayancalisan = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_randevuonay", x => x.onayid);
                    table.ForeignKey(
                        name: "FK_randevuonay_personel_onaylayancalisan",
                        column: x => x.onaylayancalisan,
                        principalTable: "personel",
                        principalColumn: "personelid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_randevuonay_randevular_randevuid",
                        column: x => x.randevuid,
                        principalTable: "randevular",
                        principalColumn: "randevuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_randevular_hizmetid",
                table: "randevular",
                column: "hizmetid");

            migrationBuilder.CreateIndex(
                name: "IX_randevular_musteriid",
                table: "randevular",
                column: "musteriid");

            migrationBuilder.CreateIndex(
                name: "IX_randevular_personelid",
                table: "randevular",
                column: "personelid");

            migrationBuilder.CreateIndex(
                name: "IX_randevuonay_onaylayancalisan",
                table: "randevuonay",
                column: "onaylayancalisan");

            migrationBuilder.CreateIndex(
                name: "IX_randevuonay_randevuid",
                table: "randevuonay",
                column: "randevuid");

            migrationBuilder.CreateIndex(
                name: "IX_uygunluk_personelid",
                table: "uygunluk",
                column: "personelid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "randevuonay");

            migrationBuilder.DropTable(
                name: "uygunluk");

            migrationBuilder.DropTable(
                name: "randevular");

            migrationBuilder.DropTable(
                name: "musteriler");

            migrationBuilder.DropTable(
                name: "personel");

            migrationBuilder.DropTable(
                name: "services");
        }
    }
}
