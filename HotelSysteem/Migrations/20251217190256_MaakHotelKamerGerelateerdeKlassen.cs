using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelSysteem.Migrations
{
    /// <inheritdoc />
    public partial class MaakHotelKamerGerelateerdeKlassen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KamerNummer",
                table: "HotelKamers");

            migrationBuilder.DropColumn(
                name: "Omschrijving",
                table: "HotelKamers");

            migrationBuilder.DropColumn(
                name: "PrijsPerNacht",
                table: "HotelKamers");

            migrationBuilder.RenameColumn(
                name: "AantalPersonen",
                table: "HotelKamers",
                newName: "VoorzieningenId");

            migrationBuilder.AddColumn<int>(
                name: "Nummer",
                table: "HotelKamers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Bedden",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Omschrijving = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bedden", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Voorzieningens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KamerId = table.Column<int>(type: "int", nullable: false),
                    Oppervlakte = table.Column<int>(type: "int", nullable: false),
                    Balkon = table.Column<bool>(type: "bit", nullable: false),
                    Badkamers = table.Column<int>(type: "int", nullable: false),
                    Slaapkamers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voorzieningens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voorzieningens_HotelKamers_KamerId",
                        column: x => x.KamerId,
                        principalTable: "HotelKamers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Beddens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BedId = table.Column<int>(type: "int", nullable: false),
                    Aantal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beddens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beddens_Bedden_BedId",
                        column: x => x.BedId,
                        principalTable: "Bedden",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelKamerBeddenHotelKamerVoorzieningen",
                columns: table => new
                {
                    BeddenId = table.Column<int>(type: "int", nullable: false),
                    VoorzieningenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelKamerBeddenHotelKamerVoorzieningen", x => new { x.BeddenId, x.VoorzieningenId });
                    table.ForeignKey(
                        name: "FK_HotelKamerBeddenHotelKamerVoorzieningen_Beddens_BeddenId",
                        column: x => x.BeddenId,
                        principalTable: "Beddens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelKamerBeddenHotelKamerVoorzieningen_Voorzieningens_VoorzieningenId",
                        column: x => x.VoorzieningenId,
                        principalTable: "Voorzieningens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beddens_BedId",
                table: "Beddens",
                column: "BedId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelKamerBeddenHotelKamerVoorzieningen_VoorzieningenId",
                table: "HotelKamerBeddenHotelKamerVoorzieningen",
                column: "VoorzieningenId");

            migrationBuilder.CreateIndex(
                name: "IX_Voorzieningens_KamerId",
                table: "Voorzieningens",
                column: "KamerId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelKamerBeddenHotelKamerVoorzieningen");

            migrationBuilder.DropTable(
                name: "Beddens");

            migrationBuilder.DropTable(
                name: "Voorzieningens");

            migrationBuilder.DropTable(
                name: "Bedden");

            migrationBuilder.DropColumn(
                name: "Nummer",
                table: "HotelKamers");

            migrationBuilder.RenameColumn(
                name: "VoorzieningenId",
                table: "HotelKamers",
                newName: "AantalPersonen");

            migrationBuilder.AddColumn<string>(
                name: "KamerNummer",
                table: "HotelKamers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Omschrijving",
                table: "HotelKamers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "PrijsPerNacht",
                table: "HotelKamers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
