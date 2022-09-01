using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CCMS.NEOPE.Infra.Data.Migrations
{
    public partial class AddOrderToTasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: "9641e920-d9fb-46ca-8a80-609c95e93fae");

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: "a23a5bc0-27e4-40a3-8bb3-01ee83fee45b");

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "TaskItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: "066766ef-a5ea-40ee-997a-22e7328c668c");

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: "8f04e1da-bd81-444a-b8f3-8b1711fc11b0");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "TaskItems");

            migrationBuilder.InsertData(
                table: "ApplicationRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9641e920-d9fb-46ca-8a80-609c95e93fae", "23e614ba-cb92-4c24-a2d8-6ea572fd6ba9", "Administrador do sistema", "Administrator", "ADMINISTRATOR" },
                    { "a23a5bc0-27e4-40a3-8bb3-01ee83fee45b", "f334fbc6-2efb-4caf-8138-251740eb9cef", "Usuário comum do sistema", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "TaskCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 8, 26, 16, 28, 20, 215, DateTimeKind.Local).AddTicks(7361));

            migrationBuilder.UpdateData(
                table: "TaskCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2022, 8, 26, 16, 28, 20, 215, DateTimeKind.Local).AddTicks(7364));

            migrationBuilder.UpdateData(
                table: "TaskCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2022, 8, 26, 16, 28, 20, 215, DateTimeKind.Local).AddTicks(7365));

            migrationBuilder.UpdateData(
                table: "TaskCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2022, 8, 26, 16, 28, 20, 215, DateTimeKind.Local).AddTicks(7366));

            migrationBuilder.UpdateData(
                table: "TaskCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2022, 8, 26, 16, 28, 20, 215, DateTimeKind.Local).AddTicks(7367));

            migrationBuilder.UpdateData(
                table: "TaskCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2022, 8, 26, 16, 28, 20, 215, DateTimeKind.Local).AddTicks(7368));

            migrationBuilder.UpdateData(
                table: "TaskCategories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2022, 8, 26, 16, 28, 20, 215, DateTimeKind.Local).AddTicks(7369));

            migrationBuilder.UpdateData(
                table: "TaskCategories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateDate",
                value: new DateTime(2022, 8, 26, 16, 28, 20, 215, DateTimeKind.Local).AddTicks(7370));

            migrationBuilder.UpdateData(
                table: "TaskSteps",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 8, 26, 16, 28, 20, 212, DateTimeKind.Local).AddTicks(7272));

            migrationBuilder.UpdateData(
                table: "TaskSteps",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2022, 8, 26, 16, 28, 20, 212, DateTimeKind.Local).AddTicks(7283));

            migrationBuilder.UpdateData(
                table: "TaskSteps",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2022, 8, 26, 16, 28, 20, 212, DateTimeKind.Local).AddTicks(7284));

            migrationBuilder.UpdateData(
                table: "TaskSteps",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2022, 8, 26, 16, 28, 20, 212, DateTimeKind.Local).AddTicks(7285));

            migrationBuilder.UpdateData(
                table: "TaskSteps",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2022, 8, 26, 16, 28, 20, 212, DateTimeKind.Local).AddTicks(7286));

            migrationBuilder.UpdateData(
                table: "TaskSteps",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2022, 8, 26, 16, 28, 20, 212, DateTimeKind.Local).AddTicks(7287));

            migrationBuilder.UpdateData(
                table: "TaskTypes",
                keyColumn: "Id",
                keyValue: 1ul,
                column: "CreateDate",
                value: new DateTime(2022, 8, 26, 16, 28, 20, 215, DateTimeKind.Local).AddTicks(6858));

            migrationBuilder.UpdateData(
                table: "TaskTypes",
                keyColumn: "Id",
                keyValue: 2ul,
                column: "CreateDate",
                value: new DateTime(2022, 8, 26, 16, 28, 20, 215, DateTimeKind.Local).AddTicks(6866));

            migrationBuilder.UpdateData(
                table: "TaskTypes",
                keyColumn: "Id",
                keyValue: 3ul,
                column: "CreateDate",
                value: new DateTime(2022, 8, 26, 16, 28, 20, 215, DateTimeKind.Local).AddTicks(6867));

            migrationBuilder.UpdateData(
                table: "TaskTypes",
                keyColumn: "Id",
                keyValue: 4ul,
                column: "CreateDate",
                value: new DateTime(2022, 8, 26, 16, 28, 20, 215, DateTimeKind.Local).AddTicks(6868));

            migrationBuilder.UpdateData(
                table: "TaskTypes",
                keyColumn: "Id",
                keyValue: 5ul,
                column: "CreateDate",
                value: new DateTime(2022, 8, 26, 16, 28, 20, 215, DateTimeKind.Local).AddTicks(6869));
        }
    }
}
