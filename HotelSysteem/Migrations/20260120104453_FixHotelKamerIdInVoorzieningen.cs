using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelSysteem.Migrations
{
    /// <inheritdoc />
    public partial class FixHotelKamerIdInVoorzieningen : Migration
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

            migrationBuilder.AlterColumn<int>(
                name: "KamerId",
                table: "Voorzieningens",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voorzieningens_HotelKamers_KamerId",
                table: "Voorzieningens");

            migrationBuilder.DropIndex(
                name: "IX_Voorzieningens_KamerId",
                table: "Voorzieningens");

            migrationBuilder.AlterColumn<int>(
                name: "KamerId",
                table: "Voorzieningens",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Voorzieningens_KamerId",
                table: "Voorzieningens",
                column: "KamerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Voorzieningens_HotelKamers_KamerId",
                table: "Voorzieningens",
                column: "KamerId",
                principalTable: "HotelKamers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
