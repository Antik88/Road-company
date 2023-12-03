using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace roads.Migrations
{
    /// <inheritdoc />
    public partial class orderfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderMaterials_User_UserId",
                table: "OrderMaterials");

            migrationBuilder.DropIndex(
                name: "IX_OrderMaterials_UserId",
                table: "OrderMaterials");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "OrderMaterials");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "OrderMaterials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderMaterials_UserId",
                table: "OrderMaterials",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderMaterials_User_UserId",
                table: "OrderMaterials",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
