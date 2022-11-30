using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CCMS.NEOPE.Infra.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Accountables",
                columns: table => new
                {
                    Id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DisplayName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sector = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RowVersion = table.Column<DateTime>(type: "timestamp(6)", rowVersion: true, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accountables", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ApplicationRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationRoles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AssetTypes",
                columns: table => new
                {
                    Id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RowVersion = table.Column<DateTime>(type: "timestamp(6)", rowVersion: true, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RowVersion = table.Column<DateTime>(type: "timestamp(6)", rowVersion: true, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Labels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Color = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RowVersion = table.Column<DateTime>(type: "timestamp(6)", rowVersion: true, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labels", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RowVersion = table.Column<DateTime>(type: "timestamp(6)", rowVersion: true, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Steps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RowVersion = table.Column<DateTime>(type: "timestamp(6)", rowVersion: true, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steps", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RowVersion = table.Column<DateTime>(type: "timestamp(6)", rowVersion: true, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FirstName = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Photo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsFirstAccess = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccountableId = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationUsers_Accountables_AccountableId",
                        column: x => x.AccountableId,
                        principalTable: "Accountables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_ApplicationRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "ApplicationRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AssetTypeStep",
                columns: table => new
                {
                    AllowedStepsId = table.Column<int>(type: "int", nullable: false),
                    AssetTypesId = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetTypeStep", x => new { x.AllowedStepsId, x.AssetTypesId });
                    table.ForeignKey(
                        name: "FK_AssetTypeStep_AssetTypes_AssetTypesId",
                        column: x => x.AssetTypesId,
                        principalTable: "AssetTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetTypeStep_Steps_AllowedStepsId",
                        column: x => x.AllowedStepsId,
                        principalTable: "Steps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TaskItems",
                columns: table => new
                {
                    Id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProjectId = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    Title = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SapNoteNumber = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TypeId = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    StepId = table.Column<int>(type: "int", nullable: false),
                    ParentTaskId = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    PlannedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CompletedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ReporterId = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RowVersion = table.Column<DateTime>(type: "timestamp(6)", rowVersion: true, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskItems_Accountables_ReporterId",
                        column: x => x.ReporterId,
                        principalTable: "Accountables",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TaskItems_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskItems_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskItems_Steps_StepId",
                        column: x => x.StepId,
                        principalTable: "Steps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskItems_TaskItems_ParentTaskId",
                        column: x => x.ParentTaskId,
                        principalTable: "TaskItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TaskItems_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_ApplicationUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_ApplicationUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_ApplicationRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "ApplicationRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_ApplicationUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LoginProvider = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_ApplicationUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AccountableTaskItem",
                columns: table => new
                {
                    AssignedTasksId = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    AssigneesId = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountableTaskItem", x => new { x.AssignedTasksId, x.AssigneesId });
                    table.ForeignKey(
                        name: "FK_AccountableTaskItem_Accountables_AssigneesId",
                        column: x => x.AssigneesId,
                        principalTable: "Accountables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountableTaskItem_TaskItems_AssignedTasksId",
                        column: x => x.AssignedTasksId,
                        principalTable: "TaskItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TypeId = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    ProjectId = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    AttachmentsLink = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TaskItemId = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RowVersion = table.Column<DateTime>(type: "timestamp(6)", rowVersion: true, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assets_AssetTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "AssetTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assets_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assets_TaskItems_TaskItemId",
                        column: x => x.TaskItemId,
                        principalTable: "TaskItems",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CheckListItems",
                columns: table => new
                {
                    Id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TaskId = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RowVersion = table.Column<DateTime>(type: "timestamp(6)", rowVersion: true, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckListItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckListItems_TaskItems_TaskId",
                        column: x => x.TaskId,
                        principalTable: "TaskItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LabelTaskItem",
                columns: table => new
                {
                    LabelsId = table.Column<int>(type: "int", nullable: false),
                    TasksId = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabelTaskItem", x => new { x.LabelsId, x.TasksId });
                    table.ForeignKey(
                        name: "FK_LabelTaskItem_Labels_LabelsId",
                        column: x => x.LabelsId,
                        principalTable: "Labels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabelTaskItem_TaskItems_TasksId",
                        column: x => x.TasksId,
                        principalTable: "TaskItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LinkedTasks",
                columns: table => new
                {
                    Id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SubjectTaskId = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ObjectTaskId = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RowVersion = table.Column<DateTime>(type: "timestamp(6)", rowVersion: true, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkedTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinkedTasks_TaskItems_ObjectTaskId",
                        column: x => x.ObjectTaskId,
                        principalTable: "TaskItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LinkedTasks_TaskItems_SubjectTaskId",
                        column: x => x.SubjectTaskId,
                        principalTable: "TaskItems",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AssetProjectStatus",
                columns: table => new
                {
                    Id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StepId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    AssetId = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RowVersion = table.Column<DateTime>(type: "timestamp(6)", rowVersion: true, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetProjectStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetProjectStatus_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetProjectStatus_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AssetProjectStatus_Steps_StepId",
                        column: x => x.StepId,
                        principalTable: "Steps",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AccountableAssetProjectStatus",
                columns: table => new
                {
                    AssetStatusPerAccountableId = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    AssigneesId = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountableAssetProjectStatus", x => new { x.AssetStatusPerAccountableId, x.AssigneesId });
                    table.ForeignKey(
                        name: "FK_AccountableAssetProjectStatus_Accountables_AssigneesId",
                        column: x => x.AssigneesId,
                        principalTable: "Accountables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountableAssetProjectStatus_AssetProjectStatus_AssetStatus~",
                        column: x => x.AssetStatusPerAccountableId,
                        principalTable: "AssetProjectStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Path = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AssetStatusId = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RowVersion = table.Column<DateTime>(type: "timestamp(6)", rowVersion: true, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachments_AssetProjectStatus_AssetStatusId",
                        column: x => x.AssetStatusId,
                        principalTable: "AssetProjectStatus",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    AssetStatusId = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RowVersion = table.Column<DateTime>(type: "timestamp(6)", rowVersion: true, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Accountables_UserId",
                        column: x => x.UserId,
                        principalTable: "Accountables",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_AssetProjectStatus_AssetStatusId",
                        column: x => x.AssetStatusId,
                        principalTable: "AssetProjectStatus",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AssetStatusId = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RowVersion = table.Column<DateTime>(type: "timestamp(6)", rowVersion: true, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logs_AssetProjectStatus_AssetStatusId",
                        column: x => x.AssetStatusId,
                        principalTable: "AssetProjectStatus",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "ApplicationRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "17400699-da3a-4ecc-b09b-428cee8cf43f", "31461aa2-3479-4e32-99c6-40fde4360573", "Administrador do sistema", "Administrator", "ADMINISTRATOR" },
                    { "d37ca026-1499-4ca4-812c-f1da3b551e6a", "96080756-7521-44bb-b857-8bd9f9b6a2fe", "Usuário comum do sistema", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateDate", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 30, 8, 29, 46, 743, DateTimeKind.Local).AddTicks(8710), "Civil", null },
                    { 2, new DateTime(2022, 11, 30, 8, 29, 46, 743, DateTimeKind.Local).AddTicks(8716), "Eletromecânico", null },
                    { 3, new DateTime(2022, 11, 30, 8, 29, 46, 743, DateTimeKind.Local).AddTicks(8718), "Aterramento", null },
                    { 4, new DateTime(2022, 11, 30, 8, 29, 46, 743, DateTimeKind.Local).AddTicks(8719), "Projeto", null },
                    { 5, new DateTime(2022, 11, 30, 8, 29, 46, 743, DateTimeKind.Local).AddTicks(8721), "Painéis", null },
                    { 6, new DateTime(2022, 11, 30, 8, 29, 46, 743, DateTimeKind.Local).AddTicks(8723), "Equipamentos", null },
                    { 7, new DateTime(2022, 11, 30, 8, 29, 46, 743, DateTimeKind.Local).AddTicks(8724), "Interligações", null },
                    { 8, new DateTime(2022, 11, 30, 8, 29, 46, 743, DateTimeKind.Local).AddTicks(8727), "SPCS", null }
                });

            migrationBuilder.InsertData(
                table: "Steps",
                columns: new[] { "Id", "CreateDate", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 30, 8, 29, 46, 718, DateTimeKind.Local).AddTicks(8230), "Planejamento", null },
                    { 2, new DateTime(2022, 11, 30, 8, 29, 46, 718, DateTimeKind.Local).AddTicks(8241), "Inspeção", null },
                    { 3, new DateTime(2022, 11, 30, 8, 29, 46, 718, DateTimeKind.Local).AddTicks(8242), "TAC Equip. Interlig.", null },
                    { 4, new DateTime(2022, 11, 30, 8, 29, 46, 718, DateTimeKind.Local).AddTicks(8243), "TAF SPCS", null },
                    { 5, new DateTime(2022, 11, 30, 8, 29, 46, 718, DateTimeKind.Local).AddTicks(8244), "TAC SPCS", null },
                    { 6, new DateTime(2022, 11, 30, 8, 29, 46, 718, DateTimeKind.Local).AddTicks(8245), "Energização", null },
                    { 7, new DateTime(2022, 11, 30, 8, 29, 46, 718, DateTimeKind.Local).AddTicks(8245), "SAP", null }
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "CreateDate", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { 1ul, new DateTime(2022, 11, 30, 8, 29, 46, 743, DateTimeKind.Local).AddTicks(7449), "Informativo", null },
                    { 2ul, new DateTime(2022, 11, 30, 8, 29, 46, 743, DateTimeKind.Local).AddTicks(7465), "Acompanhamento", null },
                    { 3ul, new DateTime(2022, 11, 30, 8, 29, 46, 743, DateTimeKind.Local).AddTicks(7467), "Pendência não impeditiva", null },
                    { 4ul, new DateTime(2022, 11, 30, 8, 29, 46, 743, DateTimeKind.Local).AddTicks(7468), "Pendência impeditiva", null },
                    { 5ul, new DateTime(2022, 11, 30, 8, 29, 46, 743, DateTimeKind.Local).AddTicks(7470), "Não conformidade", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountableAssetProjectStatus_AssigneesId",
                table: "AccountableAssetProjectStatus",
                column: "AssigneesId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountableTaskItem_AssigneesId",
                table: "AccountableTaskItem",
                column: "AssigneesId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "ApplicationRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "ApplicationUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_AccountableId",
                table: "ApplicationUsers",
                column: "AccountableId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_Code",
                table: "ApplicationUsers",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "ApplicationUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

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
                name: "IX_AssetProjectStatus_AssetId",
                table: "AssetProjectStatus",
                column: "AssetId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssetProjectStatus_CategoryId",
                table: "AssetProjectStatus",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetProjectStatus_StepId",
                table: "AssetProjectStatus",
                column: "StepId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_Code",
                table: "Assets",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assets_ProjectId",
                table: "Assets",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_TaskItemId",
                table: "Assets",
                column: "TaskItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_TypeId",
                table: "Assets",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetTypes_Name",
                table: "AssetTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssetTypeStep_AssetTypesId",
                table: "AssetTypeStep",
                column: "AssetTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_AssetStatusId",
                table: "Attachments",
                column: "AssetStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CheckListItems_TaskId",
                table: "CheckListItems",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AssetStatusId",
                table: "Comments",
                column: "AssetStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LabelTaskItem_TasksId",
                table: "LabelTaskItem",
                column: "TasksId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkedTasks_ObjectTaskId",
                table: "LinkedTasks",
                column: "ObjectTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkedTasks_SubjectTaskId",
                table: "LinkedTasks",
                column: "SubjectTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_AssetStatusId",
                table: "Logs",
                column: "AssetStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_Name",
                table: "Steps",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_CategoryId",
                table: "TaskItems",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_ParentTaskId",
                table: "TaskItems",
                column: "ParentTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_ProjectId",
                table: "TaskItems",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_ReporterId",
                table: "TaskItems",
                column: "ReporterId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_StepId",
                table: "TaskItems",
                column: "StepId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_TypeId",
                table: "TaskItems",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Types_Name",
                table: "Types",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountableAssetProjectStatus");

            migrationBuilder.DropTable(
                name: "AccountableTaskItem");

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
                name: "AssetTypeStep");

            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "CheckListItems");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "LabelTaskItem");

            migrationBuilder.DropTable(
                name: "LinkedTasks");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "ApplicationRoles");

            migrationBuilder.DropTable(
                name: "ApplicationUsers");

            migrationBuilder.DropTable(
                name: "Labels");

            migrationBuilder.DropTable(
                name: "AssetProjectStatus");

            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "AssetTypes");

            migrationBuilder.DropTable(
                name: "TaskItems");

            migrationBuilder.DropTable(
                name: "Accountables");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Steps");

            migrationBuilder.DropTable(
                name: "Types");
        }
    }
}
