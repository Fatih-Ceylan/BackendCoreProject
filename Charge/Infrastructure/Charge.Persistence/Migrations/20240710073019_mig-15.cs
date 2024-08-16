using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GCharge.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElectricitySalesPrices_ChargePoint_ChargePointsChargePointId",
                table: "ElectricitySalesPrices");

            migrationBuilder.RenameColumn(
                name: "ChargePointsChargePointId",
                table: "ElectricitySalesPrices",
                newName: "ChargePointId");

            migrationBuilder.RenameIndex(
                name: "IX_ElectricitySalesPrices_ChargePointsChargePointId",
                table: "ElectricitySalesPrices",
                newName: "IX_ElectricitySalesPrices_ChargePointId");

            migrationBuilder.AddForeignKey(
                name: "FK_ElectricitySalesPrices_ChargePoint_ChargePointId",
                table: "ElectricitySalesPrices",
                column: "ChargePointId",
                principalTable: "ChargePoint",
                principalColumn: "ChargePointId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElectricitySalesPrices_ChargePoint_ChargePointId",
                table: "ElectricitySalesPrices");

            migrationBuilder.RenameColumn(
                name: "ChargePointId",
                table: "ElectricitySalesPrices",
                newName: "ChargePointsChargePointId");

            migrationBuilder.RenameIndex(
                name: "IX_ElectricitySalesPrices_ChargePointId",
                table: "ElectricitySalesPrices",
                newName: "IX_ElectricitySalesPrices_ChargePointsChargePointId");

            migrationBuilder.AddForeignKey(
                name: "FK_ElectricitySalesPrices_ChargePoint_ChargePointsChargePointId",
                table: "ElectricitySalesPrices",
                column: "ChargePointsChargePointId",
                principalTable: "ChargePoint",
                principalColumn: "ChargePointId");
        }
    }
}
