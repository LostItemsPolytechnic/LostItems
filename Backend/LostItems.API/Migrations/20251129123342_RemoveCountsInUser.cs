using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LostItems.API.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCountsInUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumOfFoundedItems",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NumOfLostItems",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumOfFoundedItems",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumOfLostItems",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
