using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GCharge.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ElectricitySalesPriceId",
                table: "ChargePoint",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ElectricitySalesPriceId1",
                table: "ChargePoint",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChargePoint_ElectricitySalesPriceId1",
                table: "ChargePoint",
                column: "ElectricitySalesPriceId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ChargePoint_ElectricitySalesPrices_ElectricitySalesPriceId1",
                table: "ChargePoint",
                column: "ElectricitySalesPriceId1",
                principalTable: "ElectricitySalesPrices",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChargePoint_ElectricitySalesPrices_ElectricitySalesPriceId1",
                table: "ChargePoint");

            migrationBuilder.DropIndex(
                name: "IX_ChargePoint_ElectricitySalesPriceId1",
                table: "ChargePoint");

            migrationBuilder.DropColumn(
                name: "ElectricitySalesPriceId",
                table: "ChargePoint");

            migrationBuilder.DropColumn(
                name: "ElectricitySalesPriceId1",
                table: "ChargePoint");
        }
    }
}
