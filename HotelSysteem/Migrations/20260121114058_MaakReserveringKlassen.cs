using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelSysteem.Migrations
{
    /// <inheritdoc />
    public partial class MaakReserveringKlassen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HotelKamerTarievens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KamerId = table.Column<int>(type: "int", nullable: true),
                    GeldingVan = table.Column<DateOnly>(type: "date", nullable: false),
                    GeldigTot = table.Column<DateOnly>(type: "date", nullable: false),
                    Tarief = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelKamerTarievens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelKamerTarievens_HotelKamers_KamerId",
                        column: x => x.KamerId,
                        principalTable: "HotelKamers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HotelRekeningen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToeristenBelasting = table.Column<int>(type: "int", nullable: false),
                    Korting = table.Column<int>(type: "int", nullable: false),
                    Betaald = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelRekeningen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HotelReserveringen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RekeningId = table.Column<int>(type: "int", nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Emailaddres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefoonNummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BeginDatum = table.Column<DateOnly>(type: "date", nullable: false),
                    EindDatum = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelReserveringen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelReserveringen_HotelRekeningen_RekeningId",
                        column: x => x.RekeningId,
                        principalTable: "HotelRekeningen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelKamerReserveringen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReserveringId = table.Column<int>(type: "int", nullable: false),
                    KamerId = table.Column<int>(type: "int", nullable: false),
                    TariefId = table.Column<int>(type: "int", nullable: false),
                    AantalPersonen = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelKamerReserveringen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelKamerReserveringen_HotelKamerTarievens_TariefId",
                        column: x => x.TariefId,
                        principalTable: "HotelKamerTarievens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelKamerReserveringen_HotelKamers_ReserveringId",
                        column: x => x.ReserveringId,
                        principalTable: "HotelKamers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelKamerReserveringen_HotelReserveringen_ReserveringId",
                        column: x => x.ReserveringId,
                        principalTable: "HotelReserveringen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelKamerReserveringen_ReserveringId",
                table: "HotelKamerReserveringen",
                column: "ReserveringId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelKamerReserveringen_TariefId",
                table: "HotelKamerReserveringen",
                column: "TariefId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelKamerTarievens_KamerId",
                table: "HotelKamerTarievens",
                column: "KamerId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelReserveringen_RekeningId",
                table: "HotelReserveringen",
                column: "RekeningId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelKamerReserveringen");

            migrationBuilder.DropTable(
                name: "HotelKamerTarievens");

            migrationBuilder.DropTable(
                name: "HotelReserveringen");

            migrationBuilder.DropTable(
                name: "HotelRekeningen");
        }
    }
}
