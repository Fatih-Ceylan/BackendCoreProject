using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GCharge.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserChargeTags_ChargeTags_ChargeTagTagId",
                table: "UserChargeTags");

            migrationBuilder.DropIndex(
                name: "IX_UserChargeTags_ChargeTagTagId",
                table: "UserChargeTags");

            migrationBuilder.DropColumn(
                name: "ChargeTagTagId",
                table: "UserChargeTags");

            migrationBuilder.AlterColumn<string>(
                name: "TagId",
                table: "UserChargeTags",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_UserChargeTags_TagId",
                table: "UserChargeTags",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserChargeTags_ChargeTags_TagId",
                table: "UserChargeTags",
                column: "TagId",
                principalTable: "ChargeTags",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserChargeTags_ChargeTags_TagId",
                table: "UserChargeTags");

            migrationBuilder.DropIndex(
                name: "IX_UserChargeTags_TagId",
                table: "UserChargeTags");

            migrationBuilder.AlterColumn<string>(
                name: "TagId",
                table: "UserChargeTags",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AddColumn<string>(
                name: "ChargeTagTagId",
                table: "UserChargeTags",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_UserChargeTags_ChargeTagTagId",
                table: "UserChargeTags",
                column: "ChargeTagTagId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserChargeTags_ChargeTags_ChargeTagTagId",
                table: "UserChargeTags",
                column: "ChargeTagTagId",
                principalTable: "ChargeTags",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
