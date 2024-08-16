using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GCharge.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency",
                table: "ElectricitySalesPrices");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "ElectricitySalesPrices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "ElectricitySalesPrices");

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "ElectricitySalesPrices",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
