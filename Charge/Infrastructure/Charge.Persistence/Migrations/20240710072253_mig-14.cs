using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GCharge.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChargePoint_ElectricitySalesPrices_ElectricitySalesPriceId",
                table: "ChargePoint");

            migrationBuilder.DropIndex(
                name: "IX_ChargePoint_ElectricitySalesPriceId",
                table: "ChargePoint");

            migrationBuilder.DropColumn(
                name: "ElectricitySalesPriceId",
                table: "ChargePoint");

            migrationBuilder.AddColumn<string>(
                name: "ChargePointsChargePointId",
                table: "ElectricitySalesPrices",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ElectricitySalesPrices_ChargePointsChargePointId",
                table: "ElectricitySalesPrices",
                column: "ChargePointsChargePointId");

            migrationBuilder.AddForeignKey(
                name: "FK_ElectricitySalesPrices_ChargePoint_ChargePointsChargePointId",
                table: "ElectricitySalesPrices",
                column: "ChargePointsChargePointId",
                principalTable: "ChargePoint",
                principalColumn: "ChargePointId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElectricitySalesPrices_ChargePoint_ChargePointsChargePointId",
                table: "ElectricitySalesPrices");

            migrationBuilder.DropIndex(
                name: "IX_ElectricitySalesPrices_ChargePointsChargePointId",
                table: "ElectricitySalesPrices");

            migrationBuilder.DropColumn(
                name: "ChargePointsChargePointId",
                table: "ElectricitySalesPrices");

            migrationBuilder.AddColumn<Guid>(
                name: "ElectricitySalesPriceId",
                table: "ChargePoint",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChargePoint_ElectricitySalesPriceId",
                table: "ChargePoint",
                column: "ElectricitySalesPriceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChargePoint_ElectricitySalesPrices_ElectricitySalesPriceId",
                table: "ChargePoint",
                column: "ElectricitySalesPriceId",
                principalTable: "ElectricitySalesPrices",
                principalColumn: "Id");
        }
    }
}
