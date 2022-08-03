using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CCMS.NEOPE.Infra.Data.Migrations
{
    public partial class addAssetTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: "5792c89d-b4f8-4abb-af6f-9ff9838fa117");

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: "8a6ad7d5-b3a9-43fb-9e72-19892a40c213");

            migrationBuilder.AddColumn<ulong>(
                name: "Key",
                table: "TaskItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0ul);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Projects",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<ulong>(
                name: "TypeId",
                table: "Assets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0ul);

            migrationBuilder.CreateTable(
                name: "AssetType",
                columns: table => new
                {
                    Id = table.Column<ulong>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetType", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ApplicationRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { "40ced6eb-62ba-4ebb-9af1-cc953e01c537", "6dfd11aa-dd9e-49ca-91be-cdee055ec44a", "Usuário comum do sistema", "User", "USER" });

            migrationBuilder.InsertData(
                table: "ApplicationRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { "446d57c9-9842-48da-87e7-d0b32d1c4127", "84897595-6635-4f54-a776-7781cc05ba4e", "Administrador do sistema", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_Key",
                table: "TaskItems",
                column: "Key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assets_TypeId",
                table: "Assets",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_AssetType_TypeId",
                table: "Assets",
                column: "TypeId",
                principalTable: "AssetType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_AssetType_TypeId",
                table: "Assets");

            migrationBuilder.DropTable(
                name: "AssetType");

            migrationBuilder.DropIndex(
                name: "IX_TaskItems_Key",
                table: "TaskItems");

            migrationBuilder.DropIndex(
                name: "IX_Assets_TypeId",
                table: "Assets");

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: "40ced6eb-62ba-4ebb-9af1-cc953e01c537");

            migrationBuilder.DeleteData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: "446d57c9-9842-48da-87e7-d0b32d1c4127");

            migrationBuilder.DropColumn(
                name: "Key",
                table: "TaskItems");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Assets");

            migrationBuilder.InsertData(
                table: "ApplicationRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { "5792c89d-b4f8-4abb-af6f-9ff9838fa117", "f034545d-4838-42a5-a6ca-814c32a1e519", "Administrador do sistema", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "ApplicationRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { "8a6ad7d5-b3a9-43fb-9e72-19892a40c213", "e8d458da-c1dd-4752-805e-df1fe18ccf4f", "Usuário comum do sistema", "User", "USER" });
        }
    }
}
