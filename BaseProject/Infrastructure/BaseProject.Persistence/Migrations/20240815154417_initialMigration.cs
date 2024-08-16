using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseProject.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Storage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserAppellations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainAppellationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserAppellations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Card_PasswordRemakes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card_PasswordRemakes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GControl_EmployeeLabels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GControl_EmployeeLabels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GControl_EmployeeTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GControl_EmployeeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GControl_PasswordRemakes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GControl_PasswordRemakes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GControl_UserMainInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GControl_UserMainInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GCrm_CompanyContactNames",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCrm_CompanyContactNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GCrm_CompanyOffers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCrm_CompanyOffers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GCrm_CompanyTenders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCrm_CompanyTenders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GCrm_CustomerActivityKinds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCrm_CustomerActivityKinds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GCrm_CustomerActivityStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCrm_CustomerActivityStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GCrm_CustomerActivitySubjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCrm_CustomerActivitySubjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GCrm_CustomerActivityTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCrm_CustomerActivityTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GCrm_CustomerCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCrm_CustomerCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GCrm_CustomerGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerGroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerGroupType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCrm_CustomerGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GCrm_CustomerKinds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCrm_CustomerKinds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GCrm_CustomerSectors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCrm_CustomerSectors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GCrm_CustomerSources",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCrm_CustomerSources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GCrm_CustomerStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCrm_CustomerStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GCrm_CustomerTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCrm_CustomerTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GCrm_OpportunityReferences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCrm_OpportunityReferences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GCrm_OpportunitySectors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCrm_OpportunitySectors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GCrm_OpportunityStages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCrm_OpportunityStages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GCrm_ProductBrands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductBrandCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductBrandName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCrm_ProductBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GCrm_ProductCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductCategoryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryTopCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryTopCodeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCrm_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GCrm_ProductMainCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCrm_ProductMainCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GCrm_ProductManufacturers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductManufacturerCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductManufacturerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCrm_ProductManufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GCrm_ProductModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductModelCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCrm_ProductModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GCrm_ProductSubCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCrm_ProductSubCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GCrm_ProductTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCrm_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GCrm_ProjectManagers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectManagerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCrm_ProjectManagers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GCrm_ProjectStatues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCrm_ProjectStatues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GCrm_ProjectTeams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectTeamName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCrm_ProjectTeams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GCrm_ProjectType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCrm_ProjectType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GCrm_UserTitle",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TitleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCrm_UserTitle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AddressTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserAppUserFile",
                columns: table => new
                {
                    AppUserFilesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppUsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserAppUserFile", x => new { x.AppUserFilesId, x.AppUsersId });
                    table.ForeignKey(
                        name: "FK_AppUserAppUserFile_AppFiles_AppUserFilesId",
                        column: x => x.AppUserFilesId,
                        principalTable: "AppFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserLicenses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LicenseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsInUse = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserLicenses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProfileImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AppUserAppellationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_AppUserAppellations_AppUserAppellationId",
                        column: x => x.AppUserAppellationId,
                        principalTable: "AppUserAppellations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MasterCompanyIdFromPlatform = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MainCompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LogoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorizedFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaxNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxOffice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TradeRegisterNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialSecurityNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MersisNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Companies_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Companies_AspNetUsers_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Companies_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Idc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Idc);
                    table.ForeignKey(
                        name: "FK_Countries_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Countries_AspNetUsers_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Countries_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HR_Appellations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainAppellationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Appellations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HR_Appellations_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Appellations_AspNetUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Appellations_AspNetUsers_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HR_JobApplicationStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_JobApplicationStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HR_JobApplicationStatuses_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_JobApplicationStatuses_AspNetUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_JobApplicationStatuses_AspNetUsers_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HR_LeaveTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_LeaveTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HR_LeaveTypes_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_LeaveTypes_AspNetUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_LeaveTypes_AspNetUsers_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HR_Recruiters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Recruiters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HR_Recruiters_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Recruiters_AspNetUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Recruiters_AspNetUsers_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HR_RecruitmentProcesses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecruiterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_RecruitmentProcesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HR_RecruitmentProcesses_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_RecruitmentProcesses_AspNetUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_RecruitmentProcesses_AspNetUsers_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HR_SelfServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_SelfServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HR_SelfServices_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_SelfServices_AspNetUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_SelfServices_AspNetUsers_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompanyCompanyFile",
                columns: table => new
                {
                    CompaniesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyFilesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyCompanyFile", x => new { x.CompaniesId, x.CompanyFilesId });
                    table.ForeignKey(
                        name: "FK_CompanyCompanyFile_AppFiles_CompanyFilesId",
                        column: x => x.CompanyFilesId,
                        principalTable: "AppFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyCompanyFile_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyLicenses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LicenseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsInUse = table.Column<bool>(type: "bit", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyLicenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyLicenses_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyLicenses_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyLicenses_AspNetUsers_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyLicenses_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyLicenses_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GControl_Announcement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GControl_Announcement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GControl_Announcement_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GControl_ApplicationSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GControl_ApplicationSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GControl_ApplicationSettings_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GControl_Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Radius = table.Column<int>(type: "int", nullable: false),
                    EntryTimeLimit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEntryTimeLimitEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LocationOut = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GControl_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GControl_Locations_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GControl_ShiftManagements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShiftStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ShiftEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Monday = table.Column<bool>(type: "bit", nullable: false),
                    Tuesday = table.Column<bool>(type: "bit", nullable: false),
                    Wednesday = table.Column<bool>(type: "bit", nullable: false),
                    Thursday = table.Column<bool>(type: "bit", nullable: false),
                    Friday = table.Column<bool>(type: "bit", nullable: false),
                    Saturday = table.Column<bool>(type: "bit", nullable: false),
                    Sunday = table.Column<bool>(type: "bit", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GControl_ShiftManagements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GControl_ShiftManagements_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Idc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Idc);
                    table.ForeignKey(
                        name: "FK_Cities_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cities_AspNetUsers_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cities_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Idc",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HR_Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Salary = table.Column<float>(type: "real", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AppellationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ManagedDepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HR_Employees_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Employees_AspNetUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Employees_AspNetUsers_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Employees_HR_Appellations_AppellationId",
                        column: x => x.AppellationId,
                        principalTable: "HR_Appellations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HR_JobAdverts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfVacancy = table.Column<int>(type: "int", nullable: false),
                    PostingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AppellationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkLocationString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_JobAdverts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HR_JobAdverts_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_JobAdverts_AspNetUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_JobAdverts_AspNetUsers_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_JobAdverts_HR_Appellations_AppellationId",
                        column: x => x.AppellationId,
                        principalTable: "HR_Appellations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HR_JobApplicationStatusHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobApplicationStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_JobApplicationStatusHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HR_JobApplicationStatusHistories_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_JobApplicationStatusHistories_AspNetUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_JobApplicationStatusHistories_AspNetUsers_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_JobApplicationStatusHistories_HR_JobApplicationStatuses_JobApplicationStatusId",
                        column: x => x.JobApplicationStatusId,
                        principalTable: "HR_JobApplicationStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GControl_AnnouncementEmployeeLabel",
                columns: table => new
                {
                    AnnouncementsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeLabelsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GControl_AnnouncementEmployeeLabel", x => new { x.AnnouncementsId, x.EmployeeLabelsId });
                    table.ForeignKey(
                        name: "FK_GControl_AnnouncementEmployeeLabel_GControl_Announcement_AnnouncementsId",
                        column: x => x.AnnouncementsId,
                        principalTable: "GControl_Announcement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GControl_AnnouncementEmployeeLabel_GControl_EmployeeLabels_EmployeeLabelsId",
                        column: x => x.EmployeeLabelsId,
                        principalTable: "GControl_EmployeeLabels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Idc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Idc);
                    table.ForeignKey(
                        name: "FK_Districts_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Districts_AspNetUsers_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Districts_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Districts_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Idc",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HR_DepartmentManagers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_DepartmentManagers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HR_DepartmentManagers_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_DepartmentManagers_AspNetUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_DepartmentManagers_AspNetUsers_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_DepartmentManagers_HR_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "HR_Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HR_EducationInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_EducationInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HR_EducationInfos_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_EducationInfos_AspNetUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_EducationInfos_AspNetUsers_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_EducationInfos_HR_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "HR_Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HR_EmployeeRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_EmployeeRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HR_EmployeeRoles_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_EmployeeRoles_AspNetUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_EmployeeRoles_AspNetUsers_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_EmployeeRoles_HR_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "HR_Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HR_Leaves",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DayCount = table.Column<int>(type: "int", nullable: true),
                    HourCount = table.Column<double>(type: "float", nullable: true),
                    LeaveTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeReplacement = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LeaveStatus = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Leaves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HR_Leaves_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Leaves_AspNetUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Leaves_AspNetUsers_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Leaves_HR_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "HR_Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HR_Leaves_HR_LeaveTypes_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "HR_LeaveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HR_Payrolls",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DayCount = table.Column<int>(type: "int", nullable: true),
                    SalaryPaid = table.Column<double>(type: "float", nullable: true),
                    SalaryTotal = table.Column<double>(type: "float", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Payrolls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HR_Payrolls_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Payrolls_AspNetUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Payrolls_AspNetUsers_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Payrolls_HR_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "HR_Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HR_JobAdvertPostedOn",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobAdvertId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostedLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_JobAdvertPostedOn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HR_JobAdvertPostedOn_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_JobAdvertPostedOn_AspNetUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_JobAdvertPostedOn_AspNetUsers_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_JobAdvertPostedOn_HR_JobAdverts_JobAdvertId",
                        column: x => x.JobAdvertId,
                        principalTable: "HR_JobAdverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HR_JobApplicants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobAdvertId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    JobApplicantDocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_JobApplicants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HR_JobApplicants_AppFiles_JobApplicantDocumentId",
                        column: x => x.JobApplicantDocumentId,
                        principalTable: "AppFiles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_JobApplicants_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_JobApplicants_AspNetUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_JobApplicants_AspNetUsers_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_JobApplicants_HR_JobAdverts_JobAdvertId",
                        column: x => x.JobAdvertId,
                        principalTable: "HR_JobAdverts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HR_Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobAdvertId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HR_Locations_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Locations_AspNetUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Locations_AspNetUsers_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Locations_HR_JobAdverts_JobAdvertId",
                        column: x => x.JobAdvertId,
                        principalTable: "HR_JobAdverts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HR_RecruitmentSteps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobAdvertId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_RecruitmentSteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HR_RecruitmentSteps_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_RecruitmentSteps_AspNetUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_RecruitmentSteps_AspNetUsers_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_RecruitmentSteps_HR_JobAdverts_JobAdvertId",
                        column: x => x.JobAdvertId,
                        principalTable: "HR_JobAdverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorizedFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    DistrictId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branches_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Branches_AspNetUsers_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Branches_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Branches_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Branches_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Idc");
                });

            migrationBuilder.CreateTable(
                name: "CompanyAddresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    DistrictId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyAddresses_AddressTypes_AddressTypeId",
                        column: x => x.AddressTypeId,
                        principalTable: "AddressTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyAddresses_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyAddresses_AspNetUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyAddresses_AspNetUsers_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyAddresses_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyAddresses_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Idc");
                });

            migrationBuilder.CreateTable(
                name: "HR_RoleTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeRolesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_RoleTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HR_RoleTypes_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_RoleTypes_AspNetUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_RoleTypes_AspNetUsers_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_RoleTypes_HR_EmployeeRoles_EmployeeRolesId",
                        column: x => x.EmployeeRolesId,
                        principalTable: "HR_EmployeeRoles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HR_JobApplications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobApplicantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecruiterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RecruitmentProcessId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    JobApplicationStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobAdvertId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_JobApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HR_JobApplications_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_JobApplications_AspNetUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_JobApplications_AspNetUsers_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_JobApplications_HR_JobAdverts_JobAdvertId",
                        column: x => x.JobAdvertId,
                        principalTable: "HR_JobAdverts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_JobApplications_HR_JobApplicants_JobApplicantId",
                        column: x => x.JobApplicantId,
                        principalTable: "HR_JobApplicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HR_JobApplications_HR_JobApplicationStatuses_JobApplicationStatusId",
                        column: x => x.JobApplicationStatusId,
                        principalTable: "HR_JobApplicationStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HR_JobApplications_HR_Recruiters_RecruiterId",
                        column: x => x.RecruiterId,
                        principalTable: "HR_Recruiters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_JobApplications_HR_RecruitmentProcesses_RecruitmentProcessId",
                        column: x => x.RecruitmentProcessId,
                        principalTable: "HR_RecruitmentProcesses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HR_Notes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecruiterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoteText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HR_Notes_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Notes_AspNetUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Notes_AspNetUsers_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_Notes_HR_JobApplicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "HR_JobApplicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HR_Notes_HR_Recruiters_RecruiterId",
                        column: x => x.RecruiterId,
                        principalTable: "HR_Recruiters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HR_RecruitmentProcessSteps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecruitmentProcessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecruitmentStepId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_RecruitmentProcessSteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HR_RecruitmentProcessSteps_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_RecruitmentProcessSteps_AspNetUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_RecruitmentProcessSteps_AspNetUsers_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_RecruitmentProcessSteps_HR_RecruitmentProcesses_RecruitmentProcessId",
                        column: x => x.RecruitmentProcessId,
                        principalTable: "HR_RecruitmentProcesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HR_RecruitmentProcessSteps_HR_RecruitmentSteps_RecruitmentStepId",
                        column: x => x.RecruitmentStepId,
                        principalTable: "HR_RecruitmentSteps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Base_MailCredentials",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Port = table.Column<int>(type: "int", nullable: false),
                    Host = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnableSsl = table.Column<bool>(type: "bit", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Base_MailCredentials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Base_MailCredentials_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Base_MailCredentials_AspNetUsers_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Base_MailCredentials_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Base_MailCredentials_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Base_MailCredentials_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainDepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Departments_AspNetUsers_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Departments_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Departments_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Card_Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressLine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Card_Addresses_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Card_Cargos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxRate = table.Column<int>(type: "int", nullable: false),
                    CargoPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card_Cargos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Card_Cargos_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Card_Fields",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card_Fields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Card_Fields_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Card_SocialMedias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card_SocialMedias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Card_SocialMedias_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Card_Staffs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePicturePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card_Staffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Card_Staffs_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GCrm_Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DefaultContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CustomerStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerKindId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CustomerTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CustomerRepresentativeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CustomerSectorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerSourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrackStatus = table.Column<bool>(type: "bit", nullable: false),
                    TaxOffice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentType = table.Column<int>(type: "int", nullable: true),
                    CurrencyType = table.Column<int>(type: "int", nullable: true),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RiskStatus = table.Column<int>(type: "int", nullable: true),
                    SkypeAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkedinAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacebookAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwitterAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerRating = table.Column<double>(type: "float", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaxNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CustomerFileId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCrm_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GCrm_Customers_AppFiles_CustomerFileId",
                        column: x => x.CustomerFileId,
                        principalTable: "AppFiles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GCrm_Customers_AspNetUsers_CustomerRepresentativeId",
                        column: x => x.CustomerRepresentativeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GCrm_Customers_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GCrm_Customers_GCrm_CustomerGroups_CustomerGroupId",
                        column: x => x.CustomerGroupId,
                        principalTable: "GCrm_CustomerGroups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GCrm_Customers_GCrm_CustomerKinds_CustomerKindId",
                        column: x => x.CustomerKindId,
                        principalTable: "GCrm_CustomerKinds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GCrm_Customers_GCrm_CustomerSectors_CustomerSectorId",
                        column: x => x.CustomerSectorId,
                        principalTable: "GCrm_CustomerSectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GCrm_Customers_GCrm_CustomerSources_CustomerSourceId",
                        column: x => x.CustomerSourceId,
                        principalTable: "GCrm_CustomerSources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GCrm_Customers_GCrm_CustomerStatuses_CustomerStatusId",
                        column: x => x.CustomerStatusId,
                        principalTable: "GCrm_CustomerStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GCrm_Customers_GCrm_CustomerTypes_CustomerTypeId",
                        column: x => x.CustomerTypeId,
                        principalTable: "GCrm_CustomerTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GCrm_Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductServiceEnum = table.Column<int>(type: "int", nullable: false),
                    ProductMainCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductSubCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductBrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductManufacturerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductShortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ForeignName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EANNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UPCCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BarcodeTypeEnum = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManufacturerCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropductDimensions = table.Column<int>(type: "int", nullable: false),
                    PiecesBox = table.Column<int>(type: "int", nullable: false),
                    WarehouseLocationCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkingConditionEnum = table.Column<int>(type: "int", nullable: false),
                    ProductStatuEnum = table.Column<int>(type: "int", nullable: false),
                    ProductCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductUnitEnum = table.Column<int>(type: "int", nullable: false),
                    StandartCost = table.Column<int>(type: "int", nullable: false),
                    CurrencyTypeEnum = table.Column<int>(type: "int", nullable: false),
                    PurchasePrice = table.Column<int>(type: "int", nullable: false),
                    SpecialPurchasePrice = table.Column<int>(type: "int", nullable: false),
                    PurchaseDiscount = table.Column<int>(type: "int", nullable: false),
                    SalePrice = table.Column<int>(type: "int", nullable: false),
                    SalePriceA = table.Column<int>(type: "int", nullable: false),
                    SalePriceB = table.Column<int>(type: "int", nullable: false),
                    SalePriceC = table.Column<int>(type: "int", nullable: false),
                    SalePriceD = table.Column<int>(type: "int", nullable: false),
                    SalesDiscount = table.Column<int>(type: "int", nullable: false),
                    ProductKdvEnum = table.Column<int>(type: "int", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCrm_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GCrm_Products_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GCrm_Products_GCrm_ProductBrands_ProductBrandId",
                        column: x => x.ProductBrandId,
                        principalTable: "GCrm_ProductBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GCrm_Products_GCrm_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "GCrm_ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GCrm_Products_GCrm_ProductMainCategories_ProductMainCategoryId",
                        column: x => x.ProductMainCategoryId,
                        principalTable: "GCrm_ProductMainCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GCrm_Products_GCrm_ProductManufacturers_ProductManufacturerId",
                        column: x => x.ProductManufacturerId,
                        principalTable: "GCrm_ProductManufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GCrm_Products_GCrm_ProductModels_ProductModelId",
                        column: x => x.ProductModelId,
                        principalTable: "GCrm_ProductModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GCrm_Products_GCrm_ProductSubCategories_ProductSubCategoryId",
                        column: x => x.ProductSubCategoryId,
                        principalTable: "GCrm_ProductSubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GCrm_Products_GCrm_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "GCrm_ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GCrm_Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPassword = table.Column<int>(type: "int", nullable: false),
                    UserPasswordRepeat = table.Column<int>(type: "int", nullable: false),
                    DataTransfer = table.Column<bool>(type: "bit", nullable: false),
                    UserCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserTitleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PriceNameEnum = table.Column<int>(type: "int", nullable: false),
                    GenderEnum = table.Column<int>(type: "int", nullable: false),
                    HomePhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobilePhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomeAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartWorkhDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishWorkhDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdentificationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BloodGroupEnum = table.Column<int>(type: "int", nullable: false),
                    EducationalStatuEnum = table.Column<int>(type: "int", nullable: false),
                    GraduationSchoolName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GraduationFacultyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GraduationSchoolDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaritalStatusEnum = table.Column<int>(type: "int", nullable: false),
                    MarriageDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserStatuEnum = table.Column<int>(type: "int", nullable: false),
                    AdminUser = table.Column<bool>(type: "bit", nullable: false),
                    UserPicture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCrm_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GCrm_Users_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GCrm_Users_AspNetUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GCrm_Users_AspNetUsers_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GCrm_Users_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GCrm_Users_GCrm_UserTitle_UserTitleId",
                        column: x => x.UserTitleId,
                        principalTable: "GCrm_UserTitle",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GControl_Department",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BaseDepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GControl_Department", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GControl_Department_Departments_BaseDepartmentId",
                        column: x => x.BaseDepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GControl_Department_GControl_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "GControl_Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GControl_Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfilePicturePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartWorkDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmployeeTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GControl_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GControl_Employees_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GControl_Employees_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GControl_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GControl_Employees_GControl_EmployeeTypes_EmployeeTypeId",
                        column: x => x.EmployeeTypeId,
                        principalTable: "GControl_EmployeeTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GControl_Employees_GControl_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "GControl_Locations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HR_JobHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_JobHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HR_JobHistories_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_JobHistories_AspNetUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_JobHistories_AspNetUsers_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_JobHistories_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HR_JobHistories_HR_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "HR_Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Card_Ibans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IbanNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StaffId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card_Ibans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Card_Ibans_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Card_Ibans_Card_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Card_Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Card_PhoneNumbers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card_PhoneNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Card_PhoneNumbers_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Card_PhoneNumbers_Card_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Card_Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Card_SocialMediaUrls",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UrlPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StaffId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SocialMediaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card_SocialMediaUrls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Card_SocialMediaUrls_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Card_SocialMediaUrls_Card_SocialMedias_SocialMediaId",
                        column: x => x.SocialMediaId,
                        principalTable: "Card_SocialMedias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Card_SocialMediaUrls_Card_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Card_Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Card_StaffContacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StaffId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card_StaffContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Card_StaffContacts_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Card_StaffContacts_Card_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Card_Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Card_StaffFields",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RowNumber = table.Column<int>(type: "int", nullable: false),
                    StaffId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card_StaffFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Card_StaffFields_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Card_StaffFields_Card_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Card_Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Card_StaffFields_Card_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Card_Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Card_StaffStaffFile",
                columns: table => new
                {
                    StaffFilesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StaffsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card_StaffStaffFile", x => new { x.StaffFilesId, x.StaffsId });
                    table.ForeignKey(
                        name: "FK_Card_StaffStaffFile_AppFiles_StaffFilesId",
                        column: x => x.StaffFilesId,
                        principalTable: "AppFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Card_StaffStaffFile_Card_Staffs_StaffsId",
                        column: x => x.StaffsId,
                        principalTable: "Card_Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GCrm_CustomerAddresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressType = table.Column<int>(type: "int", nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    DistrictId = table.Column<int>(type: "int", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegionCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCrm_CustomerAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GCrm_CustomerAddresses_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Idc");
                    table.ForeignKey(
                        name: "FK_GCrm_CustomerAddresses_GCrm_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "GCrm_Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GCrm_CustomerContacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InternalNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaxNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressType = table.Column<int>(type: "int", nullable: true),
                    DecisionStatus = table.Column<int>(type: "int", nullable: false),
                    RelationCompany = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MaritalStatus = table.Column<int>(type: "int", nullable: true),
                    MarriageDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AssistantName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssistantPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardVisitImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCrm_CustomerContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GCrm_CustomerContacts_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GCrm_CustomerContacts_GCrm_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "GCrm_Customers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GCrm_CustomersCustomerCategories",
                columns: table => new
                {
                    CustomerCategoriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCrm_CustomersCustomerCategories", x => new { x.CustomerCategoriesId, x.CustomersId });
                    table.ForeignKey(
                        name: "FK_GCrm_CustomersCustomerCategories_GCrm_CustomerCategories_CustomerCategoriesId",
                        column: x => x.CustomerCategoriesId,
                        principalTable: "GCrm_CustomerCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GCrm_CustomersCustomerCategories_GCrm_Customers_CustomersId",
                        column: x => x.CustomersId,
                        principalTable: "GCrm_Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GCrm_Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectTeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectStatuesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectFinishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectPriorityEnum = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCrm_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GCrm_Projects_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GCrm_Projects_GCrm_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "GCrm_Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GCrm_Projects_GCrm_ProjectManagers_ProjectManagerId",
                        column: x => x.ProjectManagerId,
                        principalTable: "GCrm_ProjectManagers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GCrm_Projects_GCrm_ProjectStatues_ProjectStatuesId",
                        column: x => x.ProjectStatuesId,
                        principalTable: "GCrm_ProjectStatues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GCrm_Projects_GCrm_ProjectTeams_ProjectTeamId",
                        column: x => x.ProjectTeamId,
                        principalTable: "GCrm_ProjectTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GCrm_Projects_GCrm_ProjectType_ProjectTypeId",
                        column: x => x.ProjectTypeId,
                        principalTable: "GCrm_ProjectType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GControl_AnnouncementDepartment",
                columns: table => new
                {
                    AnnouncementsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GControl_AnnouncementDepartment", x => new { x.AnnouncementsId, x.DepartmentsId });
                    table.ForeignKey(
                        name: "FK_GControl_AnnouncementDepartment_GControl_Announcement_AnnouncementsId",
                        column: x => x.AnnouncementsId,
                        principalTable: "GControl_Announcement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GControl_AnnouncementDepartment_GControl_Department_DepartmentsId",
                        column: x => x.DepartmentsId,
                        principalTable: "GControl_Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GControl_ApplicationSettingEmployee",
                columns: table => new
                {
                    ApplicationSettingsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GControl_ApplicationSettingEmployee", x => new { x.ApplicationSettingsId, x.EmployeesId });
                    table.ForeignKey(
                        name: "FK_GControl_ApplicationSettingEmployee_GControl_ApplicationSettings_ApplicationSettingsId",
                        column: x => x.ApplicationSettingsId,
                        principalTable: "GControl_ApplicationSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GControl_ApplicationSettingEmployee_GControl_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "GControl_Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GControl_EmployeeEmployeeFile",
                columns: table => new
                {
                    EmployeeFilesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GControl_EmployeeEmployeeFile", x => new { x.EmployeeFilesId, x.EmployeesId });
                    table.ForeignKey(
                        name: "FK_GControl_EmployeeEmployeeFile_AppFiles_EmployeeFilesId",
                        column: x => x.EmployeeFilesId,
                        principalTable: "AppFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GControl_EmployeeEmployeeFile_GControl_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "GControl_Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GControl_EmployeeEmployeeLabel",
                columns: table => new
                {
                    EmployeeLabelsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GControl_EmployeeEmployeeLabel", x => new { x.EmployeeLabelsId, x.EmployeesId });
                    table.ForeignKey(
                        name: "FK_GControl_EmployeeEmployeeLabel_GControl_EmployeeLabels_EmployeeLabelsId",
                        column: x => x.EmployeeLabelsId,
                        principalTable: "GControl_EmployeeLabels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GControl_EmployeeEmployeeLabel_GControl_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "GControl_Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GControl_EmployeeShiftManagement",
                columns: table => new
                {
                    EmployeesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShiftManagementsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GControl_EmployeeShiftManagement", x => new { x.EmployeesId, x.ShiftManagementsId });
                    table.ForeignKey(
                        name: "FK_GControl_EmployeeShiftManagement_GControl_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "GControl_Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GControl_EmployeeShiftManagement_GControl_ShiftManagements_ShiftManagementsId",
                        column: x => x.ShiftManagementsId,
                        principalTable: "GControl_ShiftManagements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GControl_EntryExitManagements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsLocationOut = table.Column<bool>(type: "bit", nullable: false),
                    IsRegistrationType = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GControl_EntryExitManagements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GControl_EntryExitManagements_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GControl_EntryExitManagements_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GControl_EntryExitManagements_GControl_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "GControl_Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GControl_EntryExitManagements_GControl_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "GControl_Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GCrm_CustomerActivities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerActivitySubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerActivityTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerActivityKindId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerActivityStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActivityDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReminderDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OfferCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpportunityCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailStatus = table.Column<bool>(type: "bit", nullable: false),
                    ActivityAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivityDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCrm_CustomerActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GCrm_CustomerActivities_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GCrm_CustomerActivities_GCrm_CustomerActivityKinds_CustomerActivityKindId",
                        column: x => x.CustomerActivityKindId,
                        principalTable: "GCrm_CustomerActivityKinds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GCrm_CustomerActivities_GCrm_CustomerActivityStatuses_CustomerActivityStatusId",
                        column: x => x.CustomerActivityStatusId,
                        principalTable: "GCrm_CustomerActivityStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GCrm_CustomerActivities_GCrm_CustomerActivitySubjects_CustomerActivitySubjectId",
                        column: x => x.CustomerActivitySubjectId,
                        principalTable: "GCrm_CustomerActivitySubjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GCrm_CustomerActivities_GCrm_CustomerActivityTypes_CustomerActivityTypeId",
                        column: x => x.CustomerActivityTypeId,
                        principalTable: "GCrm_CustomerActivityTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GCrm_CustomerActivities_GCrm_CustomerContacts_CustomerContactId",
                        column: x => x.CustomerContactId,
                        principalTable: "GCrm_CustomerContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GCrm_CustomerActivities_GCrm_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "GCrm_Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GCrm_Opportunities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SalesUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OpportunitySubject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpportunitySectorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenderCustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OfferCustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OfferCustomerContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OpportunityStageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenderBroadcastDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SpecificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinalOfferDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemainingTime = table.Column<int>(type: "int", nullable: true),
                    SolutionOffer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandsOffered = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpportunityReferenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReferrerPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpportunityTotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OpportunityTotalAmountEnum = table.Column<int>(type: "int", nullable: true),
                    PotentialAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PotentialAmountEnum = table.Column<int>(type: "int", nullable: true),
                    OpportunityStatu = table.Column<int>(type: "int", nullable: true),
                    ProbabilityWinning = table.Column<int>(type: "int", nullable: true),
                    EstimatedEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OpportunityLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionTaken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CustomerContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCrm_Opportunities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GCrm_Opportunities_AspNetUsers_SalesUserId",
                        column: x => x.SalesUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GCrm_Opportunities_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GCrm_Opportunities_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GCrm_Opportunities_GCrm_CustomerContacts_CustomerContactId",
                        column: x => x.CustomerContactId,
                        principalTable: "GCrm_CustomerContacts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GCrm_Opportunities_GCrm_Customers_OfferCustomerId",
                        column: x => x.OfferCustomerId,
                        principalTable: "GCrm_Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GCrm_Opportunities_GCrm_Customers_TenderCustomerId",
                        column: x => x.TenderCustomerId,
                        principalTable: "GCrm_Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GCrm_Opportunities_GCrm_OpportunityReferences_OpportunityReferenceId",
                        column: x => x.OpportunityReferenceId,
                        principalTable: "GCrm_OpportunityReferences",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GCrm_Opportunities_GCrm_OpportunitySectors_OpportunitySectorId",
                        column: x => x.OpportunitySectorId,
                        principalTable: "GCrm_OpportunitySectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GCrm_Opportunities_GCrm_OpportunityStages_OpportunityStageId",
                        column: x => x.OpportunityStageId,
                        principalTable: "GCrm_OpportunityStages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GCrm_Opportunities_GCrm_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "GCrm_Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GCrm_ProjectProjectFiles",
                columns: table => new
                {
                    ProjectFilesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCrm_ProjectProjectFiles", x => new { x.ProjectFilesId, x.ProjectsId });
                    table.ForeignKey(
                        name: "FK_GCrm_ProjectProjectFiles_AppFiles_ProjectFilesId",
                        column: x => x.ProjectFilesId,
                        principalTable: "AppFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GCrm_ProjectProjectFiles_GCrm_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "GCrm_Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GCrm_CustomerActivityTeams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerActivityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CustomerActivityTeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCrm_CustomerActivityTeams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GCrm_CustomerActivityTeams_GCrm_CustomerActivities_CustomerActivityId",
                        column: x => x.CustomerActivityId,
                        principalTable: "GCrm_CustomerActivities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GCrm_CustomerActivityTeams_GCrm_CustomerActivityTeams_CustomerActivityTeamId",
                        column: x => x.CustomerActivityTeamId,
                        principalTable: "GCrm_CustomerActivityTeams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GCrm_SolutionOffers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpportunityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCrm_SolutionOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GCrm_SolutionOffers_GCrm_Opportunities_OpportunityId",
                        column: x => x.OpportunityId,
                        principalTable: "GCrm_Opportunities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Card_Cards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxRate = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card_Cards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Card_Invoices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BillingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Card_Invoices_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Card_Invoices_Card_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Card_Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Card_Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true),
                    PaymentStatus = table.Column<int>(type: "int", nullable: true),
                    OrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeneralTotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GeneralTotalTaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CargoTrackingNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuyerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Card_Orders_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Card_Orders_Card_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Card_Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Card_Orders_Card_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Card_Invoices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Card_OrderDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalTaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxRate = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PurchasedForStaffId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Card_OrderDetails_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Card_OrderDetails_Card_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Card_Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Card_OrderDetails_Card_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Card_Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Card_OrderDetails_Card_Staffs_PurchasedForStaffId",
                        column: x => x.PurchasedForStaffId,
                        principalTable: "Card_Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Card_OrderDetails_Card_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Card_Staffs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressTypes_CreatedBy",
                table: "AddressTypes",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AddressTypes_DeletedBy",
                table: "AddressTypes",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AddressTypes_UpdatedBy",
                table: "AddressTypes",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserAppUserFile_AppUsersId",
                table: "AppUserAppUserFile",
                column: "AppUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserLicenses_AppUserId",
                table: "AppUserLicenses",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserLicenses_CreatedBy",
                table: "AppUserLicenses",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserLicenses_DeletedBy",
                table: "AppUserLicenses",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserLicenses_UpdatedBy",
                table: "AppUserLicenses",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AppUserAppellationId",
                table: "AspNetUsers",
                column: "AppUserAppellationId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DepartmentId",
                table: "AspNetUsers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Base_MailCredentials_BranchId",
                table: "Base_MailCredentials",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Base_MailCredentials_CreatedBy",
                table: "Base_MailCredentials",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Base_MailCredentials_DeletedBy",
                table: "Base_MailCredentials",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Base_MailCredentials_UpdatedBy",
                table: "Base_MailCredentials",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Base_MailCredentials_UserId",
                table: "Base_MailCredentials",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_CompanyId",
                table: "Branches",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_CreatedBy",
                table: "Branches",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_DeletedBy",
                table: "Branches",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_DistrictId",
                table: "Branches",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_UpdatedBy",
                table: "Branches",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CreatedBy",
                table: "Cities",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_DeletedBy",
                table: "Cities",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_UpdatedBy",
                table: "Cities",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_AppUserId",
                table: "Companies",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CreatedBy",
                table: "Companies",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_DeletedBy",
                table: "Companies",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_UpdatedBy",
                table: "Companies",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAddresses_AddressTypeId",
                table: "CompanyAddresses",
                column: "AddressTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAddresses_CompanyId",
                table: "CompanyAddresses",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAddresses_CreatedByUserId",
                table: "CompanyAddresses",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAddresses_DeletedByUserId",
                table: "CompanyAddresses",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAddresses_DistrictId",
                table: "CompanyAddresses",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAddresses_UpdatedByUserId",
                table: "CompanyAddresses",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCompanyFile_CompanyFilesId",
                table: "CompanyCompanyFile",
                column: "CompanyFilesId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyLicenses_AppUserId",
                table: "CompanyLicenses",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyLicenses_CompanyId",
                table: "CompanyLicenses",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyLicenses_CreatedBy",
                table: "CompanyLicenses",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyLicenses_DeletedBy",
                table: "CompanyLicenses",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyLicenses_UpdatedBy",
                table: "CompanyLicenses",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CreatedBy",
                table: "Countries",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_DeletedBy",
                table: "Countries",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_UpdatedBy",
                table: "Countries",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_BranchId",
                table: "Departments",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CreatedBy",
                table: "Departments",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DeletedBy",
                table: "Departments",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_UpdatedBy",
                table: "Departments",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_CityId",
                table: "Districts",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_CreatedBy",
                table: "Districts",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_DeletedBy",
                table: "Districts",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_UpdatedBy",
                table: "Districts",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Card_Addresses_BranchId",
                table: "Card_Addresses",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_Cards_OrderId",
                table: "Card_Cards",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_Cargos_BranchId",
                table: "Card_Cargos",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_Fields_BranchId",
                table: "Card_Fields",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_Ibans_BranchId",
                table: "Card_Ibans",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_Ibans_StaffId",
                table: "Card_Ibans",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_Invoices_BranchId",
                table: "Card_Invoices",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_Invoices_CardId",
                table: "Card_Invoices",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_OrderDetails_BranchId",
                table: "Card_OrderDetails",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_OrderDetails_CardId",
                table: "Card_OrderDetails",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_OrderDetails_OrderId",
                table: "Card_OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_OrderDetails_PurchasedForStaffId",
                table: "Card_OrderDetails",
                column: "PurchasedForStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_OrderDetails_StaffId",
                table: "Card_OrderDetails",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_Orders_AddressId",
                table: "Card_Orders",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_Orders_BranchId",
                table: "Card_Orders",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_Orders_InvoiceId",
                table: "Card_Orders",
                column: "InvoiceId",
                unique: true,
                filter: "[InvoiceId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Card_PhoneNumbers_BranchId",
                table: "Card_PhoneNumbers",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_PhoneNumbers_StaffId",
                table: "Card_PhoneNumbers",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_SocialMedias_BranchId",
                table: "Card_SocialMedias",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_SocialMediaUrls_BranchId",
                table: "Card_SocialMediaUrls",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_SocialMediaUrls_SocialMediaId",
                table: "Card_SocialMediaUrls",
                column: "SocialMediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_SocialMediaUrls_StaffId",
                table: "Card_SocialMediaUrls",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_StaffContacts_BranchId",
                table: "Card_StaffContacts",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_StaffContacts_StaffId",
                table: "Card_StaffContacts",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_StaffFields_BranchId",
                table: "Card_StaffFields",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_StaffFields_FieldId",
                table: "Card_StaffFields",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_StaffFields_StaffId",
                table: "Card_StaffFields",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_Staffs_BranchId",
                table: "Card_Staffs",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_StaffStaffFile_StaffsId",
                table: "Card_StaffStaffFile",
                column: "StaffsId");

            migrationBuilder.CreateIndex(
                name: "IX_GControl_Announcement_CompanyId",
                table: "GControl_Announcement",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_GControl_AnnouncementDepartment_DepartmentsId",
                table: "GControl_AnnouncementDepartment",
                column: "DepartmentsId");

            migrationBuilder.CreateIndex(
                name: "IX_GControl_AnnouncementEmployeeLabel_EmployeeLabelsId",
                table: "GControl_AnnouncementEmployeeLabel",
                column: "EmployeeLabelsId");

            migrationBuilder.CreateIndex(
                name: "IX_GControl_ApplicationSettingEmployee_EmployeesId",
                table: "GControl_ApplicationSettingEmployee",
                column: "EmployeesId");

            migrationBuilder.CreateIndex(
                name: "IX_GControl_ApplicationSettings_CompanyId",
                table: "GControl_ApplicationSettings",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_GControl_Department_BaseDepartmentId",
                table: "GControl_Department",
                column: "BaseDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_GControl_Department_LocationId",
                table: "GControl_Department",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_GControl_EmployeeEmployeeFile_EmployeesId",
                table: "GControl_EmployeeEmployeeFile",
                column: "EmployeesId");

            migrationBuilder.CreateIndex(
                name: "IX_GControl_EmployeeEmployeeLabel_EmployeesId",
                table: "GControl_EmployeeEmployeeLabel",
                column: "EmployeesId");

            migrationBuilder.CreateIndex(
                name: "IX_GControl_Employees_BranchId",
                table: "GControl_Employees",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_GControl_Employees_CompanyId",
                table: "GControl_Employees",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_GControl_Employees_DepartmentId",
                table: "GControl_Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_GControl_Employees_EmployeeTypeId",
                table: "GControl_Employees",
                column: "EmployeeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GControl_Employees_LocationId",
                table: "GControl_Employees",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_GControl_EmployeeShiftManagement_ShiftManagementsId",
                table: "GControl_EmployeeShiftManagement",
                column: "ShiftManagementsId");

            migrationBuilder.CreateIndex(
                name: "IX_GControl_EntryExitManagements_BranchId",
                table: "GControl_EntryExitManagements",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_GControl_EntryExitManagements_CompanyId",
                table: "GControl_EntryExitManagements",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_GControl_EntryExitManagements_EmployeeId",
                table: "GControl_EntryExitManagements",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_GControl_EntryExitManagements_LocationId",
                table: "GControl_EntryExitManagements",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_GControl_Locations_CompanyId",
                table: "GControl_Locations",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_GControl_ShiftManagements_CompanyId",
                table: "GControl_ShiftManagements",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_CustomerActivities_BranchId",
                table: "GCrm_CustomerActivities",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_CustomerActivities_CustomerActivityKindId",
                table: "GCrm_CustomerActivities",
                column: "CustomerActivityKindId");

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_CustomerActivities_CustomerActivityStatusId",
                table: "GCrm_CustomerActivities",
                column: "CustomerActivityStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_CustomerActivities_CustomerActivitySubjectId",
                table: "GCrm_CustomerActivities",
                column: "CustomerActivitySubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_CustomerActivities_CustomerActivityTypeId",
                table: "GCrm_CustomerActivities",
                column: "CustomerActivityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_CustomerActivities_CustomerContactId",
                table: "GCrm_CustomerActivities",
                column: "CustomerContactId");

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_CustomerActivities_CustomerId",
                table: "GCrm_CustomerActivities",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_CustomerActivityTeams_CustomerActivityId",
                table: "GCrm_CustomerActivityTeams",
                column: "CustomerActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_CustomerActivityTeams_CustomerActivityTeamId",
                table: "GCrm_CustomerActivityTeams",
                column: "CustomerActivityTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_CustomerAddresses_CustomerId",
                table: "GCrm_CustomerAddresses",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_CustomerAddresses_DistrictId",
                table: "GCrm_CustomerAddresses",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_CustomerContacts_BranchId",
                table: "GCrm_CustomerContacts",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_CustomerContacts_CustomerId",
                table: "GCrm_CustomerContacts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_Customers_BranchId",
                table: "GCrm_Customers",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_Customers_CustomerFileId",
                table: "GCrm_Customers",
                column: "CustomerFileId");

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_Customers_CustomerGroupId",
                table: "GCrm_Customers",
                column: "CustomerGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_Customers_CustomerKindId",
                table: "GCrm_Customers",
                column: "CustomerKindId");

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_Customers_CustomerRepresentativeId",
                table: "GCrm_Customers",
                column: "CustomerRepresentativeId");

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_Customers_CustomerSectorId",
                table: "GCrm_Customers",
                column: "CustomerSectorId");

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_Customers_CustomerSourceId",
                table: "GCrm_Customers",
                column: "CustomerSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_Customers_CustomerStatusId",
                table: "GCrm_Customers",
                column: "CustomerStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_Customers_CustomerTypeId",
                table: "GCrm_Customers",
                column: "CustomerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_CustomersCustomerCategories_CustomersId",
                table: "GCrm_CustomersCustomerCategories",
                column: "CustomersId");

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_Opportunities_BranchId",
                table: "GCrm_Opportunities",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_Opportunities_CompanyId",
                table: "GCrm_Opportunities",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_Opportunities_CustomerContactId",
                table: "GCrm_Opportunities",
                column: "CustomerContactId");

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_Opportunities_OfferCustomerId",
                table: "GCrm_Opportunities",
                column: "OfferCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_Opportunities_OpportunityReferenceId",
                table: "GCrm_Opportunities",
                column: "OpportunityReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_Opportunities_OpportunitySectorId",
                table: "GCrm_Opportunities",
                column: "OpportunitySectorId");

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_Opportunities_OpportunityStageId",
                table: "GCrm_Opportunities",
                column: "OpportunityStageId");

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_Opportunities_SalesUserId",
                table: "GCrm_Opportunities",
                column: "SalesUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_Opportunities_TenderCustomerId",
                table: "GCrm_Opportunities",
                column: "TenderCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_Opportunities_UsersId",
                table: "GCrm_Opportunities",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_Products_BranchId",
                table: "GCrm_Products",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_Products_ProductBrandId",
                table: "GCrm_Products",
                column: "ProductBrandId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_Products_ProductCategoryId",
                table: "GCrm_Products",
                column: "ProductCategoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_Products_ProductMainCategoryId",
                table: "GCrm_Products",
                column: "ProductMainCategoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_Products_ProductManufacturerId",
                table: "GCrm_Products",
                column: "ProductManufacturerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_Products_ProductModelId",
                table: "GCrm_Products",
                column: "ProductModelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_Products_ProductSubCategoryId",
                table: "GCrm_Products",
                column: "ProductSubCategoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_Products_ProductTypeId",
                table: "GCrm_Products",
                column: "ProductTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_ProjectProjectFiles_ProjectsId",
                table: "GCrm_ProjectProjectFiles",
                column: "ProjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_Projects_BranchId",
                table: "GCrm_Projects",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_Projects_CustomerId",
                table: "GCrm_Projects",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_Projects_ProjectManagerId",
                table: "GCrm_Projects",
                column: "ProjectManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_Projects_ProjectStatuesId",
                table: "GCrm_Projects",
                column: "ProjectStatuesId");

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_Projects_ProjectTeamId",
                table: "GCrm_Projects",
                column: "ProjectTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_Projects_ProjectTypeId",
                table: "GCrm_Projects",
                column: "ProjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_SolutionOffers_OpportunityId",
                table: "GCrm_SolutionOffers",
                column: "OpportunityId");

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_Users_BranchId",
                table: "GCrm_Users",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_Users_CreatedByUserId",
                table: "GCrm_Users",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_Users_DeletedByUserId",
                table: "GCrm_Users",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_Users_UpdatedByUserId",
                table: "GCrm_Users",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GCrm_Users_UserTitleId",
                table: "GCrm_Users",
                column: "UserTitleId",
                unique: true,
                filter: "[UserTitleId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Appellations_CreatedByUserId",
                table: "HR_Appellations",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Appellations_DeletedByUserId",
                table: "HR_Appellations",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Appellations_UpdatedByUserId",
                table: "HR_Appellations",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_DepartmentManagers_CreatedByUserId",
                table: "HR_DepartmentManagers",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_DepartmentManagers_DeletedByUserId",
                table: "HR_DepartmentManagers",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_DepartmentManagers_EmployeeId",
                table: "HR_DepartmentManagers",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_DepartmentManagers_UpdatedByUserId",
                table: "HR_DepartmentManagers",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_EducationInfos_CreatedByUserId",
                table: "HR_EducationInfos",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_EducationInfos_DeletedByUserId",
                table: "HR_EducationInfos",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_EducationInfos_EmployeeId",
                table: "HR_EducationInfos",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_EducationInfos_UpdatedByUserId",
                table: "HR_EducationInfos",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_EmployeeRoles_CreatedByUserId",
                table: "HR_EmployeeRoles",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_EmployeeRoles_DeletedByUserId",
                table: "HR_EmployeeRoles",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_EmployeeRoles_EmployeeId",
                table: "HR_EmployeeRoles",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_EmployeeRoles_UpdatedByUserId",
                table: "HR_EmployeeRoles",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Employees_AppellationId",
                table: "HR_Employees",
                column: "AppellationId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Employees_CreatedByUserId",
                table: "HR_Employees",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Employees_DeletedByUserId",
                table: "HR_Employees",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Employees_UpdatedByUserId",
                table: "HR_Employees",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_JobAdvertPostedOn_CreatedByUserId",
                table: "HR_JobAdvertPostedOn",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_JobAdvertPostedOn_DeletedByUserId",
                table: "HR_JobAdvertPostedOn",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_JobAdvertPostedOn_JobAdvertId",
                table: "HR_JobAdvertPostedOn",
                column: "JobAdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_JobAdvertPostedOn_UpdatedByUserId",
                table: "HR_JobAdvertPostedOn",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_JobAdverts_AppellationId",
                table: "HR_JobAdverts",
                column: "AppellationId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_JobAdverts_CreatedByUserId",
                table: "HR_JobAdverts",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_JobAdverts_DeletedByUserId",
                table: "HR_JobAdverts",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_JobAdverts_UpdatedByUserId",
                table: "HR_JobAdverts",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_JobApplicants_CreatedByUserId",
                table: "HR_JobApplicants",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_JobApplicants_DeletedByUserId",
                table: "HR_JobApplicants",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_JobApplicants_JobAdvertId",
                table: "HR_JobApplicants",
                column: "JobAdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_JobApplicants_JobApplicantDocumentId",
                table: "HR_JobApplicants",
                column: "JobApplicantDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_JobApplicants_UpdatedByUserId",
                table: "HR_JobApplicants",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_JobApplications_CreatedByUserId",
                table: "HR_JobApplications",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_JobApplications_DeletedByUserId",
                table: "HR_JobApplications",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_JobApplications_JobAdvertId",
                table: "HR_JobApplications",
                column: "JobAdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_JobApplications_JobApplicantId",
                table: "HR_JobApplications",
                column: "JobApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_JobApplications_JobApplicationStatusId",
                table: "HR_JobApplications",
                column: "JobApplicationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_JobApplications_RecruiterId",
                table: "HR_JobApplications",
                column: "RecruiterId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_JobApplications_RecruitmentProcessId",
                table: "HR_JobApplications",
                column: "RecruitmentProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_JobApplications_UpdatedByUserId",
                table: "HR_JobApplications",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_JobApplicationStatuses_CreatedByUserId",
                table: "HR_JobApplicationStatuses",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_JobApplicationStatuses_DeletedByUserId",
                table: "HR_JobApplicationStatuses",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_JobApplicationStatuses_UpdatedByUserId",
                table: "HR_JobApplicationStatuses",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_JobApplicationStatusHistories_CreatedByUserId",
                table: "HR_JobApplicationStatusHistories",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_JobApplicationStatusHistories_DeletedByUserId",
                table: "HR_JobApplicationStatusHistories",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_JobApplicationStatusHistories_JobApplicationStatusId",
                table: "HR_JobApplicationStatusHistories",
                column: "JobApplicationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_JobApplicationStatusHistories_UpdatedByUserId",
                table: "HR_JobApplicationStatusHistories",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_JobHistories_CreatedByUserId",
                table: "HR_JobHistories",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_JobHistories_DeletedByUserId",
                table: "HR_JobHistories",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_JobHistories_DepartmentId",
                table: "HR_JobHistories",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_JobHistories_EmployeeId",
                table: "HR_JobHistories",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_JobHistories_UpdatedByUserId",
                table: "HR_JobHistories",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Leaves_CreatedByUserId",
                table: "HR_Leaves",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Leaves_DeletedByUserId",
                table: "HR_Leaves",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Leaves_EmployeeId",
                table: "HR_Leaves",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Leaves_LeaveTypeId",
                table: "HR_Leaves",
                column: "LeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Leaves_UpdatedByUserId",
                table: "HR_Leaves",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_LeaveTypes_CreatedByUserId",
                table: "HR_LeaveTypes",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_LeaveTypes_DeletedByUserId",
                table: "HR_LeaveTypes",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_LeaveTypes_UpdatedByUserId",
                table: "HR_LeaveTypes",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Locations_CreatedByUserId",
                table: "HR_Locations",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Locations_DeletedByUserId",
                table: "HR_Locations",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Locations_JobAdvertId",
                table: "HR_Locations",
                column: "JobAdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Locations_UpdatedByUserId",
                table: "HR_Locations",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Notes_ApplicantId",
                table: "HR_Notes",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Notes_CreatedByUserId",
                table: "HR_Notes",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Notes_DeletedByUserId",
                table: "HR_Notes",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Notes_RecruiterId",
                table: "HR_Notes",
                column: "RecruiterId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Notes_UpdatedByUserId",
                table: "HR_Notes",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Payrolls_CreatedByUserId",
                table: "HR_Payrolls",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Payrolls_DeletedByUserId",
                table: "HR_Payrolls",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Payrolls_EmployeeId",
                table: "HR_Payrolls",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Payrolls_UpdatedByUserId",
                table: "HR_Payrolls",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Recruiters_CreatedByUserId",
                table: "HR_Recruiters",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Recruiters_DeletedByUserId",
                table: "HR_Recruiters",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Recruiters_UpdatedByUserId",
                table: "HR_Recruiters",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_RecruitmentProcesses_CreatedByUserId",
                table: "HR_RecruitmentProcesses",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_RecruitmentProcesses_DeletedByUserId",
                table: "HR_RecruitmentProcesses",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_RecruitmentProcesses_UpdatedByUserId",
                table: "HR_RecruitmentProcesses",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_RecruitmentProcessSteps_CreatedByUserId",
                table: "HR_RecruitmentProcessSteps",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_RecruitmentProcessSteps_DeletedByUserId",
                table: "HR_RecruitmentProcessSteps",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_RecruitmentProcessSteps_RecruitmentProcessId",
                table: "HR_RecruitmentProcessSteps",
                column: "RecruitmentProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_RecruitmentProcessSteps_RecruitmentStepId",
                table: "HR_RecruitmentProcessSteps",
                column: "RecruitmentStepId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_RecruitmentProcessSteps_UpdatedByUserId",
                table: "HR_RecruitmentProcessSteps",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_RecruitmentSteps_CreatedByUserId",
                table: "HR_RecruitmentSteps",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_RecruitmentSteps_DeletedByUserId",
                table: "HR_RecruitmentSteps",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_RecruitmentSteps_JobAdvertId",
                table: "HR_RecruitmentSteps",
                column: "JobAdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_RecruitmentSteps_UpdatedByUserId",
                table: "HR_RecruitmentSteps",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_RoleTypes_CreatedByUserId",
                table: "HR_RoleTypes",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_RoleTypes_DeletedByUserId",
                table: "HR_RoleTypes",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_RoleTypes_EmployeeRolesId",
                table: "HR_RoleTypes",
                column: "EmployeeRolesId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_RoleTypes_UpdatedByUserId",
                table: "HR_RoleTypes",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_SelfServices_CreatedByUserId",
                table: "HR_SelfServices",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_SelfServices_DeletedByUserId",
                table: "HR_SelfServices",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_SelfServices_UpdatedByUserId",
                table: "HR_SelfServices",
                column: "UpdatedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressTypes_AspNetUsers_CreatedBy",
                table: "AddressTypes",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AddressTypes_AspNetUsers_DeletedBy",
                table: "AddressTypes",
                column: "DeletedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AddressTypes_AspNetUsers_UpdatedBy",
                table: "AddressTypes",
                column: "UpdatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserAppUserFile_AspNetUsers_AppUsersId",
                table: "AppUserAppUserFile",
                column: "AppUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserLicenses_AspNetUsers_AppUserId",
                table: "AppUserLicenses",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserLicenses_AspNetUsers_CreatedBy",
                table: "AppUserLicenses",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserLicenses_AspNetUsers_DeletedBy",
                table: "AppUserLicenses",
                column: "DeletedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserLicenses_AspNetUsers_UpdatedBy",
                table: "AppUserLicenses",
                column: "UpdatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Departments_DepartmentId",
                table: "AspNetUsers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Card_Cards_Card_Orders_OrderId",
                table: "Card_Cards",
                column: "OrderId",
                principalTable: "Card_Orders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_AspNetUsers_CreatedBy",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_Branches_AspNetUsers_DeletedBy",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_Branches_AspNetUsers_UpdatedBy",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_AspNetUsers_CreatedBy",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_AspNetUsers_DeletedBy",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_AspNetUsers_UpdatedBy",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_AspNetUsers_AppUserId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_AspNetUsers_CreatedBy",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_AspNetUsers_DeletedBy",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_AspNetUsers_UpdatedBy",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_AspNetUsers_CreatedBy",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_AspNetUsers_DeletedBy",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_AspNetUsers_UpdatedBy",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_AspNetUsers_CreatedBy",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_AspNetUsers_DeletedBy",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_AspNetUsers_UpdatedBy",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Districts_AspNetUsers_CreatedBy",
                table: "Districts");

            migrationBuilder.DropForeignKey(
                name: "FK_Districts_AspNetUsers_DeletedBy",
                table: "Districts");

            migrationBuilder.DropForeignKey(
                name: "FK_Districts_AspNetUsers_UpdatedBy",
                table: "Districts");

            migrationBuilder.DropForeignKey(
                name: "FK_Card_Addresses_Branches_BranchId",
                table: "Card_Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Card_Invoices_Branches_BranchId",
                table: "Card_Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Card_Orders_Branches_BranchId",
                table: "Card_Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Card_Cards_Card_Orders_OrderId",
                table: "Card_Cards");

            migrationBuilder.DropTable(
                name: "AppUserAppUserFile");

            migrationBuilder.DropTable(
                name: "AppUserLicenses");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Base_MailCredentials");

            migrationBuilder.DropTable(
                name: "CompanyAddresses");

            migrationBuilder.DropTable(
                name: "CompanyCompanyFile");

            migrationBuilder.DropTable(
                name: "CompanyLicenses");

            migrationBuilder.DropTable(
                name: "Card_Cargos");

            migrationBuilder.DropTable(
                name: "Card_Ibans");

            migrationBuilder.DropTable(
                name: "Card_OrderDetails");

            migrationBuilder.DropTable(
                name: "Card_PasswordRemakes");

            migrationBuilder.DropTable(
                name: "Card_PhoneNumbers");

            migrationBuilder.DropTable(
                name: "Card_SocialMediaUrls");

            migrationBuilder.DropTable(
                name: "Card_StaffContacts");

            migrationBuilder.DropTable(
                name: "Card_StaffFields");

            migrationBuilder.DropTable(
                name: "Card_StaffStaffFile");

            migrationBuilder.DropTable(
                name: "GControl_AnnouncementDepartment");

            migrationBuilder.DropTable(
                name: "GControl_AnnouncementEmployeeLabel");

            migrationBuilder.DropTable(
                name: "GControl_ApplicationSettingEmployee");

            migrationBuilder.DropTable(
                name: "GControl_EmployeeEmployeeFile");

            migrationBuilder.DropTable(
                name: "GControl_EmployeeEmployeeLabel");

            migrationBuilder.DropTable(
                name: "GControl_EmployeeShiftManagement");

            migrationBuilder.DropTable(
                name: "GControl_EntryExitManagements");

            migrationBuilder.DropTable(
                name: "GControl_PasswordRemakes");

            migrationBuilder.DropTable(
                name: "GControl_UserMainInfo");

            migrationBuilder.DropTable(
                name: "GCrm_CompanyContactNames");

            migrationBuilder.DropTable(
                name: "GCrm_CompanyOffers");

            migrationBuilder.DropTable(
                name: "GCrm_CompanyTenders");

            migrationBuilder.DropTable(
                name: "GCrm_CustomerActivityTeams");

            migrationBuilder.DropTable(
                name: "GCrm_CustomerAddresses");

            migrationBuilder.DropTable(
                name: "GCrm_CustomersCustomerCategories");

            migrationBuilder.DropTable(
                name: "GCrm_Products");

            migrationBuilder.DropTable(
                name: "GCrm_ProjectProjectFiles");

            migrationBuilder.DropTable(
                name: "GCrm_SolutionOffers");

            migrationBuilder.DropTable(
                name: "HR_DepartmentManagers");

            migrationBuilder.DropTable(
                name: "HR_EducationInfos");

            migrationBuilder.DropTable(
                name: "HR_JobAdvertPostedOn");

            migrationBuilder.DropTable(
                name: "HR_JobApplications");

            migrationBuilder.DropTable(
                name: "HR_JobApplicationStatusHistories");

            migrationBuilder.DropTable(
                name: "HR_JobHistories");

            migrationBuilder.DropTable(
                name: "HR_Leaves");

            migrationBuilder.DropTable(
                name: "HR_Locations");

            migrationBuilder.DropTable(
                name: "HR_Notes");

            migrationBuilder.DropTable(
                name: "HR_Payrolls");

            migrationBuilder.DropTable(
                name: "HR_RecruitmentProcessSteps");

            migrationBuilder.DropTable(
                name: "HR_RoleTypes");

            migrationBuilder.DropTable(
                name: "HR_SelfServices");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AddressTypes");

            migrationBuilder.DropTable(
                name: "Card_SocialMedias");

            migrationBuilder.DropTable(
                name: "Card_Fields");

            migrationBuilder.DropTable(
                name: "Card_Staffs");

            migrationBuilder.DropTable(
                name: "GControl_Department");

            migrationBuilder.DropTable(
                name: "GControl_Announcement");

            migrationBuilder.DropTable(
                name: "GControl_ApplicationSettings");

            migrationBuilder.DropTable(
                name: "GControl_EmployeeLabels");

            migrationBuilder.DropTable(
                name: "GControl_ShiftManagements");

            migrationBuilder.DropTable(
                name: "GControl_Employees");

            migrationBuilder.DropTable(
                name: "GCrm_CustomerActivities");

            migrationBuilder.DropTable(
                name: "GCrm_CustomerCategories");

            migrationBuilder.DropTable(
                name: "GCrm_ProductBrands");

            migrationBuilder.DropTable(
                name: "GCrm_ProductCategories");

            migrationBuilder.DropTable(
                name: "GCrm_ProductMainCategories");

            migrationBuilder.DropTable(
                name: "GCrm_ProductManufacturers");

            migrationBuilder.DropTable(
                name: "GCrm_ProductModels");

            migrationBuilder.DropTable(
                name: "GCrm_ProductSubCategories");

            migrationBuilder.DropTable(
                name: "GCrm_ProductTypes");

            migrationBuilder.DropTable(
                name: "GCrm_Projects");

            migrationBuilder.DropTable(
                name: "GCrm_Opportunities");

            migrationBuilder.DropTable(
                name: "HR_JobApplicationStatuses");

            migrationBuilder.DropTable(
                name: "HR_LeaveTypes");

            migrationBuilder.DropTable(
                name: "HR_JobApplicants");

            migrationBuilder.DropTable(
                name: "HR_Recruiters");

            migrationBuilder.DropTable(
                name: "HR_RecruitmentProcesses");

            migrationBuilder.DropTable(
                name: "HR_RecruitmentSteps");

            migrationBuilder.DropTable(
                name: "HR_EmployeeRoles");

            migrationBuilder.DropTable(
                name: "GControl_EmployeeTypes");

            migrationBuilder.DropTable(
                name: "GControl_Locations");

            migrationBuilder.DropTable(
                name: "GCrm_CustomerActivityKinds");

            migrationBuilder.DropTable(
                name: "GCrm_CustomerActivityStatuses");

            migrationBuilder.DropTable(
                name: "GCrm_CustomerActivitySubjects");

            migrationBuilder.DropTable(
                name: "GCrm_CustomerActivityTypes");

            migrationBuilder.DropTable(
                name: "GCrm_ProjectManagers");

            migrationBuilder.DropTable(
                name: "GCrm_ProjectStatues");

            migrationBuilder.DropTable(
                name: "GCrm_ProjectTeams");

            migrationBuilder.DropTable(
                name: "GCrm_ProjectType");

            migrationBuilder.DropTable(
                name: "GCrm_CustomerContacts");

            migrationBuilder.DropTable(
                name: "GCrm_OpportunityReferences");

            migrationBuilder.DropTable(
                name: "GCrm_OpportunitySectors");

            migrationBuilder.DropTable(
                name: "GCrm_OpportunityStages");

            migrationBuilder.DropTable(
                name: "GCrm_Users");

            migrationBuilder.DropTable(
                name: "HR_JobAdverts");

            migrationBuilder.DropTable(
                name: "HR_Employees");

            migrationBuilder.DropTable(
                name: "GCrm_Customers");

            migrationBuilder.DropTable(
                name: "GCrm_UserTitle");

            migrationBuilder.DropTable(
                name: "HR_Appellations");

            migrationBuilder.DropTable(
                name: "AppFiles");

            migrationBuilder.DropTable(
                name: "GCrm_CustomerGroups");

            migrationBuilder.DropTable(
                name: "GCrm_CustomerKinds");

            migrationBuilder.DropTable(
                name: "GCrm_CustomerSectors");

            migrationBuilder.DropTable(
                name: "GCrm_CustomerSources");

            migrationBuilder.DropTable(
                name: "GCrm_CustomerStatuses");

            migrationBuilder.DropTable(
                name: "GCrm_CustomerTypes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AppUserAppellations");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Card_Orders");

            migrationBuilder.DropTable(
                name: "Card_Addresses");

            migrationBuilder.DropTable(
                name: "Card_Invoices");

            migrationBuilder.DropTable(
                name: "Card_Cards");
        }
    }
}
