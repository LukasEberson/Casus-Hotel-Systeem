using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelSysteem.Migrations
{
    /// <inheritdoc />
    public partial class UpdateReserveringKlassen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelKamerReserveringen_HotelKamerTarievens_TariefId",
                table: "HotelKamerReserveringen");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelKamerTarievens_HotelKamers_KamerId",
                table: "HotelKamerTarievens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelKamerTarievens",
                table: "HotelKamerTarievens");

            migrationBuilder.RenameTable(
                name: "HotelKamerTarievens",
                newName: "HotelKamerTarieven");

            migrationBuilder.RenameIndex(
                name: "IX_HotelKamerTarievens_KamerId",
                table: "HotelKamerTarieven",
                newName: "IX_HotelKamerTarieven_KamerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelKamerTarieven",
                table: "HotelKamerTarieven",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelKamerReserveringen_HotelKamerTarieven_TariefId",
                table: "HotelKamerReserveringen",
                column: "TariefId",
                principalTable: "HotelKamerTarieven",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelKamerTarieven_HotelKamers_KamerId",
                table: "HotelKamerTarieven",
                column: "KamerId",
                principalTable: "HotelKamers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelKamerReserveringen_HotelKamerTarieven_TariefId",
                table: "HotelKamerReserveringen");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelKamerTarieven_HotelKamers_KamerId",
                table: "HotelKamerTarieven");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelKamerTarieven",
                table: "HotelKamerTarieven");

            migrationBuilder.RenameTable(
                name: "HotelKamerTarieven",
                newName: "HotelKamerTarievens");

            migrationBuilder.RenameIndex(
                name: "IX_HotelKamerTarieven_KamerId",
                table: "HotelKamerTarievens",
                newName: "IX_HotelKamerTarievens_KamerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelKamerTarievens",
                table: "HotelKamerTarievens",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelKamerReserveringen_HotelKamerTarievens_TariefId",
                table: "HotelKamerReserveringen",
                column: "TariefId",
                principalTable: "HotelKamerTarievens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelKamerTarievens_HotelKamers_KamerId",
                table: "HotelKamerTarievens",
                column: "KamerId",
                principalTable: "HotelKamers",
                principalColumn: "Id");
        }
    }
}
