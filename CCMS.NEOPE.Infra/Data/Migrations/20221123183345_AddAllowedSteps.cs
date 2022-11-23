using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CCMS.NEOPE.Infra.Data.Migrations
{
    public partial class AddAllowedSteps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: "b97c49d6-8186-4129-a7cd-92d88df5eea0");

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: "d9beec0c-0596-4ce1-8157-93934530e91c");

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

            migrationBuilder.InsertData(
                table: "ApplicationRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "159f96e4-1ecb-4bf5-8172-f2686c658bb8", "de391e89-54b4-4514-a6ab-04273f91ad57", "Administrador do sistema", "Administrator", "ADMINISTRATOR" },
                    { "77902611-8080-4f8b-b103-3e39814d4e7c", "24586352-88a1-471f-ae22-3e8c1a173c3e", "Usuário comum do sistema", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 11, 23, 15, 33, 44, 773, DateTimeKind.Local).AddTicks(2019));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2022, 11, 23, 15, 33, 44, 773, DateTimeKind.Local).AddTicks(2026));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2022, 11, 23, 15, 33, 44, 773, DateTimeKind.Local).AddTicks(2028));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2022, 11, 23, 15, 33, 44, 773, DateTimeKind.Local).AddTicks(2029));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2022, 11, 23, 15, 33, 44, 773, DateTimeKind.Local).AddTicks(2031));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2022, 11, 23, 15, 33, 44, 773, DateTimeKind.Local).AddTicks(2032));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2022, 11, 23, 15, 33, 44, 773, DateTimeKind.Local).AddTicks(2034));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateDate",
                value: new DateTime(2022, 11, 23, 15, 33, 44, 773, DateTimeKind.Local).AddTicks(2036));

            migrationBuilder.UpdateData(
                table: "Steps",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 11, 23, 15, 33, 44, 736, DateTimeKind.Local).AddTicks(6102));

            migrationBuilder.UpdateData(
                table: "Steps",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2022, 11, 23, 15, 33, 44, 736, DateTimeKind.Local).AddTicks(6115));

            migrationBuilder.UpdateData(
                table: "Steps",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2022, 11, 23, 15, 33, 44, 736, DateTimeKind.Local).AddTicks(6116));

            migrationBuilder.UpdateData(
                table: "Steps",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2022, 11, 23, 15, 33, 44, 736, DateTimeKind.Local).AddTicks(6118));

            migrationBuilder.UpdateData(
                table: "Steps",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2022, 11, 23, 15, 33, 44, 736, DateTimeKind.Local).AddTicks(6119));

            migrationBuilder.UpdateData(
                table: "Steps",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2022, 11, 23, 15, 33, 44, 736, DateTimeKind.Local).AddTicks(6120));

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 1ul,
                column: "CreateDate",
                value: new DateTime(2022, 11, 23, 15, 33, 44, 773, DateTimeKind.Local).AddTicks(431));

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 2ul,
                column: "CreateDate",
                value: new DateTime(2022, 11, 23, 15, 33, 44, 773, DateTimeKind.Local).AddTicks(447));

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 3ul,
                column: "CreateDate",
                value: new DateTime(2022, 11, 23, 15, 33, 44, 773, DateTimeKind.Local).AddTicks(448));

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 4ul,
                column: "CreateDate",
                value: new DateTime(2022, 11, 23, 15, 33, 44, 773, DateTimeKind.Local).AddTicks(450));

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 5ul,
                column: "CreateDate",
                value: new DateTime(2022, 11, 23, 15, 33, 44, 773, DateTimeKind.Local).AddTicks(452));

            migrationBuilder.CreateIndex(
                name: "IX_AssetTypeStep_AssetTypesId",
                table: "AssetTypeStep",
                column: "AssetTypesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetTypeStep");

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: "159f96e4-1ecb-4bf5-8172-f2686c658bb8");

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: "77902611-8080-4f8b-b103-3e39814d4e7c");

            migrationBuilder.InsertData(
                table: "ApplicationRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b97c49d6-8186-4129-a7cd-92d88df5eea0", "c48c74fd-c2ab-4811-a888-6ad40195c229", "Administrador do sistema", "Administrator", "ADMINISTRATOR" },
                    { "d9beec0c-0596-4ce1-8157-93934530e91c", "02c65148-083a-4fc7-8c7f-2967f11bd77f", "Usuário comum do sistema", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 11, 23, 14, 0, 54, 740, DateTimeKind.Local).AddTicks(485));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2022, 11, 23, 14, 0, 54, 740, DateTimeKind.Local).AddTicks(532));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2022, 11, 23, 14, 0, 54, 740, DateTimeKind.Local).AddTicks(534));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2022, 11, 23, 14, 0, 54, 740, DateTimeKind.Local).AddTicks(535));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2022, 11, 23, 14, 0, 54, 740, DateTimeKind.Local).AddTicks(536));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2022, 11, 23, 14, 0, 54, 740, DateTimeKind.Local).AddTicks(537));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2022, 11, 23, 14, 0, 54, 740, DateTimeKind.Local).AddTicks(539));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateDate",
                value: new DateTime(2022, 11, 23, 14, 0, 54, 740, DateTimeKind.Local).AddTicks(540));

            migrationBuilder.UpdateData(
                table: "Steps",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 11, 23, 14, 0, 54, 718, DateTimeKind.Local).AddTicks(9863));

            migrationBuilder.UpdateData(
                table: "Steps",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2022, 11, 23, 14, 0, 54, 718, DateTimeKind.Local).AddTicks(9875));

            migrationBuilder.UpdateData(
                table: "Steps",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2022, 11, 23, 14, 0, 54, 718, DateTimeKind.Local).AddTicks(9876));

            migrationBuilder.UpdateData(
                table: "Steps",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2022, 11, 23, 14, 0, 54, 718, DateTimeKind.Local).AddTicks(9877));

            migrationBuilder.UpdateData(
                table: "Steps",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2022, 11, 23, 14, 0, 54, 718, DateTimeKind.Local).AddTicks(9878));

            migrationBuilder.UpdateData(
                table: "Steps",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2022, 11, 23, 14, 0, 54, 718, DateTimeKind.Local).AddTicks(9879));

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 1ul,
                column: "CreateDate",
                value: new DateTime(2022, 11, 23, 14, 0, 54, 739, DateTimeKind.Local).AddTicks(9716));

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 2ul,
                column: "CreateDate",
                value: new DateTime(2022, 11, 23, 14, 0, 54, 739, DateTimeKind.Local).AddTicks(9728));

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 3ul,
                column: "CreateDate",
                value: new DateTime(2022, 11, 23, 14, 0, 54, 739, DateTimeKind.Local).AddTicks(9730));

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 4ul,
                column: "CreateDate",
                value: new DateTime(2022, 11, 23, 14, 0, 54, 739, DateTimeKind.Local).AddTicks(9731));

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 5ul,
                column: "CreateDate",
                value: new DateTime(2022, 11, 23, 14, 0, 54, 739, DateTimeKind.Local).AddTicks(9732));
        }
    }
}
