using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CCMS.NEOPE.Infra.Data.Migrations
{
    public partial class RefactorTasksAndPendencies_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_TaskCategories_CategoryId",
                table: "TaskItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_TaskSteps_StepId",
                table: "TaskItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_TaskTypes_TypeId",
                table: "TaskItems");

            migrationBuilder.DropTable(
                name: "TaskCategories");

            migrationBuilder.DropTable(
                name: "TaskSteps");

            migrationBuilder.DropTable(
                name: "TaskTypes");

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: "cc4ab119-be38-4eab-94eb-5fbbcab6bbb5");

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: "e52bcf97-e128-4209-b662-d5675b214836");

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

            migrationBuilder.InsertData(
                table: "ApplicationRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2f892af8-b3dc-4160-b348-0f9e07b35c60", "0bd20131-9282-4e5c-85e9-83c78660b4bf", "Usuário comum do sistema", "User", "USER" },
                    { "c844e220-6e6e-4b70-b0fe-4eb3e96e45cc", "992ae190-9caf-4008-8d3e-62281c629a1d", "Administrador do sistema", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateDate", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 22, 17, 38, 16, 986, DateTimeKind.Local).AddTicks(8852), "Civil", null },
                    { 2, new DateTime(2022, 11, 22, 17, 38, 16, 986, DateTimeKind.Local).AddTicks(8856), "Eletromecânico", null },
                    { 3, new DateTime(2022, 11, 22, 17, 38, 16, 986, DateTimeKind.Local).AddTicks(8858), "Aterramento", null },
                    { 4, new DateTime(2022, 11, 22, 17, 38, 16, 986, DateTimeKind.Local).AddTicks(8860), "Projeto", null },
                    { 5, new DateTime(2022, 11, 22, 17, 38, 16, 986, DateTimeKind.Local).AddTicks(8861), "Painéis", null },
                    { 6, new DateTime(2022, 11, 22, 17, 38, 16, 986, DateTimeKind.Local).AddTicks(8863), "Equipamentos", null },
                    { 7, new DateTime(2022, 11, 22, 17, 38, 16, 986, DateTimeKind.Local).AddTicks(8864), "Interligações", null },
                    { 8, new DateTime(2022, 11, 22, 17, 38, 16, 986, DateTimeKind.Local).AddTicks(8866), "SPCS", null }
                });

            migrationBuilder.InsertData(
                table: "Steps",
                columns: new[] { "Id", "CreateDate", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 22, 17, 38, 16, 957, DateTimeKind.Local).AddTicks(7848), "Planejamento", null },
                    { 2, new DateTime(2022, 11, 22, 17, 38, 16, 957, DateTimeKind.Local).AddTicks(7860), "TAC Equip. Interlig.", null },
                    { 3, new DateTime(2022, 11, 22, 17, 38, 16, 957, DateTimeKind.Local).AddTicks(7862), "TAF SPCS", null },
                    { 4, new DateTime(2022, 11, 22, 17, 38, 16, 957, DateTimeKind.Local).AddTicks(7863), "TAC SPCS", null },
                    { 5, new DateTime(2022, 11, 22, 17, 38, 16, 957, DateTimeKind.Local).AddTicks(7865), "Energização", null },
                    { 6, new DateTime(2022, 11, 22, 17, 38, 16, 957, DateTimeKind.Local).AddTicks(7866), "SAP", null }
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "CreateDate", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { 1ul, new DateTime(2022, 11, 22, 17, 38, 16, 986, DateTimeKind.Local).AddTicks(7571), "Informativo", null },
                    { 2ul, new DateTime(2022, 11, 22, 17, 38, 16, 986, DateTimeKind.Local).AddTicks(7588), "Acompanhamento", null },
                    { 3ul, new DateTime(2022, 11, 22, 17, 38, 16, 986, DateTimeKind.Local).AddTicks(7591), "Pendência não impeditiva", null },
                    { 4ul, new DateTime(2022, 11, 22, 17, 38, 16, 986, DateTimeKind.Local).AddTicks(7592), "Pendência impeditiva", null },
                    { 5ul, new DateTime(2022, 11, 22, 17, 38, 16, 986, DateTimeKind.Local).AddTicks(7594), "Não conformidade", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Steps_Name",
                table: "Steps",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Types_Name",
                table: "Types",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_Categories_CategoryId",
                table: "TaskItems",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_Steps_StepId",
                table: "TaskItems",
                column: "StepId",
                principalTable: "Steps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_Types_TypeId",
                table: "TaskItems",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_Categories_CategoryId",
                table: "TaskItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_Steps_StepId",
                table: "TaskItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_Types_TypeId",
                table: "TaskItems");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Steps");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: "2f892af8-b3dc-4160-b348-0f9e07b35c60");

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: "c844e220-6e6e-4b70-b0fe-4eb3e96e45cc");

            migrationBuilder.CreateTable(
                name: "TaskCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RowVersion = table.Column<DateTime>(type: "timestamp(6)", rowVersion: true, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskCategories", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TaskSteps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RowVersion = table.Column<DateTime>(type: "timestamp(6)", rowVersion: true, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskSteps", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TaskTypes",
                columns: table => new
                {
                    Id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RowVersion = table.Column<DateTime>(type: "timestamp(6)", rowVersion: true, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "ApplicationRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cc4ab119-be38-4eab-94eb-5fbbcab6bbb5", "94ce2696-e958-455b-9e06-b0a5285e715d", "Administrador do sistema", "Administrator", "ADMINISTRATOR" },
                    { "e52bcf97-e128-4209-b662-d5675b214836", "ee30eee7-6f72-47ea-b952-642e3150fd24", "Usuário comum do sistema", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "TaskCategories",
                columns: new[] { "Id", "CreateDate", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 22, 11, 37, 12, 46, DateTimeKind.Local).AddTicks(8943), "Civil", null },
                    { 2, new DateTime(2022, 11, 22, 11, 37, 12, 46, DateTimeKind.Local).AddTicks(8948), "Eletromecânico", null },
                    { 3, new DateTime(2022, 11, 22, 11, 37, 12, 46, DateTimeKind.Local).AddTicks(8949), "Aterramento", null },
                    { 4, new DateTime(2022, 11, 22, 11, 37, 12, 46, DateTimeKind.Local).AddTicks(8950), "Projeto", null },
                    { 5, new DateTime(2022, 11, 22, 11, 37, 12, 46, DateTimeKind.Local).AddTicks(8952), "Painéis", null },
                    { 6, new DateTime(2022, 11, 22, 11, 37, 12, 46, DateTimeKind.Local).AddTicks(8953), "Equipamentos", null },
                    { 7, new DateTime(2022, 11, 22, 11, 37, 12, 46, DateTimeKind.Local).AddTicks(8954), "Interligações", null },
                    { 8, new DateTime(2022, 11, 22, 11, 37, 12, 46, DateTimeKind.Local).AddTicks(8955), "SPCS", null }
                });

            migrationBuilder.InsertData(
                table: "TaskSteps",
                columns: new[] { "Id", "CreateDate", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 22, 11, 37, 12, 29, DateTimeKind.Local).AddTicks(1632), "Planejamento", null },
                    { 2, new DateTime(2022, 11, 22, 11, 37, 12, 29, DateTimeKind.Local).AddTicks(1644), "TAC Equip. Interlig.", null },
                    { 3, new DateTime(2022, 11, 22, 11, 37, 12, 29, DateTimeKind.Local).AddTicks(1645), "TAF SPCS", null },
                    { 4, new DateTime(2022, 11, 22, 11, 37, 12, 29, DateTimeKind.Local).AddTicks(1646), "TAC SPCS", null },
                    { 5, new DateTime(2022, 11, 22, 11, 37, 12, 29, DateTimeKind.Local).AddTicks(1647), "Energização", null },
                    { 6, new DateTime(2022, 11, 22, 11, 37, 12, 29, DateTimeKind.Local).AddTicks(1648), "SAP", null }
                });

            migrationBuilder.InsertData(
                table: "TaskTypes",
                columns: new[] { "Id", "CreateDate", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { 1ul, new DateTime(2022, 11, 22, 11, 37, 12, 46, DateTimeKind.Local).AddTicks(8227), "Informativo", null },
                    { 2ul, new DateTime(2022, 11, 22, 11, 37, 12, 46, DateTimeKind.Local).AddTicks(8238), "Acompanhamento", null },
                    { 3ul, new DateTime(2022, 11, 22, 11, 37, 12, 46, DateTimeKind.Local).AddTicks(8240), "Pendência não impeditiva", null },
                    { 4ul, new DateTime(2022, 11, 22, 11, 37, 12, 46, DateTimeKind.Local).AddTicks(8242), "Pendência impeditiva", null },
                    { 5ul, new DateTime(2022, 11, 22, 11, 37, 12, 46, DateTimeKind.Local).AddTicks(8243), "Não conformidade", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskCategories_Name",
                table: "TaskCategories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskSteps_Name",
                table: "TaskSteps",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskTypes_Name",
                table: "TaskTypes",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_TaskCategories_CategoryId",
                table: "TaskItems",
                column: "CategoryId",
                principalTable: "TaskCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_TaskSteps_StepId",
                table: "TaskItems",
                column: "StepId",
                principalTable: "TaskSteps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_TaskTypes_TypeId",
                table: "TaskItems",
                column: "TypeId",
                principalTable: "TaskTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
