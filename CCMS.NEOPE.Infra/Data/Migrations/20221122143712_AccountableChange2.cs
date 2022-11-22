using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CCMS.NEOPE.Infra.Data.Migrations
{
    public partial class AccountableChange2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: "c269eb03-6a0c-4863-8690-81fd0ef2b88f");

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: "cc33265f-0881-4687-a05e-ce8adea09b0d");

            migrationBuilder.AlterColumn<string>(
                name: "Sector",
                table: "Accountables",
                type: "varchar(128)",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 128)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "ApplicationRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cc4ab119-be38-4eab-94eb-5fbbcab6bbb5", "94ce2696-e958-455b-9e06-b0a5285e715d", "Administrador do sistema", "Administrator", "ADMINISTRATOR" },
                    { "e52bcf97-e128-4209-b662-d5675b214836", "ee30eee7-6f72-47ea-b952-642e3150fd24", "Usuário comum do sistema", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "TaskCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 11, 22, 11, 37, 12, 46, DateTimeKind.Local).AddTicks(8943));

            migrationBuilder.UpdateData(
                table: "TaskCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2022, 11, 22, 11, 37, 12, 46, DateTimeKind.Local).AddTicks(8948));

            migrationBuilder.UpdateData(
                table: "TaskCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2022, 11, 22, 11, 37, 12, 46, DateTimeKind.Local).AddTicks(8949));

            migrationBuilder.UpdateData(
                table: "TaskCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2022, 11, 22, 11, 37, 12, 46, DateTimeKind.Local).AddTicks(8950));

            migrationBuilder.UpdateData(
                table: "TaskCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2022, 11, 22, 11, 37, 12, 46, DateTimeKind.Local).AddTicks(8952));

            migrationBuilder.UpdateData(
                table: "TaskCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2022, 11, 22, 11, 37, 12, 46, DateTimeKind.Local).AddTicks(8953));

            migrationBuilder.UpdateData(
                table: "TaskCategories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2022, 11, 22, 11, 37, 12, 46, DateTimeKind.Local).AddTicks(8954));

            migrationBuilder.UpdateData(
                table: "TaskCategories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateDate",
                value: new DateTime(2022, 11, 22, 11, 37, 12, 46, DateTimeKind.Local).AddTicks(8955));

            migrationBuilder.UpdateData(
                table: "TaskSteps",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 11, 22, 11, 37, 12, 29, DateTimeKind.Local).AddTicks(1632));

            migrationBuilder.UpdateData(
                table: "TaskSteps",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2022, 11, 22, 11, 37, 12, 29, DateTimeKind.Local).AddTicks(1644));

            migrationBuilder.UpdateData(
                table: "TaskSteps",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2022, 11, 22, 11, 37, 12, 29, DateTimeKind.Local).AddTicks(1645));

            migrationBuilder.UpdateData(
                table: "TaskSteps",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2022, 11, 22, 11, 37, 12, 29, DateTimeKind.Local).AddTicks(1646));

            migrationBuilder.UpdateData(
                table: "TaskSteps",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2022, 11, 22, 11, 37, 12, 29, DateTimeKind.Local).AddTicks(1647));

            migrationBuilder.UpdateData(
                table: "TaskSteps",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2022, 11, 22, 11, 37, 12, 29, DateTimeKind.Local).AddTicks(1648));

            migrationBuilder.UpdateData(
                table: "TaskTypes",
                keyColumn: "Id",
                keyValue: 1ul,
                column: "CreateDate",
                value: new DateTime(2022, 11, 22, 11, 37, 12, 46, DateTimeKind.Local).AddTicks(8227));

            migrationBuilder.UpdateData(
                table: "TaskTypes",
                keyColumn: "Id",
                keyValue: 2ul,
                column: "CreateDate",
                value: new DateTime(2022, 11, 22, 11, 37, 12, 46, DateTimeKind.Local).AddTicks(8238));

            migrationBuilder.UpdateData(
                table: "TaskTypes",
                keyColumn: "Id",
                keyValue: 3ul,
                column: "CreateDate",
                value: new DateTime(2022, 11, 22, 11, 37, 12, 46, DateTimeKind.Local).AddTicks(8240));

            migrationBuilder.UpdateData(
                table: "TaskTypes",
                keyColumn: "Id",
                keyValue: 4ul,
                column: "CreateDate",
                value: new DateTime(2022, 11, 22, 11, 37, 12, 46, DateTimeKind.Local).AddTicks(8242));

            migrationBuilder.UpdateData(
                table: "TaskTypes",
                keyColumn: "Id",
                keyValue: 5ul,
                column: "CreateDate",
                value: new DateTime(2022, 11, 22, 11, 37, 12, 46, DateTimeKind.Local).AddTicks(8243));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: "cc4ab119-be38-4eab-94eb-5fbbcab6bbb5");

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: "e52bcf97-e128-4209-b662-d5675b214836");

            migrationBuilder.UpdateData(
                table: "Accountables",
                keyColumn: "Sector",
                keyValue: null,
                column: "Sector",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Sector",
                table: "Accountables",
                type: "varchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 128,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

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
        }
    }
}
