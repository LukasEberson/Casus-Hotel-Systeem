using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelSysteem.Migrations
{
    /// <inheritdoc />
    public partial class FixHotelKamerVoorzieningenIdInKamer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voorzieningens_HotelKamers_KamerId",
                table: "Voorzieningens");

            migrationBuilder.DropIndex(
                name: "IX_Voorzieningens_KamerId",
                table: "Voorzieningens");

            migrationBuilder.CreateIndex(
                name: "IX_HotelKamers_VoorzieningenId",
                table: "HotelKamers",
                column: "VoorzieningenId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelKamers_Voorzieningens_VoorzieningenId",
                table: "HotelKamers",
                column: "VoorzieningenId",
                principalTable: "Voorzieningens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelKamers_Voorzieningens_VoorzieningenId",
                table: "HotelKamers");

            migrationBuilder.DropIndex(
                name: "IX_HotelKamers_VoorzieningenId",
                table: "HotelKamers");

            migrationBuilder.CreateIndex(
                name: "IX_Voorzieningens_KamerId",
                table: "Voorzieningens",
                column: "KamerId",
                unique: true,
                filter: "[KamerId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Voorzieningens_HotelKamers_KamerId",
                table: "Voorzieningens",
                column: "KamerId",
                principalTable: "HotelKamers",
                principalColumn: "Id");
        }
    }
}
