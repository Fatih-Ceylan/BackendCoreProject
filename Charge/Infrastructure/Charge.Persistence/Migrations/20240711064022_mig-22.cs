using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GCharge.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTransactions_UserChargeTags_UserChargeTagId",
                table: "UserTransactions");

            migrationBuilder.DropIndex(
                name: "IX_UserTransactions_UserChargeTagId",
                table: "UserTransactions");

            migrationBuilder.DropColumn(
                name: "UserChargeTagId",
                table: "UserTransactions");

            migrationBuilder.RenameColumn(
                name: "User",
                table: "UserTransactions",
                newName: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserTransactions",
                newName: "User");

            migrationBuilder.AddColumn<Guid>(
                name: "UserChargeTagId",
                table: "UserTransactions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserTransactions_UserChargeTagId",
                table: "UserTransactions",
                column: "UserChargeTagId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTransactions_UserChargeTags_UserChargeTagId",
                table: "UserTransactions",
                column: "UserChargeTagId",
                principalTable: "UserChargeTags",
                principalColumn: "Id");
        }
    }
}
