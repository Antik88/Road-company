using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace roads.Migrations
{
    /// <inheritdoc />
    public partial class ppp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<double>(
                name: "startPointLat",
                table: "Projects",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "startPointLng",
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

            migrationBuilder.DropColumn(
                name: "startPointLat",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "startPointLng",
                table: "Projects");
        }
    }
}
