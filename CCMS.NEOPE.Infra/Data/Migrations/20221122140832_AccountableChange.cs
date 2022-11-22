using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CCMS.NEOPE.Infra.Data.Migrations
{
    public partial class AccountableChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_ApplicationUsers_ReporterId",
                table: "TaskItems");

            migrationBuilder.DropTable(
                name: "ApplicationUserTaskItem");

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: "066766ef-a5ea-40ee-997a-22e7328c668c");

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: "8f04e1da-bd81-444a-b8f3-8b1711fc11b0");

            migrationBuilder.AlterColumn<ulong>(
                name: "ReporterId",
                table: "TaskItems",
                type: "bigint unsigned",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<ulong>(
                name: "AccountableId",
                table: "ApplicationUsers",
                type: "bigint unsigned",
                nullable: false,
                defaultValue: 0ul);

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
                    Sector = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
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

            migrationBuilder.InsertData(
                table: "ApplicationRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c269eb03-6a0c-4863-8690-81fd0ef2b88f", "dea3c12e-caed-4f5c-ac10-4fcb32ba0b3f", "Usuário comum do sistema", "User", "USER" },
                    { "cc33265f-0881-4687-a05e-ce8adea09b0d", "74f4f201-07a2-4d72-9351-a7b843a5cb2f", "Administrador do sistema", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "TaskCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 11, 22, 11, 8, 31, 506, DateTimeKind.Local).AddTicks(5744));

            migrationBuilder.UpdateData(
                table: "TaskCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2022, 11, 22, 11, 8, 31, 506, DateTimeKind.Local).AddTicks(5748));

            migrationBuilder.UpdateData(
                table: "TaskCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2022, 11, 22, 11, 8, 31, 506, DateTimeKind.Local).AddTicks(5749));

            migrationBuilder.UpdateData(
                table: "TaskCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2022, 11, 22, 11, 8, 31, 506, DateTimeKind.Local).AddTicks(5750));

            migrationBuilder.UpdateData(
                table: "TaskCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2022, 11, 22, 11, 8, 31, 506, DateTimeKind.Local).AddTicks(5751));

            migrationBuilder.UpdateData(
                table: "TaskCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2022, 11, 22, 11, 8, 31, 506, DateTimeKind.Local).AddTicks(5752));

            migrationBuilder.UpdateData(
                table: "TaskCategories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2022, 11, 22, 11, 8, 31, 506, DateTimeKind.Local).AddTicks(5753));

            migrationBuilder.UpdateData(
                table: "TaskCategories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateDate",
                value: new DateTime(2022, 11, 22, 11, 8, 31, 506, DateTimeKind.Local).AddTicks(5755));

            migrationBuilder.UpdateData(
                table: "TaskSteps",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 11, 22, 11, 8, 31, 487, DateTimeKind.Local).AddTicks(556));

            migrationBuilder.UpdateData(
                table: "TaskSteps",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2022, 11, 22, 11, 8, 31, 487, DateTimeKind.Local).AddTicks(567));

            migrationBuilder.UpdateData(
                table: "TaskSteps",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2022, 11, 22, 11, 8, 31, 487, DateTimeKind.Local).AddTicks(569));

            migrationBuilder.UpdateData(
                table: "TaskSteps",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2022, 11, 22, 11, 8, 31, 487, DateTimeKind.Local).AddTicks(569));

            migrationBuilder.UpdateData(
                table: "TaskSteps",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2022, 11, 22, 11, 8, 31, 487, DateTimeKind.Local).AddTicks(570));

            migrationBuilder.UpdateData(
                table: "TaskSteps",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2022, 11, 22, 11, 8, 31, 487, DateTimeKind.Local).AddTicks(571));

            migrationBuilder.UpdateData(
                table: "TaskTypes",
                keyColumn: "Id",
                keyValue: 1ul,
                column: "CreateDate",
                value: new DateTime(2022, 11, 22, 11, 8, 31, 506, DateTimeKind.Local).AddTicks(5020));

            migrationBuilder.UpdateData(
                table: "TaskTypes",
                keyColumn: "Id",
                keyValue: 2ul,
                column: "CreateDate",
                value: new DateTime(2022, 11, 22, 11, 8, 31, 506, DateTimeKind.Local).AddTicks(5032));

            migrationBuilder.UpdateData(
                table: "TaskTypes",
                keyColumn: "Id",
                keyValue: 3ul,
                column: "CreateDate",
                value: new DateTime(2022, 11, 22, 11, 8, 31, 506, DateTimeKind.Local).AddTicks(5034));

            migrationBuilder.UpdateData(
                table: "TaskTypes",
                keyColumn: "Id",
                keyValue: 4ul,
                column: "CreateDate",
                value: new DateTime(2022, 11, 22, 11, 8, 31, 506, DateTimeKind.Local).AddTicks(5035));

            migrationBuilder.UpdateData(
                table: "TaskTypes",
                keyColumn: "Id",
                keyValue: 5ul,
                column: "CreateDate",
                value: new DateTime(2022, 11, 22, 11, 8, 31, 506, DateTimeKind.Local).AddTicks(5036));

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_AccountableId",
                table: "ApplicationUsers",
                column: "AccountableId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountableTaskItem_AssigneesId",
                table: "AccountableTaskItem",
                column: "AssigneesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUsers_Accountables_AccountableId",
                table: "ApplicationUsers",
                column: "AccountableId",
                principalTable: "Accountables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_Accountables_ReporterId",
                table: "TaskItems",
                column: "ReporterId",
                principalTable: "Accountables",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUsers_Accountables_AccountableId",
                table: "ApplicationUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_Accountables_ReporterId",
                table: "TaskItems");

            migrationBuilder.DropTable(
                name: "AccountableTaskItem");

            migrationBuilder.DropTable(
                name: "Accountables");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUsers_AccountableId",
                table: "ApplicationUsers");

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: "c269eb03-6a0c-4863-8690-81fd0ef2b88f");

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: "cc33265f-0881-4687-a05e-ce8adea09b0d");

            migrationBuilder.DropColumn(
                name: "AccountableId",
                table: "ApplicationUsers");

            migrationBuilder.AlterColumn<string>(
                name: "ReporterId",
                table: "TaskItems",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ApplicationUserTaskItem",
                columns: table => new
                {
                    AssignedTasksId = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    AssigneesId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserTaskItem", x => new { x.AssignedTasksId, x.AssigneesId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserTaskItem_ApplicationUsers_AssigneesId",
                        column: x => x.AssigneesId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserTaskItem_TaskItems_AssignedTasksId",
                        column: x => x.AssignedTasksId,
                        principalTable: "TaskItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "ApplicationRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "066766ef-a5ea-40ee-997a-22e7328c668c", "2e2f6529-165b-4ebf-bf72-02cbace794d5", "Administrador do sistema", "Administrator", "ADMINISTRATOR" },
                    { "8f04e1da-bd81-444a-b8f3-8b1711fc11b0", "4225326f-7730-42ea-bc0c-6c55149d06c5", "Usuário comum do sistema", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "TaskCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 9, 1, 13, 33, 5, 251, DateTimeKind.Local).AddTicks(4694));

            migrationBuilder.UpdateData(
                table: "TaskCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2022, 9, 1, 13, 33, 5, 251, DateTimeKind.Local).AddTicks(4699));

            migrationBuilder.UpdateData(
                table: "TaskCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2022, 9, 1, 13, 33, 5, 251, DateTimeKind.Local).AddTicks(4700));

            migrationBuilder.UpdateData(
                table: "TaskCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2022, 9, 1, 13, 33, 5, 251, DateTimeKind.Local).AddTicks(4702));

            migrationBuilder.UpdateData(
                table: "TaskCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2022, 9, 1, 13, 33, 5, 251, DateTimeKind.Local).AddTicks(4703));

            migrationBuilder.UpdateData(
                table: "TaskCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2022, 9, 1, 13, 33, 5, 251, DateTimeKind.Local).AddTicks(4705));

            migrationBuilder.UpdateData(
                table: "TaskCategories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2022, 9, 1, 13, 33, 5, 251, DateTimeKind.Local).AddTicks(4706));

            migrationBuilder.UpdateData(
                table: "TaskCategories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateDate",
                value: new DateTime(2022, 9, 1, 13, 33, 5, 251, DateTimeKind.Local).AddTicks(4707));

            migrationBuilder.UpdateData(
                table: "TaskSteps",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 9, 1, 13, 33, 5, 246, DateTimeKind.Local).AddTicks(8032));

            migrationBuilder.UpdateData(
                table: "TaskSteps",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2022, 9, 1, 13, 33, 5, 246, DateTimeKind.Local).AddTicks(8044));

            migrationBuilder.UpdateData(
                table: "TaskSteps",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2022, 9, 1, 13, 33, 5, 246, DateTimeKind.Local).AddTicks(8045));

            migrationBuilder.UpdateData(
                table: "TaskSteps",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2022, 9, 1, 13, 33, 5, 246, DateTimeKind.Local).AddTicks(8047));

            migrationBuilder.UpdateData(
                table: "TaskSteps",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2022, 9, 1, 13, 33, 5, 246, DateTimeKind.Local).AddTicks(8048));

            migrationBuilder.UpdateData(
                table: "TaskSteps",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2022, 9, 1, 13, 33, 5, 246, DateTimeKind.Local).AddTicks(8049));

            migrationBuilder.UpdateData(
                table: "TaskTypes",
                keyColumn: "Id",
                keyValue: 1ul,
                column: "CreateDate",
                value: new DateTime(2022, 9, 1, 13, 33, 5, 251, DateTimeKind.Local).AddTicks(3902));

            migrationBuilder.UpdateData(
                table: "TaskTypes",
                keyColumn: "Id",
                keyValue: 2ul,
                column: "CreateDate",
                value: new DateTime(2022, 9, 1, 13, 33, 5, 251, DateTimeKind.Local).AddTicks(3913));

            migrationBuilder.UpdateData(
                table: "TaskTypes",
                keyColumn: "Id",
                keyValue: 3ul,
                column: "CreateDate",
                value: new DateTime(2022, 9, 1, 13, 33, 5, 251, DateTimeKind.Local).AddTicks(3915));

            migrationBuilder.UpdateData(
                table: "TaskTypes",
                keyColumn: "Id",
                keyValue: 4ul,
                column: "CreateDate",
                value: new DateTime(2022, 9, 1, 13, 33, 5, 251, DateTimeKind.Local).AddTicks(3916));

            migrationBuilder.UpdateData(
                table: "TaskTypes",
                keyColumn: "Id",
                keyValue: 5ul,
                column: "CreateDate",
                value: new DateTime(2022, 9, 1, 13, 33, 5, 251, DateTimeKind.Local).AddTicks(3918));

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserTaskItem_AssigneesId",
                table: "ApplicationUserTaskItem",
                column: "AssigneesId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_ApplicationUsers_ReporterId",
                table: "TaskItems",
                column: "ReporterId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id");
        }
    }
}
