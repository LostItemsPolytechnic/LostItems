using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LostItems.API.Migrations
{
    /// <inheritdoc />
    public partial class FixItemFieldNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReturned",
                table: "Items");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Items",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Items");

            migrationBuilder.AddColumn<bool>(
                name: "IsReturned",
                table: "Items",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
