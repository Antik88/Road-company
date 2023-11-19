using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace roads.Migrations
{
    /// <inheritdoc />
    public partial class startendlatlng : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "startPoint",
                table: "Projects",
                newName: "startPointLng");

            migrationBuilder.RenameColumn(
                name: "endPoint",
                table: "Projects",
                newName: "startPointLat");

            migrationBuilder.AddColumn<double>(
                name: "endPointLat",
                table: "Projects",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "endPointLng",
                table: "Projects",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "endPointLat",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "endPointLng",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "startPointLng",
                table: "Projects",
                newName: "startPoint");

            migrationBuilder.RenameColumn(
                name: "startPointLat",
                table: "Projects",
                newName: "endPoint");
        }
    }
}
