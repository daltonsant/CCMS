using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CCMS.NEOPE.Infra.Data.Migrations
{
    public partial class AllowNullOnAssetLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: "17400699-da3a-4ecc-b09b-428cee8cf43f");

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: "d37ca026-1499-4ca4-812c-f1da3b551e6a");

            migrationBuilder.AlterColumn<string>(
                name: "AttachmentsLink",
                table: "Assets",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "ApplicationRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "19fcaecb-dc72-4661-b738-e06351877baf", "955cbe55-dfa5-41b7-81a2-d175c973e9dd", "Administrador do sistema", "Administrator", "ADMINISTRATOR" },
                    { "be1f683b-1ee1-49bf-b779-06d95ec9f44d", "dcec7e73-a2f2-4069-904b-7285eab135b5", "Usuário comum do sistema", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 11, 30, 8, 42, 32, 116, DateTimeKind.Local).AddTicks(6470));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2022, 11, 30, 8, 42, 32, 116, DateTimeKind.Local).AddTicks(6477));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2022, 11, 30, 8, 42, 32, 116, DateTimeKind.Local).AddTicks(6479));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2022, 11, 30, 8, 42, 32, 116, DateTimeKind.Local).AddTicks(6481));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2022, 11, 30, 8, 42, 32, 116, DateTimeKind.Local).AddTicks(6482));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2022, 11, 30, 8, 42, 32, 116, DateTimeKind.Local).AddTicks(6484));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2022, 11, 30, 8, 42, 32, 116, DateTimeKind.Local).AddTicks(6488));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateDate",
                value: new DateTime(2022, 11, 30, 8, 42, 32, 116, DateTimeKind.Local).AddTicks(6490));

            migrationBuilder.UpdateData(
                table: "Steps",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 11, 30, 8, 42, 32, 91, DateTimeKind.Local).AddTicks(7929));

            migrationBuilder.UpdateData(
                table: "Steps",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2022, 11, 30, 8, 42, 32, 91, DateTimeKind.Local).AddTicks(7941));

            migrationBuilder.UpdateData(
                table: "Steps",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2022, 11, 30, 8, 42, 32, 91, DateTimeKind.Local).AddTicks(7943));

            migrationBuilder.UpdateData(
                table: "Steps",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2022, 11, 30, 8, 42, 32, 91, DateTimeKind.Local).AddTicks(7944));

            migrationBuilder.UpdateData(
                table: "Steps",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2022, 11, 30, 8, 42, 32, 91, DateTimeKind.Local).AddTicks(7946));

            migrationBuilder.UpdateData(
                table: "Steps",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2022, 11, 30, 8, 42, 32, 91, DateTimeKind.Local).AddTicks(7947));

            migrationBuilder.UpdateData(
                table: "Steps",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2022, 11, 30, 8, 42, 32, 91, DateTimeKind.Local).AddTicks(7948));

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 1ul,
                column: "CreateDate",
                value: new DateTime(2022, 11, 30, 8, 42, 32, 116, DateTimeKind.Local).AddTicks(5279));

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 2ul,
                column: "CreateDate",
                value: new DateTime(2022, 11, 30, 8, 42, 32, 116, DateTimeKind.Local).AddTicks(5294));

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 3ul,
                column: "CreateDate",
                value: new DateTime(2022, 11, 30, 8, 42, 32, 116, DateTimeKind.Local).AddTicks(5296));

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 4ul,
                column: "CreateDate",
                value: new DateTime(2022, 11, 30, 8, 42, 32, 116, DateTimeKind.Local).AddTicks(5298));

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 5ul,
                column: "CreateDate",
                value: new DateTime(2022, 11, 30, 8, 42, 32, 116, DateTimeKind.Local).AddTicks(5299));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: "19fcaecb-dc72-4661-b738-e06351877baf");

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: "be1f683b-1ee1-49bf-b779-06d95ec9f44d");

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "AttachmentsLink",
                keyValue: null,
                column: "AttachmentsLink",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "AttachmentsLink",
                table: "Assets",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "ApplicationRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "17400699-da3a-4ecc-b09b-428cee8cf43f", "31461aa2-3479-4e32-99c6-40fde4360573", "Administrador do sistema", "Administrator", "ADMINISTRATOR" },
                    { "d37ca026-1499-4ca4-812c-f1da3b551e6a", "96080756-7521-44bb-b857-8bd9f9b6a2fe", "Usuário comum do sistema", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 11, 30, 8, 29, 46, 743, DateTimeKind.Local).AddTicks(8710));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2022, 11, 30, 8, 29, 46, 743, DateTimeKind.Local).AddTicks(8716));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2022, 11, 30, 8, 29, 46, 743, DateTimeKind.Local).AddTicks(8718));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2022, 11, 30, 8, 29, 46, 743, DateTimeKind.Local).AddTicks(8719));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2022, 11, 30, 8, 29, 46, 743, DateTimeKind.Local).AddTicks(8721));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2022, 11, 30, 8, 29, 46, 743, DateTimeKind.Local).AddTicks(8723));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2022, 11, 30, 8, 29, 46, 743, DateTimeKind.Local).AddTicks(8724));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateDate",
                value: new DateTime(2022, 11, 30, 8, 29, 46, 743, DateTimeKind.Local).AddTicks(8727));

            migrationBuilder.UpdateData(
                table: "Steps",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 11, 30, 8, 29, 46, 718, DateTimeKind.Local).AddTicks(8230));

            migrationBuilder.UpdateData(
                table: "Steps",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2022, 11, 30, 8, 29, 46, 718, DateTimeKind.Local).AddTicks(8241));

            migrationBuilder.UpdateData(
                table: "Steps",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2022, 11, 30, 8, 29, 46, 718, DateTimeKind.Local).AddTicks(8242));

            migrationBuilder.UpdateData(
                table: "Steps",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2022, 11, 30, 8, 29, 46, 718, DateTimeKind.Local).AddTicks(8243));

            migrationBuilder.UpdateData(
                table: "Steps",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2022, 11, 30, 8, 29, 46, 718, DateTimeKind.Local).AddTicks(8244));

            migrationBuilder.UpdateData(
                table: "Steps",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2022, 11, 30, 8, 29, 46, 718, DateTimeKind.Local).AddTicks(8245));

            migrationBuilder.UpdateData(
                table: "Steps",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2022, 11, 30, 8, 29, 46, 718, DateTimeKind.Local).AddTicks(8245));

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 1ul,
                column: "CreateDate",
                value: new DateTime(2022, 11, 30, 8, 29, 46, 743, DateTimeKind.Local).AddTicks(7449));

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 2ul,
                column: "CreateDate",
                value: new DateTime(2022, 11, 30, 8, 29, 46, 743, DateTimeKind.Local).AddTicks(7465));

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 3ul,
                column: "CreateDate",
                value: new DateTime(2022, 11, 30, 8, 29, 46, 743, DateTimeKind.Local).AddTicks(7467));

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 4ul,
                column: "CreateDate",
                value: new DateTime(2022, 11, 30, 8, 29, 46, 743, DateTimeKind.Local).AddTicks(7468));

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 5ul,
                column: "CreateDate",
                value: new DateTime(2022, 11, 30, 8, 29, 46, 743, DateTimeKind.Local).AddTicks(7470));
        }
    }
}
