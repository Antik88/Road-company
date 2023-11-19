using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace roads.Migrations
{
    /// <inheritdoc />
    public partial class startend : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "endPoint",
                table: "Projects",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "startPoint",
                table: "Projects",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "endPoint",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "startPoint",
                table: "Projects");
        }
    }
}
