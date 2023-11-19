using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace roads.Migrations
{
    /// <inheritdoc />
    public partial class addRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Materials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ProjectId",
                table: "Materials",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Projects_ProjectId",
                table: "Materials",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Projects_ProjectId",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Materials_ProjectId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Materials");
        }
    }
}
