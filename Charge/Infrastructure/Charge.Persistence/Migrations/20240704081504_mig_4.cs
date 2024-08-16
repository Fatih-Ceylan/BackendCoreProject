using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GCharge.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserChargeTags_AspNetUsers",
                table: "UserChargeTags");

            migrationBuilder.DropForeignKey(
                name: "FK_UserChargeTags_ChargeTags",
                table: "UserChargeTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserChargeTags",
                table: "UserChargeTags");

            migrationBuilder.DropIndex(
                name: "IX_UserChargeTags_TagId",
                table: "UserChargeTags");

            migrationBuilder.RenameColumn(
                name: "IsPhysicalCard",
                table: "UserChargeTags",
                newName: "IsDeleted");

            migrationBuilder.AlterColumn<string>(
                name: "TagId",
                table: "UserChargeTags",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "UserChargeTags",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "ChargeTagTagId",
                table: "UserChargeTags",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "UserChargeTags",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "UserChargeTags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "UserChargeTags",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "UserChargeTags",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "UserChargeTags",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "UserChargeTags",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserChargeTags",
                table: "UserChargeTags",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserChargeTags_ChargeTagTagId",
                table: "UserChargeTags",
                column: "ChargeTagTagId");

            migrationBuilder.CreateIndex(
                name: "IX_UserChargeTags_UserId",
                table: "UserChargeTags",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserChargeTags_AspNetUsers_UserId",
                table: "UserChargeTags",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserChargeTags_ChargeTags_ChargeTagTagId",
                table: "UserChargeTags",
                column: "ChargeTagTagId",
                principalTable: "ChargeTags",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserChargeTags_AspNetUsers_UserId",
                table: "UserChargeTags");

            migrationBuilder.DropForeignKey(
                name: "FK_UserChargeTags_ChargeTags_ChargeTagTagId",
                table: "UserChargeTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserChargeTags",
                table: "UserChargeTags");

            migrationBuilder.DropIndex(
                name: "IX_UserChargeTags_ChargeTagTagId",
                table: "UserChargeTags");

            migrationBuilder.DropIndex(
                name: "IX_UserChargeTags_UserId",
                table: "UserChargeTags");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserChargeTags");

            migrationBuilder.DropColumn(
                name: "ChargeTagTagId",
                table: "UserChargeTags");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "UserChargeTags");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "UserChargeTags");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "UserChargeTags");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "UserChargeTags");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "UserChargeTags");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "UserChargeTags");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "UserChargeTags",
                newName: "IsPhysicalCard");

            migrationBuilder.AlterColumn<string>(
                name: "TagId",
                table: "UserChargeTags",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserChargeTags",
                table: "UserChargeTags",
                columns: new[] { "UserId", "TagId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserChargeTags_TagId",
                table: "UserChargeTags",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserChargeTags_AspNetUsers",
                table: "UserChargeTags",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserChargeTags_ChargeTags",
                table: "UserChargeTags",
                column: "TagId",
                principalTable: "ChargeTags",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
