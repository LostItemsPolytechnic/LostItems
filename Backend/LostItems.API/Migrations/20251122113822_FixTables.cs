using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LostItems.API.Migrations
{
    /// <inheritdoc />
    public partial class FixTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "PasswordHash");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ItemId",
                table: "ReturnedItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<int>(
                name: "ItemStatus",
                table: "Items",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<DateTime>(
                name: "FoundDate",
                table: "Items",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsReturned",
                table: "Items",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_ReturnedItems_ItemId",
                table: "ReturnedItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnedItems_LosterId",
                table: "ReturnedItems",
                column: "LosterId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnedItems_Items_ItemId",
                table: "ReturnedItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnedItems_Users_LosterId",
                table: "ReturnedItems",
                column: "LosterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReturnedItems_Items_ItemId",
                table: "ReturnedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ReturnedItems_Users_LosterId",
                table: "ReturnedItems");

            migrationBuilder.DropIndex(
                name: "IX_ReturnedItems_ItemId",
                table: "ReturnedItems");

            migrationBuilder.DropIndex(
                name: "IX_ReturnedItems_LosterId",
                table: "ReturnedItems");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "ReturnedItems");

            migrationBuilder.DropColumn(
                name: "FoundDate",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "IsReturned",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Users",
                newName: "Password");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ItemStatus",
                table: "Items",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
