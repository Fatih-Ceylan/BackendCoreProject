using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Platform.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BaseProjectBranchId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BaseProjectBranchId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "BaseProjectCompanyId",
                table: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "BaseProjectCompanyId",
                table: "Orders",
                newName: "OrderIdFromModule");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderIdFromModule",
                table: "Orders",
                newName: "BaseProjectCompanyId");

            migrationBuilder.AddColumn<Guid>(
                name: "BaseProjectBranchId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BaseProjectBranchId",
                table: "OrderDetails",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BaseProjectCompanyId",
                table: "OrderDetails",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
